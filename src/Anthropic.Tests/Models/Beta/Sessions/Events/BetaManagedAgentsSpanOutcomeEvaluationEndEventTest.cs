using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSpanOutcomeEvaluationEndEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent
        {
            ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Result = "satisfied",
            Usage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 1536,
                InputTokens = 1842,
                OutputTokens = 213,
                Speed = Speed.Standard,
            },
        };

        string expectedID = "sevt_011CZkZUVz5nHiv9qfWYomas";
        string expectedExplanation = "All five sections present with inline citations.";
        int expectedIteration = 0;
        string expectedOutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr";
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z");
        string expectedResult = "satisfied";
        JsonElement expectedType = JsonSerializer.SerializeToElement("span.outcome_evaluation_end");
        BetaManagedAgentsSpanModelUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 1536,
            InputTokens = 1842,
            OutputTokens = 213,
            Speed = Speed.Standard,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedIteration, model.Iteration);
        Assert.Equal(expectedOutcomeEvaluationStartID, model.OutcomeEvaluationStartID);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent
        {
            ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Result = "satisfied",
            Usage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 1536,
                InputTokens = 1842,
                OutputTokens = 213,
                Speed = Speed.Standard,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationEndEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent
        {
            ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Result = "satisfied",
            Usage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 1536,
                InputTokens = 1842,
                OutputTokens = 213,
                Speed = Speed.Standard,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsSpanOutcomeEvaluationEndEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZUVz5nHiv9qfWYomas";
        string expectedExplanation = "All five sections present with inline citations.";
        int expectedIteration = 0;
        string expectedOutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr";
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z");
        string expectedResult = "satisfied";
        JsonElement expectedType = JsonSerializer.SerializeToElement("span.outcome_evaluation_end");
        BetaManagedAgentsSpanModelUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 1536,
            InputTokens = 1842,
            OutputTokens = 213,
            Speed = Speed.Standard,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedIteration, deserialized.Iteration);
        Assert.Equal(expectedOutcomeEvaluationStartID, deserialized.OutcomeEvaluationStartID);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent
        {
            ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Result = "satisfied",
            Usage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 1536,
                InputTokens = 1842,
                OutputTokens = 213,
                Speed = Speed.Standard,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSpanOutcomeEvaluationEndEvent
        {
            ID = "sevt_011CZkZUVz5nHiv9qfWYomas",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeEvaluationStartID = "sevt_011CZkZTUy4mGhu8peVXnmzr",
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Result = "satisfied",
            Usage = new()
            {
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 1536,
                InputTokens = 1842,
                OutputTokens = 213,
                Speed = Speed.Standard,
            },
        };

        BetaManagedAgentsSpanOutcomeEvaluationEndEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
