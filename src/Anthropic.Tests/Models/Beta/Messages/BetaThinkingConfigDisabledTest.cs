using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingConfigDisabled
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"disabled\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
