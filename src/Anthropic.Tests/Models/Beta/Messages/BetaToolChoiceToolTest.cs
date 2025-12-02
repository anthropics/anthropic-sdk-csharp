using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolChoiceTool
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
