using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void text_block_paramValidation_Works()
    {
        ContentBlockSourceContent value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void image_block_paramValidation_Works()
    {
        ContentBlockSourceContent value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
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
    public void text_block_paramSerializationRoundtrip_Works()
    {
        ContentBlockSourceContent value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void image_block_paramSerializationRoundtrip_Works()
    {
        ContentBlockSourceContent value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }
}
