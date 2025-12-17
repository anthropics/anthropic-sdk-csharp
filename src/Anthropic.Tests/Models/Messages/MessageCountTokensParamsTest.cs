using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCountTokensParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageCountTokensParamsSystem value = new("string");
        value.Validate();
    }

    [Fact]
    public void TextBlockParamsValidationWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
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
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamsSerializationRoundtripWorks()
    {
        MessageCountTokensParamsSystem value = new(
            [
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
                },
            ]
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensParamsSystem>(json);

        Assert.Equal(value, deserialized);
    }
}
