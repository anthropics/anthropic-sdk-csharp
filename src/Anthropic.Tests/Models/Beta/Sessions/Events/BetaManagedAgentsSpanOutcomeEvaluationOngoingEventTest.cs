using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSpanOutcomeEvaluationOngoingEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type =
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
        };

        string expectedID = "sevt_011CZkZbCG2uOpc6xmDfvTzh";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType> expectedType =
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIteration, model.Iteration);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type =
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type =
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZbCG2uOpc6xmDfvTzh";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType> expectedType =
            BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIteration, deserialized.Iteration);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type =
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uOpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type =
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
        };

        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSpanOutcomeEvaluationOngoingEventTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing
    )]
    public void Validation_Works(BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
