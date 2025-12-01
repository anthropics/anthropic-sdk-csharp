using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMCPToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMCPToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaRequestMCPToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
    }
}
