using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        ToolChoice value = new ToolChoiceAuto() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        ToolChoice value = new ToolChoiceAny() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        ToolChoice value = new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        ToolChoice value = new ToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceAuto() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceAny() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoTypeWorks()
    {
        ToolChoice value = new ToolChoiceAuto() { DisableParallelToolUse = true };
        Assert.Equal(ToolChoiceType.Auto, value.Type.Value());
    }

    [Fact]
    public void AnyTypeWorks()
    {
        ToolChoice value = new ToolChoiceAny() { DisableParallelToolUse = true };
        Assert.Equal(ToolChoiceType.Any, value.Type.Value());
    }

    [Fact]
    public void ToolTypeWorks()
    {
        ToolChoice value = new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true };
        Assert.Equal(ToolChoiceType.Tool, value.Type.Value());
    }

    [Fact]
    public void NoneTypeWorks()
    {
        ToolChoice value = new ToolChoiceNone();
        Assert.Equal(ToolChoiceType.None, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ToolChoice value = new(
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

        ApiEnum<string, ToolChoiceType> expectedType = ToolChoiceType.Auto;
        bool expectedDisableParallelToolUse = true;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedDisableParallelToolUse, value.DisableParallelToolUse);

        ToolChoice emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.DisableParallelToolUse);

        ToolChoice mismatchedValue = new(
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

public class ToolChoiceTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolChoiceType.Auto)]
    [InlineData(ToolChoiceType.Any)]
    [InlineData(ToolChoiceType.Tool)]
    [InlineData(ToolChoiceType.None)]
    public void Validation_Works(ToolChoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolChoiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolChoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolChoiceType.Auto)]
    [InlineData(ToolChoiceType.Any)]
    [InlineData(ToolChoiceType.Tool)]
    [InlineData(ToolChoiceType.None)]
    public void SerializationRoundtrip_Works(ToolChoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolChoiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolChoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolChoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolChoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
