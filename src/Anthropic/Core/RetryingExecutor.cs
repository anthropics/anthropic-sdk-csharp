using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core.Telemetry;
using Anthropic.Credentials;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// Sends a request, and sends it again for as long as the retry policy allows.
/// </summary>
internal sealed class RetryingExecutor
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly AnthropicClientWithRawResponse _client;

    internal RetryingExecutor(AnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    internal async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        // One span covers every attempt of the call, and ends when its response has been read.
        // A request that was not made through an SDK method has no span name, and no span. The
        // attributes are built only for a span that would be emitted.
        var span =
            request.Span
            ?? (
                request.SpanName == null || !Tracing.IsEnabled(this._client.Options)
                    ? null
                    : Tracing.StartApiCallSpan(
                        this._client.Options.ResolvedOpenTelemetry,
                        request.SpanName,
                        Tracing.StartAttributes(this._client.Options, request),
                        this._client.Options.OpenTelemetrySource
                    )
            );
        if (span == null)
        {
            return await this.ExecuteWithRetries(request, null, cancellationToken)
                .ConfigureAwait(false);
        }
        HttpResponse response;
        try
        {
            response = await this.ExecuteWithRetries(request, span, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Tracing.EndApiCallSpan(span, e, cancellationToken);
            throw;
        }
        response.Span = span;
        return response;
    }

    async Task<HttpResponse> ExecuteWithRetries<T>(
        HttpRequest<T> request,
        Activity? span,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        // A body that reads from a caller's stream can only be sent once, so such a request gets no retries.
        var maxRetries = request.Params.IsBodyRepeatable()
            ? this._client.Options.MaxRetries ?? ClientOptions.DefaultMaxRetries
            : 0;
        var retries = 0;
        var authRetryConsumed = false;
        while (true)
        {
            HttpResponse? response = null;
            string? sentToken = null;
            try
            {
                (response, sentToken) = await ExecuteOnce(request, retries, span, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e, cancellationToken))
                {
                    throw;
                }
            }

            // 401 with token credentials: get a new token (refreshing if needed) and retry once.
            // Gated on retries == 0 so an auth retry never stacks on top of a transport
            // retry, and on IsBodyRepeatable because a multipart body reads from the caller's
            // streams, which the first attempt has already consumed.
            if (
                response?.StatusCode == HttpStatusCode.Unauthorized
                && this._client.ActiveTokenCache is { } tokenCache
            )
            {
                if (!authRetryConsumed && retries == 0 && request.Params.IsBodyRepeatable())
                {
                    authRetryConsumed = true;
                    // The 401 is for the token this request sent; if the cache already holds a
                    // different one (a concurrent request refreshed it), retry with that without
                    // refreshing. A request with no bearer token compares against the cache.
                    var cachedToken = tokenCache.Cached?.Token;
                    var rejectedToken = sentToken ?? cachedToken;
                    if (
                        cachedToken != null
                        && !string.Equals(cachedToken, rejectedToken, StringComparison.Ordinal)
                    )
                    {
                        response.Dispose();
                        retries++;
                        continue;
                    }
                    // Prime the cache so the retry's BeforeSend picks up the fresh token.
                    AccessToken fresh;
                    try
                    {
                        fresh = await tokenCache
                            .GetTokenAsync(forceRefresh: true, cancellationToken)
                            .ConfigureAwait(false);
                    }
                    catch
                    {
                        // A failed refresh abandons the 401 response, so release it here.
                        response.Dispose();
                        throw;
                    }
                    // Only retry if the refresh actually produced a different token —
                    // StaticTokenCredentials / ANTHROPIC_AUTH_TOKEN can't change, so
                    // skipping avoids one wasted round-trip.
                    if (!string.Equals(fresh.Token, rejectedToken, StringComparison.Ordinal))
                    {
                        response.Dispose();
                        retries++;
                        continue;
                    }
                }
                else
                {
                    // Not retrying — invalidate so the caller's next request fetches fresh.
                    tokenCache.Invalidate();
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (span != null)
                {
                    // The span records the final attempt's response.
                    SpanAttributes.SetResponseHeaderAttributes(span, response.RawMessage);
                    Tracing.SetResponseStatusCode(span, response.RawMessage);
                }
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw AnthropicExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false),
                        response
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new AnthropicIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            TimeSpan backoff;
            try
            {
                backoff = ComputeRetryBackoff(retries, response);
            }
            finally
            {
                // The response being retried is abandoned whether or not the computation
                // succeeds.
                response?.Dispose();
            }
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    // Also returns the bearer token the request was sent with, which the 401-retry path needs.
    async Task<(HttpResponse Response, string? SentToken)> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        Activity? span,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._client.Options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        Qualifiers.Attach(requestMessage, request.Qualifiers);
        // Wire parity with the other SDKs: bare media type, no charset suffix
        // (JSON is UTF-8 by definition per RFC 8259).
        if (requestMessage.Content?.Headers.ContentType is { CharSet: not null } contentType)
        {
            contentType.CharSet = null;
        }
        request.Params.AddHeadersToRequest(requestMessage, this._client.Options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add(
                "x-stainless-retry-count",
                retryCount.ToString(CultureInfo.InvariantCulture)
            );
        }
        var timeout = this._client.Options.Timeout ?? ClientOptions.DefaultTimeout;
        using CancellationTokenSource timeoutCts = new(timeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        string? sentToken;
        try
        {
            await this
                ._client.SendingRequest(request, requestMessage, cts.Token)
                .ConfigureAwait(false);
            sentToken = requestMessage.Headers.Authorization?.Parameter;
            if (span != null)
            {
                Tracing.InjectTraceHeaders(span, requestMessage.Headers);
                Tracing.TrackRequest(
                    requestMessage,
                    span,
                    request.Params,
                    Content.IsRecorded(this._client.Options.ResolvedOpenTelemetry)
                );
            }
            responseMessage = await this
                ._client.Options.SendRequestAsync(requestMessage, cts.Token)
                .ConfigureAwait(false);
            await this
                ._client.ReceivedResponse(request, responseMessage, cts.Token)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new AnthropicIOException("I/O exception", e);
        }
        catch (OperationCanceledException e)
            when (timeoutCts.IsCancellationRequested && !cancellationToken.IsCancellationRequested)
        {
            throw new TaskCanceledException(
                string.Format(
                    "The request was canceled due to the configured client timeout of {0} elapsing.",
                    timeout
                ),
                new TimeoutException(e.Message, e)
            );
        }
        // `cts` is disposed as this method returns, before any of the body has been read, so its
        // token must not travel with the response: every body read links against the response's
        // token, and linking against a disposed source throws on .NET Framework in <=4.5.2
        // compatibility mode (and is inert everywhere else). Body reads are governed by the
        // tokens handed to them instead.
        return (new HttpResponse { RawMessage = responseMessage }, sentToken);
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff > TimeSpan.Zero)
        {
            // If the API asks us to wait a certain amount of time, then just do what it says.
            // `Task.Delay` throws for delays above `int.MaxValue` milliseconds, so wait at most that long.
            var maxDelay = TimeSpan.FromMilliseconds(int.MaxValue);
            return apiBackoff < maxDelay ? (TimeSpan)apiBackoff : maxDelay;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (
            float.TryParse(
                headerValue,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out var retryAfterMs
            )
        )
        {
            // NaN, infinite or out-of-range values can't be converted to a TimeSpan (the conversion
            // throws), so treat them like an unparsable header.
            if (
                float.IsNaN(retryAfterMs)
                || Math.Abs(retryAfterMs) >= TimeSpan.MaxValue.TotalMilliseconds
            )
            {
                return null;
            }

            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (
            float.TryParse(
                headerValue,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out var retryAfterSeconds
            )
        )
        {
            // NaN, infinite or out-of-range values can't be converted to a TimeSpan (the conversion
            // throws), so treat them like an unparsable header.
            if (
                float.IsNaN(retryAfterSeconds)
                || Math.Abs(retryAfterSeconds) >= TimeSpan.MaxValue.TotalSeconds
            )
            {
                return null;
            }

            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (
            DateTimeOffset.TryParse(
                headerValue,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out var retryAfterDate
            )
        )
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // The caller cancelled the request, so don't retry.
            return false;
        }

        // Retry connection errors and attempts that hit the per-attempt timeout.
        return (
                e is IOException
                && e is not FileNotFoundException
                && e is not DirectoryNotFoundException
            )
            || e is AnthropicIOException
            || e is OperationCanceledException;
    }
}
