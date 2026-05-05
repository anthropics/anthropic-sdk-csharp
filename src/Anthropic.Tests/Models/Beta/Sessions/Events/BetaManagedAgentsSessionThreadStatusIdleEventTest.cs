using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionThreadStatusIdleEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
        };

        string expectedID = "sevt_011CZkZXYc8qKly2tiZbrpDv";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason expectedStopReason =
            new BetaManagedAgentsSessionEndTurn(BetaManagedAgentsSessionEndTurnType.EndTurn);
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZXYc8qKly2tiZbrpDv";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt";
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason expectedStopReason =
            new BetaManagedAgentsSessionEndTurn(BetaManagedAgentsSessionEndTurnType.EndTurn);
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType> expectedType =
            BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKly2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
        };

        BetaManagedAgentsSessionThreadStatusIdleEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionThreadStatusIdleEventStopReasonTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsSessionEndTurnValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionEndTurn(BetaManagedAgentsSessionEndTurnType.EndTurn);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRequiresAction()
            {
                EventIds = ["string"],
                Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRetriesExhausted(
                BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionEndTurn(BetaManagedAgentsSessionEndTurnType.EndTurn);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRequiresAction()
            {
                EventIds = ["string"],
                Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRetriesExhausted(
                BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionThreadStatusIdleEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle)]
    public void Validation_Works(BetaManagedAgentsSessionThreadStatusIdleEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionThreadStatusIdleEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
