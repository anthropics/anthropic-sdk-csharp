using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingConfigDisabled
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"disabled\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
