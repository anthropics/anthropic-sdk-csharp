using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlock
        {
            Content = new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_tool_result\""
            ),
        };

        BetaTextEditorCodeExecutionToolResultBlockContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultError()
            {
                ErrorCode = BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
