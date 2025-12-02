using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaURLPDFSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaURLPDFSource
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
