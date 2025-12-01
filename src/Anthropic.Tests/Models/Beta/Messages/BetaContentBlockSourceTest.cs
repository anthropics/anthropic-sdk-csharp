using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContentBlockSource
        {
            Content = "string",
            Type = JsonSerializer.Deserialize<JsonElement>("\"content\""),
        };

        BetaContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
