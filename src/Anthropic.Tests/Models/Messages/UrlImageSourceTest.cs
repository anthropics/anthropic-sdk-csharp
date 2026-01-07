using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class UrlImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlImageSource { Url = "url" };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlImageSource { Url = "url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UrlImageSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlImageSource { Url = "url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UrlImageSource>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlImageSource { Url = "url" };

        model.Validate();
    }
}
