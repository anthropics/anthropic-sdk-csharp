using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers;
using static Anthropic.Core.Telemetry.SemanticConventions;
using BetaMessages = Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// Records a streamed Message on its call span as the application reads its events. The Messages
/// create methods that stream wrap their events with it.
/// </summary>
static class StreamRecording
{
    /// <summary>
    /// The Message that the events of a streamed Messages create call of <paramref name="client"/>
    /// deliver, to read them into. In content mode the SDK's own aggregator of those events builds
    /// its output content.
    /// </summary>
    internal static StreamedMessage<Messages::RawMessageStreamEvent> StreamedMessage(
        IAnthropicClientWithRawResponse client
    ) =>
        new(
            NonContentEventJson,
            streamEvent => streamEvent.Value is Messages::RawContentBlockDeltaEvent,
            Content.IsRecorded(RequestAttributes.OpenTelemetry(client))
                ? StreamedOutput.Of(
                    new MessageContentAggregator(),
                    new Messages::RawMessageStreamEvent(new Messages::RawMessageStopEvent())
                )
                : null
        );

    /// <inheritdoc cref="StreamedMessage(IAnthropicClientWithRawResponse)"/>
    internal static StreamedMessage<BetaMessages::BetaRawMessageStreamEvent> BetaStreamedMessage(
        IAnthropicClientWithRawResponse client
    ) =>
        new(
            NonContentEventJson,
            streamEvent => streamEvent.Value is BetaMessages::BetaRawContentBlockDeltaEvent,
            Content.IsRecorded(RequestAttributes.OpenTelemetry(client))
                ? StreamedOutput.Of(
                    new BetaMessageContentAggregator(),
                    new BetaMessages::BetaRawMessageStreamEvent(
                        new BetaMessages::BetaRawMessageStopEvent()
                    )
                )
                : null
        );

    /// <summary>
    /// Returns the stream to read in place of <paramref name="events"/>, the events of a streamed
    /// Message, in a call whose request's content on the span is
    /// <paramref name="requestContent"/>, in content mode, and that started at
    /// <paramref name="startTimestamp"/>, in <see cref="Stopwatch"/> ticks: it reads them through
    /// into <paramref name="message"/> and records the Message on <paramref name="span"/>, the
    /// call span, as far as it has been read when the reading ends. Returns
    /// <paramref name="events"/> as they are when there is no span, or it does not record or has
    /// ended, as that of a stream that was read before has.
    /// </summary>
    internal static IAsyncEnumerable<T> RecordStreamedMessage<T>(
        Activity? span,
        RequestContent? requestContent,
        long startTimestamp,
        IAsyncEnumerable<T> events,
        StreamedMessage<T> message,
        CancellationToken cancellationToken
    ) =>
        span is { IsAllDataRequested: true, IsStopped: false }
            ? RecordEvents(span, requestContent, startTimestamp, events, message, cancellationToken)
            : events;

    /// <summary>
    /// The JSON of <paramref name="streamEvent"/> when the response attributes may come from it,
    /// and null for a content delta or the end of a content block, which outside content mode are
    /// not looked into. The start of a content block may be a <c>fallback</c> block, which names
    /// the model that serves the rest of the response.
    /// </summary>
    static JsonElement? NonContentEventJson(Messages::RawMessageStreamEvent streamEvent) =>
        streamEvent.Value
            is Messages::RawContentBlockDeltaEvent
                or Messages::RawContentBlockStopEvent
            ? null
            : streamEvent.Json;

    /// <inheritdoc cref="NonContentEventJson(Messages::RawMessageStreamEvent)"/>
    static JsonElement? NonContentEventJson(BetaMessages::BetaRawMessageStreamEvent streamEvent) =>
        streamEvent.Value
            is BetaMessages::BetaRawContentBlockDeltaEvent
                or BetaMessages::BetaRawContentBlockStopEvent
            ? null
            : streamEvent.Json;

    /// <summary>
    /// Returns <paramref name="events"/> read through, as <see cref="RecordStreamedMessage"/>
    /// describes: each one builds up <paramref name="message"/>, the first
    /// <c>content_block_delta</c> sets the time to the first chunk, and the end of the reading,
    /// wherever it comes, records the Message as far as it got.
    /// </summary>
    static async IAsyncEnumerable<T> RecordEvents<T>(
        Activity span,
        RequestContent? requestContent,
        long startTimestamp,
        IAsyncEnumerable<T> events,
        StreamedMessage<T> message,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var hasFirstChunk = false;
        try
        {
            await foreach (
                var streamEvent in events.WithCancellation(cancellationToken).ConfigureAwait(false)
            )
            {
                try
                {
                    if (!hasFirstChunk && message.IsContentBlockDelta(streamEvent))
                    {
                        hasFirstChunk = true;
                        var elapsed = Stopwatch.GetTimestamp() - startTimestamp;
                        span.SetTag(
                            AttributeGenAiResponseTimeToFirstChunk,
                            (double)elapsed / Stopwatch.Frequency
                        );
                    }
                    message.OnEvent(streamEvent);
                }
                catch (Exception)
                {
                    // A failure to record telemetry must not fail the read. An output that
                    // misses an event is wrong, so the span gets none.
                    message.DropOutput();
                }
                yield return streamEvent;
            }
        }
        finally
        {
            try
            {
                ResponseAttributes.SetMessagesCreateResponseAttributes(span, message);
                // A stream that ended early has the output as far as its events built it.
                if (requestContent != null && StreamedOutputParts(message) is { } output)
                {
                    Content.SetResponseContent(span, requestContent, output);
                }
            }
            catch (Exception)
            {
                // A failure to record telemetry must not fail the API call.
            }
        }
    }

    /// <summary>
    /// The parts of the one message of <c>gen_ai.output.messages</c> for a streamed
    /// <paramref name="message"/>: those of the Message that the SDK's aggregator makes of the
    /// events, as for a Message read whole. A stream that ended before <c>message_stop</c>,
    /// however it ended, has those of the Message as far as the events that were read built it.
    /// Null when <c>message_start</c> did not arrive, and when the aggregator was dropped or
    /// fails.
    /// </summary>
    static JsonArray? StreamedOutputParts<T>(StreamedMessage<T> message)
    {
        if (message.Start is null || message.Output is not { } output)
        {
            return null;
        }
        try
        {
            return Content.Parts(output.Message().RawData.Property("content"));
        }
        catch (Exception)
        {
            // The request's content is still recorded.
            return null;
        }
    }
}
