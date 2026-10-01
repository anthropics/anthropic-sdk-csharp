using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputTransformationTest : TestBase
{
    [Fact]
    public void ThinkingDroppedValidationWorks()
    {
        BetaInputTransformation value = new BetaThinkingDroppedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };
        value.Validate();
    }

    [Fact]
    public void ThinkingMismatchAllowedValidationWorks()
    {
        BetaInputTransformation value = new BetaThinkingMismatchAllowedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };
        value.Validate();
    }

    [Fact]
    public void ThinkingDroppedSerializationRoundtripWorks()
    {
        BetaInputTransformation value = new BetaThinkingDroppedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputTransformation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThinkingMismatchAllowedSerializationRoundtripWorks()
    {
        BetaInputTransformation value = new BetaThinkingMismatchAllowedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputTransformation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaInputTransformation value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "path": "path",
                  "type": "thinking_dropped"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedPath = "path";
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking_dropped");

        Assert.Equal(expectedPath, value.Path);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaInputTransformation emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Path);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaInputTransformation mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "path": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Path);
    }
}
