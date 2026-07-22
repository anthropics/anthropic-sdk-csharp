using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using static Anthropic.Core.JsonNodes;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// Renders the server-side <c>fallbacks</c> wire shape (transition blocks,
/// <c>usage.iterations</c>, synthesized stream events) for both protocols from one place, so
/// the two output paths cannot drift apart.
///
/// <para>Fidelity rules: anything derived from a wire event is deep-cloned and surgically
/// mutated, never rebuilt through typed models (unknown fields must survive); anything
/// synthesized from scratch is built from the typed models.</para>
/// </summary>
internal static class WireShape
{
    /// <summary>One model boundary: the models on each side and the trigger category.</summary>
    public readonly record struct ModelTransition(string From, string To, string? Category);

    /// <summary>The synthetic <c>fallback</c> block marking one model transition, the same shape
    /// on the buffered and spliced paths.</summary>
    public static BetaFallbackBlock TransitionBlock(
        string fromModel,
        string toModel,
        string? category
    ) =>
        new()
        {
            From = new BetaFallbackInfo { Model = fromModel },
            To = new BetaFallbackInfo { Model = toModel },
            Trigger = new BetaFallbackRefusalTrigger
            {
                Category = category is { } c
                    ? (ApiEnum<string, BetaFallbackRefusalTriggerCategory>)c
                    : null,
            },
        };

    /// <summary>
    /// Rewrites a buffered serving response to carry one <c>fallback</c> block per model transition prepended
    /// to its content. A body that doesn't parse to a message with a content array is left
    /// untouched.
    /// </summary>
    public static async Task PrependTransitionBlocks(
        HttpResponseMessage response,
        IReadOnlyList<ModelTransition> transitions,
        CancellationToken cancellationToken
    )
    {
        // The refusal classification already buffered the content, so re-reading is cheap.
        var body = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);
        var message = ParseObject(body);
        if (message?["content"] is not JsonArray content)
        {
            return;
        }

        // Walk the transitions in reverse so the earliest one ends up first in the content array.
        for (var i = transitions.Count - 1; i >= 0; i--)
        {
            content.Insert(
                0,
                JsonSerializer.SerializeToNode(
                    TransitionBlock(
                        transitions[i].From,
                        transitions[i].To,
                        transitions[i].Category
                    ),
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

    // --- spliced-stream event synthesis ---

    public static byte[] FallbackBlockStart(int index, ModelTransition transition) =>
        Emit(
            "content_block_start",
            JsonSerializer.Serialize(
                new BetaRawContentBlockStartEvent
                {
                    Index = index,
                    ContentBlock = TransitionBlock(
                        transition.From,
                        transition.To,
                        transition.Category
                    ),
                },
                ModelBase.SerializerOptions
            )
        );

    public static byte[] ContentBlockStop(int index) =>
        Emit(
            "content_block_stop",
            JsonSerializer.Serialize(
                new BetaRawContentBlockStopEvent(index),
                ModelBase.SerializerOptions
            )
        );

    public static byte[] MessageStop() =>
        Emit(
            "message_stop",
            JsonSerializer.Serialize(new BetaRawMessageStopEvent(), ModelBase.SerializerOptions)
        );

    /// <summary>
    /// Emits a held refusal's message_delta verbatim, so fields the splice doesn't use
    /// (<c>context_management</c>, unknown fields, ...) ride along on the captured wire event.
    /// <c>recommended_model</c> is pointed at the entry last tried and the usage is replaced by
    /// the accumulated iterations chain (failed hops contributed no usage), so even a degraded
    /// close reports every hop.
    /// </summary>
    public static byte[] HeldRefusalDelta(
        JsonObject refusalEvent,
        JsonObject refusalUsage,
        string recommendedModel,
        IReadOnlyList<JsonObject> iterations
    )
    {
        var @event = (JsonObject)refusalEvent.DeepClone();
        if (@event["delta"] is JsonObject delta && delta["stop_details"] is JsonObject details)
        {
            details["recommended_model"] = recommendedModel;
        }
        var usage = (JsonObject)refusalUsage.DeepClone();
        usage["iterations"] = CloneAll(iterations);
        @event["usage"] = usage;
        return Emit(@event);
    }

    /// <summary>
    /// Replaces a terminal message_delta's usage with the backfilled chain shape: every prior
    /// hop's entry plus this hop's own, <c>fallback_message</c> when it served or <c>message</c>
    /// when it refused (a refused terminal hop didn't serve). The hop's self-reported
    /// single-entry chain (a fresh request counts itself as one <c>message</c> hop) is replaced,
    /// not appended to.
    /// </summary>
    public static void RewriteTerminalUsage(
        JsonObject @event,
        JsonObject? startUsage,
        IReadOnlyList<JsonObject> priorIterations,
        string model,
        bool refused
    )
    {
        var usage = Backfill(@event["usage"] as JsonObject, startUsage);
        var chain = CloneAll(priorIterations);
        chain.Add(refused ? MessageIteration(model, usage) : FallbackIteration(model, usage));
        usage["iterations"] = chain;
        @event["usage"] = usage;
    }

    static JsonArray CloneAll(IReadOnlyList<JsonObject> iterations)
    {
        JsonArray chain = [];
        foreach (var iteration in iterations)
        {
            chain.Add(iteration.DeepClone());
        }
        return chain;
    }

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
    public static JsonObject MessageIteration(string model, JsonObject? usage)
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
    public static JsonObject FallbackIteration(string model, JsonObject? usage)
    {
        // `BetaFallbackMessageIterationUsage` differs from `BetaMessageIterationUsage` only in
        // its type discriminator; restamping one shape keeps a new usage field from being mapped
        // in one entry kind but not the other.
        var entry = MessageIteration(model, usage);
        entry["type"] = "fallback_message";
        return entry;
    }

    /// <summary>
    /// Fills null/missing fields on <paramref name="primary"/> (a message_delta usage) from
    /// <paramref name="fallback"/> (the message_start usage): a delta's explicit null never
    /// erases a start value, but a null field the start doesn't carry either is kept.
    /// </summary>
    public static JsonObject Backfill(JsonObject? primary, JsonObject? fallback)
    {
        var merged = fallback?.DeepClone() as JsonObject ?? [];
        if (primary != null)
        {
            foreach (var field in primary)
            {
                if (field.Value != null || !merged.ContainsKey(field.Key))
                {
                    merged[field.Key] = field.Value?.DeepClone();
                }
            }
        }
        return merged;
    }

    // --- SSE serialization ---

    /// <summary>Serializes an event payload to its SSE wire form.</summary>
    public static byte[] Emit(string eventName, string dataJson) =>
        Encoding.UTF8.GetBytes($"event: {eventName}\ndata: {dataJson}\n\n");

    /// <summary>
    /// Serializes a wire event payload to its SSE wire form (its <c>type</c> is the event name).
    /// </summary>
    public static byte[] Emit(JsonObject @event) =>
        Emit(GetString(@event["type"]) ?? "", @event.ToJsonString());

    /// <summary>
    /// Forwards a decoded event on its original data payload, preserving the SSE fields the
    /// parser exposes (<c>id:</c>, <c>retry:</c>).
    /// </summary>
    public static byte[] Passthrough(SseItem<string> sse)
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
}
