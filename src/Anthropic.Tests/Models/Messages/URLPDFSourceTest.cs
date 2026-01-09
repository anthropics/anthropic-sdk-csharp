using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class URLPDFSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new URLPDFSource { URL = "url" };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedURL = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedURL, model.URL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new URLPDFSource { URL = "url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<URLPDFSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new URLPDFSource { URL = "url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<URLPDFSource>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedURL = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedURL, deserialized.URL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new URLPDFSource { URL = "url" };

        model.Validate();
    }
}
