using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Anthropic.Exceptions;

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
    private TResult? _message;

    /// <summary>
    /// Collects and filters the provided <see cref="IAsyncEnumerable{TMessage}"/> for aggregation with the <see cref="AggregateAsync"/> method.
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

        _messages = [];

        foreach (FilterResult item in Enum.GetValues(typeof(FilterResult)))
        {
            _messages[item] = [];
        }

        var startMessageReceived = false;
        FilterResult filterResult = FilterResult.Ignore;
        await foreach (var message in messageStream)
        {
            if (!_streamEnded)
            {
                if (!startMessageReceived && Filter(message) != FilterResult.StartMessage)
                {
                    _messages[FilterResult.StartMessage].Add(message);
                    continue;
                }

                startMessageReceived = true;
                filterResult = Filter(message);
                _messages[filterResult].Add(message);
                if (filterResult == FilterResult.EndMessage)
                {
                    break;
                }
            }

            yield return message;
        }

        if (filterResult != FilterResult.EndMessage)
        {
            throw new AnthropicInvalidDataException(
                $"Expected last message to be the End message but found: {filterResult}"
            );
        }

        _streamEnded = true;
    }

    /// <summary>
    /// Aggregates all items based on the Anthropic streaming protocol present in the <see cref="IAsyncEnumerable{TMessage}"/> provided on initialization.
    /// </summary>
    /// <returns>The result of the aggregation.</returns>
    public virtual TResult? Message()
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

    /// <summary>
    /// Defines the filter result types.
    /// </summary>
    public enum FilterResult
    {
        /// <summary>
        /// The filtered message should be ignored.
        /// </summary>
        Ignore = 0,

        /// <summary>
        /// The message defines the start of a package.
        /// </summary>
        StartMessage = 1,

        /// <summary>
        /// The message contains aggregate content.
        /// </summary>
        Content = 2,

        /// <summary>
        /// The message defines the end of the message stream.
        /// </summary>
        EndMessage = 3,
    }
}
