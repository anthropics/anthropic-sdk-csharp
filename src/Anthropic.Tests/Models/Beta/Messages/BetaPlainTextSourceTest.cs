using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaPlainTextSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPlainTextSource { Data = "data" };

        string expectedData = "data";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, model.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPlainTextSource { Data = "data" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPlainTextSource { Data = "data" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(json);
        Assert.NotNull(deserialized);

        string expectedData = "data";
        JsonElement expectedMediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedMediaType, deserialized.MediaType));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPlainTextSource { Data = "data" };

        model.Validate();
    }
}
