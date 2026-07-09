using System.Collections.Generic;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Helpers;

/// <summary>
/// Extension methods for chaining a <see cref="BetaManagedAgentsEventAggregator"/> onto a session
/// event stream.
/// </summary>
public static class BetaManagedAgentsEventAggregatorExtensions
{
    /// <summary>
    /// Feeds each event from <paramref name="source"/> into <paramref name="aggregator"/> as it is
    /// enumerated, mirroring the stream back to the caller. Lets callers chain aggregation onto the
    /// stream instead of calling <see cref="BetaManagedAgentsEventAggregator.Aggregate"/> in the loop
    /// body:
    ///
    /// <code>
    /// var aggregator = new BetaManagedAgentsEventAggregator();
    /// await foreach (var events in stream.CollectAsync(aggregator))
    /// {
    ///     if (events.TryPickDeltaEvent(out var delta))
    ///     {
    ///         Console.Write(aggregator.TryGetAgentMessageText(delta.EventID) ?? "");
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <param name="source">The session event stream to aggregate.</param>
    /// <param name="aggregator">The aggregator to feed with each event.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/> that mirrors <paramref name="source"/>.</returns>
    public static async IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> CollectAsync(
        this IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> source,
        BetaManagedAgentsEventAggregator aggregator
    )
    {
        await foreach (var events in source)
        {
            aggregator.Aggregate(events);
            yield return events;
        }
    }
}
