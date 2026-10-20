using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// A Message as the events of its stream, of type <typeparamref name="T"/>, have delivered it so
/// far: the message of <c>message_start</c>, the model that a <c>fallback</c> content block named,
/// the usage and stop reason that <c>message_delta</c> events changed, and, in content mode, the
/// events themselves for the output content. It is complete once <c>message_stop</c> arrived, and
/// has what it says of its output once a <c>message_delta</c> did.
/// </summary>
/// <param name="nonContentEventJson">
/// Gives the JSON of an event that the response attributes may come from, and null for a content
/// delta or the end of a content block.
/// </param>
/// <param name="isContentBlockDelta">
/// Says whether an event is a <c>content_block_delta</c>, whatever the delta's type.
/// </param>
/// <param name="output">What builds the output content, in content mode.</param>
sealed class StreamedMessage<T>(
    Func<T, JsonElement?> nonContentEventJson,
    Func<T, bool> isContentBlockDelta,
    StreamedOutput<T>? output
)
{
    /// <summary>
    /// The message of the <c>message_start</c> event, once it arrived.
    /// </summary>
    internal JsonElement? Start { get; private set; }

    /// <summary>
    /// The model that serves the rest of the response, once a <c>fallback</c> content block named
    /// one: the Message's model from there on, as in the Message that the SDK's aggregator builds.
    /// </summary>
    internal string? FallbackModel { get; private set; }

    /// <summary>
    /// The fields of <c>message_start</c>'s usage that are not null, with those that
    /// <c>message_delta</c> events replaced.
    /// </summary>
    internal Dictionary<string, JsonElement> Usage { get; } = [];

    /// <summary>
    /// The stop reason, once a <c>message_delta</c> event brought one.
    /// </summary>
    internal string? StopReason { get; private set; }

    /// <summary>
    /// Whether a <c>message_delta</c> arrived. Until then the stop reason and the output tokens
    /// are those of <c>message_start</c>, which say nothing of the output.
    /// </summary>
    internal bool ReachedMessageDelta { get; private set; }

    internal bool ReachedMessageStop { get; private set; }

    /// <summary>
    /// What builds the output content from the events. Null outside content mode, and once it was
    /// dropped because an event failed to go into it: the span then gets no output content.
    /// </summary>
    internal StreamedOutput<T>? Output { get; private set; } = output;

    /// <summary>
    /// Stops building the output content, and lets go of the events kept for it.
    /// </summary>
    internal void DropOutput() => Output = null;

    /// <summary>
    /// Whether <paramref name="streamEvent"/> is a <c>content_block_delta</c>, of any delta type:
    /// the first one is the first chunk of the response.
    /// </summary>
    internal bool IsContentBlockDelta(T streamEvent) => isContentBlockDelta(streamEvent);

    /// <summary>
    /// Takes from <paramref name="streamEvent"/> what the attributes need: the Message of
    /// <c>message_start</c>, the model of a <c>fallback</c> content block, the usage and stop
    /// reason of <c>message_delta</c>, and whether <c>message_stop</c> arrived. In content mode the
    /// event also goes to the output content.
    /// </summary>
    internal void OnEvent(T streamEvent)
    {
        if (nonContentEventJson(streamEvent) is { } json)
        {
            OnMessageEvent(json);
        }
        Output?.Add(streamEvent);
    }

    void OnMessageEvent(JsonElement streamEvent)
    {
        switch (streamEvent.Text("type"))
        {
            case "message_start":
                if (streamEvent.Property("message") is { } message)
                {
                    Start = message;
                    StopReason = message.Text("stop_reason");
                    SetUsage(message.Property("usage"), delta: false);
                }
                break;
            case "content_block_start":
                if (
                    streamEvent.Property("content_block") is { } block
                    && block.Text("type") == "fallback"
                )
                {
                    FallbackModel = block.Property("to")?.Text("model");
                }
                break;
            case "message_delta":
                ReachedMessageDelta = true;
                SetUsage(streamEvent.Property("usage"), delta: true);
                if (streamEvent.Property("delta")?.Text("stop_reason") is { } stopReason)
                {
                    StopReason = stopReason;
                }
                break;
            case "message_stop":
                ReachedMessageStop = true;
                break;
        }
    }

    /// <summary>
    /// Takes the fields of <paramref name="usage"/> that are not null. A <c>message_delta</c> event
    /// does not change the cache writes by lifetime: the span reports the ones from
    /// <c>message_start</c>.
    /// </summary>
    void SetUsage(JsonElement? usage, bool delta)
    {
        foreach (var field in ResponseAttributes.NonNullProperties(usage))
        {
            if (!delta || field.Key != "cache_creation")
            {
                Usage[field.Key] = field.Value;
            }
        }
    }
}
