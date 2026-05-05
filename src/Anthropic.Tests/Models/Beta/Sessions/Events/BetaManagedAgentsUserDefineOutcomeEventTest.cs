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
            ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
        };

        string expectedID = "sevt_011CZkZSTx3lFgt7odUWmkyq";
        string expectedDescription = "Produce a 2-page summary as summary.md";
        int expectedMaxIterations = 3;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        Rubric expectedRubric = new BetaManagedAgentsTextRubric()
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricType.Text,
        };
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType> expectedType =
            BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMaxIterations, model.MaxIterations);
        Assert.Equal(expectedOutcomeID, model.OutcomeID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedRubric, model.Rubric);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
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
            ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZSTx3lFgt7odUWmkyq";
        string expectedDescription = "Produce a 2-page summary as summary.md";
        int expectedMaxIterations = 3;
        string expectedOutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z");
        Rubric expectedRubric = new BetaManagedAgentsTextRubric()
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricType.Text,
        };
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType> expectedType =
            BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMaxIterations, deserialized.MaxIterations);
        Assert.Equal(expectedOutcomeID, deserialized.OutcomeID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedRubric, deserialized.Rubric);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEvent
        {
            ID = "sevt_011CZkZSTx3lFgt7odUWmkyq",
            Description = "Produce a 2-page summary as summary.md",
            MaxIterations = 3,
            OutcomeID = "outc_011CZkZRSw2kEfs6ncTVljxP",
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:02:14Z"),
            Rubric = new BetaManagedAgentsTextRubric()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome,
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
        Rubric value = new BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileRubricType.File,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextValidationWorks()
    {
        Rubric value = new BetaManagedAgentsTextRubric()
        {
            Content = "content",
            Type = BetaManagedAgentsTextRubricType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileSerializationRoundtripWorks()
    {
        Rubric value = new BetaManagedAgentsFileRubric()
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileRubricType.File,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextSerializationRoundtripWorks()
    {
        Rubric value = new BetaManagedAgentsTextRubric()
        {
            Content = "content",
            Type = BetaManagedAgentsTextRubricType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rubric>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserDefineOutcomeEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome)]
    public void Validation_Works(BetaManagedAgentsUserDefineOutcomeEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserDefineOutcomeEventType.UserDefineOutcome)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUserDefineOutcomeEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
