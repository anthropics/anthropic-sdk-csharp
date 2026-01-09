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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StopReason.EndTurn)]
    [InlineData(StopReason.MaxTokens)]
    [InlineData(StopReason.StopSequence)]
    [InlineData(StopReason.ToolUse)]
    [InlineData(StopReason.PauseTurn)]
    [InlineData(StopReason.Refusal)]
    public void SerializationRoundtrip_Works(StopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
