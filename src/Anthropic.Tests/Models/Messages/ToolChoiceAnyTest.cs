using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceAnyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceAny
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
