using System;
using Anthropic.Helpers;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The output content of a streamed Message in content mode. The SDK's own aggregator of the
/// stream's events, of type <typeparamref name="T"/>, builds it, so that the span holds what
/// <c>Aggregate()</c> gives the application, and what a Message read whole would hold. The
/// aggregator keeps every event until the stream ends, and nothing is measured while it does:
/// the application asked for the content, and the request's <c>max_tokens</c> bounds it. The
/// output then counts toward the size limit of the span's content
/// (<see cref="RequestContent.Limit"/>) as that of a Message read whole does.
/// </summary>
/// <param name="add">Gives the aggregator its next event.</param>
/// <param name="message">The aggregator's Message, which it has after <c>message_stop</c>.</param>
/// <param name="messageStop">
/// A <c>message_stop</c> event, for a stream that ended without one.
/// </param>
sealed class StreamedOutput<T>(Action<T> add, Func<JsonModel> message, T messageStop)
{
    internal void Add(T streamEvent) => add(streamEvent);

    /// <summary>
    /// The Message that the aggregator makes of the events it has, once the stream has ended. The
    /// aggregator makes one only after <c>message_stop</c>, so it gets the one that a stream cut
    /// short lacks, and ignores it after the stream's own. An open tool use block keeps the
    /// <c>input</c> that it started with. Throws without <c>message_start</c>, and for events
    /// that do not make a Message.
    /// </summary>
    internal JsonModel Message()
    {
        add(messageStop);
        return message();
    }
}

/// <summary>
/// Makes a <see cref="StreamedOutput{T}"/> of an aggregator.
/// </summary>
static class StreamedOutput
{
    internal static StreamedOutput<T> Of<T, TMessage>(
        SseAggregator<T, TMessage> aggregator,
        T messageStop
    )
        where TMessage : JsonModel => new(aggregator.Add, aggregator.Message, messageStop);
}
