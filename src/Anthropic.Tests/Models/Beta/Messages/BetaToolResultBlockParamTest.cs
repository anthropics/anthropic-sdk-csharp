using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
    }
}
