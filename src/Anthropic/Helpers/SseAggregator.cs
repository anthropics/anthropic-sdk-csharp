using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Anthropic.Exceptions;

namespace Anthropic.Helpers;

/// <summary>
/// Defines the base for all Aggregators using ServerSideStreaming events.
/// </summary>
/// <typeparam name="TMessage">The raw message base element type.</typeparam>
/// <typeparam name="TResult">The element type that defines an aggregated <typeparamref name="TMessage"/></typeparam>
public abstract class SseAggregator<TMessage, TResult>
{
    private readonly IAsyncEnumerable<TMessage> _messages;

    /// <summary>
    /// Initialize a new instance of the <see cref="SseAggregator{TMessage, TResult}"/>.
    /// </summary>
    /// <param name="messages">The service attached enumerable for reading messages.</param>
    public SseAggregator(IAsyncEnumerable<TMessage> messages)
    {
        _messages = messages;
    }

    private Task<TResult?>? _collectionTask;

    /// <summary>
    /// Aggregates all items based on the Anthropic streaming protocol present in the <see cref="IAsyncEnumerable{TMessage}"/> provided on initialization.
    /// </summary>
    /// <returns>A task that completes when all messages have been aggregated.</returns>
    public virtual async Task<TResult?> AggregateAsync()
    {
        return await (_collectionTask ??= Task.Run(async () =>
        {
            var messages = new Dictionary<FilterResult, IList<TMessage>>();
            foreach (FilterResult item in Enum.GetValues(typeof(FilterResult)))
            {
                messages[item] = [];
            }

            var startMessageReceived = false;
            FilterResult filterResult = FilterResult.Ignore;
            await foreach (var item in _messages.ConfigureAwait(false))
            {
                if (!startMessageReceived && Filter(item) != FilterResult.StartMessage)
                {
                    messages[FilterResult.StartMessage].Add(item);
                    continue;
                }

                startMessageReceived = true;
                filterResult = Filter(item);
                messages[filterResult].Add(item);
                if (filterResult == FilterResult.EndMessage)
                {
                    break;
                }
            }

            if (messages is { Count: 0 })
            {
                return default;
            }

            if (filterResult != FilterResult.EndMessage)
            {
                throw new AnthropicInvalidDataException(
                    $"Expected last message to be the End message but found: {filterResult}"
                );
            }

            return GetResult(new ReadOnlyDictionary<FilterResult, IList<TMessage>>(messages));
        }));
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
