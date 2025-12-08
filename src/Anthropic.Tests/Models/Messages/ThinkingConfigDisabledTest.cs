using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingConfigDisabled { };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingConfigDisabled { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingConfigDisabled { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingConfigDisabled { };

        model.Validate();
    }
}
