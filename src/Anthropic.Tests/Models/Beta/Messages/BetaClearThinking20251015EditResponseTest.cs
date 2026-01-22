using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearThinking20251015EditResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearThinking20251015EditResponse
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };

        long expectedClearedInputTokens = 0;
        long expectedClearedThinkingTurns = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("clear_thinking_20251015");

        Assert.Equal(expectedClearedInputTokens, model.ClearedInputTokens);
        Assert.Equal(expectedClearedThinkingTurns, model.ClearedThinkingTurns);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClearThinking20251015EditResponse
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClearThinking20251015EditResponse
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedClearedInputTokens = 0;
        long expectedClearedThinkingTurns = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("clear_thinking_20251015");

        Assert.Equal(expectedClearedInputTokens, deserialized.ClearedInputTokens);
        Assert.Equal(expectedClearedThinkingTurns, deserialized.ClearedThinkingTurns);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClearThinking20251015EditResponse
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClearThinking20251015EditResponse
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };

        BetaClearThinking20251015EditResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
