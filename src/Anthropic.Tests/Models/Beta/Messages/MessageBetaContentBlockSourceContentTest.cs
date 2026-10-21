using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageBetaContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void TextBlockParamValidationWorks()
    {
        MessageBetaContentBlockSourceContent value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new BetaCitationCharLocationParam()
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
        MessageBetaContentBlockSourceContent value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
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
        MessageBetaContentBlockSourceContent value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new BetaCitationCharLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageBlockParamSerializationRoundtripWorks()
    {
        MessageBetaContentBlockSourceContent value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamTypeWorks()
    {
        MessageBetaContentBlockSourceContent value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new BetaCitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        Assert.Equal(MessageBetaContentBlockSourceContentType.Text, value.Type.Value());
    }

    [Fact]
    public void ImageBlockParamTypeWorks()
    {
        MessageBetaContentBlockSourceContent value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        Assert.Equal(MessageBetaContentBlockSourceContentType.Image, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        MessageBetaContentBlockSourceContent value = new(
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

        ApiEnum<string, MessageBetaContentBlockSourceContentType> expectedType =
            MessageBetaContentBlockSourceContentType.Text;
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedCacheControl, value.CacheControl);

        MessageBetaContentBlockSourceContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CacheControl);

        MessageBetaContentBlockSourceContent mismatchedValue = new(
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

public class MessageBetaContentBlockSourceContentTypeTest : TestBase
{
    [Theory]
    [InlineData(MessageBetaContentBlockSourceContentType.Text)]
    [InlineData(MessageBetaContentBlockSourceContentType.Image)]
    public void Validation_Works(MessageBetaContentBlockSourceContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageBetaContentBlockSourceContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MessageBetaContentBlockSourceContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageBetaContentBlockSourceContentType.Text)]
    [InlineData(MessageBetaContentBlockSourceContentType.Image)]
    public void SerializationRoundtrip_Works(MessageBetaContentBlockSourceContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageBetaContentBlockSourceContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MessageBetaContentBlockSourceContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MessageBetaContentBlockSourceContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MessageBetaContentBlockSourceContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
