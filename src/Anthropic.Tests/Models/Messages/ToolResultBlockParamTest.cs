using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\""),
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        ToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
    }
}
