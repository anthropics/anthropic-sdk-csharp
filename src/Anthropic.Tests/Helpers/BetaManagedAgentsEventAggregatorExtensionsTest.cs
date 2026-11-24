using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Helpers;

public class BetaManagedAgentsEventAggregatorExtensionsTest
{
    static Events::BetaManagedAgentsStreamSessionEvents SseEvent(string json)
    {
        var deserialized = JsonSerializer.Deserialize<Events::BetaManagedAgentsStreamSessionEvents>(
            json,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
        return deserialized;
    }

    static Events::BetaManagedAgentsStreamSessionEvents EventStart(string eventID)
    {
        return SseEvent(
            $$$"""{"type":"event_start","event":{"type":"agent.message","id":"{{{eventID}}}"}}"""
        );
    }

    static Events::BetaManagedAgentsStreamSessionEvents EventDelta(
        string eventID,
        string text,
        long index
    )
    {
        return SseEvent(
            $$$$"""{"type":"event_delta","event_id":"{{{{eventID}}}}","delta":{"type":"content_delta","index":{{{{index}}}},"content":{"type":"text","text":"{{{{text}}}}"}}}"""
        );
    }

    static async IAsyncEnumerable<Events::BetaManagedAgentsStreamSessionEvents> GetTestValues(
        params Events::BetaManagedAgentsStreamSessionEvents[] events
    )
    {
        foreach (var streamEvents in events)
        {
            yield return streamEvents;
        }
        await Task.CompletedTask;
    }

    [Fact]
    public async Task CollectAsyncFeedsAggregatorAndMirrorsStream()
    {
        var aggregator = new BetaManagedAgentsEventAggregator();
        var source = GetTestValues(EventStart("evt_1"), EventDelta("evt_1", "Hello", 0));

        var seen = new List<Events::BetaManagedAgentsStreamSessionEvents>();
        await foreach (var events in source.CollectAsync(aggregator, TestContext.Current.CancellationToken))
        {
            seen.Add(events);
        }

        Assert.Equal(2, seen.Count);
        Assert.Equal("Hello", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public async Task CollectAsyncForwardsTheTokenFromWithCancellationToTheSource()
    {
        using var cts = new CancellationTokenSource();
        CancellationToken? received = null;
        async IAsyncEnumerable<Events::BetaManagedAgentsStreamSessionEvents> Source(
            [EnumeratorCancellation] CancellationToken token = default
        )
        {
            received = token;
            yield return EventStart("evt_1");
            await Task.CompletedTask;
        }

#pragma warning disable xUnit1051
        await foreach (
            var _ in Source()
                .CollectAsync(new BetaManagedAgentsEventAggregator())
                .WithCancellation(cts.Token)
        ) { }
#pragma warning restore xUnit1051

        Assert.Equal(cts.Token, received);
    }
}
