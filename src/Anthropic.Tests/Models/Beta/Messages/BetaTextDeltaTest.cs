using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextDelta { Text = "text" };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextDelta { Text = "text" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextDelta { Text = "text" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(element);
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");

        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextDelta { Text = "text" };

        model.Validate();
    }
}
