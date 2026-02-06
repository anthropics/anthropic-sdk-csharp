using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputTokensTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInputTokensTrigger { ValueValue = 1 };

        JsonElement expectedType = JsonSerializer.SerializeToElement("input_tokens");
        long expectedValueValue = 1;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedValueValue, model.ValueValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaInputTokensTrigger { ValueValue = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaInputTokensTrigger { ValueValue = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("input_tokens");
        long expectedValueValue = 1;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedValueValue, deserialized.ValueValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaInputTokensTrigger { ValueValue = 1 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaInputTokensTrigger { ValueValue = 1 };

        BetaInputTokensTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}
