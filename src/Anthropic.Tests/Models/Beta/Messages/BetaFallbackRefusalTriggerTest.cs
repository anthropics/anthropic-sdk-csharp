using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackRefusalTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackRefusalTrigger
        {
            Category = BetaFallbackRefusalTriggerCategory.Cyber,
        };

        ApiEnum<string, BetaFallbackRefusalTriggerCategory> expectedCategory =
            BetaFallbackRefusalTriggerCategory.Cyber;
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedCategory, model.Category);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackRefusalTrigger
        {
            Category = BetaFallbackRefusalTriggerCategory.Cyber,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackRefusalTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackRefusalTrigger
        {
            Category = BetaFallbackRefusalTriggerCategory.Cyber,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackRefusalTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaFallbackRefusalTriggerCategory> expectedCategory =
            BetaFallbackRefusalTriggerCategory.Cyber;
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackRefusalTrigger
        {
            Category = BetaFallbackRefusalTriggerCategory.Cyber,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackRefusalTrigger
        {
            Category = BetaFallbackRefusalTriggerCategory.Cyber,
        };

        BetaFallbackRefusalTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaFallbackRefusalTriggerCategoryTest : TestBase
{
    [Theory]
    [InlineData(BetaFallbackRefusalTriggerCategory.Cyber)]
    [InlineData(BetaFallbackRefusalTriggerCategory.Bio)]
    [InlineData(BetaFallbackRefusalTriggerCategory.FrontierLlm)]
    [InlineData(BetaFallbackRefusalTriggerCategory.ReasoningExtraction)]
    [InlineData(BetaFallbackRefusalTriggerCategory.MilitaryWeapons)]
    public void Validation_Works(BetaFallbackRefusalTriggerCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaFallbackRefusalTriggerCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackRefusalTriggerCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaFallbackRefusalTriggerCategory.Cyber)]
    [InlineData(BetaFallbackRefusalTriggerCategory.Bio)]
    [InlineData(BetaFallbackRefusalTriggerCategory.FrontierLlm)]
    [InlineData(BetaFallbackRefusalTriggerCategory.ReasoningExtraction)]
    [InlineData(BetaFallbackRefusalTriggerCategory.MilitaryWeapons)]
    public void SerializationRoundtrip_Works(BetaFallbackRefusalTriggerCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaFallbackRefusalTriggerCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaFallbackRefusalTriggerCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaFallbackRefusalTriggerCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaFallbackRefusalTriggerCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
