using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolUsesKeepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolUsesKeep
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\""),
            Value = 0,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
        long expectedValue = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }
}
