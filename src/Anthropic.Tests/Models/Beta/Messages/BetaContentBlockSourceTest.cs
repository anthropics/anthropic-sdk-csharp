using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContentBlockSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        BetaContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(json);
        Assert.NotNull(deserialized);

        BetaContentBlockSourceContent expectedContent = "string";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"content\"");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaContentBlockSource { Content = "string" };

        model.Validate();
    }
}
