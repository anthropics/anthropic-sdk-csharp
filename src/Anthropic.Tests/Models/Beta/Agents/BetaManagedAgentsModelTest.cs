using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsModelTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5_2)]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku5_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet5_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus5_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5_1)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet5)]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus5)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_8)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_7)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_6)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_6)]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5_20251001)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5_20251101)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5_20250929)]
    public void Validation_Works(BetaManagedAgentsModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5_2, 0, "claude-fable-5-2")]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku5_5, 1, "claude-haiku-5-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet5_5, 2, "claude-sonnet-5-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus5_5, 3, "claude-opus-5-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5_1, 4, "claude-fable-5-1")]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet5, 5, "claude-sonnet-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeFable5, 6, "claude-fable-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus5, 7, "claude-opus-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_8, 8, "claude-opus-4-8")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_7, 9, "claude-opus-4-7")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_6, 10, "claude-opus-4-6")]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_6, 11, "claude-sonnet-4-6")]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5, 12, "claude-haiku-4-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5_20251001, 13, "claude-haiku-4-5-20251001")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5, 14, "claude-opus-4-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5_20251101, 15, "claude-opus-4-5-20251101")]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5, 16, "claude-sonnet-4-5")]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5_20250929, 17, "claude-sonnet-4-5-20250929")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaManagedAgentsModel rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsModel> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
