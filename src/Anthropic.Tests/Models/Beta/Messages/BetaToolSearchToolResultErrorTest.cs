using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\""),
        };

        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
