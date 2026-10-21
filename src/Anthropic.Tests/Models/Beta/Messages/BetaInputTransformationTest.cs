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
    public void ThinkingDroppedTypeWorks()
    {
        BetaInputTransformation value = new BetaThinkingDroppedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };
        Assert.Equal(BetaInputTransformationType.ThinkingDropped, value.Type.Value());
    }

    [Fact]
    public void ThinkingMismatchAllowedTypeWorks()
    {
        BetaInputTransformation value = new BetaThinkingMismatchAllowedInputTransformation()
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };
        Assert.Equal(BetaInputTransformationType.ThinkingMismatchAllowed, value.Type.Value());
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
        ApiEnum<string, BetaInputTransformationType> expectedType =
            BetaInputTransformationType.ThinkingDropped;

        Assert.Equal(expectedPath, value.Path);
        Assert.Equal(expectedType, value.Type);

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

public class BetaInputTransformationTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaInputTransformationType.ThinkingDropped)]
    [InlineData(BetaInputTransformationType.ThinkingMismatchAllowed)]
    public void Validation_Works(BetaInputTransformationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaInputTransformationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaInputTransformationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaInputTransformationType.ThinkingDropped)]
    [InlineData(BetaInputTransformationType.ThinkingMismatchAllowed)]
    public void SerializationRoundtrip_Works(BetaInputTransformationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaInputTransformationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaInputTransformationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaInputTransformationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaInputTransformationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
