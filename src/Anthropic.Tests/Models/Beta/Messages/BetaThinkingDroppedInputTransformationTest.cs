using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingDroppedInputTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingDroppedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };

        string expectedPath = "path";
        ApiEnum<string, BetaThinkingDroppedInputTransformationReason> expectedReason =
            BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking_dropped");

        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingDroppedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingDroppedInputTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingDroppedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingDroppedInputTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        ApiEnum<string, BetaThinkingDroppedInputTransformationReason> expectedReason =
            BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking_dropped");

        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingDroppedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingDroppedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
        };

        BetaThinkingDroppedInputTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaThinkingDroppedInputTransformationReasonTest : TestBase
{
    [Theory]
    [InlineData(BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.PrefixBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.OrganizationBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.EndUserBindingMismatch)]
    public void Validation_Works(BetaThinkingDroppedInputTransformationReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingDroppedInputTransformationReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingDroppedInputTransformationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.PrefixBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.OrganizationBindingMismatch)]
    [InlineData(BetaThinkingDroppedInputTransformationReason.EndUserBindingMismatch)]
    public void SerializationRoundtrip_Works(BetaThinkingDroppedInputTransformationReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingDroppedInputTransformationReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingDroppedInputTransformationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingDroppedInputTransformationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingDroppedInputTransformationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
