using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsTokenTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens)]
    [InlineData(BetaAnalyticsTokenType.CacheCreationEphemeral5mInputTokens)]
    [InlineData(BetaAnalyticsTokenType.CacheReadInputTokens)]
    [InlineData(BetaAnalyticsTokenType.OutputTokens)]
    [InlineData(BetaAnalyticsTokenType.UncachedInputTokens)]
    public void Validation_Works(BetaAnalyticsTokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTokenType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens)]
    [InlineData(BetaAnalyticsTokenType.CacheCreationEphemeral5mInputTokens)]
    [InlineData(BetaAnalyticsTokenType.CacheReadInputTokens)]
    [InlineData(BetaAnalyticsTokenType.OutputTokens)]
    [InlineData(BetaAnalyticsTokenType.UncachedInputTokens)]
    public void SerializationRoundtrip_Works(BetaAnalyticsTokenType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTokenType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTokenType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTokenType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
