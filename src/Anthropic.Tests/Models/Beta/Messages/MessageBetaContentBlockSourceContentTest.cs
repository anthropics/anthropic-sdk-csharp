using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageBetaContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void TextBlockParamValidationWorks()
    {
        MessageBetaContentBlockSourceContent value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        value.Validate();
    }

    [Fact]
    public void ImageBlockParamValidationWorks()
    {
        MessageBetaContentBlockSourceContent value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextBlockParamSerializationRoundtripWorks()
    {
        MessageBetaContentBlockSourceContent value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new BetaCitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageBlockParamSerializationRoundtripWorks()
    {
        MessageBetaContentBlockSourceContent value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
