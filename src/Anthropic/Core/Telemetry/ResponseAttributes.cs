using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;
using BetaMessages = Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The attributes of a Messages call span that come with the response. The methods set them on
/// the span they started, from the response they deserialized, before reading the response ends
/// the span.
/// </summary>
static class ResponseAttributes
{
    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of a Messages create call that is not
    /// streamed, what comes with <paramref name="message"/>, the Message that the call returned:
    /// the response attributes and, in content mode, the response's content, beside
    /// <paramref name="requestContent"/>, the request's content that the span already has, so
    /// that the size limit counts both.
    ///
    /// <para>Never throws into the API call, and does nothing to a span that is not
    /// recording.</para>
    /// </summary>
    internal static void SetMessagesCreateResponseAttributes(
        Activity? span,
        RequestContent? requestContent,
        Messages::Message message
    ) =>
        Record(
            span,
            recordingSpan =>
            {
                var usage = message.Usage;
                SetMessagesCreateResponseAttributes(
                    recordingSpan,
                    id: message.ID,
                    model: message.Model.Raw(),
                    inputTokens: usage.InputTokens,
                    cacheReadInputTokens: usage.CacheReadInputTokens,
                    cacheCreationInputTokens: usage.CacheCreationInputTokens,
                    ephemeral5mInputTokens: usage.CacheCreation?.Ephemeral5mInputTokens,
                    ephemeral1hInputTokens: usage.CacheCreation?.Ephemeral1hInputTokens,
                    serviceTier: usage.ServiceTier?.Raw(),
                    outputTokens: usage.OutputTokens,
                    thinkingTokens: usage.OutputTokensDetails?.ThinkingTokens,
                    compaction: null,
                    stopReason: message.StopReason?.Raw(),
                    reachedMessageDelta: true
                );
                if (requestContent != null)
                {
                    Content.SetResponseContent(
                        recordingSpan,
                        requestContent,
                        Content.Parts(message.RawData.Property("content"))
                    );
                }
            }
        );

    /// <inheritdoc cref="SetMessagesCreateResponseAttributes(Activity?, RequestContent?, Messages::Message)"/>
    internal static void SetMessagesCreateResponseAttributes(
        Activity? span,
        RequestContent? requestContent,
        BetaMessages::BetaMessage message
    ) =>
        Record(
            span,
            recordingSpan =>
            {
                var usage = message.Usage;
                SetMessagesCreateResponseAttributes(
                    recordingSpan,
                    id: message.ID,
                    model: message.Model.Raw(),
                    inputTokens: usage.InputTokens,
                    cacheReadInputTokens: usage.CacheReadInputTokens,
                    cacheCreationInputTokens: usage.CacheCreationInputTokens,
                    ephemeral5mInputTokens: usage.CacheCreation?.Ephemeral5mInputTokens,
                    ephemeral1hInputTokens: usage.CacheCreation?.Ephemeral1hInputTokens,
                    serviceTier: usage.ServiceTier?.Raw(),
                    outputTokens: usage.OutputTokens,
                    thinkingTokens: usage.OutputTokensDetails?.ThinkingTokens,
                    compaction: CompactionTokens(usage.Iterations),
                    stopReason: message.StopReason?.Raw(),
                    reachedMessageDelta: true
                );
                if (requestContent != null)
                {
                    Content.SetResponseContent(
                        recordingSpan,
                        requestContent,
                        Content.Parts(message.RawData.Property("content"))
                    );
                }
            }
        );

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of a streamed Messages create call, the
    /// response attributes of <paramref name="message"/>, the Message as far as its events
    /// delivered it. Does nothing before <c>message_start</c> arrived.
    /// </summary>
    internal static void SetMessagesCreateResponseAttributes<T>(
        Activity span,
        StreamedMessage<T> message
    )
    {
        if (message.Start is not { } start)
        {
            return;
        }
        var usage = message.Usage;
        SetMessagesCreateResponseAttributes(
            span,
            id: start.Text("id"),
            model: message.FallbackModel ?? start.Text("model"),
            inputTokens: usage.Long("input_tokens"),
            cacheReadInputTokens: usage.Long("cache_read_input_tokens"),
            cacheCreationInputTokens: usage.Long("cache_creation_input_tokens"),
            ephemeral5mInputTokens: usage
                .Property("cache_creation")
                ?.Long("ephemeral_5m_input_tokens"),
            ephemeral1hInputTokens: usage
                .Property("cache_creation")
                ?.Long("ephemeral_1h_input_tokens"),
            serviceTier: usage.Text("service_tier"),
            outputTokens: usage.Long("output_tokens"),
            thinkingTokens: usage.Property("output_tokens_details")?.Long("thinking_tokens"),
            compaction: CompactionTokens(usage.Property("iterations")),
            stopReason: message.StopReason,
            reachedMessageDelta: message.ReachedMessageDelta
        );
    }

    /// <summary>
    /// Sets the response attributes of a Messages create call, stable or beta, streamed or not,
    /// from the values of its Message. A stream that ended before <c>message_stop</c> has them as
    /// far as its events brought them. Before its first <c>message_delta</c> nothing says how the
    /// output went, so its output tokens, the tokens of its compactions and its stop reason are
    /// left out.
    /// </summary>
    static void SetMessagesCreateResponseAttributes(
        Activity span,
        string? id,
        string? model,
        long? inputTokens,
        long? cacheReadInputTokens,
        long? cacheCreationInputTokens,
        long? ephemeral5mInputTokens,
        long? ephemeral1hInputTokens,
        string? serviceTier,
        long? outputTokens,
        long? thinkingTokens,
        (long Input, long Output)? compaction,
        string? stopReason,
        bool reachedMessageDelta
    )
    {
        SetTag(span, AttributeGenAiResponseId, id);
        SetTag(span, AttributeGenAiResponseModel, model);
        if (inputTokens is { } uncached)
        {
            // The conventions define the input tokens as the sum of these three.
            span.SetTag(
                AttributeGenAiUsageInputTokens,
                uncached + (cacheReadInputTokens ?? 0) + (cacheCreationInputTokens ?? 0)
            );
        }
        SetTag(span, AttributeGenAiUsageCacheWriteInputTokens, cacheCreationInputTokens);
        SetTag(span, AttributeGenAiUsageCacheReadInputTokens, cacheReadInputTokens);
        SetTag(
            span,
            AttributeAnthropicUsageCacheCreationEphemeral5mInputTokens,
            ephemeral5mInputTokens
        );
        SetTag(
            span,
            AttributeAnthropicUsageCacheCreationEphemeral1hInputTokens,
            ephemeral1hInputTokens
        );
        SetTag(span, AttributeAnthropicResponseServiceTier, serviceTier);
        if (reachedMessageDelta)
        {
            SetTag(span, AttributeGenAiUsageOutputTokens, outputTokens);
            SetTag(span, AttributeGenAiUsageReasoningOutputTokens, thinkingTokens);
            SetTag(span, AttributeAnthropicUsageCompactionInputTokens, compaction?.Input);
            SetTag(span, AttributeAnthropicUsageCompactionOutputTokens, compaction?.Output);
            SetTag(span, AttributeAnthropicMessageStopReason, stopReason);
        }
    }

    /// <summary>
    /// The input and output tokens of the compactions among <paramref name="iterations"/>, those of
    /// a response's usage, or null when none is a compaction. The response's own usage does not
    /// include them. The input tokens of each are the sum that
    /// <see cref="AttributeGenAiUsageInputTokens"/> is of the response's.
    /// </summary>
    static (long Input, long Output)? CompactionTokens(
        IReadOnlyList<BetaMessages::BetaUsageIteration>? iterations
    )
    {
        (long Input, long Output)? tokens = null;
        foreach (var iteration in iterations ?? [])
        {
            if (!iteration.TryPickBetaCompactionIterationUsage(out var compaction))
            {
                continue;
            }
            tokens = (
                (tokens?.Input ?? 0)
                    + compaction.InputTokens
                    + compaction.CacheReadInputTokens
                    + compaction.CacheCreationInputTokens,
                (tokens?.Output ?? 0) + compaction.OutputTokens
            );
        }
        return tokens;
    }

    /// <inheritdoc cref="CompactionTokens(IReadOnlyList{BetaMessages::BetaUsageIteration}?)"/>
    static (long Input, long Output)? CompactionTokens(JsonElement? iterations)
    {
        if (iterations is not { ValueKind: JsonValueKind.Array } entries)
        {
            return null;
        }
        (long Input, long Output)? tokens = null;
        foreach (var iteration in entries.EnumerateArray())
        {
            if (iteration.Text("type") != "compaction")
            {
                continue;
            }
            tokens = (
                (tokens?.Input ?? 0)
                    + (iteration.Long("input_tokens") ?? 0)
                    + (iteration.Long("cache_read_input_tokens") ?? 0)
                    + (iteration.Long("cache_creation_input_tokens") ?? 0),
                (tokens?.Output ?? 0) + (iteration.Long("output_tokens") ?? 0)
            );
        }
        return tokens;
    }

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of a Messages count-tokens call, the count
    /// that the call returned. Never throws into the API call.
    /// </summary>
    internal static void SetCountTokensResponseAttributes(
        Activity? span,
        Messages::MessageTokensCount count
    ) =>
        Record(
            span,
            recordingSpan =>
                recordingSpan.SetTag(
                    AttributeAnthropicMessageCountTokensInputTokens,
                    count.InputTokens
                )
        );

    /// <inheritdoc cref="SetCountTokensResponseAttributes(Activity?, Messages::MessageTokensCount)"/>
    internal static void SetCountTokensResponseAttributes(
        Activity? span,
        BetaMessages::BetaMessageTokensCount count
    ) =>
        Record(
            span,
            recordingSpan =>
                recordingSpan.SetTag(
                    AttributeAnthropicMessageCountTokensInputTokens,
                    count.InputTokens
                )
        );

    internal static Dictionary<string, JsonElement> NonNullProperties(JsonElement? element)
    {
        var fields = new Dictionary<string, JsonElement>();
        if (element is { ValueKind: JsonValueKind.Object } value)
        {
            foreach (var field in value.EnumerateObject())
            {
                if (field.Value.ValueKind != JsonValueKind.Null)
                {
                    fields[field.Name] = field.Value;
                }
            }
        }
        return fields;
    }
}
