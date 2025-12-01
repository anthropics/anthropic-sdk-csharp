using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolReferenceBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolReferenceBlock
        {
            ToolName = "tool_name",
            Type = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\""),
        };

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");

        Assert.Equal(expectedToolName, model.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
