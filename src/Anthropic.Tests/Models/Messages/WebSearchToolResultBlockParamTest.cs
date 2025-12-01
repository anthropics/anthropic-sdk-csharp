using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockParam
        {
            Content = new(
                [
                    new()
                    {
                        EncryptedContent = "encrypted_content",
                        Title = "title",
                        URL = "url",
                        PageAge = "page_age",
                    },
                ]
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result\""),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        WebSearchToolResultBlockParamContent expectedContent = new(
            [
                new()
                {
                    EncryptedContent = "encrypted_content",
                    Title = "title",
                    URL = "url",
                    PageAge = "page_age",
                },
            ]
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
