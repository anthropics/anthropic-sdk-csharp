using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingTurnsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingTurns
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\""),
            Value = 1,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"");
        long expectedValue = 1;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }
}
