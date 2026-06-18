using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers;

// --- streaming fallback (credit-token continuation) -----------------------------------------
//
// The retry uses the appended-assistant form documented on `fallback_credit_token`: the refused
// request's body, extended by one trailing assistant turn carrying the refused model's partial
// output. The token authorizes that turn as a prefill continuation and applies the fallback
// credit. The refusal's `fallback_has_prefill_claim` says whether the partial output may be
// resent verbatim: when true the accumulated blocks are appended as-is; when false the refused
// hop's output is dropped and the token is redeemed against the same body.
//
// Known divergences from server-side `fallbacks`:
//
// * `message.model` keeps the refused model's id — message_start has already been sent when the
//   refusal arrives; the `fallback` block's `model` field carries the serving model.
// * Refusal text streamed before the refusal stays in the message and is resent as-is — the
//   appended turn must match the partial output verbatim.

/// <summary>
/// Splices the fallback chain's events onto a stream that ends in a retryable refusal.
///
/// <para>The spliced body is produced lazily as it's read: the refused stream's events pass
/// through until a chainable refusal, then each fallback hop's request is issued and its events
/// are spliced on. Disposing the response tears down whichever stream is being read; an in-flight
/// hop request can't be cancelled, but its response is disposed once it resolves.</para>
///
/// <para>Events flowing through the splice — and the partial output resent as the continuation
/// prefill — are handled as raw JSON rather than the typed models: the credit token is only
/// redeemable when the prefill matches the wire output verbatim, and only raw JSON accumulates
/// deltas onto block types the SDK doesn't model yet (exactly what a brand-new model may stream).
/// Events the splicer synthesizes itself are built from the typed models.</para>
/// </summary>
sealed class FallbackStreamSplicer
{
    readonly BetaRefusalFallbackHandler _handler;

    /// <summary>
    /// The request the initial stream was made with — the body its credit token is redeemable
    /// against — and the pin for the entry being tried.
    /// </summary>
    readonly BetaRefusalFallbackHandler.PreparedRequest _preparedRequest;

    /// <summary>The initial stream: the OK SSE response that may end in a refusal.</summary>
    readonly HttpResponseMessage _initialResponse;

    /// <summary>Index into the fallbacks of the first entry to try when the initial stream
    /// refuses.</summary>
    readonly int _firstHop;

    int _closed;

    /// <summary>
    /// The response currently being consumed, disposed when fully consumed or on close. Seeded
    /// with the initial response so a close before the first read still releases it.
    /// </summary>
    HttpResponseMessage? _currentResponse;

    public FallbackStreamSplicer(
        BetaRefusalFallbackHandler handler,
        BetaRefusalFallbackHandler.PreparedRequest preparedRequest,
        HttpResponseMessage initialResponse,
        int firstHop
    )
    {
        _handler = handler;
        _preparedRequest = preparedRequest;
        _initialResponse = initialResponse;
        _firstHop = firstHop;
        _currentResponse = initialResponse;
    }

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
        SplicedContent content = new(this);
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

    bool Closed => Volatile.Read(ref _closed) == 1;

    void Close()
    {
        Volatile.Write(ref _closed, 1);
        CloseCurrentResponse();
    }

    void CloseCurrentResponse() => Interlocked.Exchange(ref _currentResponse, null)?.Dispose();

    /// <summary>The spliced response body over the lazily produced SSE byte chunks.</summary>
    sealed class SplicedContent : HttpContent
    {
        readonly FallbackStreamSplicer _splicer;

        public SplicedContent(FallbackStreamSplicer splicer)
        {
            _splicer = splicer;
        }

        protected override Task<Stream> CreateContentReadStreamAsync() =>
            Task.FromResult<Stream>(new ChunkStream(_splicer));

        protected override async Task SerializeToStreamAsync(
            Stream stream,
            TransportContext? context
        )
        {
            using ChunkStream source = new(_splicer);
            await source.CopyToAsync(stream).ConfigureAwait(false);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _splicer.Close();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>A <see cref="Stream"/> over the lazily produced sequence of byte chunks.</summary>
    sealed class ChunkStream : Stream
    {
        readonly FallbackStreamSplicer _splicer;
        IAsyncEnumerator<byte[]>? _chunks;

        /// <summary>
        /// The in-flight iterator step, kept across reads: <c>MoveNextAsync</c> takes no token,
        /// so each read awaits the step under its own token, and a cancelled read leaves the
        /// step for the next read to resume — starting a second <c>MoveNextAsync</c> while one
        /// is pending is illegal.
        /// </summary>
        Task<bool>? _pendingMoveNext;
        byte[] _current = [];
        int _position;
        int _reading;

        public ChunkStream(FallbackStreamSplicer splicer)
        {
            _splicer = splicer;
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() { }

        public override int Read(byte[] buffer, int offset, int count) =>
            ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();

        public override Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken
        ) => ReadCoreAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

#if NET
        public override ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default
        ) => ReadCoreAsync(buffer, cancellationToken);
#endif

        async ValueTask<int> ReadCoreAsync(Memory<byte> buffer, CancellationToken cancellationToken)
        {
            if (buffer.Length == 0)
            {
                return 0;
            }
            Interlocked.Exchange(ref _reading, 1);
            try
            {
                while (_position >= _current.Length)
                {
                    if (_splicer.Closed)
                    {
                        return 0;
                    }
                    // Created on the first read so hop requests use a token that's alive while
                    // the body is being read — the one the initial request was sent with belongs
                    // to a scope the caller tore down when the response headers arrived.
                    _chunks ??= _splicer
                        .SplicedChunks(cancellationToken)
                        .GetAsyncEnumerator(CancellationToken.None);
                    var moveNext = _pendingMoveNext ??= _chunks.MoveNextAsync().AsTask();
                    var hasNext = await WaitAsync(moveNext, cancellationToken)
                        .ConfigureAwait(false);
                    _pendingMoveNext = null;
                    if (!hasNext)
                    {
                        return 0;
                    }
                    _current = _chunks.Current;
                    _position = 0;
                }
                var copied = Math.Min(buffer.Length, _current.Length - _position);
                _current.AsMemory(_position, copied).CopyTo(buffer);
                _position += copied;
                return copied;
            }
            finally
            {
                Interlocked.Exchange(ref _reading, 0);
            }
        }

        /// <summary>
        /// Awaits the task, abandoning the wait — not the task — when the token fires.
        /// </summary>
        static async Task<bool> WaitAsync(Task<bool> task, CancellationToken cancellationToken)
        {
#if NET
            return await task.WaitAsync(cancellationToken).ConfigureAwait(false);
#else
            if (task.IsCompleted || !cancellationToken.CanBeCanceled)
            {
                return await task.ConfigureAwait(false);
            }
            TaskCompletionSource<bool> cancelled = new(
                TaskCreationOptions.RunContinuationsAsynchronously
            );
            using (cancellationToken.Register(() => cancelled.TrySetCanceled(cancellationToken)))
            {
                var completed = await Task.WhenAny(task, cancelled.Task).ConfigureAwait(false);
                return await completed.ConfigureAwait(false);
            }
#endif
        }

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _splicer.Close();
                // A read may still be awaiting an in-flight hop request — or a cancelled read
                // may have abandoned a step that's still running; either way the iterator
                // observes the close and finishes on its own — disposing its enumerator here
                // would race the pending MoveNextAsync.
                if (
                    Interlocked.CompareExchange(ref _reading, 0, 0) == 0
                    && _pendingMoveNext == null
                )
                {
                    var chunks = _chunks;
                    _chunks = null;
                    if (chunks != null)
                    {
                        try
                        {
                            chunks.DisposeAsync().AsTask().GetAwaiter().GetResult();
                        }
                        catch (Exception)
                        {
                            // Tearing down; the consumer already has everything it's getting.
                        }
                    }
                }
                // A step abandoned for good is never awaited again; observe its fault so it
                // doesn't surface as an UnobservedTaskException.
                _pendingMoveNext?.ContinueWith(
                    static task => _ = task.Exception,
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnFaulted
                        | TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default
                );
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// The spliced SSE byte chunks: the initial stream passed through until a chainable refusal,
    /// then each fallback hop tried in order.
    /// </summary>
    async IAsyncEnumerable<byte[]> SplicedChunks(
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        var fallbacks = _handler.Fallbacks;

        // --- the initial stream: pass through until a chainable refusal ---
        // the caller guarantees firstHop < fallbacks.Count
        HopResult initial = new();
        await foreach (
            var chunk in ConsumeHop(
                    _initialResponse,
                    indexBase: 0,
                    hasNext: true,
                    splice: null,
                    initial,
                    cancellationToken
                )
                // ConfigureAwait(false) everywhere in the splice: ChunkStream supports
                // synchronous reads by blocking on this iterator, which deadlocks a
                // single-threaded SynchronizationContext if any await resumes on it.
                .ConfigureAwait(false)
        )
        {
            yield return chunk;
        }
        CloseCurrentResponse();
        if (initial.Refusal is not { } initialRefusal)
        {
            yield break; // non-refusal: pure pass-through
        }

        // --- fallback chain: try each entry in order ---
        // `baseBlocks` is the assistant-turn content the current token's request already carried
        // — the token is redeemable only with it resent verbatim. `partial` is the newest refused
        // hop's output, included only when its refusal granted a prefill claim (any other change
        // to the body is a 400).
        var nextIndex = initial.NextIndex; // monotonic block index across all spliced streams
        // The refusal whose token is currently in flight — its message_delta is surfaced verbatim
        // (with a recommended_model added) if every fallback request fails and we degrade.
        var refusal = initialRefusal;
        List<JsonObject> baseBlocks = [];
        var partial = initialRefusal.HasPrefillClaim ? ToPrefillBlocks(initial.Blocks) : [];
        var fromModel = initial.Model ?? "";

        // One `message` entry per refused hop, in order — the initial stream's first. Failed hops
        // are skipped (no usage came back); the serving hop is appended as `fallback_message`
        // when its message_delta arrives.
        List<JsonObject> iterations =
        [
            ToMessageIterationUsage(initial.Model ?? "", initialRefusal.Usage),
        ];

        for (var hop = _firstHop; hop < fallbacks.Count; hop++)
        {
            var model = fallbacks[hop].Model.Raw();
            var hasNext = hop + 1 < fallbacks.Count;

            // --- boundary: a `fallback` content block at the next monotonic index ---
            // Emitted before the request, so a hop that fails leaves its boundary in place and
            // the next attempt emits its own (still `from: fromModel` — the last model that
            // contributed output).
            var boundaryIndex = nextIndex++;
            yield return FallbackBlockStart(boundaryIndex, fromModel, model, refusal.Category);
            yield return ContentBlockStop(boundaryIndex);

            // --- build the request: appended-assistant continuation ---
            // The first attempt carries the newest partial appended (when its refusal granted a
            // prefill claim); a 400 on that form means the server rejected the prefill, so the
            // hop is retried once without it — the same-body form the token always supports.
            var continuation = baseBlocks.Concat(partial).ToList();
            HttpResponseMessage? hopResponse = null;
            var failed = false;
            for (var attempt = 0; attempt <= 1; attempt++)
            {
                using var hopRequest = _preparedRequest.HopRequest(
                    model,
                    refusal.Token,
                    continuation
                );
                HttpResponseMessage response;
                try
                {
                    response = await _handler
                        .SendToInnerAsync(hopRequest, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception e) when (e is not OperationCanceledException)
                {
                    Warn($"fallback request to {model} failed: {e}");
                    failed = true;
                    break;
                }
                // The spliced stream may have been closed while the hop was in flight; the
                // request can't be cancelled, so release its response now that it has resolved.
                if (Closed)
                {
                    response.Dispose();
                    yield break;
                }
                if (response.IsSuccessStatusCode)
                {
                    hopResponse = response;
                    break;
                }
                var errorBody = await ReadErrorBody(response, cancellationToken)
                    .ConfigureAwait(false);
                if (
                    attempt == 0
                    && response.StatusCode == HttpStatusCode.BadRequest
                    && partial.Count > 0
                )
                {
                    Warn(
                        "fallback request with the partial output appended was rejected "
                            + $"(HTTP 400: {errorBody}); retrying without it"
                    );
                    continuation = baseBlocks;
                    continue;
                }
                Warn(
                    $"fallback request to {model} failed: HTTP {(int)response.StatusCode}: {errorBody}"
                );
                failed = true;
                break;
            }

            if (failed)
            {
                // The token was never redeemed — retry it against the next entry.
                if (hasNext)
                {
                    continue;
                }
                // Surface the held refusal verbatim — its category/explanation and the still
                // unredeemed credit token — and point recommended_model at the hop we last tried.
                yield return HeldRefusalDelta(refusal, model, iterations);
                yield return MessageStop();
                yield break;
            }

            // --- splice: monotonic indices, suppressed message_start, usage.iterations ---
            Interlocked.Exchange(ref _currentResponse, hopResponse);
            // A close between the in-flight check above and this registration finds
            // _currentResponse empty; re-check so the hop response is still released.
            if (Closed)
            {
                CloseCurrentResponse();
                yield break;
            }
            HopResult outcome = new();
            await foreach (
                var chunk in ConsumeHop(
                        hopResponse!,
                        nextIndex,
                        hasNext,
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
            if (outcome.Refusal is not { } hopRefusal)
            {
                // Pin only a hop that actually served: a refused last entry (or a token-less
                // refusal) passed through to the client, and follow-up requests sharing the
                // state shouldn't start at a model that just refused.
                if (!outcome.Refused)
                {
                    _preparedRequest.Pin(hop);
                }
                yield break;
            }

            // This hop refused too, with a fresh token: its emitted partial stays in the
            // client's message, becomes the next partial segment, and the chain continues.
            refusal = hopRefusal;
            baseBlocks = continuation;
            partial = hopRefusal.HasPrefillClaim ? ToPrefillBlocks(outcome.Blocks) : [];
            iterations.Add(ToMessageIterationUsage(model, hopRefusal.Usage));
            fromModel = model;
            nextIndex = outcome.NextIndex;
        }
    }

    /// <summary>
    /// Consumes one hop's SSE events, forwarding them to the client while accumulating its
    /// content blocks (returned in the result).
    ///
    /// <para>The initial stream (<paramref name="splice"/> <c>null</c>) is forwarded on its
    /// original data payloads; a spliced hop (<paramref name="splice"/> set) has its
    /// message_start suppressed (the client already saw the initial one), its block indices
    /// shifted by <paramref name="indexBase"/>, and its terminal message_delta's usage rewritten
    /// to the <c>usage.iterations</c> chain shape.</para>
    ///
    /// <para>A refusal that can be chained — it carries a <c>fallback_credit_token</c> and a
    /// fallback entry remains — ends the hop early: open blocks are closed, the terminal
    /// message_delta + message_stop are suppressed, and the token + usage are returned so the
    /// caller can issue the next hop. Any other refusal is reported with a warning and passes
    /// through to the client.</para>
    /// </summary>
    async IAsyncEnumerable<byte[]> ConsumeHop(
        HttpResponseMessage response,
        // Shifts wire block indices by this much, keeping them monotonic across hops.
        int indexBase,
        // Whether a fallback entry exists to chain to if this hop refuses.
        bool hasNext,
        // Splice context for fallback hops; null for the initial stream.
        Splice? splice,
        HopResult result,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        BlockTracker tracker = new(this, indexBase);
        string? model = null;
        JsonObject? startUsage = null;

        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);
        await foreach (
            var sse in SseParser
                .Create(stream)
                .EnumerateAsync(cancellationToken)
                .ConfigureAwait(false)
        )
        {
            var @event = ParseJsonObject(sse.Data);
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
                    tracker.Start(@event!);
                    if (splice != null)
                    {
                        yield return Emit(@event!);
                        continue;
                    }
                    break;
                }
                case "content_block_delta":
                {
                    tracker.Delta(@event!);
                    if (splice != null)
                    {
                        yield return Emit(@event!);
                        continue;
                    }
                    break;
                }
                case "content_block_stop":
                {
                    tracker.Stop(@event!);
                    if (splice != null)
                    {
                        yield return Emit(@event!);
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
                        result.Refused = true;
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
                        if (token != null && hasNext)
                        {
                            var usage = Backfill(@event["usage"] as JsonObject, startUsage);
                            foreach (var stop in tracker.CloseOpenBlocks())
                            {
                                yield return stop;
                            }
                            // suppress this hop's message_delta + message_stop
                            result.Refusal = new Refusal(
                                token,
                                details!["category"] is JsonValue cat
                                && cat.TryGetValue(out string? categoryStr)
                                    ? categoryStr
                                    : null,
                                details!["fallback_has_prefill_claim"] is JsonValue claim
                                    && claim.TryGetValue(out bool hasClaim)
                                    && hasClaim,
                                usage,
                                (JsonObject)@event.DeepClone()
                            );
                            result.Model = model;
                            result.Blocks = tracker.Blocks;
                            result.NextIndex = tracker.NextIndex;
                            yield break;
                        }
                        // Chain exhaustion (a token with no entries left) is normal operation and
                        // fully visible in the terminal message_delta, so it isn't warned; a
                        // missing token can be steady-state (the account may not have the
                        // fallback-credit beta — unless a hop's token already proved it is), so
                        // it's warned only once.
                        if (token == null)
                        {
                            _handler.WarnMissingTokenOnce(
                                "there is nothing to retry",
                                betaEnabled: splice != null
                            );
                        }
                    }
                    if (splice != null)
                    {
                        // Terminal hop. Replace iterations, don't append: this hop's own
                        // message_delta self-reports a single `{type: "message"}` iteration (a
                        // fresh non-fallback request counts itself as one message hop).
                        // Server-side `fallbacks` relabels the whole chain instead — refused hops
                        // as `message`, the serving hop as `fallback_message` — so keeping the
                        // self-report would add a spurious entry. A terminal hop that refused
                        // didn't serve, so it keeps the refused-hop label.
                        var usage = Backfill(@event["usage"] as JsonObject, startUsage);
                        JsonArray chain = [];
                        foreach (var iteration in splice.Iterations)
                        {
                            chain.Add(iteration.DeepClone());
                        }
                        chain.Add(
                            refused
                                ? ToMessageIterationUsage(splice.Model, usage)
                                : ToFallbackIterationUsage(splice.Model, usage)
                        );
                        usage["iterations"] = chain;
                        @event["usage"] = usage;
                        yield return Emit(@event);
                        continue;
                    }
                    break;
                }
            }

            // message_stop, ping, error, unrecognised — and for the initial stream every event —
            // pass through on their original data payloads.
            yield return Passthrough(sse);
        }
        result.Model = model;
        result.Blocks = tracker.Blocks;
        result.NextIndex = tracker.NextIndex;
    }

    /// <summary>Reads a failed hop response's error body, disposing the response.</summary>
    internal static async Task<string> ReadErrorBody(
        HttpResponseMessage response,
        CancellationToken cancellationToken
    )
    {
        using (response)
        {
            try
            {
                return await response
                    .Content.ReadAsStringAsync(
#if NET
                        cancellationToken
#endif
                    )
                    .ConfigureAwait(false);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                return "";
            }
        }
    }

    // --- event synthesis & serialization ---

    static byte[] FallbackBlockStart(
        int index,
        string fromModel,
        string toModel,
        string? category
    ) =>
        Emit(
            "content_block_start",
            JsonSerializer.Serialize(
                new BetaRawContentBlockStartEvent
                {
                    Index = index,
                    ContentBlock = new BetaFallbackBlock
                    {
                        From = new BetaFallbackInfo { Model = fromModel },
                        To = new BetaFallbackInfo { Model = toModel },
                        Trigger = new BetaFallbackRefusalTrigger
                        {
                            Category = category is { } c
                                ? (ApiEnum<string, BetaFallbackRefusalTriggerCategory>)c
                                : null,
                        },
                    },
                },
                ModelBase.SerializerOptions
            )
        );

    static byte[] ContentBlockStop(int index) =>
        Emit(
            "content_block_stop",
            JsonSerializer.Serialize(
                new BetaRawContentBlockStopEvent(index),
                ModelBase.SerializerOptions
            )
        );

    /// <summary>
    /// Surfaces a held refusal's message_delta verbatim — fields the splicer doesn't use
    /// (<c>context_management</c>, unknown fields, ...) ride along on the captured wire event —
    /// with <c>recommended_model</c> pointed at the hop last tried and its usage backfilled from
    /// its message_start.
    /// </summary>
    static byte[] HeldRefusalDelta(
        Refusal refusal,
        string recommendedModel,
        IReadOnlyList<JsonObject> iterations
    )
    {
        var @event = (JsonObject)refusal.Event.DeepClone();
        if (@event["delta"] is JsonObject delta && delta["stop_details"] is JsonObject details)
        {
            details["recommended_model"] = recommendedModel;
        }
        var usage = (JsonObject)refusal.Usage.DeepClone();
        // The held refusal's usage self-reports only its own hop; the accumulated chain (the
        // initial stream plus every chained refusal — failed hops contributed no usage) replaces
        // it so even a degraded close reports every hop.
        JsonArray chain = [];
        foreach (var iteration in iterations)
        {
            chain.Add(iteration.DeepClone());
        }
        usage["iterations"] = chain;
        @event["usage"] = usage;
        return Emit(@event);
    }

    static byte[] MessageStop() =>
        Emit(
            "message_stop",
            JsonSerializer.Serialize(new BetaRawMessageStopEvent(), ModelBase.SerializerOptions)
        );

    /// <summary>Serializes an event payload to its SSE wire form.</summary>
    static byte[] Emit(string eventName, string dataJson) =>
        Encoding.UTF8.GetBytes($"event: {eventName}\ndata: {dataJson}\n\n");

    /// <summary>
    /// Serializes a wire event payload to its SSE wire form (its <c>type</c> is the event name).
    /// </summary>
    static byte[] Emit(JsonObject @event) =>
        Emit(GetString(@event["type"]) ?? "", @event.ToJsonString());

    /// <summary>
    /// Forwards a decoded event on its original data payload, preserving the SSE fields the
    /// parser surfaces (<c>id:</c>, <c>retry:</c>).
    /// </summary>
    static byte[] Passthrough(SseItem<string> sse)
    {
        StringBuilder builder = new();
        if (sse.EventId is { } id)
        {
            builder.Append("id: ").Append(id).Append('\n');
        }
        if (sse.ReconnectionInterval is { } retry)
        {
            builder.Append("retry: ").Append((long)retry.TotalMilliseconds).Append('\n');
        }
        builder.Append("event: ").Append(sse.EventType).Append('\n');
        foreach (var line in sse.Data.Split('\n'))
        {
            builder.Append("data: ").Append(line).Append('\n');
        }
        builder.Append('\n');
        return Encoding.UTF8.GetBytes(builder.ToString());
    }

    static JsonObject? ParseJsonObject(string data)
    {
        try
        {
            return JsonNode.Parse(data) as JsonObject;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    static void Warn(string message) => BetaRefusalFallbackHandler.Warn(message);

    // --- usage bookkeeping ---

    /// <summary>
    /// The numeric fields <see cref="BetaMessageIterationUsage"/> requires; coerced to 0 when the
    /// wire usage lacks them so the typed accessors stay safe.
    /// </summary>
    static readonly string[] IterationTokenFields =
    [
        "input_tokens",
        "output_tokens",
        "cache_read_input_tokens",
        "cache_creation_input_tokens",
    ];

    /// <summary>
    /// Builds a <c>usage.iterations</c> entry for a refused hop from its (raw, backfilled) usage.
    /// </summary>
    static JsonObject ToMessageIterationUsage(string model, JsonObject? usage)
    {
        // Copied from the wire usage rather than rebuilt from the typed model so fields the SDK
        // doesn't model yet (output_tokens_details, service_tier, ...) survive the splice.
        var entry = usage?.DeepClone() as JsonObject ?? [];
        entry.Remove("iterations"); // a hop's self-reported chain doesn't nest
        entry["type"] = "message";
        entry["model"] = model;
        foreach (var field in IterationTokenFields)
        {
            if (GetLong(entry[field]) == null)
            {
                entry[field] = 0;
            }
        }
        return entry;
    }

    /// <summary>Builds the serving hop's <c>usage.iterations</c> entry from its (raw, backfilled)
    /// usage.</summary>
    static JsonObject ToFallbackIterationUsage(string model, JsonObject? usage)
    {
        // `BetaFallbackMessageIterationUsage` differs from `BetaMessageIterationUsage` only in
        // its type discriminator; restamping one shape keeps a new usage field from being mapped
        // in one entry kind but not the other.
        var entry = ToMessageIterationUsage(model, usage);
        entry["type"] = "fallback_message";
        return entry;
    }

    /// <summary>
    /// Fills null/missing fields on <paramref name="primary"/> (a message_delta usage) from
    /// <paramref name="fallback"/> (the message_start usage).
    /// </summary>
    static JsonObject Backfill(JsonObject? primary, JsonObject? fallback)
    {
        var merged = fallback?.DeepClone() as JsonObject ?? [];
        if (primary != null)
        {
            foreach (var field in primary)
            {
                merged[field.Key] = field.Value?.DeepClone();
            }
        }
        foreach (var key in merged.Select(field => field.Key).ToList())
        {
            var fallbackValue = fallback?[key];
            if (merged[key] == null && fallbackValue != null)
            {
                merged[key] = fallbackValue.DeepClone();
            }
        }
        return merged;
    }

    // --- block accumulation & prefill conversion ---

    static string? GetString(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out string? text) ? text : null;

    static long? GetLong(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out long number) ? number : null;

    static int GetInt(JsonNode? node) =>
        node is JsonValue value && value.TryGetValue(out int number) ? number : 0;

    /// <summary>Splice context for fallback hops.</summary>
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

    /// <summary>The outcome of consuming one hop's stream.</summary>
    sealed class HopResult
    {
        /// <summary>Set when the hop refused with a credit token and an entry remained to chain
        /// to.</summary>
        public Refusal? Refusal { get; set; }

        /// <summary>Whether the hop's terminal message_delta was a refusal, chainable or
        /// not.</summary>
        public bool Refused { get; set; }

        /// <summary>The hop's serving model, from its message_start.</summary>
        public string? Model { get; set; }

        /// <summary>The hop's accumulated content blocks, in start order — the next partial
        /// segment.</summary>
        public List<AccumulatedBlock> Blocks { get; set; } = [];

        /// <summary>One past the highest (shifted) block index emitted — where the next boundary
        /// goes.</summary>
        public int NextIndex { get; set; }
    }

    sealed class Refusal
    {
        public Refusal(
            string token,
            string? category,
            bool hasPrefillClaim,
            JsonObject usage,
            JsonObject @event
        )
        {
            Token = token;
            Category = category;
            HasPrefillClaim = hasPrefillClaim;
            Usage = usage;
            Event = @event;
        }

        public string Token { get; }

        /// <summary>The policy category that triggered the refusal; <c>null</c> when none was
        /// surfaced.</summary>
        public string? Category { get; }

        public bool HasPrefillClaim { get; }
        public JsonObject Usage { get; }

        /// <summary>The refusal's message_delta wire event, surfaced if the whole chain
        /// degrades.</summary>
        public JsonObject Event { get; }
    }

    /// <summary>A response content block being accumulated from its streaming deltas.</summary>
    sealed class AccumulatedBlock
    {
        public AccumulatedBlock(int index, JsonObject block)
        {
            Index = index;
            Block = block;
        }

        public int Index { get; }
        public JsonObject Block { get; }

        /// <summary>The block's <c>input_json_delta</c> JSON accumulated so far, if any
        /// arrived.</summary>
        public StringBuilder? PartialJson { get; set; }
    }

    /// <summary>
    /// Block bookkeeping for one stream of the splice: accumulates each content block from its
    /// deltas (for the continuation prefill), shifts wire indices by the index base so they stay
    /// monotonic across hops, and tracks which blocks are still open so a refusal that cuts
    /// mid-block can close them.
    /// </summary>
    sealed class BlockTracker
    {
        readonly FallbackStreamSplicer _splicer;
        readonly int _indexBase;

        /// <summary>Shifted indices of blocks started but not yet stopped.</summary>
        readonly List<int> _open = [];

        public BlockTracker(FallbackStreamSplicer splicer, int indexBase)
        {
            _splicer = splicer;
            _indexBase = indexBase;
            NextIndex = indexBase;
        }

        /// <summary>The stream's accumulated blocks keyed by their original wire index, in start
        /// order.</summary>
        public List<AccumulatedBlock> Blocks { get; } = [];

        /// <summary>One past the highest shifted block index seen.</summary>
        public int NextIndex { get; private set; }

        /// <summary>Tracks a content_block_start, shifting the event's <c>index</c>.</summary>
        public void Start(JsonObject @event)
        {
            var index = GetInt(@event["index"]);
            var block = (@event["content_block"] as JsonObject)?.DeepClone() as JsonObject ?? [];
            Blocks.Add(new AccumulatedBlock(index, block));
            var shifted = index + _indexBase;
            @event["index"] = shifted;
            _open.Add(shifted);
            NextIndex = Math.Max(NextIndex, shifted + 1);
        }

        /// <summary>
        /// Applies a content_block_delta to its accumulating block, shifting the event's
        /// <c>index</c>.
        /// </summary>
        public void Delta(JsonObject @event)
        {
            var index = GetInt(@event["index"]);
            var accumulated = Blocks.Find(block => block.Index == index);
            if (accumulated != null)
            {
                ApplyDelta(accumulated, @event["delta"]);
            }
            @event["index"] = index + _indexBase;
        }

        /// <summary>Tracks a content_block_stop, shifting the event's <c>index</c>.</summary>
        public void Stop(JsonObject @event)
        {
            var shifted = GetInt(@event["index"]) + _indexBase;
            @event["index"] = shifted;
            _open.Remove(shifted);
            NextIndex = Math.Max(NextIndex, shifted + 1);
        }

        /// <summary>content_block_stop events for any blocks still open.</summary>
        public List<byte[]> CloseOpenBlocks()
        {
            var stops = _open.Select(ContentBlockStop).ToList();
            _open.Clear();
            return stops;
        }

        void ApplyDelta(AccumulatedBlock accumulated, JsonNode? delta)
        {
            var block = accumulated.Block;
            switch (delta == null ? "" : GetString(delta["type"]) ?? "")
            {
                case "text_delta":
                    block["text"] =
                        (GetString(block["text"]) ?? "") + (GetString(delta!["text"]) ?? "");
                    break;
                case "input_json_delta":
                    var partialJson = accumulated.PartialJson ??= new StringBuilder();
                    partialJson.Append(GetString(delta!["partial_json"]) ?? "");
                    break;
                case "citations_delta":
                    if (block["citations"] is not JsonArray citations)
                    {
                        citations = [];
                        block["citations"] = citations;
                    }
                    citations.Add(delta!["citation"]?.DeepClone());
                    break;
                case "thinking_delta":
                    block["thinking"] =
                        (GetString(block["thinking"]) ?? "")
                        + (GetString(delta!["thinking"]) ?? "");
                    break;
                case "signature_delta":
                    block["signature"] =
                        (GetString(block["signature"]) ?? "")
                        + (GetString(delta!["signature"]) ?? "");
                    break;
                case "compaction_delta":
                    // The start block leaves both fields null until the deltas arrive.
                    if (GetString(delta!["content"]) is { } content)
                    {
                        block["content"] = (GetString(block["content"]) ?? "") + content;
                    }
                    if (GetString(delta["encrypted_content"]) is { } encryptedContent)
                    {
                        block["encrypted_content"] =
                            (GetString(block["encrypted_content"]) ?? "") + encryptedContent;
                    }
                    break;
                default:
                    // A delta type this accumulator doesn't know (a brand-new model's, say)
                    // can't be folded into the block, so a prefill including it may not match
                    // the wire output; the server rejects it and the hop retries without the
                    // prefill.
                    _splicer._handler.WarnDeltaTypeOnce(
                        delta == null ? "" : GetString(delta["type"]) ?? ""
                    );
                    break;
            }
        }
    }

    /// <summary>
    /// Converts a hop's accumulated response blocks to the appended assistant turn, as-is: a
    /// <c>fallback_has_prefill_claim</c> refusal guarantees the partial output is resendable
    /// verbatim, so no client-side filtering is applied. The only rewrite is reassembling tool
    /// inputs from their accumulated <c>input_json_delta</c> JSON (content_block_start carries
    /// <c>input: {}</c>).
    /// </summary>
    static List<JsonObject> ToPrefillBlocks(List<AccumulatedBlock> blocks) =>
        [
            .. blocks.Select(accumulated =>
            {
                if (accumulated.PartialJson is not { } partialJson)
                {
                    return accumulated.Block;
                }
                JsonNode? input;
                try
                {
                    input = JsonNode.Parse(partialJson.ToString());
                }
                catch (JsonException)
                {
                    input = null;
                }
                if (input != null)
                {
                    accumulated.Block["input"] = input;
                }
                return accumulated.Block;
            }),
        ];
}
