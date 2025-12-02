using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaPlainTextSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPlainTextSource
        {
            Data = "data",
            MediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"text\""),
        };

        string expectedData = "data";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
