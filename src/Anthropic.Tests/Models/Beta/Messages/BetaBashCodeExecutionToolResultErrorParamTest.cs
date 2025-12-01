using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBashCodeExecutionToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBashCodeExecutionToolResultErrorParam
        {
            ErrorCode = BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>(
                "\"bash_code_execution_tool_result_error\""
            ),
        };

        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> expectedErrorCode =
            BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
