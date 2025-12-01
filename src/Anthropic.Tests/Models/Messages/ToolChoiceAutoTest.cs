using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceAutoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceAuto
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"auto\""),
            DisableParallelToolUse = true,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }
}
