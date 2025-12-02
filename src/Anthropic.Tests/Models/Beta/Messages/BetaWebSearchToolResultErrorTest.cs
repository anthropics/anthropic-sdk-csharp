using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultError
        {
            ErrorCode = BetaWebSearchToolResultErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\""),
        };

        ApiEnum<string, BetaWebSearchToolResultErrorCode> expectedErrorCode =
            BetaWebSearchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
