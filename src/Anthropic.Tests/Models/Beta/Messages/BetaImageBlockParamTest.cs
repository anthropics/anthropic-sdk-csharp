using System.Text.Json;
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
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaImageBlockParamSource expectedSource = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"image\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedSource, model.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(json);

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
                MediaType = MediaType.ImageJPEG,
            },
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(json);
        Assert.NotNull(deserialized);

        BetaImageBlockParamSource expectedSource = new BetaBase64ImageSource()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"image\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedSource, deserialized.Source);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
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
        var model = new BetaImageBlockParam
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJPEG,
            },

            CacheControl = null,
        };

        model.Validate();
    }
}
