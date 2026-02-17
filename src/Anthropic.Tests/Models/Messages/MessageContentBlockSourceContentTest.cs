using System.Text.Json;
using Anthropic.Core;
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
                    CitedText = "cited_text",
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
                    CitedText = "cited_text",
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageContentBlockSourceContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
