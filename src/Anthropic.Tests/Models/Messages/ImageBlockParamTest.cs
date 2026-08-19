using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ImageBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        ImageBlockParamSource expectedSource = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ImageTransformationsParam expectedTransformations = new()
        {
            OversizedImage = OversizedImage.Downsize,
        };

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedTransformations, model.Transformations);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ImageBlockParamSource expectedSource = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ImageTransformationsParam expectedTransformations = new()
        {
            OversizedImage = OversizedImage.Downsize,
        };

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedTransformations, deserialized.Transformations);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Transformations);
        Assert.False(model.RawData.ContainsKey("transformations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },

            CacheControl = null,
            Transformations = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Transformations);
        Assert.True(model.RawData.ContainsKey("transformations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },

            CacheControl = null,
            Transformations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        ImageBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageBlockParamSourceTest : TestBase
{
    [Fact]
    public void Base64ImageValidationWorks()
    {
        ImageBlockParamSource value = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        value.Validate();
    }

    [Fact]
    public void UrlImageValidationWorks()
    {
        ImageBlockParamSource value = new UrlImageSource("url");
        value.Validate();
    }

    [Fact]
    public void FileImageValidationWorks()
    {
        ImageBlockParamSource value = new FileImageSource("file_id");
        value.Validate();
    }

    [Fact]
    public void Base64ImageSerializationRoundtripWorks()
    {
        ImageBlockParamSource value = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlImageSerializationRoundtripWorks()
    {
        ImageBlockParamSource value = new UrlImageSource("url");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileImageSerializationRoundtripWorks()
    {
        ImageBlockParamSource value = new FileImageSource("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
