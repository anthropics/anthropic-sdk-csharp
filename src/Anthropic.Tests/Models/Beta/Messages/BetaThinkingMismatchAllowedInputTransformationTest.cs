using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingMismatchAllowedInputTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingMismatchAllowedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };

        string expectedPath = "path";
        ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason> expectedReason =
            BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking_mismatch_allowed");

        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedReason, model.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingMismatchAllowedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaThinkingMismatchAllowedInputTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingMismatchAllowedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaThinkingMismatchAllowedInputTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason> expectedReason =
            BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking_mismatch_allowed");

        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingMismatchAllowedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingMismatchAllowedInputTransformation
        {
            Path = "path",
            Reason = BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch,
        };

        BetaThinkingMismatchAllowedInputTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaThinkingMismatchAllowedInputTransformationReasonTest : TestBase
{
    [Theory]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.PrefixBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.OrganizationBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.EndUserBindingMismatch)]
    public void Validation_Works(BetaThinkingMismatchAllowedInputTransformationReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.ModelBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.PrefixBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.OrganizationBindingMismatch)]
    [InlineData(BetaThinkingMismatchAllowedInputTransformationReason.EndUserBindingMismatch)]
    public void SerializationRoundtrip_Works(
        BetaThinkingMismatchAllowedInputTransformationReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaThinkingMismatchAllowedInputTransformationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
