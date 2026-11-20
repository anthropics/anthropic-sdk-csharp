using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class WorkspaceRateLimitTypeTest : TestBase
{
    [Theory]
    [InlineData(WorkspaceRateLimitType.FastItpmca)]
    [InlineData(WorkspaceRateLimitType.FastOtpm)]
    [InlineData(WorkspaceRateLimitType.InputTokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.InputTokensPerMinuteCacheAware)]
    [InlineData(WorkspaceRateLimitType.OutputTokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.RequestsPerMinute)]
    [InlineData(WorkspaceRateLimitType.TokensPerDay)]
    [InlineData(WorkspaceRateLimitType.TokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.ToolUsesPerSecond)]
    public void Validation_Works(WorkspaceRateLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRateLimitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRateLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkspaceRateLimitType.FastItpmca, 0, "fast_itpmca")]
    [InlineData(WorkspaceRateLimitType.FastOtpm, 1, "fast_otpm")]
    [InlineData(WorkspaceRateLimitType.InputTokensPerMinute, 2, "input_tokens_per_minute")]
    [InlineData(
        WorkspaceRateLimitType.InputTokensPerMinuteCacheAware,
        3,
        "input_tokens_per_minute_cache_aware"
    )]
    [InlineData(WorkspaceRateLimitType.OutputTokensPerMinute, 4, "output_tokens_per_minute")]
    [InlineData(WorkspaceRateLimitType.RequestsPerMinute, 5, "requests_per_minute")]
    [InlineData(WorkspaceRateLimitType.TokensPerDay, 6, "tokens_per_day")]
    [InlineData(WorkspaceRateLimitType.TokensPerMinute, 7, "tokens_per_minute")]
    [InlineData(WorkspaceRateLimitType.ToolUsesPerSecond, 8, "tool_uses_per_second")]
    public void EnumMemberSerializationRoundtrip_Works(
        WorkspaceRateLimitType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRateLimitType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRateLimitType>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRateLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRateLimitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
