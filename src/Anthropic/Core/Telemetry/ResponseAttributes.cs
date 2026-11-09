using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using static Anthropic.Core.Telemetry.ActivityTags;
using static Anthropic.Core.Telemetry.SemanticConventions;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The attributes of a Messages create call span that are computed from the response, and the
/// response's content. The methods set them on the span they started, before reading the response
/// ends the span. The attributes that the SDK's configuration names come from
/// <see cref="SpanAttributes"/>.
/// </summary>
static class ResponseAttributes
{
    /// <summary>
    /// The paths in the JSON of a Message to what is final only once a <c>message_delta</c>
    /// arrived: the stop reason, the output tokens with their details, and the iterations. The
    /// <c>message_start</c> of a stream has placeholders there, so the span of a stream that ended
    /// before its <c>message_delta</c> gets none of them (<see cref="StreamedMessage{T}.Snapshot"/>).
    /// A response attribute of the SDK's configuration that a <c>message_delta</c> completes needs
    /// its path, or the one it is under, here.
    /// </summary>
    internal static readonly string[][] FinalFromMessageDelta =
    [
        ["stop_reason"],
        ["usage", "output_tokens"],
        ["usage", "output_tokens_details"],
        ["usage", "iterations"],
    ];

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of a Messages create call that is not
    /// streamed, what is computed from <paramref name="message"/>, the Message that the call
    /// returned, stable or beta: the token sums and, in content mode, the response's content,
    /// beside <paramref name="requestContent"/>, the request's content that the span already has,
    /// so that the size limit counts both. The response sets the other attributes once it has
    /// been deserialized (<see cref="SpanAttributes.SetResponseAttributes"/>).
    ///
    /// <para>Never throws into the API call, and does nothing to a span that is not
    /// recording.</para>
    /// </summary>
    internal static void SetMessagesCreateResponseAttributes(
        Activity? span,
        RequestContent? requestContent,
        JsonModel message
    ) =>
        Record(
            span,
            recordingSpan =>
            {
                SetTokenSums(recordingSpan, message.RawData);
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
        if (message.Snapshot() is not { } snapshot)
        {
            return;
        }
        SpanAttributes.SetResponseAttributes(span, snapshot);
        SetTokenSums(span, snapshot);
    }

    /// <summary>
    /// Sets on <paramref name="span"/> the token counts that are sums over the usage of
    /// <paramref name="message"/>, the JSON of a Message: the input tokens, and the tokens of its
    /// compactions.
    /// </summary>
    static void SetTokenSums(Activity span, IReadOnlyDictionary<string, JsonElement> message)
    {
        if (message.Property("usage") is not { } usage)
        {
            return;
        }
        if (usage.Long("input_tokens") is { } uncached)
        {
            // The conventions define the input tokens as the sum of these three.
            span.SetTag(
                AttributeGenAiUsageInputTokens,
                uncached
                    + (usage.Long("cache_read_input_tokens") ?? 0)
                    + (usage.Long("cache_creation_input_tokens") ?? 0)
            );
        }
        var compaction = CompactionTokens(usage.Property("iterations"));
        SetTag(span, AttributeAnthropicUsageCompactionInputTokens, compaction?.Input);
        SetTag(span, AttributeAnthropicUsageCompactionOutputTokens, compaction?.Output);
    }

    /// <summary>
    /// The input and output tokens of the compactions among <paramref name="iterations"/>, those of
    /// a response's usage, or null when none is a compaction. The response's own usage does not
    /// include them. The input tokens of each are the sum that
    /// <see cref="AttributeGenAiUsageInputTokens"/> is of the response's.
    /// </summary>
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
