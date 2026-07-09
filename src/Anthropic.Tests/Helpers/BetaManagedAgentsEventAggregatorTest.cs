using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Helpers;

public class BetaManagedAgentsEventAggregatorTest
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

    static BetaManagedAgentsEventAggregator Aggregate(
        params Events::BetaManagedAgentsStreamSessionEvents[] events
    )
    {
        BetaManagedAgentsEventAggregator aggregator = new();
        foreach (var streamEvents in events)
        {
            aggregator.Aggregate(streamEvents);
        }
        return aggregator;
    }

    [Fact]
    public void StartOpensEmptyPreview()
    {
        var aggregator = Aggregate(EventStart("evt_1"));

        var message = Assert.Contains("evt_1", aggregator.AgentMessages);
        Assert.Equal("evt_1", message.ID);
        Assert.Equal(
            Events::BetaManagedAgentsAgentMessageEventType.AgentMessage,
            message.Type.Value()
        );
        Assert.Empty(message.Content);
    }

    [Fact]
    public void StartIgnoresNonAgentMessage()
    {
        var aggregator = Aggregate(
            SseEvent("""{"type":"event_start","event":{"type":"agent.thinking","id":"evt_1"}}""")
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void DeltaForIgnoredPreviewIsNoOp()
    {
        var aggregator = Aggregate(
            SseEvent("""{"type":"event_start","event":{"type":"agent.thinking","id":"evt_1"}}"""),
            EventDelta("evt_1", "x", 0)
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void StartIgnoresUnknownPreviewType()
    {
        var aggregator = Aggregate(
            SseEvent("""{"type":"event_start","event":{"type":"agent.tool_use","id":"evt_1"}}"""),
            EventDelta("evt_1", "x", 0)
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void UnknownPreviewWithoutIDIsIgnored()
    {
        var aggregator = Aggregate(
            SseEvent("""{"type":"event_start","event":{"type":"agent.future"}}""")
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void StragglerDeltaAfterCanonicalIsDropped()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "partial", 0),
            SseEvent(
                """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"complete"}]}"""
            ),
            EventDelta("evt_1", "straggler", 0)
        );

        Assert.Equal("complete", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void StragglerStartAfterCanonicalIsDropped()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "partial", 0),
            SseEvent(
                """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"complete"}]}"""
            ),
            EventStart("evt_1")
        );

        Assert.Equal("complete", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void PreviewProcessedAtIsPlaceholderUntilCanonical()
    {
        var aggregator = Aggregate(EventStart("evt_1"), EventDelta("evt_1", "partial", 0));
        var preview = Assert.Contains("evt_1", aggregator.AgentMessages);
        Assert.Equal(default, preview.ProcessedAt);

        aggregator.Aggregate(
            SseEvent(
                """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"complete"}]}"""
            )
        );
        var canonical = Assert.Contains("evt_1", aggregator.AgentMessages);
        Assert.Equal(System.DateTimeOffset.Parse("2024-01-01T00:00:00Z"), canonical.ProcessedAt);
    }

    [Fact]
    public void DeltaAppendsAndInserts()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "Hel", 0),
            EventDelta("evt_1", "lo", 0),
            EventDelta("evt_1", "World", 1)
        );

        var message = Assert.Contains("evt_1", aggregator.AgentMessages);
        Assert.Equal(2, message.Content.Count);
        Assert.Equal("Hello", message.Content[0].Text);
        Assert.Equal("World", message.Content[1].Text);
        Assert.Equal("HelloWorld", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void DeltaDefaultsIndexZero()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            SseEvent(
                """{"type":"event_delta","event_id":"evt_1","delta":{"type":"content_delta","content":{"type":"text","text":"a"}}}"""
            ),
            SseEvent(
                """{"type":"event_delta","event_id":"evt_1","delta":{"type":"content_delta","content":{"type":"text","text":"b"}}}"""
            )
        );

        Assert.Equal("ab", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void DeltaBeforeStartIsIgnored()
    {
        var aggregator = Aggregate(EventDelta("evt_1", "x", 0));

        Assert.Empty(aggregator.AgentMessages);
        Assert.Null(aggregator.TryGetAgentMessageText("evt_1"));
    }

    [Fact]
    public void IndexGapThrows()
    {
        BetaManagedAgentsEventAggregator aggregator = new();
        aggregator.Aggregate(EventStart("evt_1"));

        Assert.Throws<AnthropicInvalidDataException>(() =>
            aggregator.Aggregate(EventDelta("evt_1", "x", 2))
        );
        Assert.Throws<AnthropicInvalidDataException>(() =>
            aggregator.Aggregate(EventDelta("evt_1", "y", -1))
        );
    }

    [Fact]
    public void BufferedEventReplacesPreview()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "partial", 0),
            SseEvent(
                """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"complete"}]}"""
            )
        );

        Assert.Equal("complete", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void BufferedEventFullyReplacesLossyPreviewContent()
    {
        // Deltas assemble two lossy content blocks; the canonical event has a single,
        // differently-worded block. The stored snapshot must become exactly the
        // canonical event, not a merge of the two.
        var canonical = SseEvent(
            """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"final"}]}"""
        );
        Assert.True(canonical.TryPickAgentMessageEvent(out var canonicalEvent));

        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "Hel", 0),
            EventDelta("evt_1", "lo", 0),
            EventDelta("evt_1", "World", 1),
            canonical
        );

        var stored = Assert.Contains("evt_1", aggregator.AgentMessages);
        Assert.Equal(canonicalEvent, stored);
        Assert.Single(stored.Content);
        Assert.Equal("final", aggregator.GetAgentMessageText("evt_1"));
    }

    [Fact]
    public void ModelRequestEndClearsOpenPreviews()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "x", 0),
            SseEvent(
                """{"type":"span.model_request_end","id":"sevt_2","model_request_start_id":"sevt_1","is_error":true,"processed_at":"2024-01-01T00:00:00Z"}"""
            )
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void ModelRequestEndKeepsCanonicalMessages()
    {
        var aggregator = Aggregate(
            EventStart("evt_1"),
            EventDelta("evt_1", "partial", 0),
            SseEvent(
                """{"type":"agent.message","id":"evt_1","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"complete"}]}"""
            ),
            EventStart("evt_2"),
            EventDelta("evt_2", "open preview", 0),
            SseEvent(
                """{"type":"span.model_request_end","id":"sevt_2","model_request_start_id":"sevt_1","is_error":true,"processed_at":"2024-01-01T00:00:00Z"}"""
            )
        );

        var survivor = Assert.Single(aggregator.AgentMessages);
        Assert.Equal("evt_1", survivor.Key);
        Assert.Equal("complete", aggregator.GetAgentMessageText("evt_1"));
        Assert.Null(aggregator.TryGetAgentMessageText("evt_2"));
    }

    [Fact]
    public void OtherEventsAreNoOps()
    {
        var aggregator = Aggregate(
            SseEvent(
                """{"type":"session.status_running","id":"sevt_1","processed_at":"2024-01-01T00:00:00Z"}"""
            )
        );

        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void MultiplePreviews()
    {
        var aggregator = Aggregate(
            EventStart("evt_a"),
            EventDelta("evt_a", "alpha", 0),
            EventStart("evt_b"),
            EventDelta("evt_b", "beta", 0),
            SseEvent("""{"type":"event_start","event":{"type":"agent.thinking","id":"evt_c"}}""")
        );

        Assert.Equal(2, aggregator.AgentMessages.Count);
        Assert.Equal("alpha", aggregator.GetAgentMessageText("evt_a"));
        Assert.Equal("beta", aggregator.GetAgentMessageText("evt_b"));
    }

    [Fact]
    public void EmptyAggregator()
    {
        BetaManagedAgentsEventAggregator aggregator = new();

        Assert.Null(aggregator.TryGetAgentMessageText("evt_1"));
        Assert.Throws<KeyNotFoundException>(() => aggregator.GetAgentMessageText("evt_1"));
        Assert.Empty(aggregator.AgentMessages);
    }

    [Fact]
    public void AgentMessagesEnumerateInInsertionOrder()
    {
        BetaManagedAgentsEventAggregator aggregator = new();
        foreach (var id in new[] { "evt_c", "evt_a", "evt_b" })
        {
            aggregator.Aggregate(EventStart(id));
        }
        // Replacing with the canonical event must not change the id's position.
        aggregator.Aggregate(
            SseEvent(
                """{"type":"agent.message","id":"evt_a","processed_at":"2024-01-01T00:00:00Z","content":[{"type":"text","text":"alpha"}]}"""
            )
        );

        string[] expected = ["evt_c", "evt_a", "evt_b"];
        Assert.Equal(expected, aggregator.AgentMessages.Keys);
    }
}
