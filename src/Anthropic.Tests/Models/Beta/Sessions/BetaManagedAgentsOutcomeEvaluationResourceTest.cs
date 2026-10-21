using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsOutcomeEvaluationResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsOutcomeEvaluationResource
        {
            CompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Description = "Produce a 2-page summary as summary.md",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            Result = "satisfied",
        };

        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z");
        string expectedDescription = "Produce a 2-page summary as summary.md";
        string expectedExplanation = "All five sections present with inline citations.";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        string expectedResult = "satisfied";
        JsonElement expectedType = JsonSerializer.SerializeToElement("outcome_evaluation");

        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedIteration, model.Iteration);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsOutcomeEvaluationResource
        {
            CompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Description = "Produce a 2-page summary as summary.md",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            Result = "satisfied",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsOutcomeEvaluationResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsOutcomeEvaluationResource
        {
            CompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Description = "Produce a 2-page summary as summary.md",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            Result = "satisfied",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsOutcomeEvaluationResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z");
        string expectedDescription = "Produce a 2-page summary as summary.md";
        string expectedExplanation = "All five sections present with inline citations.";
        int expectedIteration = 0;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        string expectedResult = "satisfied";
        JsonElement expectedType = JsonSerializer.SerializeToElement("outcome_evaluation");

        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedIteration, deserialized.Iteration);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsOutcomeEvaluationResource
        {
            CompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Description = "Produce a 2-page summary as summary.md",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            Result = "satisfied",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsOutcomeEvaluationResource
        {
            CompletedAt = DateTimeOffset.Parse("2026-03-15T10:02:31Z"),
            Description = "Produce a 2-page summary as summary.md",
            Explanation = "All five sections present with inline citations.",
            Iteration = 0,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            Result = "satisfied",
        };

        BetaManagedAgentsOutcomeEvaluationResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
