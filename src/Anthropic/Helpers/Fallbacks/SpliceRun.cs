using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using static Anthropic.Core.JsonNodes;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// Executes the fallback chain for a streaming request whose initial stream may end in a
/// retryable refusal: the initial stream's events pass through until a chainable refusal, then
/// each fallback hop's request is issued and its events are spliced on, so the caller reads one
/// continuous message. Sends hops and forwards events; every decision is the
/// <see cref="ChainPolicy"/>'s and every synthesized event is <see cref="WireShape"/>'s.
///
/// <para>Each retry uses the appended-assistant form documented on <c>fallback_credit_token</c>:
/// the refused request's body, extended by one trailing assistant turn carrying the refused
/// model's partial output. The token authorizes that turn as a prefill continuation and applies
/// the fallback credit. The refusal's <c>fallback_has_prefill_claim</c> says whether the partial
/// output may be resent verbatim: when true the accumulated blocks are appended as-is; when
/// false the refused hop's output is dropped and the token is redeemed against the same
/// body.</para>
///
/// <para>The spliced body is produced lazily as it's read. Disposing the response tears down
/// whichever stream is being read; an in-flight hop request can't be cancelled, but its
/// response is disposed once it resolves.</para>
///
/// <para>Events flowing through the splice, and the partial output resent as the continuation
/// prefill, are handled as raw JSON rather than the typed models: the credit token is only
/// redeemable when the prefill matches the wire output verbatim, and only raw JSON accumulates
/// deltas onto block types the SDK doesn't model yet (exactly what a brand-new model may
/// stream).</para>
///
/// <para>Known divergences from server-side <c>fallbacks</c>: <c>message.model</c> keeps the
/// refused model's id, since message_start was sent before the refusal arrived (the
/// <c>fallback</c> block's <c>model</c> field carries the serving model); and refusal text
/// streamed before the refusal stays in the message and is resent as-is, since the appended
/// turn must match the partial output verbatim.</para>
/// </summary>
internal sealed class SpliceRun : LazySseBody.ISource
{
    /// <summary>The outcome of consuming one hop's stream.</summary>
    sealed class HopOutcome
    {
        /// <summary>Whether the hop's terminal message_delta was a refusal, chainable or
        /// not.</summary>
        public bool Refused { get; set; }

        /// <summary>Set when the refusal chained: its backfilled usage.</summary>
        public JsonObject? HeldUsage { get; set; }

        /// <summary>Set when the refusal chained: its message_delta wire event, delivered verbatim
        /// if the whole chain degrades.</summary>
        public JsonObject? HeldEvent { get; set; }

        /// <summary>The hop's serving model, from its message_start.</summary>
        public string? Model { get; set; }

        /// <summary>The hop's accumulated content blocks, in start order; the next partial
        /// segment.</summary>
        public List<BlockAccumulator.AccumulatedBlock> Blocks { get; set; } = [];

        /// <summary>One past the highest (shifted) block index emitted, where the next boundary
        /// goes.</summary>
        public int NextIndex { get; set; }
    }

    /// <summary>The result of sending one hop's request: the 2xx response to splice, or the
    /// directive the chain follows when the hop failed outright.</summary>
    sealed class HopSend
    {
        /// <summary>The successful response, ready to consume; null when the hop failed.</summary>
        public HttpResponseMessage? Response { get; init; }

        /// <summary>Where the chain goes when <see cref="Response"/> is null: the next entry, or
        /// a degraded close on the last one.</summary>
        public ChainPolicy.Directive Failure { get; init; }

        /// <summary>Whether the splice was closed while the hop was in flight, so the run must
        /// end silently (the closed response was already disposed).</summary>
        public bool Aborted { get; init; }

        /// <summary>The continuation the sent request carried, resent verbatim if this hop
        /// refuses and chains onward (the prefill may have been dropped by the retry).</summary>
        public IReadOnlyList<JsonObject> Continuation { get; init; } = [];
    }

    /// <summary>Splice context for fallback hops: the iterations accumulated so far and the
    /// hop's model; <c>null</c> for the initial stream.</summary>
    sealed class Splice
    {
        public Splice(IReadOnlyList<JsonObject> iterations, string model)
        {
            Iterations = iterations;
            Model = model;
        }

        public IReadOnlyList<JsonObject> Iterations { get; }
        public string Model { get; }
    }

    readonly RequestSnapshot _snapshot;
    readonly ChainPolicy _policy;
    readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _send;

    /// <summary>The initial stream: the OK SSE response that may end in a refusal.</summary>
    readonly HttpResponseMessage _initialResponse;

    int _closed;

    /// <summary>
    /// The response currently being consumed, disposed when fully consumed or on close. Seeded
    /// with the initial response so a close before the first read still releases it.
    /// </summary>
    HttpResponseMessage? _currentResponse;

    public SpliceRun(
        RequestSnapshot snapshot,
        ChainPolicy policy,
        HttpResponseMessage initialResponse,
        Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send
    )
    {
        _snapshot = snapshot;
        _policy = policy;
        _initialResponse = initialResponse;
        _send = send;
        _currentResponse = initialResponse;
    }

    /// <summary>The synthetic response over the lazily spliced body.</summary>
    public HttpResponseMessage Response()
    {
        HttpResponseMessage response = new(_initialResponse.StatusCode)
        {
            ReasonPhrase = _initialResponse.ReasonPhrase,
            RequestMessage = _initialResponse.RequestMessage,
            Version = _initialResponse.Version,
        };
        foreach (var header in _initialResponse.Headers)
        {
            response.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        LazySseBody content = new(this);
        foreach (var header in _initialResponse.Content.Headers)
        {
            // The spliced body's length isn't knowable up front.
            if (!string.Equals(header.Key, "Content-Length", StringComparison.OrdinalIgnoreCase))
            {
                content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        response.Content = content;
        return response;
    }

    public bool Closed => Volatile.Read(ref _closed) == 1;

    public void Close()
    {
        Volatile.Write(ref _closed, 1);
        CloseCurrentResponse();
    }

    void CloseCurrentResponse() => Interlocked.Exchange(ref _currentResponse, null)?.Dispose();

    /// <summary>
    /// The spliced SSE byte chunks: the initial stream passed through until a chainable refusal,
    /// then each fallback hop tried in order.
    /// </summary>
    public async IAsyncEnumerable<byte[]> Chunks(
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        HopOutcome initial = new();
        await foreach (
            var chunk in ConsumeHop(
                    _initialResponse,
                    indexBase: 0,
                    splice: null,
                    initial,
                    cancellationToken
                )
                // ConfigureAwait(false) everywhere in the splice: LazySseBody supports
                // synchronous reads by blocking on this iterator, which deadlocks a
                // single-threaded SynchronizationContext if any await resumes on it.
                .ConfigureAwait(false)
        )
        {
            yield return chunk;
        }
        CloseCurrentResponse();
        if (initial.HeldEvent == null)
        {
            yield break; // non-refusal (or unchainable refusal): pure pass-through
        }

        // `baseBlocks` is the assistant-turn content the current token's request already
        // carried; the token is redeemable only with it resent verbatim. `partial` is the newest
        // refused hop's output, included only when its refusal granted a prefill claim (any
        // other change to the body is a 400).
        var nextIndex = initial.NextIndex; // monotonic block index across all spliced streams
        // The refusal whose token is in flight; its message_delta is delivered verbatim (with
        // a recommended_model added) if every fallback request fails and we degrade.
        var heldUsage = initial.HeldUsage!;
        var heldEvent = initial.HeldEvent;
        List<JsonObject> baseBlocks = [];
        var partial = _policy.CarriedPrefillClaim
            ? BlockAccumulator.ToPrefillBlocks(initial.Blocks)
            : [];
        var fromModel = initial.Model ?? "";

        // One `message` entry per refused hop, in order, the initial stream's first. Failed hops
        // are skipped (no usage came back); the serving hop is appended as `fallback_message`
        // when its message_delta arrives.
        List<JsonObject> iterations = [WireShape.MessageIteration(initial.Model ?? "", heldUsage)];

        while (true)
        {
            var hop = _policy.CurrentIndex;
            var model = _snapshot.Entries[hop].Model.Raw();

            // The boundary is emitted before the request, so a hop that fails leaves its
            // boundary in place and the next attempt emits its own (still `from: fromModel`, the
            // last model that contributed output).
            var boundaryIndex = nextIndex++;
            yield return WireShape.FallbackBlockStart(
                boundaryIndex,
                new WireShape.ModelTransition(fromModel, model, _policy.CarriedCategory)
            );
            yield return WireShape.ContentBlockStop(boundaryIndex);

            var hopSend = await SendHopRequest(model, baseBlocks, partial, cancellationToken)
                .ConfigureAwait(false);
            if (hopSend.Aborted)
            {
                yield break;
            }
            if (hopSend.Response is not { } hopResponse)
            {
                if (hopSend.Failure == ChainPolicy.Directive.DegradedClose)
                {
                    // The held refusal is delivered verbatim (its category/explanation and the
                    // still unredeemed credit token), with recommended_model pointed at the
                    // hop we last tried.
                    yield return WireShape.HeldRefusalDelta(
                        heldEvent!,
                        heldUsage,
                        model,
                        iterations
                    );
                    yield return WireShape.MessageStop();
                    yield break;
                }
                continue; // the token was never redeemed; retry it against the next entry
            }
            var continuation = hopSend.Continuation;

            Interlocked.Exchange(ref _currentResponse, hopResponse);
            // A close between the in-flight check above and this registration finds
            // _currentResponse empty; re-check so the hop response is still released.
            if (Closed)
            {
                CloseCurrentResponse();
                yield break;
            }
            HopOutcome outcome = new();
            await foreach (
                var chunk in ConsumeHop(
                        hopResponse,
                        nextIndex,
                        new Splice(iterations, model),
                        outcome,
                        cancellationToken
                    )
                    .ConfigureAwait(false)
            )
            {
                yield return chunk;
            }
            CloseCurrentResponse();
            if (outcome.HeldEvent == null)
            {
                // Pin only a hop that actually served: a refused last entry (or a token-less
                // refusal) passed through to the client, and follow-up requests sharing the
                // state shouldn't start at a model that just refused.
                if (!outcome.Refused && _policy.OnServed() is { } pinIndex)
                {
                    _snapshot.Pin(pinIndex);
                }
                yield break;
            }

            // This hop refused too, with a fresh token: its emitted partial stays in the client's
            // message, becomes the next partial segment, and the chain continues (the policy has
            // already advanced to the next entry).
            heldUsage = outcome.HeldUsage!;
            heldEvent = outcome.HeldEvent;
            baseBlocks = [.. continuation];
            partial = _policy.CarriedPrefillClaim
                ? BlockAccumulator.ToPrefillBlocks(outcome.Blocks)
                : [];
            iterations.Add(WireShape.MessageIteration(model, heldUsage));
            fromModel = model;
            nextIndex = outcome.NextIndex;
        }
    }

    /// <summary>
    /// Sends the hop request for one entry (the base continuation plus the newest partial,
    /// appended as an assistant turn) and returns its 2xx response. A 400 on the prefill form
    /// is retried once with the partial dropped, the same-body form the token always supports;
    /// any other failure reports through the policy, which decides between the next entry and
    /// a degraded close.
    /// </summary>
    async Task<HopSend> SendHopRequest(
        string model,
        List<JsonObject> baseBlocks,
        List<JsonObject> partial,
        CancellationToken cancellationToken
    )
    {
        var continuation = baseBlocks.Concat(partial).ToList();
        var prefillIncluded = partial.Count > 0;
        while (true)
        {
            using var hopRequest = _snapshot.HopRequest(model, _policy.CarriedToken!, continuation);
            HttpResponseMessage response;
            try
            {
                response = await _send(hopRequest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                _snapshot.Diagnostics.WarnHopException(model, e);
                return new HopSend
                {
                    Failure = _policy.OnHopError(badRequest: false, extraIncluded: false),
                };
            }
            // The spliced stream may have been closed while the hop was in flight; the request
            // can't be cancelled, so release its response now that it has resolved.
            if (Closed)
            {
                response.Dispose();
                return new HopSend { Aborted = true };
            }
            if (response.IsSuccessStatusCode)
            {
                return new HopSend { Response = response, Continuation = continuation };
            }
            var status = response.StatusCode;
            var errorBody = await FallbackDiagnostics
                .ReadErrorBody(response, cancellationToken)
                .ConfigureAwait(false);
            var directive = _policy.OnHopError(
                badRequest: status == HttpStatusCode.BadRequest,
                extraIncluded: prefillIncluded
            );
            if (directive != ChainPolicy.Directive.ResendWithoutExtra)
            {
                _snapshot.Diagnostics.WarnHopFailure(model, status, errorBody);
                return new HopSend { Failure = directive };
            }
            _snapshot.Diagnostics.Warn(
                "fallback request with the partial output appended was rejected "
                    + $"(HTTP 400: {errorBody}); retrying without it"
            );
            continuation = baseBlocks;
            prefillIncluded = false;
        }
    }

    /// <summary>
    /// Consumes one hop's SSE events, forwarding them to the client while accumulating its
    /// content blocks (returned in <paramref name="outcome"/>).
    ///
    /// <para>The initial stream (<paramref name="splice"/> <c>null</c>) is forwarded on its
    /// original data payloads; a spliced hop (<paramref name="splice"/> set) has its
    /// message_start suppressed (the client already saw the initial one), its block indices
    /// shifted by <paramref name="indexBase"/>, and its terminal message_delta's usage rewritten
    /// to the <c>usage.iterations</c> chain shape.</para>
    ///
    /// <para>A refusal the policy chains (one carrying a <c>fallback_credit_token</c> with an
    /// entry remaining) ends the hop early: open blocks are closed, the terminal message_delta +
    /// message_stop are suppressed, and the token + usage are returned so the caller can issue
    /// the next hop. Any other refusal is reported with a warning and passes through to the
    /// client.</para>
    /// </summary>
    async IAsyncEnumerable<byte[]> ConsumeHop(
        HttpResponseMessage response,
        int indexBase,
        Splice? splice,
        HopOutcome outcome,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        BlockAccumulator accumulator = new(_snapshot.Diagnostics, indexBase);
        string? model = null;
        JsonObject? startUsage = null;

        using var stream = await response
            .Content.ReadAsStreamAsync(cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var sse in SseParser
                .Create(stream)
                .EnumerateAsync(cancellationToken)
                .ConfigureAwait(false)
        )
        {
            var @event = ParseObject(sse.Data);
            switch (@event == null ? null : GetString(@event["type"]))
            {
                case "message_start":
                {
                    var message = @event!["message"] as JsonObject;
                    model = GetString(message?["model"]);
                    startUsage = (message?["usage"] as JsonObject)?.DeepClone() as JsonObject;
                    if (splice != null)
                    {
                        continue;
                    }
                    break;
                }
                case "content_block_start":
                {
                    accumulator.Start(@event!);
                    if (splice != null)
                    {
                        yield return WireShape.Emit(@event!);
                        continue;
                    }
                    break;
                }
                case "content_block_delta":
                {
                    accumulator.Delta(@event!);
                    if (splice != null)
                    {
                        yield return WireShape.Emit(@event!);
                        continue;
                    }
                    break;
                }
                case "content_block_stop":
                {
                    accumulator.Stop(@event!);
                    if (splice != null)
                    {
                        yield return WireShape.Emit(@event!);
                        continue;
                    }
                    break;
                }
                case "message_delta":
                {
                    var delta = @event!["delta"] as JsonObject;
                    var refused = GetString(delta?["stop_reason"]) == "refusal";
                    if (refused)
                    {
                        outcome.Refused = true;
                        // `fallback_credit_token` is null when the refusal isn't eligible for a
                        // fallback credit; without one we don't retry. Any JSON can appear under
                        // `stop_details`, so its discriminator is checked.
                        var details = delta?["stop_details"] as JsonObject;
                        if (details != null && GetString(details["type"]) != "refusal")
                        {
                            details = null;
                        }
                        var token =
                            details == null ? null : GetString(details["fallback_credit_token"]);
                        var category =
                            details?["category"] is JsonValue cat
                            && cat.TryGetValue(out string? categoryStr)
                                ? categoryStr
                                : null;
                        var prefillClaim =
                            details?["fallback_has_prefill_claim"] is JsonValue claim
                            && claim.TryGetValue(out bool hasClaim)
                            && hasClaim;
                        if (
                            _policy.OnRefusal(token, category, prefillClaim)
                            == ChainPolicy.Directive.SendEntry
                        )
                        {
                            var usage = WireShape.Backfill(
                                @event["usage"] as JsonObject,
                                startUsage
                            );
                            foreach (var stop in accumulator.CloseOpenBlocks())
                            {
                                yield return stop;
                            }
                            outcome.HeldUsage = usage;
                            outcome.HeldEvent = (JsonObject)@event.DeepClone();
                            outcome.Model = model;
                            outcome.Blocks = accumulator.Blocks;
                            outcome.NextIndex = accumulator.NextIndex;
                            yield break;
                        }
                        // Chain exhaustion (a token with no entries left) is normal operation and
                        // fully visible in the terminal message_delta, so it isn't warned; a
                        // missing token can be steady-state (the account may not have the
                        // fallback-credit beta, unless a hop's token already proved it is), so
                        // it's warned only once.
                        if (token == null)
                        {
                            _snapshot.Diagnostics.WarnMissingTokenOnce(
                                "there is nothing to retry",
                                betaEnabled: _policy.TokenSeen
                            );
                        }
                    }
                    if (splice != null)
                    {
                        // Terminal hop: replace iterations with the accumulated chain, this hop
                        // last: `fallback_message` if it served, `message` if it refused (a
                        // terminal hop that refused didn't serve).
                        WireShape.RewriteTerminalUsage(
                            @event,
                            startUsage,
                            splice.Iterations,
                            splice.Model,
                            refused
                        );
                        yield return WireShape.Emit(@event);
                        continue;
                    }
                    break;
                }
            }

            // message_stop, ping, error, and unrecognised events (and every event of the
            // initial stream) pass through on their original data payloads.
            yield return WireShape.Passthrough(sse);
        }
        outcome.Model = model;
        outcome.Blocks = accumulator.Blocks;
        outcome.NextIndex = accumulator.NextIndex;
    }
}
