using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserDefineOutcomeEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            MaxIterations = 3,
        };

        string expectedDescription = "Produce a 2-page summary as summary.md";
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric expectedRubric =
            new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            };
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType> expectedType =
            BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome;
        int expectedMaxIterations = 3;

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedRubric, model.Rubric);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMaxIterations, model.MaxIterations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            MaxIterations = 3,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEventParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            MaxIterations = 3,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEventParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedDescription = "Produce a 2-page summary as summary.md";
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric expectedRubric =
            new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            };
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType> expectedType =
            BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome;
        int expectedMaxIterations = 3;

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedRubric, deserialized.Rubric);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMaxIterations, deserialized.MaxIterations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            MaxIterations = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
        };

        Assert.Null(model.MaxIterations);
        Assert.False(model.RawData.ContainsKey("max_iterations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,

            MaxIterations = null,
        };

        Assert.Null(model.MaxIterations);
        Assert.True(model.RawData.ContainsKey("max_iterations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,

            MaxIterations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserDefineOutcomeEventParams
        {
            Description = "Produce a 2-page summary as summary.md",
            Rubric = new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            },
            Type = BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome,
            MaxIterations = 3,
        };

        BetaManagedAgentsUserDefineOutcomeEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserDefineOutcomeEventParamsRubricTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsFileRubricParamsValidationWorks()
    {
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric value =
            new BetaManagedAgentsFileRubricParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                Type = BetaManagedAgentsFileRubricParamsType.File,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextRubricParamsValidationWorks()
    {
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric value =
            new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileRubricParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric value =
            new BetaManagedAgentsFileRubricParams()
            {
                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
                Type = BetaManagedAgentsFileRubricParamsType.File,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEventParamsRubric>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextRubricParamsSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserDefineOutcomeEventParamsRubric value =
            new BetaManagedAgentsTextRubricParams()
            {
                Content = "Must cover all five sections; cite sources inline.",
                Type = BetaManagedAgentsTextRubricParamsType.Text,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserDefineOutcomeEventParamsRubric>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserDefineOutcomeEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome)]
    public void Validation_Works(BetaManagedAgentsUserDefineOutcomeEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserDefineOutcomeEventParamsType.UserDefineOutcome)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserDefineOutcomeEventParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserDefineOutcomeEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
