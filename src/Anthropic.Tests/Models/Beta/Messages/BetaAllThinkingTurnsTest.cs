using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAllThinkingTurnsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAllThinkingTurns
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"all\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"all\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
