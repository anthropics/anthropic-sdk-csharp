using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.RateLimits;

public class BetaWorkspaceRateLimitTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaWorkspaceRateLimitType.FastItpmca)]
    [InlineData(BetaWorkspaceRateLimitType.FastOtpm)]
    [InlineData(BetaWorkspaceRateLimitType.InputTokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.InputTokensPerMinuteCacheAware)]
    [InlineData(BetaWorkspaceRateLimitType.OutputTokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.RequestsPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerDay)]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.ToolUsesPerSecond)]
    public void Validation_Works(BetaWorkspaceRateLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRateLimitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWorkspaceRateLimitType.FastItpmca, 0, "fast_itpmca")]
    [InlineData(BetaWorkspaceRateLimitType.FastOtpm, 1, "fast_otpm")]
    [InlineData(BetaWorkspaceRateLimitType.InputTokensPerMinute, 2, "input_tokens_per_minute")]
    [InlineData(
        BetaWorkspaceRateLimitType.InputTokensPerMinuteCacheAware,
        3,
        "input_tokens_per_minute_cache_aware"
    )]
    [InlineData(BetaWorkspaceRateLimitType.OutputTokensPerMinute, 4, "output_tokens_per_minute")]
    [InlineData(BetaWorkspaceRateLimitType.RequestsPerMinute, 5, "requests_per_minute")]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerDay, 6, "tokens_per_day")]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerMinute, 7, "tokens_per_minute")]
    [InlineData(BetaWorkspaceRateLimitType.ToolUsesPerSecond, 8, "tool_uses_per_second")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaWorkspaceRateLimitType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRateLimitType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
