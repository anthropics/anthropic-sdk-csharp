using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultError
        {
            ErrorCode = WebSearchToolResultErrorErrorCode.InvalidToolInput,
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\""),
        };

        ApiEnum<string, WebSearchToolResultErrorErrorCode> expectedErrorCode =
            WebSearchToolResultErrorErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
