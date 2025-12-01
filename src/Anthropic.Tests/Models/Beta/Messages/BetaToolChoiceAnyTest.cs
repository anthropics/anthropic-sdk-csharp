using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceAnyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChoiceAny
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"any\""),
            DisableParallelToolUse = true,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"any\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }
}
