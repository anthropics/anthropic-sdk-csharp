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
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        string expectedID = "sevt_011CZkZXYc8qKmy2tiZbrpDv";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        BetaManagedAgentsSessionRefusalStopDetails expectedStopDetails = new()
        {
            Category = Category.Cyber,
            Explanation = "explanation",
        };
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason expectedStopReason =
            new BetaManagedAgentsSessionEndTurn();
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.thread_status_idle");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentName, model.AgentName);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
        Assert.Equal(expectedStopDetails, model.StopDetails);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
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
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZXYc8qKmy2tiZbrpDv";
        string expectedAgentName = "Researcher";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        string expectedSessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt";
        BetaManagedAgentsSessionRefusalStopDetails expectedStopDetails = new()
        {
            Category = Category.Cyber,
            Explanation = "explanation",
        };
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason expectedStopReason =
            new BetaManagedAgentsSessionEndTurn();
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.thread_status_idle");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentName, deserialized.AgentName);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
        Assert.Equal(expectedStopDetails, deserialized.StopDetails);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionThreadStatusIdleEvent
        {
            ID = "sevt_011CZkZXYc8qKmy2tiZbrpDv",
            AgentName = "Researcher",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            SessionThreadID = "sthr_011CZkZVWa6oJjw1rgXZpnBt",
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
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
            new BetaManagedAgentsSessionEndTurn();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRequiresAction(["string"]);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRetriesExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionBudgetReached();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalValidationWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRefusal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionEndTurn();
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
            new BetaManagedAgentsSessionRequiresAction(["string"]);
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
            new BetaManagedAgentsSessionRetriesExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionBudgetReached();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalSerializationRoundtripWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRefusal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnTypeWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionEndTurn();
        Assert.Equal(
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.EndTurn,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionTypeWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRequiresAction(["string"]);
        Assert.Equal(
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RequiresAction,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedTypeWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRetriesExhausted();
        Assert.Equal(
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RetriesExhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedTypeWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionBudgetReached();
        Assert.Equal(
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.BudgetReached,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalTypeWorks()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value =
            new BetaManagedAgentsSessionRefusal();
        Assert.Equal(
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.Refusal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "end_turn"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType> expectedType =
            BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.EndTurn;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsSessionThreadStatusIdleEventStopReason emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsSessionThreadStatusIdleEventStopReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.EndTurn)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RequiresAction)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RetriesExhausted)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.BudgetReached)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.Refusal)]
    public void Validation_Works(
        BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.EndTurn)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RequiresAction)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.RetriesExhausted)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.BudgetReached)]
    [InlineData(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType.Refusal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventStopReasonType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
