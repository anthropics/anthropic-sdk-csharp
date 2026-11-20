using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaStopReasonTest : TestBase
{
    [Theory]
    [InlineData(BetaStopReason.EndTurn)]
    [InlineData(BetaStopReason.MaxTokens)]
    [InlineData(BetaStopReason.StopSequence)]
    [InlineData(BetaStopReason.ToolUse)]
    [InlineData(BetaStopReason.PauseTurn)]
    [InlineData(BetaStopReason.Compaction)]
    [InlineData(BetaStopReason.Refusal)]
    [InlineData(BetaStopReason.ModelContextWindowExceeded)]
    public void Validation_Works(BetaStopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStopReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaStopReason.EndTurn, 0, "end_turn")]
    [InlineData(BetaStopReason.MaxTokens, 1, "max_tokens")]
    [InlineData(BetaStopReason.StopSequence, 2, "stop_sequence")]
    [InlineData(BetaStopReason.ToolUse, 3, "tool_use")]
    [InlineData(BetaStopReason.PauseTurn, 4, "pause_turn")]
    [InlineData(BetaStopReason.Compaction, 5, "compaction")]
    [InlineData(BetaStopReason.Refusal, 6, "refusal")]
    [InlineData(BetaStopReason.ModelContextWindowExceeded, 7, "model_context_window_exceeded")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaStopReason rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStopReason> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStopReason>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaStopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
