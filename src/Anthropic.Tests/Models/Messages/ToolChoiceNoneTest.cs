using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceNoneTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceNone
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"none\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"none\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
