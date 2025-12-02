using System.Text.Json;
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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");

        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingBlock { Signature = "signature", Thinking = "thinking" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json);
        Assert.NotNull(deserialized);

        string expectedSignature = "signature";
        string expectedThinking = "thinking";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");

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
}
