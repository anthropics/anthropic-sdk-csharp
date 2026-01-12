using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaUrlImageSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUrlImageSource { Url = "url" };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUrlImageSource { Url = "url" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaUrlImageSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUrlImageSource { Url = "url" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaUrlImageSource>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"url\"");
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUrlImageSource { Url = "url" };

        model.Validate();
    }
}
