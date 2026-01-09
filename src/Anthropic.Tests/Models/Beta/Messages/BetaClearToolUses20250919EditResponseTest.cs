using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearToolUses20250919EditResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919EditResponse
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };

        long expectedClearedInputTokens = 0;
        long expectedClearedToolUses = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );

        Assert.Equal(expectedClearedInputTokens, model.ClearedInputTokens);
        Assert.Equal(expectedClearedToolUses, model.ClearedToolUses);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919EditResponse
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919EditResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClearToolUses20250919EditResponse
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919EditResponse>(
            element
        );
        Assert.NotNull(deserialized);

        long expectedClearedInputTokens = 0;
        long expectedClearedToolUses = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );

        Assert.Equal(expectedClearedInputTokens, deserialized.ClearedInputTokens);
        Assert.Equal(expectedClearedToolUses, deserialized.ClearedToolUses);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClearToolUses20250919EditResponse
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };

        model.Validate();
    }
}
