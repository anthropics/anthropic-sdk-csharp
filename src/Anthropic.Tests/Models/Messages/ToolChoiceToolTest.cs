using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceTool
        {
            Name = "name",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool\""),
            DisableParallelToolUse = true,
        };

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool\"");
        bool expectedDisableParallelToolUse = true;

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }
}
