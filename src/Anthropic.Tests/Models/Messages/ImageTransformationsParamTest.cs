using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ImageTransformationsParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageTransformationsParam { OversizedImage = OversizedImage.Downsize };

        ApiEnum<string, OversizedImage> expectedOversizedImage = OversizedImage.Downsize;

        Assert.Equal(expectedOversizedImage, model.OversizedImage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageTransformationsParam { OversizedImage = OversizedImage.Downsize };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageTransformationsParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageTransformationsParam { OversizedImage = OversizedImage.Downsize };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageTransformationsParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, OversizedImage> expectedOversizedImage = OversizedImage.Downsize;

        Assert.Equal(expectedOversizedImage, deserialized.OversizedImage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageTransformationsParam { OversizedImage = OversizedImage.Downsize };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageTransformationsParam { };

        Assert.Null(model.OversizedImage);
        Assert.False(model.RawData.ContainsKey("oversized_image"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageTransformationsParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageTransformationsParam
        {
            // Null should be interpreted as omitted for these properties
            OversizedImage = null,
        };

        Assert.Null(model.OversizedImage);
        Assert.False(model.RawData.ContainsKey("oversized_image"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageTransformationsParam
        {
            // Null should be interpreted as omitted for these properties
            OversizedImage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageTransformationsParam { OversizedImage = OversizedImage.Downsize };

        ImageTransformationsParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OversizedImageTest : TestBase
{
    [Theory]
    [InlineData(OversizedImage.Downsize)]
    [InlineData(OversizedImage.Error)]
    public void Validation_Works(OversizedImage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OversizedImage> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OversizedImage>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OversizedImage.Downsize)]
    [InlineData(OversizedImage.Error)]
    public void SerializationRoundtrip_Works(OversizedImage rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OversizedImage> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OversizedImage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OversizedImage>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OversizedImage>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
