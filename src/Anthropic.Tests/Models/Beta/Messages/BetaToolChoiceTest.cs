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

        JsonElement expectedType = JsonSerializer.SerializeToElement("auto");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
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
