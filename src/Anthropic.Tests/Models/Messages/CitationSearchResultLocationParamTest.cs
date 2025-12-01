using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationSearchResultLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationSearchResultLocationParam
        {
            CitedText = "cited_text",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\""),
        };

        string expectedCitedText = "cited_text";
        long expectedEndBlockIndex = 0;
        long expectedSearchResultIndex = 0;
        string expectedSource = "source";
        long expectedStartBlockIndex = 0;
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"search_result_location\""
        );

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEndBlockIndex, model.EndBlockIndex);
        Assert.Equal(expectedSearchResultIndex, model.SearchResultIndex);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStartBlockIndex, model.StartBlockIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
