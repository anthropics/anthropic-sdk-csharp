using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CitationsWebSearchResultLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CitationsWebSearchResultLocation
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\""),
            URL = "url",
        };

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedURL = "url";

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEncryptedIndex, model.EncryptedIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }
}
