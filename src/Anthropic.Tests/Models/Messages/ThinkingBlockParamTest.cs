using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingBlockParam { Signature = "signature", Thinking = "thinking" };

        string expectedSignature = "signature";
        string expectedThinking = "thinking";
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking");

        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingBlockParam { Signature = "signature", Thinking = "thinking" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingBlockParam { Signature = "signature", Thinking = "thinking" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSignature = "signature";
        string expectedThinking = "thinking";
        JsonElement expectedType = JsonSerializer.SerializeToElement("thinking");

        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingBlockParam { Signature = "signature", Thinking = "thinking" };

        model.Validate();
    }
}
