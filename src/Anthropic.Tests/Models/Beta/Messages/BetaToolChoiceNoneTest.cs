using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceNoneTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChoiceNone
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"none\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"none\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
