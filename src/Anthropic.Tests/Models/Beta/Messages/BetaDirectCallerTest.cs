using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaDirectCallerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDirectCaller
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"direct\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"direct\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
