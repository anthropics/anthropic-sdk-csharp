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
    [InlineData(
        BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        0,
        "cache_creation.ephemeral_1h_input_tokens"
    )]
    [InlineData(
        BetaAnalyticsTokenType.CacheCreationEphemeral5mInputTokens,
        1,
        "cache_creation.ephemeral_5m_input_tokens"
    )]
    [InlineData(BetaAnalyticsTokenType.CacheReadInputTokens, 2, "cache_read_input_tokens")]
    [InlineData(BetaAnalyticsTokenType.OutputTokens, 3, "output_tokens")]
    [InlineData(BetaAnalyticsTokenType.UncachedInputTokens, 4, "uncached_input_tokens")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsTokenType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsTokenType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsTokenType>>(
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
