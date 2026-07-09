using System.Collections.Generic;
using System.Text.Json;
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
        await foreach (var events in source.CollectAsync(aggregator))
        {
            seen.Add(events);
        }

        Assert.Equal(2, seen.Count);
        Assert.Equal("Hello", aggregator.GetAgentMessageText("evt_1"));
    }
}
