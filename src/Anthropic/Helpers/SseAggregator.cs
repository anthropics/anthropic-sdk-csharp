using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// Defines the base for all Aggregators using ServerSideStreaming events.
/// </summary>
/// <typeparam name="TMessage">The raw message base element type.</typeparam>
/// <typeparam name="TResult">The element type that defines an aggregated <typeparamref name="TMessage"/></typeparam>
public abstract class SseAggregator<TMessage, TResult>
{
    private Dictionary<FilterResult, IList<TMessage>>? _messages;
    private bool _streamEnded;
    private bool _startMessageReceived;
    private FilterResult _lastFilterResult = FilterResult.Ignore;
    private TResult? _message;

    /// <summary>
    /// Collects and filters the provided <see cref="IAsyncEnumerable{TMessage}"/> for aggregation with the <see cref="SseAggregatorExtensions.Aggregate(IAsyncEnumerable{RawMessageStreamEvent})"/> method.
    /// </summary>
    /// <param name="messageStream">An <see cref="IAsyncEnumerable{TMessage}"/> containing the messages to aggregate.</param>
    /// <returns>An <see cref="IAsyncEnumerable{TMessage}"/> of all content messages used to build the aggregation result.</returns>
    /// <exception cref="InvalidOperationException">Will be thrown if the aggregator is in an invalid state.</exception>
    /// <exception cref="AnthropicInvalidDataException">Will be thrown if the aggregator encounters an invalid state of the source message stream.</exception>
    public virtual async IAsyncEnumerable<TMessage> CollectAsync(
        IAsyncEnumerable<TMessage> messageStream
    )
    {
        if (_messages is not null)
        {
            throw new InvalidOperationException(
                "Cannot collect multiple streams into same aggregator."
            );
        }

        _messages = NewMessages();

        await foreach (var message in messageStream)
        {
            if (_streamEnded)
            {
                // Nothing follows the End message. The source is still read to its end: leaving
                // it there would abandon a stream that its sender has not ended.
                continue;
            }

            Add(message);
            if (!_startMessageReceived)
            {
                continue;
            }

            yield return message;
        }

        if (!_streamEnded)
        {
            throw new AnthropicInvalidDataException(
                $"Expected last message to be the End message but found: {_lastFilterResult}"
            );
        }
    }

    /// <summary>
    /// Adds one message of a stream to the aggregation, as <see cref="CollectAsync"/> does for each
    /// message that it reads. For a caller that reads the stream itself and cannot hand it over.
    /// </summary>
    /// <param name="message">The next message of the stream.</param>
    internal void Add(TMessage message)
    {
        _messages ??= NewMessages();
        if (_streamEnded)
        {
            return;
        }

        if (!_startMessageReceived && Filter(message) != FilterResult.StartMessage)
        {
            _messages[FilterResult.StartMessage].Add(message);
            return;
        }

        _startMessageReceived = true;
        _lastFilterResult = Filter(message);
        _messages[_lastFilterResult].Add(message);
        _streamEnded = _lastFilterResult == FilterResult.EndMessage;
    }

    private static Dictionary<FilterResult, IList<TMessage>> NewMessages()
    {
        Dictionary<FilterResult, IList<TMessage>> messages = [];
        foreach (FilterResult item in Enum.GetValues(typeof(FilterResult)))
        {
            messages[item] = [];
        }

        return messages;
    }

    /// <summary>
    /// Aggregates all items based on the Anthropic streaming protocol present in the <see cref="IAsyncEnumerable{TMessage}"/> provided on initialization.
    /// </summary>
    /// <returns>The result of the aggregation.</returns>
    public virtual TResult Message()
    {
        if (_messages == null)
        {
            throw new AnthropicInvalidDataException("Stream was not passed to aggregator");
        }

        return _message ??= GetResult(
            new ReadOnlyDictionary<FilterResult, IList<TMessage>>(_messages)
        );
    }

    /// <summary>
    /// Applies a filter to each individual message.
    /// </summary>
    /// <param name="message">The message to filter.</param>
    /// <returns>[True] if the message should be included in the aggregation result, otherwise [False]</returns>
    protected abstract FilterResult Filter(TMessage message);

    /// <summary>
    /// Gets an aggregation result of the collected list of messages.
    /// </summary>
    /// <param name="messages">The read only list of messages.</param>
    /// <returns>The aggregation result.</returns>
    protected abstract TResult GetResult(
        IReadOnlyDictionary<FilterResult, IList<TMessage>> messages
    );

    protected enum FilterResult
    {
        Ignore = 0,
        StartMessage = 1,
        Delta = 2,
        Content = 3,
        EndMessage = 4,
    }
}
