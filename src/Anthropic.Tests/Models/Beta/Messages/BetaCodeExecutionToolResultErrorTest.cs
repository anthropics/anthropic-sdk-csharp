using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionToolResultError
        {
            ErrorCode = BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result_error\""),
        };

        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> expectedErrorCode =
            BetaCodeExecutionToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
