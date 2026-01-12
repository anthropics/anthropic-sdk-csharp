using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBase64PdfSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBase64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>(
            "\"application/pdf\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBase64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBase64PdfSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBase64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaBase64PdfSource>(element);
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>(
            "\"application/pdf\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"base64\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, deserialized.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBase64PdfSource { Data = "U3RhaW5sZXNzIHJvY2tz" };

        model.Validate();
    }
}
