using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBase64PDFSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBase64PDFSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = JsonSerializer.Deserialize<JsonElement>("\"application/pdf\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"base64\""),
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>(
            "\"application/pdf\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
