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
    [InlineData(BetaStopReason.EndTurn)]
    [InlineData(BetaStopReason.MaxTokens)]
    [InlineData(BetaStopReason.StopSequence)]
    [InlineData(BetaStopReason.ToolUse)]
    [InlineData(BetaStopReason.PauseTurn)]
    [InlineData(BetaStopReason.Refusal)]
    [InlineData(BetaStopReason.ModelContextWindowExceeded)]
    public void SerializationRoundtrip_Works(BetaStopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaStopReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaStopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
