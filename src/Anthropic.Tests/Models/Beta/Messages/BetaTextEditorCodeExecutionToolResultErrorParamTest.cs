using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"text_editor_code_execution_tool_result_error\""
            ),
            ErrorMessage = "error_message",
        };

        ApiEnum<
            string,
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
        > expectedErrorCode =
            BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }
}
