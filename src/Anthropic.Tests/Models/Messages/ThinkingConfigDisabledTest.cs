using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigDisabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingConfigDisabled { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingConfigDisabled { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingConfigDisabled { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("disabled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingConfigDisabled { };

        model.Validate();
    }
}
