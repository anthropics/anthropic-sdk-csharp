using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionStatusIdleEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsSessionRefusalStopDetails expectedStopDetails = new()
        {
            Category = Category.Cyber,
            Explanation = "explanation",
        };
        StopReason expectedStopReason = new BetaManagedAgentsSessionEndTurn();
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.status_idle");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedStopDetails, model.StopDetails);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusIdleEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusIdleEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsSessionRefusalStopDetails expectedStopDetails = new()
        {
            Category = Category.Cyber,
            Explanation = "explanation",
        };
        StopReason expectedStopReason = new BetaManagedAgentsSessionEndTurn();
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.status_idle");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedStopDetails, deserialized.StopDetails);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopDetails = new() { Category = Category.Cyber, Explanation = "explanation" },
            StopReason = new BetaManagedAgentsSessionEndTurn(),
        };

        BetaManagedAgentsSessionStatusIdleEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StopReasonTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsSessionEndTurnValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionEndTurn();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRequiresAction(["string"]);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRetriesExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionBudgetReached();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRefusal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionEndTurn();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRequiresAction(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRetriesExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionBudgetReached();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRefusal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnTypeWorks()
    {
        StopReason value = new BetaManagedAgentsSessionEndTurn();
        Assert.Equal(StopReasonType.EndTurn, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionTypeWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRequiresAction(["string"]);
        Assert.Equal(StopReasonType.RequiresAction, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedTypeWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRetriesExhausted();
        Assert.Equal(StopReasonType.RetriesExhausted, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionBudgetReachedTypeWorks()
    {
        StopReason value = new BetaManagedAgentsSessionBudgetReached();
        Assert.Equal(StopReasonType.BudgetReached, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionRefusalTypeWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRefusal();
        Assert.Equal(StopReasonType.Refusal, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        StopReason value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "end_turn"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, StopReasonType> expectedType = StopReasonType.EndTurn;

        Assert.Equal(expectedType, value.Type);

        StopReason emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class StopReasonTypeTest : TestBase
{
    [Theory]
    [InlineData(StopReasonType.EndTurn)]
    [InlineData(StopReasonType.RequiresAction)]
    [InlineData(StopReasonType.RetriesExhausted)]
    [InlineData(StopReasonType.BudgetReached)]
    [InlineData(StopReasonType.Refusal)]
    public void Validation_Works(StopReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReasonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StopReasonType.EndTurn)]
    [InlineData(StopReasonType.RequiresAction)]
    [InlineData(StopReasonType.RetriesExhausted)]
    [InlineData(StopReasonType.BudgetReached)]
    [InlineData(StopReasonType.Refusal)]
    public void SerializationRoundtrip_Works(StopReasonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReasonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReasonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReasonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
