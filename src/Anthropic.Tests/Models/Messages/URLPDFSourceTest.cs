using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class URLPDFSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new URLPDFSource
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"url\""),
            URL = "url",
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedURL = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }
}
