using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class Base64ImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Base64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.ImageJPEG;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Base64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Base64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(element);
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.ImageJPEG;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Base64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
        };

        model.Validate();
    }
}

public class MediaTypeTest : TestBase
{
    [Theory]
    [InlineData(MediaType.ImageJPEG)]
    [InlineData(MediaType.ImagePNG)]
    [InlineData(MediaType.ImageGIF)]
    [InlineData(MediaType.ImageWebP)]
    public void Validation_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MediaType.ImageJPEG)]
    [InlineData(MediaType.ImagePNG)]
    [InlineData(MediaType.ImageGIF)]
    [InlineData(MediaType.ImageWebP)]
    public void SerializationRoundtrip_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
