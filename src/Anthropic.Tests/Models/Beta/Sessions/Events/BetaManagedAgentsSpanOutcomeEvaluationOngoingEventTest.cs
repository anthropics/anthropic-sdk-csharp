using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSpanOutcomeEvaluationOngoingEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };

        string expectedID = "sevt_011CZkZbCG2uPpc6xmDfvTzh";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "span.outcome_evaluation_ongoing"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIteration, model.Iteration);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
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
            ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZbCG2uPpc6xmDfvTzh";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "span.outcome_evaluation_ongoing"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIteration, deserialized.Iteration);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent
        {
            ID = "sevt_011CZkZbCG2uPpc6xmDfvTzh",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
        };

        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
