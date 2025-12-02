using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMCPToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMCPToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
            Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\""),
        };

        BetaMCPToolResultBlockContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
