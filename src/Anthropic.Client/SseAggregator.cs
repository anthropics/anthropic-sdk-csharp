using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthropic.Client;

/// <summary>
/// Defines the base for all Aggregators using ServerSideStreaming events.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
/// <typeparam name="TResult"></typeparam>
public abstract class SseAggregator<TMessage, TResult> 
    where TResult: new()
{
    private readonly IAsyncEnumerable<TMessage> _messages;

    /// <summary>
    /// Initialises a new instance of the <see cref="SseAggregator{TMessage, TResult}"/>.
    /// </summary>
    /// <param name="messages">The service attached enumerable for reading messages.</param>
    public SseAggregator(IAsyncEnumerable<TMessage> messages)
    {
        this._messages = messages;
    }

    private Task<TResult>? _collectionTask;

    public virtual Task<TResult> BeginCollectionAsync()
    {
        return _collectionTask = Task.Run<TResult>(async () =>
        {
            var messages = new List<TMessage>();
            var allMessages = new List<TMessage>();
            var startMessageReceived = false;
            FilterResult filterResult = FilterResult.Ignore;
            await foreach (var item in _messages.ConfigureAwait(false))
            {
                allMessages.Add(item);
                if (!startMessageReceived && Filter(item) != FilterResult.StartMessage)
                {
                    continue;
                }

                startMessageReceived = true;
                filterResult = Filter(item);
                if (filterResult == FilterResult.Content)
                {
                    messages.Add(item);
                }
                else if (filterResult == FilterResult.EndMessage)
                {
                    break;
                }
            }

            if(messages is {Count: 0})
            {
                return new TResult();
            }

            if (filterResult != FilterResult.EndMessage)
            {
                throw new InvalidOperationException($"Expected last message to be the End message but found: {filterResult}");
            }

            return GetResult(messages);
        });
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
    protected abstract TResult GetResult(IReadOnlyCollection<TMessage> messages);

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
        /// The message contains aggregatable content.
        /// </summary>
        Content = 2,

        /// <summary>
        /// The message defines the end boundry of the message package.
        /// </summary>
        EndMessage = 3
    }
}
