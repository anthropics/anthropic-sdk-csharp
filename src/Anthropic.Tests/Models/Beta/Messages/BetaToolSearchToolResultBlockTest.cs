using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultBlock
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\""),
        };

        BetaToolSearchToolResultBlockContent expectedContent = new BetaToolSearchToolResultError()
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
