using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextBlockParam
        {
            Text = "x",
            Type = JsonSerializer.Deserialize<JsonElement>("\"text\""),
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
        };

        string expectedText = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        List<TextCitationParam> expectedCitations =
        [
            new CitationCharLocationParam()
            {
                CitedText = "cited_text",
                DocumentIndex = 0,
                DocumentTitle = "x",
                EndCharIndex = 0,
                StartCharIndex = 0,
            },
        ];

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations.Count, model.Citations.Count);
        for (int i = 0; i < expectedCitations.Count; i++)
        {
            Assert.Equal(expectedCitations[i], model.Citations[i]);
        }
    }
}
