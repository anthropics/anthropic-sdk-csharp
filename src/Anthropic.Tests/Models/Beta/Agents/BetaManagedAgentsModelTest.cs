using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsModelTest : TestBase
{
    [Theory]
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
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_6)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_6)]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeHaiku4_5_20251001)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeOpus4_5_20251101)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5)]
    [InlineData(BetaManagedAgentsModel.ClaudeSonnet4_5_20250929)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
