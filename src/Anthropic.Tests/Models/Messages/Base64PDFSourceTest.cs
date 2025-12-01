using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class Base64PDFSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Base64PDFSource
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
