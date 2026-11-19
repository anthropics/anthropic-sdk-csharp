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
    [InlineData(BetaAnalyticsUsageGroupBy.OrganizationID)]
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
    [InlineData(BetaAnalyticsUsageGroupBy.Actor, 0, "actor")]
    [InlineData(BetaAnalyticsUsageGroupBy.ActorType, 1, "actor_type")]
    [InlineData(BetaAnalyticsUsageGroupBy.AgentID, 2, "agent_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.ApiKeyID, 3, "api_key_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagCategory, 4, "claude_tag_category")]
    [InlineData(BetaAnalyticsUsageGroupBy.ClaudeTagUserID, 5, "claude_tag_user_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.ContextWindow, 6, "context_window")]
    [InlineData(BetaAnalyticsUsageGroupBy.DeploymentID, 7, "deployment_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.EnvironmentID, 8, "environment_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.InferenceGeo, 9, "inference_geo")]
    [InlineData(BetaAnalyticsUsageGroupBy.Model, 10, "model")]
    [InlineData(BetaAnalyticsUsageGroupBy.OrganizationID, 11, "organization_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.Product, 12, "product")]
    [InlineData(BetaAnalyticsUsageGroupBy.RbacGroupID, 13, "rbac_group_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.ServiceTier, 14, "service_tier")]
    [InlineData(BetaAnalyticsUsageGroupBy.SessionID, 15, "session_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.SlackChannelID, 16, "slack_channel_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.Speed, 17, "speed")]
    [InlineData(BetaAnalyticsUsageGroupBy.UserProfileID, 18, "user_profile_id")]
    [InlineData(BetaAnalyticsUsageGroupBy.WorkspaceID, 19, "workspace_id")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsUsageGroupBy rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageGroupBy> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageGroupBy>>(
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
