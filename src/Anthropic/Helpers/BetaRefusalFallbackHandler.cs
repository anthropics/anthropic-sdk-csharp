using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
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
/// <para>When a non-streaming response comes back with <c>stop_reason: "refusal"</c>, the request
/// is retried with each entry of the fallback chain applied over the original params — passing
/// along the refusal's <c>fallback_credit_token</c>, which refunds the retry's cache-miss cost —
/// until a model accepts or the chain is exhausted.</para>
///
/// <para>When a streaming response ends in <c>stop_reason: "refusal"</c>, a second request is
/// issued to the fallback model — carrying the refused model's partial output as a trailing
/// assistant prefill when the refusal grants one (<c>fallback_has_prefill_claim</c>), plus the
/// refusal's <c>fallback_credit_token</c> — and the fallback's events are spliced onto the
/// still-open stream, so the client sees one continuous message in the server-side
/// <c>fallbacks</c> wire shape: a <c>fallback</c> content block at each model boundary, monotonic
/// block indices, and per-hop <c>usage.iterations</c> on the final <c>message_delta</c>. Only
/// <c>model</c> is honored from each entry on this path: the credit token is redeemable only
/// against the refused request's body, so the other per-entry overrides (<c>max_tokens</c>,
/// <c>thinking</c>, ...) would be rejected.</para>
///
/// <para>The fallback-credit beta the credit tokens require is sent by default on every request
/// the handler handles — the original request included, since refusals only carry a
/// <c>fallback_credit_token</c> when the beta is enabled; the <see cref="Betas"/> option controls
/// this.</para>
///
/// <para>In both modes a fallback that itself refuses with a fresh credit token continues down
/// the chain, and a fallback whose request fails outright is skipped — its token was never
/// redeemed, so it carries to the next entry. A streaming fallback whose prefill the server
/// rejects (HTTP 400) is retried once without it. A refusal with no
/// <c>fallback_credit_token</c> is reported once per handler with a warning on standard error —
/// a streaming one is surfaced to the client (the continuation requires the token); a
/// non-streaming one is still retried, only without the credit. A refusal that exhausts the
/// chain is surfaced silently — its terminal <c>message_delta</c> already reports every
/// hop.</para>
///
/// <para>To keep later requests on the model that accepted, wrap them in a
/// <see cref="BetaFallbackState.Use"/> scope; requests sharing that state start directly at the
/// pinned fallback. Reuse one state across whatever scope the pin should apply to — typically a
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

    /// <summary>
    /// The fallbacks that refused requests are retried through, in order.
    ///
    /// <para>An empty list disables the handler.</para>
    /// </summary>
    public IReadOnlyList<BetaFallbackParam> Fallbacks
    {
        get => _fallbacks;
        init => _fallbacks = [.. value];
    }

    IReadOnlyList<ApiEnum<string, AnthropicBeta>> _betas = [AnthropicBeta.FallbackCredit2026_06_01];

    /// <summary>
    /// The betas added to the <c>anthropic-beta</c> header of every <c>/v1/messages</c> request
    /// this handler handles — the original request included, since refusals only carry a
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

    int _warnedMissingState;
    int _warnedMissingToken;

    /// <summary>
    /// Delta types <see cref="FallbackStreamSplicer"/> can't accumulate into a prefill, each
    /// warned once.
    /// </summary>
    readonly ConcurrentDictionary<string, byte> _warnedDeltaTypes = new();

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var preparedRequest = await Prepare(request, cancellationToken).ConfigureAwait(false);
        if (preparedRequest == null)
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        var index = preparedRequest.InitialIndex;
        var response = await base.SendAsync(preparedRequest.Request(index), cancellationToken)
            .ConfigureAwait(false);
        if (preparedRequest.IsStreaming)
        {
            return SpliceRefusedStream(preparedRequest, response);
        }

        // Every entry whose request refused, in order — each consecutive pair (and the final
        // pair into the serving entry) spells one seam block.
        var refusedIndices = new List<int>();

        // Only a successful response can be a refusal; errors get normal handling. Hop errors
        // are skipped inside the loop, so one only reaches here when the chain stopped at it.
        while (response.IsSuccessStatusCode)
        {
            (bool IsRefusal, string? FallbackCreditToken) refusal;
            try
            {
                refusal = await RefusalCreditToken(response, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                // The response never reaches the caller; release it (and its connection).
                response.Dispose();
                throw;
            }
            if (!refusal.IsRefusal)
            {
                // Pin only a fallback that accepted; a refused last entry must not capture
                // follow-up requests sharing the state.
                if (refusedIndices.Count == 0)
                {
                    return response;
                }
                preparedRequest.Pin(index);
                // Mirror the server-side stitched envelope's block shape: one `fallback` seam
                // block per model boundary prepended to the serving hop's content, matching the
                // streaming splice's block shape (usage.iterations stitching is out of scope).
                var boundaries = refusedIndices.Append(index).ToList();
                var seams = boundaries
                    .Zip(boundaries.Skip(1), (from, to) => (from, to))
                    .Select(pair =>
                        (
                            From: preparedRequest.ModelAt(pair.from),
                            To: preparedRequest.ModelAt(pair.to)
                        )
                    )
                    .ToList();
                await PrependFallbackBlocks(response, seams, cancellationToken)
                    .ConfigureAwait(false);
                return response;
            }
            if (index >= Fallbacks.Count - 1)
            {
                return response; // chain exhausted: surface the refusal
            }
            // A refusal without a token is still retried — the next entry's params may make
            // the difference — but the retry's cache-miss cost isn't refunded.
            if (refusal.FallbackCreditToken == null)
            {
                WarnMissingTokenOnce(
                    "the retry's cache-miss cost isn't refunded",
                    betaEnabled: index != preparedRequest.InitialIndex
                );
            }

            // The entry whose body the token was minted against — its overrides were applied
            // to the refused request.
            var mintedIndex = index;
            refusedIndices.Add(index);
            response.Dispose();

            while (true)
            {
                index++;
                response = await base.SendAsync(
                        preparedRequest.Request(index, refusal.FallbackCreditToken),
                        cancellationToken
                    )
                    .ConfigureAwait(false);

                // The token is only redeemable against the refused request's body plus a model
                // swap, so a body that differs further — this entry's overrides, or overrides
                // the refused request's entry applied that this one doesn't — can be rejected
                // with the token attached; retry once without it — the overrides still apply,
                // only the credit is lost.
                if (
                    response.StatusCode == HttpStatusCode.BadRequest
                    && refusal.FallbackCreditToken != null
                    && (HasNonModelOverrides(index) || HasNonModelOverrides(mintedIndex))
                )
                {
                    var errorBody = await FallbackStreamSplicer
                        .ReadErrorBody(response, cancellationToken)
                        .ConfigureAwait(false);
                    Warn(
                        "fallback request with the entry's overrides and the credit token was "
                            + $"rejected (HTTP 400: {errorBody}); retrying without the token"
                    );
                    response = await base.SendAsync(
                            preparedRequest.Request(index),
                            cancellationToken
                        )
                        .ConfigureAwait(false);
                }
                if (response.IsSuccessStatusCode || index >= Fallbacks.Count - 1)
                {
                    break;
                }
                // A hop that failed outright never redeemed the token, so it carries to the
                // next entry.
                var body = await FallbackStreamSplicer
                    .ReadErrorBody(response, cancellationToken)
                    .ConfigureAwait(false);
                Warn(
                    $"fallback request to {Fallbacks[index].Model.Raw()} failed: "
                        + $"HTTP {(int)response.StatusCode}: {body}"
                );
            }
        }
        return response;
    }

    /// <summary>Whether the entry at the index overrides more than the model (-1 = the original
    /// request, which by definition doesn't).</summary>
    bool HasNonModelOverrides(int index) =>
        index >= 0 && Fallbacks[index].RawData.Keys.Any(key => key != "model");

    /// <summary>
    /// Returns a response that passes the refused stream's events through and splices the
    /// fallback chain's events on (see <see cref="FallbackStreamSplicer"/>), or the response
    /// unchanged if it can't end in a retryable refusal.
    /// </summary>
    HttpResponseMessage SpliceRefusedStream(
        PreparedRequest preparedRequest,
        HttpResponseMessage response
    )
    {
        var firstHop = preparedRequest.InitialIndex + 1;
        // Splicing needs at least one entry left to hop to; otherwise the stream passes through
        // untouched. Only a successful response can end in a refusal; errors get normal handling.
        if (!response.IsSuccessStatusCode || firstHop >= Fallbacks.Count)
        {
            return response;
        }
        return new FallbackStreamSplicer(this, preparedRequest, response, firstHop).Response();
    }

    /// <summary>
    /// Returns a <see cref="PreparedRequest"/> for retrying the given request through the
    /// fallback chain, or <c>null</c> if the request should pass through unintercepted.
    /// </summary>
    async Task<PreparedRequest?> Prepare(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        // This handler only applies to the beta messages API — the SDK's beta services tag their
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
            .ReadAsByteArrayAsync(
#if NET
                cancellationToken
#endif
            )
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
        // trim them before any request — initial, retry, or streaming hop — goes out.
        if (TrimFallbackTurns(body))
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
        var headers = AppendBetas(
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

        return new PreparedRequest(
            this,
            request,
            headers,
            contentHeaders,
            bodyBytes,
            state,
            index,
            isStreaming: body["stream"] is JsonValue stream
                && stream.TryGetValue(out bool isStreaming)
                && isStreaming
        );
    }

    /// <summary>
    /// Removes content the server would reject from assistant turns that contain a
    /// <c>fallback</c> block: the fallback block itself (it only parses under the server-side
    /// <c>fallbacks</c> beta, which this handler never sends), and everything before it that
    /// belongs to the model that refused — thinking, connector text, and tool calls that never
    /// got a result. Blocks after the fallback block are what the serving model produced and
    /// stay as written; a turn left empty is dropped whole. Returns whether anything changed,
    /// so an untouched body keeps its original bytes.
    ///
    /// <para>Blocks are classified through <see cref="BetaContentBlockParam"/>, but kept blocks
    /// always emit their original nodes — the deserialized models are never written back.</para>
    /// </summary>
    internal static bool TrimFallbackTurns(JsonObject body)
    {
        if (body["messages"] is not JsonArray messages)
        {
            return false;
        }

        // Tool calls whose result appears anywhere in the history are kept.
        HashSet<string> resolved = [];
        foreach (var message in messages)
        {
            if ((message as JsonObject)?["content"] is not JsonArray content)
            {
                continue;
            }
            foreach (var block in content)
            {
                if (ParseBlock(block) is { } parsed && ResolvedToolUseID(parsed) is { } toolUseId)
                {
                    resolved.Add(toolUseId);
                }
            }
        }

        var changed = false;
        for (var i = messages.Count - 1; i >= 0; i--)
        {
            if (
                messages[i] is not JsonObject message
                || StringField(message, "role") != "assistant"
                || message["content"] is not JsonArray content
            )
            {
                continue;
            }
            var parsed = new BetaContentBlockParam?[content.Count];
            var lastFallback = -1;
            for (var j = 0; j < content.Count; j++)
            {
                parsed[j] = ParseBlock(content[j]);
                if (parsed[j] is { } block && block.TryPickFallback(out _))
                {
                    lastFallback = j;
                }
            }
            if (lastFallback == -1)
            {
                continue;
            }
            for (var j = content.Count - 1; j >= 0; j--)
            {
                if (parsed[j] is not { } block)
                {
                    continue;
                }
                if (
                    block.TryPickFallback(out _)
                    || (j < lastFallback && IsRefusedAttempt(block, resolved))
                )
                {
                    content.RemoveAt(j);
                    changed = true;
                }
            }
            if (content.Count == 0)
            {
                messages.RemoveAt(i);
            }
        }
        return changed;
    }

    /// <summary>
    /// Reads a content element into the request-side block union for classification, or
    /// <c>null</c> if it isn't an object. An unrecognized block type still parses — with a null
    /// <see cref="BetaContentBlockParam.Value"/> and the element preserved as
    /// <see cref="BetaContentBlockParam.Json"/>.
    /// </summary>
    static BetaContentBlockParam? ParseBlock(JsonNode? block) =>
        block is JsonObject
            ? JsonSerializer.Deserialize<BetaContentBlockParam>(block, ModelBase.SerializerOptions)
            : null;

    /// <summary>
    /// Whether a block sitting before the seam belongs to the refused model's attempt and must
    /// be trimmed: thinking, connector text, or a tool call that never got a result. Unknown
    /// variants classify as keep — never drop a block type this SDK version doesn't recognize —
    /// hence TryPick chains rather than <c>Switch</c>/<c>Match</c>, which throw on them.
    /// </summary>
    static bool IsRefusedAttempt(BetaContentBlockParam block, HashSet<string> resolved)
    {
        if (
            block.TryPickThinking(out _)
            || block.TryPickRedactedThinking(out _)
            || block.TryPickToolUse(out _)
        )
        {
            return true;
        }
        if (block.TryPickServerToolUse(out var serverToolUse))
        {
            return ServerToolUseID(serverToolUse) is not { } id || !resolved.Contains(id);
        }
        // connector_text has no request-union variant (the SDK doesn't model it at all yet), so
        // it's the one block type still classified by its raw tag.
        return block.Value == null && RawType(block) == "connector_text";
    }

    /// <summary>
    /// The <c>tool_use_id</c> a result block resolves, or <c>null</c> for any other block. An
    /// unrecognized <c>*_tool_result</c> type still resolves its call by its raw fields — erring
    /// toward keeping the <c>server_tool_use</c> it answers.
    /// </summary>
    static string? ResolvedToolUseID(BetaContentBlockParam block)
    {
        if (block.Value != null)
        {
            try
            {
                // Non-null exactly for the union's result variants.
                return block.ToolUseID;
            }
            catch (AnthropicInvalidDataException)
            {
                return null; // a result block with a malformed tool_use_id resolves nothing
            }
        }
        return
            RawType(block) is { } type
            && type.EndsWith("_tool_result", StringComparison.Ordinal)
            && block.Json.TryGetProperty("tool_use_id", out var toolUseId)
            && toolUseId.ValueKind == JsonValueKind.String
            ? toolUseId.GetString()
            : null;
    }

    /// <summary>The block's <c>id</c>, or <c>null</c> when the replayed JSON lacks a usable one
    /// (the model's lazy property parse throws rather than returning null).</summary>
    static string? ServerToolUseID(BetaServerToolUseBlockParam serverToolUse)
    {
        try
        {
            return serverToolUse.ID;
        }
        catch (AnthropicInvalidDataException)
        {
            return null;
        }
    }

    /// <summary>The raw <c>type</c> tag, for block types the request union doesn't model.</summary>
    static string? RawType(BetaContentBlockParam block) =>
        block.Json.ValueKind == JsonValueKind.Object
        && block.Json.TryGetProperty("type", out var type)
        && type.ValueKind == JsonValueKind.String
            ? type.GetString()
            : null;

    static string? StringField(JsonObject obj, string key) =>
        obj[key] is JsonValue value && value.TryGetValue(out string? text) ? text : null;

    /// <summary>
    /// Returns a copy of the headers with <see cref="Betas"/> appended to <c>anthropic-beta</c>,
    /// skipping values already present (set by the caller or another handler).
    /// </summary>
    List<KeyValuePair<string, string[]>> AppendBetas(
        IEnumerable<KeyValuePair<string, string[]>> headers
    )
    {
        var copied = headers.ToList();
        if (Betas.Count == 0)
        {
            return copied;
        }
        HashSet<string> existing =
        [
            .. copied
                .Where(header =>
                    string.Equals(header.Key, "anthropic-beta", StringComparison.OrdinalIgnoreCase)
                )
                .SelectMany(header => header.Value)
                .SelectMany(value => value.Split(','))
                .Select(value => value.Trim()),
        ];
        var missing = Betas.Select(beta => beta.Raw()).Where(existing.Add).ToArray();
        if (missing.Length > 0)
        {
            copied.Add(new KeyValuePair<string, string[]>("anthropic-beta", missing));
        }
        return copied;
    }

    /// <summary>
    /// Returns the refusal's <c>fallback_credit_token</c> if the response is a refused message,
    /// or a non-refusal if the response isn't one and should be returned as-is.
    /// </summary>
    static async Task<(bool IsRefusal, string? FallbackCreditToken)> RefusalCreditToken(
        HttpResponseMessage response,
        CancellationToken cancellationToken
    )
    {
        // Reading the content buffers it, so a non-refusal response stays fully readable.
        var body = await response
            .Content.ReadAsStringAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);
        try
        {
            var message = JsonSerializer.Deserialize<BetaMessage>(
                body,
                ModelBase.SerializerOptions
            );
            if (
                message?.StopReason is not { } stopReason
                || stopReason.Value() != BetaStopReason.Refusal
            )
            {
                return (false, null);
            }
            return (true, message.StopDetails?.FallbackCreditToken);
        }
        catch (Exception e) when (e is JsonException or AnthropicInvalidDataException)
        {
            // Pass unexpected response shapes (e.g. errors) through for normal handling.
            return (false, null);
        }
    }

    /// <summary>
    /// Rewrites a non-streaming serving response to carry one synthetic <c>fallback</c> seam
    /// block per model boundary prepended to its content, matching the streaming splice's block
    /// shape (serialized from the typed <see cref="BetaFallbackBlock"/>). A body that doesn't
    /// parse to a message with a content array is left untouched.
    /// </summary>
    static async Task PrependFallbackBlocks(
        HttpResponseMessage response,
        List<(string From, string To)> seams,
        CancellationToken cancellationToken
    )
    {
        // RefusalCreditToken already buffered the content, so re-reading is cheap.
        var body = await response
            .Content.ReadAsStringAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);
        JsonObject? message;
        try
        {
            message = JsonNode.Parse(body) as JsonObject;
        }
        catch (JsonException)
        {
            return;
        }
        if (message?["content"] is not JsonArray content)
        {
            return;
        }

        // Insert oldest-first at index 0: walk the seams in reverse so the earliest boundary
        // ends up first in the content array.
        for (var i = seams.Count - 1; i >= 0; i--)
        {
            content.Insert(
                0,
                JsonSerializer.SerializeToNode(
                    new BetaFallbackBlock
                    {
                        From = new BetaFallbackInfo { Model = seams[i].From },
                        To = new BetaFallbackInfo { Model = seams[i].To },
                    },
                    ModelBase.SerializerOptions
                )
            );
        }

        ByteArrayContent rewritten = new(Encoding.UTF8.GetBytes(message.ToJsonString()));
        foreach (var header in response.Content.Headers)
        {
            // Content-Length is recomputed for the rewritten body.
            if (!string.Equals(header.Key, "Content-Length", StringComparison.OrdinalIgnoreCase))
            {
                rewritten.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        var old = response.Content;
        response.Content = rewritten;
        old.Dispose();
    }

    /// <summary>
    /// Sends a request down the rest of the handler chain, for hop requests issued while a
    /// spliced stream is being read.
    /// </summary>
    internal Task<HttpResponseMessage> SendToInnerAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    ) => base.SendAsync(request, cancellationToken);

    internal static void Warn(string message) =>
        Console.Error.WriteLine($"WARNING: `BetaRefusalFallbackHandler`: {message}");

    /// <param name="consequence">What the missing token means for this request.</param>
    /// <param name="betaEnabled">Whether a credit token already arrived this request — proof the
    /// fallback-credit beta is enabled, ruling that cause out of the warning.</param>
    internal void WarnMissingTokenOnce(string consequence, bool betaEnabled)
    {
        if (Interlocked.Exchange(ref _warnedMissingToken, 1) == 0)
        {
            BetaRefusalFallbackHandler.Warn(
                $"refusal stop_details has no fallback_credit_token, so {consequence}; the "
                    + "refusal may be ineligible for a fallback credit"
                    + (
                        betaEnabled
                            ? ""
                            : ", or the fallback-credit beta may not be enabled for this account"
                    )
            );
        }
    }

    internal void WarnDeltaTypeOnce(string type)
    {
        if (_warnedDeltaTypes.TryAdd(type, 0))
        {
            BetaRefusalFallbackHandler.Warn(
                $"content_block_delta type \"{type}\" is not accumulated; a continuation prefill "
                    + "including its block may be rejected and retried without the prefill"
            );
        }
    }

    /// <summary>A request being retried through the fallback chain.</summary>
    internal sealed class PreparedRequest
    {
        readonly BetaRefusalFallbackHandler _handler;
        readonly Uri _uri;
        readonly Version _version;
#if NET
        readonly HttpVersionPolicy _versionPolicy;
        readonly IReadOnlyList<KeyValuePair<string, object?>> _options;
#else
        readonly IReadOnlyList<KeyValuePair<string, object>> _properties;
#endif
        readonly IReadOnlyList<KeyValuePair<string, string[]>> _headers;
        readonly IReadOnlyList<KeyValuePair<string, string[]>> _contentHeaders;
        readonly byte[] _bodyBytes;
        readonly BetaFallbackState? _state;

        public PreparedRequest(
            BetaRefusalFallbackHandler handler,
            HttpRequestMessage request,
            IReadOnlyList<KeyValuePair<string, string[]>> headers,
            IReadOnlyList<KeyValuePair<string, string[]>> contentHeaders,
            byte[] bodyBytes,
            BetaFallbackState? state,
            int initialIndex,
            bool isStreaming
        )
        {
            _handler = handler;
            // Snapshotted (not held) — the caller disposes the request once headers arrive.
            _uri = request.RequestUri!;
            _version = request.Version;
#if NET
            _versionPolicy = request.VersionPolicy;
            _options = [.. request.Options];
#else
            _properties = [.. request.Properties];
#endif
            _headers = headers;
            _contentHeaders = contentHeaders;
            _bodyBytes = bodyBytes;
            _state = state;
            InitialIndex = initialIndex;
            IsStreaming = isStreaming;
        }

        public int InitialIndex { get; }

        public bool IsStreaming { get; }

        /// <summary>
        /// Returns a request with the fallback at the given index applied (-1 = the original
        /// request), plus the previous refusal's <c>fallback_credit_token</c>, if any.
        /// </summary>
        public HttpRequestMessage Request(int index, string? fallbackCreditToken = null)
        {
            if (index == -1)
            {
                return Build(_bodyBytes);
            }

            var body = EffectiveBody(index);
            if (fallbackCreditToken != null)
            {
                body["fallback_credit_token"] = fallbackCreditToken;
            }
            return Build(Encoding.UTF8.GetBytes(body.ToJsonString()));
        }

        /// <summary>
        /// Returns the body with the fallback at the given index applied (-1 = the original
        /// body).
        /// </summary>
        JsonObject EffectiveBody(int index)
        {
            var body = (JsonObject)JsonNode.Parse(_bodyBytes)!;
            if (index == -1)
            {
                return body;
            }
            // The fallback's raw fields are exactly its set params (`model`, optional overrides,
            // and any extra properties), so overlaying them applies the entry.
            foreach (var field in _handler.Fallbacks[index].RawData)
            {
                body[field.Key] = JsonNode.Parse(field.Value.GetRawText());
            }
            return body;
        }

        /// <summary>
        /// Returns the hop request for a spliced stream: the initial request's body with the
        /// model and credit token swapped in and the continuation appended as a trailing
        /// assistant turn.
        /// </summary>
        public HttpRequestMessage HopRequest(
            string model,
            string fallbackCreditToken,
            IReadOnlyList<JsonObject> continuation
        )
        {
            // Rebuilt on every attempt so each request starts from the body the token was minted
            // against: the initial request's — a pinned entry's overrides included, since the
            // initial request carried them and the token binds to them.
            var body = EffectiveBody(InitialIndex);

            body["model"] = model;
            body["fallback_credit_token"] = fallbackCreditToken;

            // Append the continuation (decided by the chain loop) as a trailing assistant turn;
            // everything else — max_tokens included — must stay identical to the refused request:
            // the token is only redeemable against the same body, so model,
            // fallback_credit_token, and the one appended assistant turn are the only permitted
            // deltas; anything else is a 400. This is also why the per-entry BetaFallbackParam
            // overrides are ignored on the streaming path.
            if (continuation.Count > 0)
            {
                if (body["messages"] is not JsonArray messages)
                {
                    messages = [];
                    body["messages"] = messages;
                }
                JsonArray content = [];
                foreach (var block in continuation)
                {
                    content.Add(block.DeepClone());
                }
                messages.Add(new JsonObject { ["role"] = "assistant", ["content"] = content });
            }

            return Build(Encoding.UTF8.GetBytes(body.ToJsonString()));
        }

        /// <summary>
        /// The model the request at the given index was sent with, as the caller (or the
        /// entry's override) spelled it (-1 = the original request).
        /// </summary>
        public string ModelAt(int index) =>
            EffectiveBody(index)["model"] is JsonValue value && value.TryGetValue(out string? model)
                ? model
                : "";

        /// <summary>Pins requests sharing the state to the fallback at the given index.</summary>
        public void Pin(int index)
        {
            if (_state != null)
            {
                _state.Index = index;
            }
            else if (Interlocked.Exchange(ref _handler._warnedMissingState, 1) == 0)
            {
                Console.Error.WriteLine(
                    "WARNING: `BetaRefusalFallbackHandler` fell back without an ambient "
                        + "`BetaFallbackState`; follow-up requests will retry models that already "
                        + "refused. Wrap requests that should share the pin in a "
                        + "`BetaFallbackState.Create()` scope via `using (state.Use()) { ... }` to "
                        + "pin them to the accepted model."
                );
            }
        }

        HttpRequestMessage Build(byte[] bodyBytes)
        {
            HttpRequestMessage request = new(HttpMethod.Post, _uri) { Version = _version };
#if NET
            request.VersionPolicy = _versionPolicy;
            foreach (var option in _options)
            {
                ((IDictionary<string, object?>)request.Options)[option.Key] = option.Value;
            }
#else
            foreach (var property in _properties)
            {
                request.Properties[property.Key] = property.Value;
            }
#endif
            foreach (var header in _headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            ByteArrayContent content = new(bodyBytes);
            foreach (var header in _contentHeaders)
            {
                content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            request.Content = content;
            return request;
        }
    }
}
