using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBase64ImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBase64ImageSource
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MediaType = MediaType.ImageJPEG,
            Type = JsonSerializer.Deserialize<JsonElement>("\"base64\""),
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.ImageJPEG;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
