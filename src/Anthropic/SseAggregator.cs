using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Services.Messages;

namespace Anthropic.Client;

/// <summary>
/// Defines the base for all Aggregators using ServerSideStreaming events.
/// </summary>
/// <typeparam name="TMessage"></typeparam>
/// <typeparam name="TResult"></typeparam>
public abstract class SseAggregator<TMessage, TResult>
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
        return _collectionTask = Task.Run(async () =>
        {
            var messages = new List<TMessage>();            
            await foreach (var item in _messages)
            {
                if (Filter(item))
                {
                    messages.Add(item);
                }
            }
            return GetResult(messages);
        });
    }

    /// <summary>
    /// Applies a filter to each individual message.
    /// </summary>
    /// <param name="message">The message to filter.</param>
    /// <returns>[True] if the message should be included in the aggregation result, otherwise [False]</returns>
    protected abstract bool Filter(TMessage message);

    /// <summary>
    /// Gets an aggregation result of the collected list of messages.
    /// </summary>
    /// <param name="messages">The read only list of messages.</param>
    /// <returns>The aggregation result.</returns>
    protected abstract TResult GetResult(IReadOnlyCollection<TMessage> messages);
}

public static class SseAggregatorExtensions
{
    public static Task<MessageAggregationResult> Aggregate(this IAsyncEnumerable<RawMessageStreamEvent> source)
    {
        return new MessageAggregator(source).BeginCollectionAsync();
    }
}
