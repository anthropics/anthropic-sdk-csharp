using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic;

/// <summary>
/// Extension methods for providing easy access to Aggregators
/// </summary>
public static class SseAggregatorExtensions
{
    /// <summary>
    /// Aggregates all messages received by the streaming event and aggregates them into a single object once the sender indicates a fully delivered stream.
    /// </summary>
    /// <param name="source">A enumerable as provided by the <see cref="IMessageService.CreateStreaming(Models.Messages.MessageCreateParams)"/></param>
    /// <returns>A task that completes once all messages have been received or in the event of improper streaming and exception.</returns>
    public static async Task<Message> Aggregate(this IAsyncEnumerable<RawMessageStreamEvent> source)
    {
        return await new MessageContentAggregator().Aggregate(source).ConfigureAwait(false);
    }

    /// <summary>
    /// Aggregates all messages received by the streaming event and aggregates them into a single object once the sender indicates a fully delivered stream.
    /// </summary>
    /// <param name="source">A enumerable as provided by the <see cref="IBetaService.CreateStreaming(Models.Beta.Messages.MessageCreateParams)"/></param>
    /// <returns>A task that completes once all messages have been received or in the event of improper streaming and exception.</returns>
    public static async Task<BetaMessage> Aggregate(
        this IAsyncEnumerable<BetaRawMessageStreamEvent> source
    )
    {
        return await new BetaMessageContentAggregator().Aggregate(source).ConfigureAwait(false);
    }

    /// <summary>
    /// Aggregates all messages received by the streaming event and aggregates them into a single object once the sender indicates a fully delivered stream.
    /// </summary>
    /// <typeparam name="TMessage">The type of message as provided by the Api.</typeparam>
    /// <typeparam name="TResult">The Result object that the aggregator should build.</typeparam>
    /// <param name="aggregator">The aggregator instance that will collect messages and build the result object.</param>
    /// <param name="source">The source stream of messages.</param>
    /// <returns>A task that completes after all messages from the source have been consumed.</returns>
    public static async Task<TResult> Aggregate<TMessage, TResult>(
        this SseAggregator<TMessage, TResult> aggregator,
        IAsyncEnumerable<TMessage> source
    )
    {
        await foreach (var _ in aggregator.CollectAsync(source)) { }
        return aggregator.Message();
    }

    /// <summary>
    /// Aggregates all messages received by the streaming event and collects them in the provided aggregator.
    /// </summary>
    /// <typeparam name="TMessage">The type of message as provided by the Api.</typeparam>
    /// <typeparam name="TResult">The Result object that the aggregator should build.</typeparam>
    /// <param name="source">The source stream of messages.</param>
    /// <param name="aggregator">The aggregator instance that will collect messages and build the result object.</param>
    /// <returns>An <see cref="IAsyncEnumerable{TMessage}"/> filtered by the aggregator.</returns>
    public static IAsyncEnumerable<TMessage> CollectAsync<TMessage, TResult>(
        this IAsyncEnumerable<TMessage> source,
        SseAggregator<TMessage, TResult> aggregator
    )
    {
        return aggregator.CollectAsync(source);
    }
}
