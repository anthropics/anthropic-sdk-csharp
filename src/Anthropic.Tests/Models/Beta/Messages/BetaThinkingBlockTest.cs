using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

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
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(
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
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        BetaThinkingBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
