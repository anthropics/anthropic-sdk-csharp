using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class SearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchResultBlockParam
        {
            Content =
            [
                new()
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
            ],
            Source = "source",
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Citations = new() { Enabled = true },
        };

        List<TextBlockParam> expectedContent =
        [
            new()
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
        ];
        string expectedSource = "source";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
    }
}
