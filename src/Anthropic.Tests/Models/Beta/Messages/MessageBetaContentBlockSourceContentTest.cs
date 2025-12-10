using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class MessageBetaContentBlockSourceContentTest : TestBase
{
    [Fact]
    public void text_block_paramValidation_Works()
    {
        MessageBetaContentBlockSourceContent value = new(
            new()
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
    public void image_block_paramValidation_Works()
    {
        MessageBetaContentBlockSourceContent value = new(
            new()
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
    public void text_block_paramSerializationRoundtrip_Works()
    {
        MessageBetaContentBlockSourceContent value = new(
            new()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void image_block_paramSerializationRoundtrip_Works()
    {
        MessageBetaContentBlockSourceContent value = new(
            new()
            {
                Source = new BetaBase64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBetaContentBlockSourceContent>(json);

        Assert.Equal(value, deserialized);
    }
}
