using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingDelta
        {
            Thinking = "thinking",
            Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\""),
        };

        string expectedThinking = "thinking";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");

        Assert.Equal(expectedThinking, model.Thinking);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
