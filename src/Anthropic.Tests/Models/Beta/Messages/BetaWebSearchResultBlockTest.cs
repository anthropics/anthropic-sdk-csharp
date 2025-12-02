using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchResultBlock
        {
            EncryptedContent = "encrypted_content",
            PageAge = "page_age",
            Title = "title",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\""),
            URL = "url",
        };

        string expectedEncryptedContent = "encrypted_content";
        string expectedPageAge = "page_age";
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
        string expectedURL = "url";

        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedPageAge, model.PageAge);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }
}
