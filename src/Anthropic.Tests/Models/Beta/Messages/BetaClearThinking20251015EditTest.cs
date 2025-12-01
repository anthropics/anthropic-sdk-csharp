using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearThinking20251015EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearThinking20251015Edit
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\""),
            Keep = new BetaThinkingTurns(1),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_thinking_20251015\""
        );
        Keep expectedKeep = new BetaThinkingTurns(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedKeep, model.Keep);
    }
}
