using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class PlainTextSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlainTextSource
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
