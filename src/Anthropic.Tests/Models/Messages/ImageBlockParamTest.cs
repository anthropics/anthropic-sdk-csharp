using System.Text.Json;
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
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        ImageBlockParamSource expectedSource = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"image\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json);

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
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json);
        Assert.NotNull(deserialized);

        ImageBlockParamSource expectedSource = new Base64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"image\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
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
                MediaType = MediaType.ImageJPEG,
            },
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
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
                MediaType = MediaType.ImageJPEG,
            },

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageBlockParam
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
            },

            CacheControl = null,
        };

        model.Validate();
    }
}
