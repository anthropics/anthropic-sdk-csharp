using System.Text.Json;
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
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_thinking_20251015\""
        );

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015EditResponse>(json);
        Assert.NotNull(deserialized);

        long expectedClearedInputTokens = 0;
        long expectedClearedThinkingTurns = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_thinking_20251015\""
        );

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
}
