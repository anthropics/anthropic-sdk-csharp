using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaImageBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        BetaImageBlockParamSource expectedSource = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaImageTransformationsParam expectedTransformations = new()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaImageBlockParamSource expectedSource = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaImageTransformationsParam expectedTransformations = new()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };

        BetaImageBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaImageBlockParamSourceTest : TestBase
{
    [Fact]
    public void BetaBase64ImageValidationWorks()
    {
        BetaImageBlockParamSource value = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        value.Validate();
    }

    [Fact]
    public void BetaUrlImageValidationWorks()
    {
        BetaImageBlockParamSource value = new BetaUrlImageSource("url");
        value.Validate();
    }

    [Fact]
    public void BetaFileImageValidationWorks()
    {
        BetaImageBlockParamSource value = new BetaFileImageSource("file_id");
        value.Validate();
    }

    [Fact]
    public void BetaBase64ImageSerializationRoundtripWorks()
    {
        BetaImageBlockParamSource value = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJpeg,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaUrlImageSerializationRoundtripWorks()
    {
        BetaImageBlockParamSource value = new BetaUrlImageSource("url");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaFileImageSerializationRoundtripWorks()
    {
        BetaImageBlockParamSource value = new BetaFileImageSource("file_id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParamSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
