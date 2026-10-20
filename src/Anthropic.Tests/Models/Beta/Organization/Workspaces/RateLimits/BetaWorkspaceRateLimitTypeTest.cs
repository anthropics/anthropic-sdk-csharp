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
    [InlineData(BetaWorkspaceRateLimitType.FastItpmca)]
    [InlineData(BetaWorkspaceRateLimitType.FastOtpm)]
    [InlineData(BetaWorkspaceRateLimitType.InputTokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.InputTokensPerMinuteCacheAware)]
    [InlineData(BetaWorkspaceRateLimitType.OutputTokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.RequestsPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerDay)]
    [InlineData(BetaWorkspaceRateLimitType.TokensPerMinute)]
    [InlineData(BetaWorkspaceRateLimitType.ToolUsesPerSecond)]
    public void SerializationRoundtrip_Works(BetaWorkspaceRateLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRateLimitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
