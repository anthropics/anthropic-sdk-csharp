using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAuto() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAny() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAuto() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAny() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTypeWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAuto() { DisableParallelToolUse = true };
        Assert.Equal(BetaToolChoiceType.Auto, value.Type.Value());
    }

    [Fact]
    public void AnyTypeWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAny() { DisableParallelToolUse = true };
        Assert.Equal(BetaToolChoiceType.Any, value.Type.Value());
    }

    [Fact]
    public void ToolTypeWorks()
    {
        BetaToolChoice value = new BetaToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        Assert.Equal(BetaToolChoiceType.Tool, value.Type.Value());
    }

    [Fact]
    public void NoneTypeWorks()
    {
        BetaToolChoice value = new BetaToolChoiceNone();
        Assert.Equal(BetaToolChoiceType.None, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaToolChoice value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "auto",
                  "disable_parallel_tool_use": true
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaToolChoiceType> expectedType = BetaToolChoiceType.Auto;
        bool expectedDisableParallelToolUse = true;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedDisableParallelToolUse, value.DisableParallelToolUse);

        BetaToolChoice emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.DisableParallelToolUse);

        BetaToolChoice mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "disable_parallel_tool_use": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.DisableParallelToolUse);
    }
}

public class BetaToolChoiceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaToolChoiceType.Auto)]
    [InlineData(BetaToolChoiceType.Any)]
    [InlineData(BetaToolChoiceType.Tool)]
    [InlineData(BetaToolChoiceType.None)]
    public void Validation_Works(BetaToolChoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolChoiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaToolChoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaToolChoiceType.Auto)]
    [InlineData(BetaToolChoiceType.Any)]
    [InlineData(BetaToolChoiceType.Tool)]
    [InlineData(BetaToolChoiceType.None)]
    public void SerializationRoundtrip_Works(BetaToolChoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolChoiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaToolChoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaToolChoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaToolChoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
