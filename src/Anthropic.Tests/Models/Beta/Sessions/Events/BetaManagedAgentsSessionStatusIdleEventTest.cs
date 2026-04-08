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
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
        };

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        StopReason expectedStopReason = new BetaManagedAgentsSessionEndTurn(
            BetaManagedAgentsSessionEndTurnType.EndTurn
        );
        ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType> expectedType =
            BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
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
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionStatusIdleEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        StopReason expectedStopReason = new BetaManagedAgentsSessionEndTurn(
            BetaManagedAgentsSessionEndTurnType.EndTurn
        );
        ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType> expectedType =
            BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionStatusIdleEvent
        {
            ID = "id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
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
            StopReason = new BetaManagedAgentsSessionEndTurn(
                BetaManagedAgentsSessionEndTurnType.EndTurn
            ),
            Type = BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle,
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
        StopReason value = new BetaManagedAgentsSessionEndTurn(
            BetaManagedAgentsSessionEndTurnType.EndTurn
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRequiresActionValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRequiresAction()
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRetriesExhaustedValidationWorks()
    {
        StopReason value = new BetaManagedAgentsSessionRetriesExhausted(
            BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionEndTurnSerializationRoundtripWorks()
    {
        StopReason value = new BetaManagedAgentsSessionEndTurn(
            BetaManagedAgentsSessionEndTurnType.EndTurn
        );
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
        StopReason value = new BetaManagedAgentsSessionRequiresAction()
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };
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
        StopReason value = new BetaManagedAgentsSessionRetriesExhausted(
            BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StopReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionStatusIdleEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle)]
    public void Validation_Works(BetaManagedAgentsSessionStatusIdleEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionStatusIdleEventType.SessionStatusIdle)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionStatusIdleEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionStatusIdleEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
