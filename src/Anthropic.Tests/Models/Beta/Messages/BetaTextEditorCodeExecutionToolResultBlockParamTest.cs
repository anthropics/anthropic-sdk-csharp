using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultBlockParam
        {
            Content = new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_tool_result\""
            ),
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        BetaTextEditorCodeExecutionToolResultBlockParamContent expectedContent =
            new BetaTextEditorCodeExecutionToolResultErrorParam()
            {
                ErrorCode =
                    BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }
}
