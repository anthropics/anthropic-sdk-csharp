using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultBlock
        {
            Content = new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result\""),
        };

        BetaCodeExecutionToolResultBlockContent expectedContent =
            new BetaCodeExecutionToolResultError(
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput
            );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
