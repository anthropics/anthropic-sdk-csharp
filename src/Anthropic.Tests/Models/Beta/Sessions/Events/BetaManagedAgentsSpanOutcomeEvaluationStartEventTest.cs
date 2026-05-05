using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSpanOutcomeEvaluationStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type = BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
        };

        string expectedID = "sevt_011CZkZTUy4mGhu8peVXnlzr";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType> expectedType =
            BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIteration, model.Iteration);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type = BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationStartEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type = BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationStartEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZTUy4mGhu8peVXnlzr";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType> expectedType =
            BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIteration, deserialized.Iteration);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type = BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationStartEvent
        {
            ID = "sevt_011CZkZTUy4mGhu8peVXnlzr",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Type = BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
        };

        BetaManagedAgentsSpanOutcomeEvaluationStartEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSpanOutcomeEvaluationStartEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart)]
    public void Validation_Works(BetaManagedAgentsSpanOutcomeEvaluationStartEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsSpanOutcomeEvaluationStartEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
