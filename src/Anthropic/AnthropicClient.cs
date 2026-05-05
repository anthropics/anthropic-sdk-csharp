using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Credentials;
using Anthropic.Exceptions;
using Anthropic.Services;

namespace Anthropic;

/// <inheritdoc/>
public class AnthropicClient : IAnthropicClient
{
    private static int s_shadowWarningEmitted;

    internal static void ResetShadowWarningForTests() => s_shadowWarningEmitted = 0;

    protected readonly ClientOptions _options;
    private readonly bool _ownsCredentials;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public virtual string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? AuthToken
    {
        get { return this._options.AuthToken; }
        init { this._options.AuthToken = value; }
    }

    readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public virtual IAnthropicClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public virtual IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicClient(modifier(this._options));
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    public void Dispose()
    {
        if (_ownsCredentials)
        {
            _options.Credentials?.Dispose();
        }
        HttpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Whether this client should attempt environment/profile credential auto-resolution
    /// when no explicit ApiKey/AuthToken/Credentials is provided. Cloud-backend clients
    /// (Bedrock, Vertex, Foundry, AWS) override this to false. User subclasses inherit true.
    /// </summary>
    protected virtual bool ShouldAutoResolveCredentials => true;

    public AnthropicClient()
        : this(new ClientOptions()) { }

    public AnthropicClient(ClientOptions options)
    {
        // Auto-resolve credentials when nothing explicit was provided.
        // Cloud-backend subclasses opt out via ShouldAutoResolveCredentials.
        if (
            ShouldAutoResolveCredentials
            && options.Credentials == null
            && !options.ApiKeyExplicit
            && !options.AuthTokenExplicit
        )
        {
            // Base URL precedence: explicit ctor > ANTHROPIC_BASE_URL > profile > Production.
            // Only let the profile's base_url through to Resolve (and adopt it for API
            // requests) when neither the ctor nor the env var supplied one.
            var envBaseUrl = Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL");
            var hasUserBaseUrl = options.BaseUrlExplicit || !string.IsNullOrEmpty(envBaseUrl);
            var resolved = AnthropicCredentials.Resolve(
                baseUrl: hasUserBaseUrl ? options.BaseUrl : null
            );
            if (resolved != null)
            {
                options.Credentials = resolved.Credentials;
                if (!hasUserBaseUrl && resolved.BaseUrl != null)
                {
                    options.BaseUrl = resolved.BaseUrl;
                }
                // Merge: keep any user-supplied ExtraHeaders, overlay resolved
                // (resolved wins on key conflict).
                var merged = new Dictionary<string, string>();
                if (options.ExtraHeaders != null)
                {
                    foreach (var kv in options.ExtraHeaders)
                    {
                        merged[kv.Key] = kv.Value;
                    }
                }
                foreach (var kv in resolved.ExtraHeaders)
                {
                    merged[kv.Key] = kv.Value;
                }
                options.ExtraHeaders = merged;
            }
        }

        // Warn once if an explicit API key / auth token shadows credentials the
        // user clearly intended to use (passed Credentials, or set ANTHROPIC_PROFILE).
        // The silent fallback-to-disk case is intentionally excluded.
        var explicitStaticCred =
            (options.ApiKeyExplicit && options.ApiKey != null)
            || (options.AuthTokenExplicit && options.AuthToken != null);
        var intendedProfileAuth =
            options.Credentials != null
            || Environment.GetEnvironmentVariable(CredentialsConstants.EnvProfile) != null;
        if (
            explicitStaticCred
            && intendedProfileAuth
            && Interlocked.CompareExchange(ref s_shadowWarningEmitted, 1, 0) == 0
        )
        {
            Console.Error.WriteLine(
                "WARNING: An explicit API key/auth token is set; the provided "
                    + "credentials/profile will be ignored. Remove one to silence this warning. "
                    + "(This warning is shown once per process.)"
            );
        }

        // Wrap any user-supplied provider in the shared token cache so the
        // raw-response client and 401-retry path see a single cached instance.
        // We own (and will dispose) the credentials only when this ctor created
        // or wrapped them; a TokenCache passed in (e.g. from a WithOptions clone)
        // is owned by whoever built it.
        _ownsCredentials = options.Credentials != null && options.Credentials is not TokenCache;
        if (_ownsCredentials)
        {
            options.Credentials = new TokenCache(options.Credentials!);
        }

        _options = options;

        _withRawResponse = new(() => new AnthropicClientWithRawResponse(this._options));
        _messages = new(() => new MessageService(this));
        _models = new(() => new ModelService(this));
        _beta = new(() => new BetaService(this));
    }
}

/// <inheritdoc/>
public class AnthropicClientWithRawResponse : IAnthropicClientWithRawResponse
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

    protected readonly ClientOptions _options;
    private readonly TokenCache? _tokenCache;
    private readonly bool _ownsCredentials;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public virtual string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public virtual string? AuthToken
    {
        get { return this._options.AuthToken; }
        init { this._options.AuthToken = value; }
    }

    /// <inheritdoc/>
    public virtual IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IModelServiceWithRawResponse> _models;
    public IModelServiceWithRawResponse Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        var authRetryConsumed = false;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            // 401 with token credentials: force-refresh the token and retry once.
            // Gated on retries == 0 so an auth retry never stacks on top of a transport
            // retry. Body replayability is not gated separately — ExecuteOnce rebuilds the
            // body from request.Params on every attempt, the same as the transport-retry path.
            if (response?.StatusCode == HttpStatusCode.Unauthorized && UsingTokenCredentials)
            {
                // UsingTokenCredentials => _tokenCache != null, so the ! deref is safe.
                if (!authRetryConsumed && retries == 0)
                {
                    authRetryConsumed = true;
                    var failedToken = _tokenCache!.Cached?.Token;
                    // Prime the cache so the retry's BeforeSend picks up the fresh token.
                    var fresh = await _tokenCache
                        .GetTokenAsync(forceRefresh: true, cancellationToken)
                        .ConfigureAwait(false);
                    // Only retry if the refresh actually produced a different token —
                    // StaticTokenCredentials / ANTHROPIC_AUTH_TOKEN can't change, so
                    // skipping avoids one wasted round-trip.
                    if (!string.Equals(fresh.Token, failedToken, StringComparison.Ordinal))
                    {
                        response.Dispose();
                        retries++;
                        continue;
                    }
                }
                else
                {
                    // Not retrying — invalidate so the caller's next request fetches fresh.
                    _tokenCache!.Invalidate();
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw AnthropicExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
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

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    private bool UsingTokenCredentials
    {
        get
        {
            // Precedence: explicit ApiKey/AuthToken > Credentials > env-var ApiKey/AuthToken.
            var explicitKeyAuth =
                (_options.ApiKeyExplicit && _options.ApiKey != null)
                || (_options.AuthTokenExplicit && _options.AuthToken != null);
            return _tokenCache != null && !explicitKeyAuth;
        }
    }

    protected virtual async ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        if (UsingTokenCredentials)
        {
            // Strip env-var-based API key / auth token headers that AddDefaultHeaders added.
            requestMessage.Headers.Remove("X-Api-Key");
            requestMessage.Headers.Remove("Authorization");

            var token = await _tokenCache!
                .GetTokenAsync(forceRefresh: false, cancellationToken)
                .ConfigureAwait(false);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token.Token
            );
            AppendBetaHeader(requestMessage, CredentialsConstants.ApiRequestBetaValue);
        }

        var extraHeaders = _options.ExtraHeaders;
        if (extraHeaders != null)
        {
            foreach (var header in extraHeaders)
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
    }

    private static void AppendBetaHeader(HttpRequestMessage requestMessage, string value)
    {
        // anthropic-beta is multi-valued; only append if not already present so service-level
        // betas (e.g., files-api-2025-04-14) and the OAuth beta coexist without duplicates.
        if (requestMessage.Headers.TryGetValues("anthropic-beta", out var existing))
        {
            foreach (var entry in existing)
            {
                foreach (var part in entry.Split(','))
                {
                    if (string.Equals(part.Trim(), value, StringComparison.Ordinal))
                    {
                        return;
                    }
                }
            }
        }
        requestMessage.Headers.TryAddWithoutValidation("anthropic-beta", value);
    }

    protected virtual ValueTask AfterSend<T>(
        HttpRequest<T> request,
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        // 401 handling lives in Execute<T> so it can drive the retry loop.
        return default;
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            await BeforeSend(request, requestMessage, cts.Token).ConfigureAwait(false);
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
            await AfterSend(request, responseMessage, cts.Token).ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new AnthropicIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
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

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
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

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
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
#if !NETSTANDARD2_0_OR_GREATER
            // Retry on rate limits
            429
            or
#endif
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return (
                e is IOException
                && e is not FileNotFoundException
                && e is not DirectoryNotFoundException
            )
            || e is AnthropicIOException;
    }

    public void Dispose()
    {
        if (_ownsCredentials)
        {
            _options.Credentials?.Dispose();
        }
        this.HttpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    public AnthropicClientWithRawResponse()
    {
        _options = new();

        _messages = new(() => new MessageServiceWithRawResponse(this));
        _models = new(() => new ModelServiceWithRawResponse(this));
        _beta = new(() => new BetaServiceWithRawResponse(this));
    }

    public AnthropicClientWithRawResponse(ClientOptions options)
        : this()
    {
        // Wrap any raw provider in the token cache. When constructed via
        // AnthropicClient.WithRawResponse this is already a TokenCache and is reused.
        // We own (and will dispose) the credentials only when this ctor created the
        // wrap; a TokenCache passed in is owned by whoever built it.
        _ownsCredentials = options.Credentials != null && options.Credentials is not TokenCache;
        if (_ownsCredentials)
        {
            options.Credentials = new TokenCache(options.Credentials!);
        }
        _options = options;
        _tokenCache = _options.Credentials as TokenCache;
    }
}
