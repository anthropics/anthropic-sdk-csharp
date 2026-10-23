using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Usage;

public class BetaAnalyticsUsageGroupByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageGroupBy.Actor)]
    [InlineData(BetaAnalyticsUsageGroupBy.ActorType)]
    [InlineData(BetaAnalyticsUsageGroupBy.AgentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ApiKeyID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagCategory)]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagUserID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ContextWindow)]
    [InlineData(BetaAnalyticsUsageGroupBy.DeploymentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.EnvironmentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.InferenceGeo)]
    [InlineData(BetaAnalyticsUsageGroupBy.Model)]
    [InlineData(BetaAnalyticsUsageGroupBy.Product)]
    [InlineData(BetaAnalyticsUsageGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ServiceTier)]
    [InlineData(BetaAnalyticsUsageGroupBy.SessionID)]
    [InlineData(BetaAnalyticsUsageGroupBy.SlackChannelID)]
    [InlineData(BetaAnalyticsUsageGroupBy.Speed)]
    [InlineData(BetaAnalyticsUsageGroupBy.UserProfileID)]
    [InlineData(BetaAnalyticsUsageGroupBy.WorkspaceID)]
    public void Validation_Works(BetaAnalyticsUsageGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageGroupBy.Actor)]
    [InlineData(BetaAnalyticsUsageGroupBy.ActorType)]
    [InlineData(BetaAnalyticsUsageGroupBy.AgentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ApiKeyID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagCategory)]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagUserID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ContextWindow)]
    [InlineData(BetaAnalyticsUsageGroupBy.DeploymentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.EnvironmentID)]
    [InlineData(BetaAnalyticsUsageGroupBy.InferenceGeo)]
    [InlineData(BetaAnalyticsUsageGroupBy.Model)]
    [InlineData(BetaAnalyticsUsageGroupBy.Product)]
    [InlineData(BetaAnalyticsUsageGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsUsageGroupBy.ServiceTier)]
    [InlineData(BetaAnalyticsUsageGroupBy.SessionID)]
    [InlineData(BetaAnalyticsUsageGroupBy.SlackChannelID)]
    [InlineData(BetaAnalyticsUsageGroupBy.Speed)]
    [InlineData(BetaAnalyticsUsageGroupBy.UserProfileID)]
    [InlineData(BetaAnalyticsUsageGroupBy.WorkspaceID)]
    public void SerializationRoundtrip_Works(BetaAnalyticsUsageGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
