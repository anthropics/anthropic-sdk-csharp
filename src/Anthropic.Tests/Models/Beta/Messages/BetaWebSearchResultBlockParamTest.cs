using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlockParam
        {
            EncryptedContent = "encrypted_content",
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\""),
            URL = "url",
            PageAge = "page_age",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedURL = "url";
        string expectedPageAge = "page_age";

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedPageAge, model.PageAge);
    }
}
