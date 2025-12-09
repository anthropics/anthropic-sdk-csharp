using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Client.Services.Messages;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic;

/// <summary>
/// Extension methods for providing easy access to Aggregators
/// </summary>
public static class SseAggregatorExtensions
{

    /// <summary>
    /// Aggregates all messages received by the streaming event and aggregates them into a single object once the sender indicated a fully delivered stream.
    /// </summary>
    /// <param name="source">A enumerable as provided by the <see cref="IMessageService.CreateStreaming(Models.Messages.MessageCreateParams)"/></param>
    /// <returns>A task that completes once all messages have been recieved or in the event of inproper streaming and exception.</returns>
    public static Task<MessageAggregationResult> Aggregate(this IAsyncEnumerable<RawMessageStreamEvent> source)
    {
        return new MessageContentAggregator(source).BeginCollectionAsync();
    }

    /// <summary>
    /// Aggregates all messages received by the streaming event and aggregates them into a single object once the sender indicated a fully delivered stream.
    /// </summary>
    /// <param name="source">A enumerable as provided by the <see cref="IBetaService.CreateStreaming(Models.Beta.Messages.MessageCreateParams)"/></param>
    /// <returns>A task that completes once all messages have been recieved or in the event of inproper streaming and exception.</returns>
    public static Task<BetaMessageAggregationResult> Aggregate(this IAsyncEnumerable<BetaRawMessageStreamEvent> source)
    {
        return new BetaMessageContentAggregator(source).BeginCollectionAsync();
    }
}
