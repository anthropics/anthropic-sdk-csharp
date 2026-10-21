using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void TextBlockParamValidationWorks()
    {
        MessageContentBlockSourceContent value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void ImageBlockParamValidationWorks()
    {
        MessageContentBlockSourceContent value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        value.Validate();
    }

    [Fact]
    public void TextBlockParamSerializationRoundtripWorks()
    {
        MessageContentBlockSourceContent value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageBlockParamSerializationRoundtripWorks()
    {
        MessageContentBlockSourceContent value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamTypeWorks()
    {
        MessageContentBlockSourceContent value = new TextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new CitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        Assert.Equal(MessageContentBlockSourceContentType.Text, value.Type.Value());
    }

    [Fact]
    public void ImageBlockParamTypeWorks()
    {
        MessageContentBlockSourceContent value = new ImageBlockParam()
        {
            Source = new Base64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        Assert.Equal(MessageContentBlockSourceContentType.Image, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        MessageContentBlockSourceContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "cache_control": {
                    "type": "ephemeral",
                    "ttl": "5m"
                  }
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, MessageContentBlockSourceContentType> expectedType =
            MessageContentBlockSourceContentType.Text;
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedCacheControl, value.CacheControl);

        MessageContentBlockSourceContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CacheControl);

        MessageContentBlockSourceContent mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheControl);
    }
}

public class MessageContentBlockSourceContentTypeTest : TestBase
{
    [Theory]
    [InlineData(MessageContentBlockSourceContentType.Text)]
    [InlineData(MessageContentBlockSourceContentType.Image)]
    public void Validation_Works(MessageContentBlockSourceContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageContentBlockSourceContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MessageContentBlockSourceContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageContentBlockSourceContentType.Text)]
    [InlineData(MessageContentBlockSourceContentType.Image)]
    public void SerializationRoundtrip_Works(MessageContentBlockSourceContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageContentBlockSourceContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MessageContentBlockSourceContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MessageContentBlockSourceContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MessageContentBlockSourceContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
