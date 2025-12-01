using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultErrorBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result_error\""),
        };

        ApiEnum<string, BetaWebFetchToolResultErrorCode> expectedErrorCode =
            BetaWebFetchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
