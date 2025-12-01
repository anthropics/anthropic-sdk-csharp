using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolUsesTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolUsesTrigger
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\""),
            Value = 1,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
        long expectedValue = 1;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValue, model.Value);
    }
}
