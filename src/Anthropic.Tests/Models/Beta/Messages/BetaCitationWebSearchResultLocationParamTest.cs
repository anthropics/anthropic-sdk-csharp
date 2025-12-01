using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationWebSearchResultLocationParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationWebSearchResultLocationParam
        {
            CitedText = "cited_text",
            EncryptedIndex = "encrypted_index",
            Title = "x",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result_location\""),
            URL = "x",
        };

        string expectedCitedText = "cited_text";
        string expectedEncryptedIndex = "encrypted_index";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_result_location\""
        );
        string expectedURL = "x";

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEncryptedIndex, model.EncryptedIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }
}
