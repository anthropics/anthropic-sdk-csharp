using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers.Fallbacks;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// A <see cref="DelegatingHandler"/> that retries refused beta <c>/v1/messages</c> requests down a
/// fallback chain.
///
/// <para>Only requests made through the beta API surface (<c>client.Beta.Messages</c>) are
/// handled; non-beta <c>client.Messages</c> requests pass through untouched.</para>
///
/// <para>When a non-streaming response comes back with <c>stop_reason: "refusal"</c>, the handler
/// retries the request with each entry of the fallback chain applied over the original params,
/// passing along the refusal's <c>fallback_credit_token</c> (which refunds the retry's
/// cache-miss cost), until a model accepts or the chain is exhausted.</para>
///
/// <para>When a streaming response ends in <c>stop_reason: "refusal"</c>, the handler issues a
/// second request to the fallback model, carrying the refused model's partial output as a
/// trailing assistant prefill when the refusal grants one (<c>fallback_has_prefill_claim</c>),
/// plus the refusal's <c>fallback_credit_token</c>. It splices the fallback's events onto the
/// still-open stream, so the client sees one continuous message in the server-side
/// <c>fallbacks</c> wire shape: a <c>fallback</c> content block at each model boundary, monotonic
/// block indices, and per-hop <c>usage.iterations</c> on the final <c>message_delta</c>. Only
/// <c>model</c> is honored from each entry on this path: the credit token is redeemable only
/// against the refused request's body, so the other per-entry overrides (<c>max_tokens</c>,
/// <c>thinking</c>, ...) would be rejected.</para>
///
/// <para>The handler sends the fallback-credit beta by default on every request it handles,
/// including the original, since a refusal carries a <c>fallback_credit_token</c> only when the
/// beta is enabled; the <see cref="Betas"/> option controls this.</para>
///
/// <para>In both modes a fallback that itself refuses with a fresh credit token continues down
/// the chain, and a fallback whose request fails outright is skipped: its token was never
/// redeemed, so it carries to the next entry. A streaming fallback whose prefill the server
/// rejects (HTTP 400) is retried once without it. A refusal with no
/// <c>fallback_credit_token</c> is reported once per handler by a warning on standard error;
/// a streaming one is passed to the client (the continuation requires the token), while a
/// non-streaming one is still retried, without the credit. A refusal that exhausts the chain is
/// passed through silently, since its terminal <c>message_delta</c> already reports every
/// hop.</para>
///
/// <para>To keep later requests on the model that accepted, wrap them in a
/// <see cref="BetaFallbackState.Use"/> scope; requests sharing that state start directly at the
/// pinned fallback. Reuse one state across whatever scope the pin should cover, typically a
/// conversation.</para>
///
/// <para>Example:</para>
///
/// <code>
/// AnthropicClient client = new()
/// {
///     Handlers = [new BetaRefusalFallbackHandler { Fallbacks = [new(Model.ClaudeOpus4_8)] }],
/// };
///
/// BetaFallbackState fallbackState = BetaFallbackState.Create();
/// using (fallbackState.Use())
/// {
///     BetaMessage message = await client.Beta.Messages.Create(parameters);
/// }
/// </code>
/// </summary>
public sealed class BetaRefusalFallbackHandler : DelegatingHandler
{
    IReadOnlyList<BetaFallbackParam> _fallbacks = [];
    IReadOnlyList<bool> _hasNonModelOverrides = [];

    /// <summary>
    /// The fallbacks that refused requests are retried through, in order.
    ///
    /// <para>An empty list disables the handler.</para>
    /// </summary>
    public IReadOnlyList<BetaFallbackParam> Fallbacks
    {
        get => _fallbacks;
        init
        {
            _fallbacks = [.. value];
            _hasNonModelOverrides =
            [
                .. _fallbacks.Select(fallback => fallback.RawData.Keys.Any(key => key != "model")),
            ];
        }
    }

    IReadOnlyList<ApiEnum<string, AnthropicBeta>> _betas = [AnthropicBeta.FallbackCredit2026_06_01];

    /// <summary>
    /// The betas added to the <c>anthropic-beta</c> header of every <c>/v1/messages</c> request
    /// this handler handles, including the original, since refusals only carry a
    /// <c>fallback_credit_token</c> when the beta is enabled.
    ///
    /// <para>Defaults to <see cref="AnthropicBeta.FallbackCredit2026_06_01"/>; set an empty list
    /// to send none.</para>
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>> Betas
    {
        get => _betas;
        init => _betas = [.. value];
    }

    readonly FallbackDiagnostics _diagnostics = new();

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var snapshot = await Prepare(request, cancellationToken).ConfigureAwait(false);
        if (snapshot == null)
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        if (!snapshot.IsStreaming)
        {
            ChainPolicy policy = new(
                ChainPolicy.Mode.Buffered,
                Fallbacks.Count,
                _hasNonModelOverrides,
                snapshot.InitialIndex
            );
            return await new BufferedRun(snapshot, policy, SendInner)
                .Run(cancellationToken)
                .ConfigureAwait(false);
        }

        var response = await base.SendAsync(
                snapshot.Request(snapshot.InitialIndex),
                cancellationToken
            )
            .ConfigureAwait(false);
        // Splicing needs at least one entry left to hop to; otherwise the stream passes through
        // untouched. Only a successful response can end in a refusal; errors get normal handling.
        if (!response.IsSuccessStatusCode || snapshot.InitialIndex + 1 >= Fallbacks.Count)
        {
            return response;
        }
        ChainPolicy splicePolicy = new(
            ChainPolicy.Mode.Spliced,
            Fallbacks.Count,
            _hasNonModelOverrides,
            snapshot.InitialIndex
        );
        return new SpliceRun(snapshot, splicePolicy, response, SendInner).Response();
    }

    /// <summary>Sends a request down the rest of the handler chain, for hop requests, including
    /// those issued while a spliced stream is being read.</summary>
    Task<HttpResponseMessage> SendInner(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    ) => base.SendAsync(request, cancellationToken);

    /// <summary>
    /// Returns a <see cref="RequestSnapshot"/> for retrying the given request through the fallback
    /// chain, or <c>null</c> if the request should pass through unintercepted.
    /// </summary>
    async Task<RequestSnapshot?> Prepare(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        // This handler only applies to the beta messages API; the SDK's beta services tag their
        // requests with `beta=true`. An empty chain also disables this handler.
        if (
            Fallbacks.Count == 0
            || request.Method != HttpMethod.Post
            || request.RequestUri is not Uri uri
            || !uri.AbsolutePath.EndsWith("/v1/messages", StringComparison.Ordinal)
            || !uri.Query.TrimStart('?').Split('&').Contains("beta=true")
            || request.Content is not HttpContent requestContent
        )
        {
            return null;
        }

        // Snapshot the request eagerly: the caller disposes the request (and its body) as soon as
        // headers arrive, but a spliced stream issues hop requests while its body is being read.
        var bodyBytes = await requestContent
            .ReadAsByteArrayAsync(cancellationToken)
            .ConfigureAwait(false);
        JsonObject? body;
        try
        {
            body = JsonNode.Parse(bodyBytes) as JsonObject;
        }
        catch (JsonException)
        {
            body = null;
        }
        if (body == null)
        {
            return null;
        }
        // The server would apply its own chain on top of this handler's retries.
        if (body.TryGetPropertyValue("fallbacks", out var fallbacks) && fallbacks != null)
        {
            throw new AnthropicException(
                "Sending the `fallbacks:` request param is not supported when using the "
                    + "`BetaRefusalFallbackHandler`. You should either remove the middleware "
                    + "and send `fallbacks:` with "
                    + "the `server-side-fallback-2026-06-01` beta header to let the API handle "
                    + "refusal fallbacks, or omit "
                    + "the `fallbacks:` param if you'd like `BetaRefusalFallbackHandler` to "
                    + "handle fallbacks on the client side."
            );
        }

        // History replayed from an earlier fallback turn contains blocks the server rejects;
        // trim them before any request (initial, retry, or streaming hop) goes out.
        if (HistoryTrimmer.TrimFallbackTurns(body))
        {
            bodyBytes = Encoding.UTF8.GetBytes(body.ToJsonString());
        }

        var state = BetaFallbackState.Current;
        // Start from the pinned fallback (-1 = the original params).
        var index = state?.Index ?? -1;
        if (index < -1 || index >= Fallbacks.Count)
        {
            throw new AnthropicException(
                $"BetaFallbackState.Index {index} is out of bounds for a chain of "
                    + $"{Fallbacks.Count} fallback(s); was the state shared with a different handler?"
            );
        }

        // Send the configured betas on this and every hop request derived from it.
        var headers = WithHandlerHeaders(
            request.Headers.Select(header => new KeyValuePair<string, string[]>(
                header.Key,
                [.. header.Value]
            ))
        );
        var contentHeaders = requestContent
            .Headers.Where(header =>
                // The hop bodies differ in length; ByteArrayContent recomputes it.
                !string.Equals(header.Key, "Content-Length", StringComparison.OrdinalIgnoreCase)
            )
            .Select(header => new KeyValuePair<string, string[]>(header.Key, [.. header.Value]))
            .ToList();

        return new RequestSnapshot(uri, request)
        {
            Entries = Fallbacks,
            Diagnostics = _diagnostics,
            Headers = headers,
            ContentHeaders = contentHeaders,
            BodyBytes = bodyBytes,
            State = state,
            InitialIndex = index,
            IsStreaming =
                body["stream"] is JsonValue stream
                && stream.TryGetValue(out bool isStreaming)
                && isStreaming,
        };
    }

    /// <summary>
    /// Returns a copy of the headers with <see cref="Betas"/> appended to <c>anthropic-beta</c>
    /// (skipping values already present) and the handler's helper-telemetry tag appended to
    /// <c>x-stainless-helper</c>.
    /// </summary>
    List<KeyValuePair<string, string[]>> WithHandlerHeaders(
        IEnumerable<KeyValuePair<string, string[]>> headers
    )
    {
        List<KeyValuePair<string, string[]>> copied = [];
        HashSet<string> existingBetas = [];
        foreach (var header in headers)
        {
            if (
                string.Equals(
                    header.Key,
                    StainlessHelperHeader.Name,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                continue; // replaced below with the merged value
            }
            copied.Add(header);
            if (string.Equals(header.Key, "anthropic-beta", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var value in header.Value)
                {
                    foreach (var beta in value.Split(','))
                    {
                        existingBetas.Add(beta.Trim());
                    }
                }
            }
        }
        List<string> missing = [];
        foreach (var beta in Betas)
        {
            if (existingBetas.Add(beta.Raw()))
            {
                missing.Add(beta.Raw());
            }
        }
        if (missing.Count > 0)
        {
            copied.Add(new KeyValuePair<string, string[]>("anthropic-beta", [.. missing]));
        }
        copied.Add(
            new KeyValuePair<string, string[]>(
                StainlessHelperHeader.Name,
                [
                    StainlessHelperHeader.MergedValue(
                        headers,
                        StainlessHelperHeader.FallbackRefusalMiddleware
                    ),
                ]
            )
        );
        return copied;
    }
}
