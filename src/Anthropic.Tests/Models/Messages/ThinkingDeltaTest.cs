using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingDelta
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
