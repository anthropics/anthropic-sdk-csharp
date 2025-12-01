using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultErrorParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultErrorParam
        {
            ErrorCode = BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\""),
        };

        ApiEnum<string, BetaToolSearchToolResultErrorParamErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
