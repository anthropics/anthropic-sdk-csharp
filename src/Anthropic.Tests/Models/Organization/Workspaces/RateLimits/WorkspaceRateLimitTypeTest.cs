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
    [InlineData(WorkspaceRateLimitType.FastItpmca)]
    [InlineData(WorkspaceRateLimitType.FastOtpm)]
    [InlineData(WorkspaceRateLimitType.InputTokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.InputTokensPerMinuteCacheAware)]
    [InlineData(WorkspaceRateLimitType.OutputTokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.RequestsPerMinute)]
    [InlineData(WorkspaceRateLimitType.TokensPerDay)]
    [InlineData(WorkspaceRateLimitType.TokensPerMinute)]
    [InlineData(WorkspaceRateLimitType.ToolUsesPerSecond)]
    public void SerializationRoundtrip_Works(WorkspaceRateLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRateLimitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRateLimitType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
