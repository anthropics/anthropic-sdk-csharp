using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class StopReasonTest : TestBase
{
    [Theory]
    [InlineData(StopReason.EndTurn)]
    [InlineData(StopReason.MaxTokens)]
    [InlineData(StopReason.StopSequence)]
    [InlineData(StopReason.ToolUse)]
    [InlineData(StopReason.PauseTurn)]
    [InlineData(StopReason.Refusal)]
    [InlineData(StopReason.ModelContextWindowExceeded)]
    public void Validation_Works(StopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StopReason.EndTurn, 0, "end_turn")]
    [InlineData(StopReason.MaxTokens, 1, "max_tokens")]
    [InlineData(StopReason.StopSequence, 2, "stop_sequence")]
    [InlineData(StopReason.ToolUse, 3, "tool_use")]
    [InlineData(StopReason.PauseTurn, 4, "pause_turn")]
    [InlineData(StopReason.Refusal, 5, "refusal")]
    [InlineData(StopReason.ModelContextWindowExceeded, 6, "model_context_window_exceeded")]
    public void EnumMemberSerializationRoundtrip_Works(
        StopReason rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReason> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
