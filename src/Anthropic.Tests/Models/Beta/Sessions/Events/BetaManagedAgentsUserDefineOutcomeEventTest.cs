using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserDefineOutcomeEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };

        string expectedID = "sevt_011CZkZSTx3mFgt7odUWmkyq";
        string expectedDescription = "Produce a 2-page summary as summary.md";
        int expectedMaxIterations = 3;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        Rubric expectedRubric = new BetaManagedAgentsTextRubric(
            "Must cover all five sections; cite sources inline."
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.define_outcome");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMaxIterations, model.MaxIterations);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedRubric, model.Rubric);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZSTx3mFgt7odUWmkyq";
        string expectedDescription = "Produce a 2-page summary as summary.md";
        int expectedMaxIterations = 3;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        Rubric expectedRubric = new BetaManagedAgentsTextRubric(
            "Must cover all five sections; cite sources inline."
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.define_outcome");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMaxIterations, deserialized.MaxIterations);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedRubric, deserialized.Rubric);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3mFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVmjxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric(
                "Must cover all five sections; cite sources inline."
            ),
        };

        BetaManagedAgentsUserDefineOutcomeEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RubricTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsFileValidationWorks()
    {
        Rubric value = new BetaManagedAgentsFileRubric("file_id");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextValidationWorks()
    {
        Rubric value = new BetaManagedAgentsTextRubric("content");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileSerializationRoundtripWorks()
    {
        Rubric value = new BetaManagedAgentsFileRubric("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextSerializationRoundtripWorks()
    {
        Rubric value = new BetaManagedAgentsTextRubric("content");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileTypeWorks()
    {
        Rubric value = new BetaManagedAgentsFileRubric("file_id");
        Assert.Equal(RubricType.File, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsTextTypeWorks()
    {
        Rubric value = new BetaManagedAgentsTextRubric("content");
        Assert.Equal(RubricType.Text, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Rubric value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RubricType> expectedType = RubricType.Text;

        Assert.Equal(expectedType, value.Type);

        Rubric emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class RubricTypeTest : TestBase
{
    [Theory]
    [InlineData(RubricType.File)]
    [InlineData(RubricType.Text)]
    public void Validation_Works(RubricType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RubricType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RubricType.File)]
    [InlineData(RubricType.Text)]
    public void SerializationRoundtrip_Works(RubricType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RubricType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RubricType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
