using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearToolUses20250919EditResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919EditResponse
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\""),
        };

        long expectedClearedInputTokens = 0;
        long expectedClearedToolUses = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );

        Assert.Equal(expectedClearedInputTokens, model.ClearedInputTokens);
        Assert.Equal(expectedClearedToolUses, model.ClearedToolUses);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
