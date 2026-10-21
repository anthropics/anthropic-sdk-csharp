using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionThreadCreatedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };

        string expectedID = "sevt_011CZkZWXb7pJkx1shYaqoCu";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.thread_created");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Null(model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadCreatedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadCreatedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZWXb7pJkx1shYaqoCu";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.thread_created");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Null(deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadCreatedEvent
        {
            ID = "sevt_011CZkZWXb7pJkx1shYaqoCu",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            WorkflowRunID = null,
        };

        BetaManagedAgentsSessionThreadCreatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
