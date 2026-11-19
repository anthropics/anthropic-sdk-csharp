using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class BetaAnalyticsCostGroupByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsCostGroupBy.Actor)]
    [InlineData(BetaAnalyticsCostGroupBy.ActorType)]
    [InlineData(BetaAnalyticsCostGroupBy.AgentID)]
    [InlineData(BetaAnalyticsCostGroupBy.ApiKeyID)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagCategory)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagUserID)]
    [InlineData(BetaAnalyticsCostGroupBy.ContextWindow)]
    [InlineData(BetaAnalyticsCostGroupBy.CostType)]
    [InlineData(BetaAnalyticsCostGroupBy.DeploymentID)]
    [InlineData(BetaAnalyticsCostGroupBy.EnvironmentID)]
    [InlineData(BetaAnalyticsCostGroupBy.InferenceGeo)]
    [InlineData(BetaAnalyticsCostGroupBy.Model)]
    [InlineData(BetaAnalyticsCostGroupBy.OrganizationID)]
    [InlineData(BetaAnalyticsCostGroupBy.Product)]
    [InlineData(BetaAnalyticsCostGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsCostGroupBy.ServiceTier)]
    [InlineData(BetaAnalyticsCostGroupBy.SessionID)]
    [InlineData(BetaAnalyticsCostGroupBy.SlackChannelID)]
    [InlineData(BetaAnalyticsCostGroupBy.Speed)]
    [InlineData(BetaAnalyticsCostGroupBy.TokenType)]
    [InlineData(BetaAnalyticsCostGroupBy.UserProfileID)]
    [InlineData(BetaAnalyticsCostGroupBy.WorkspaceID)]
    public void Validation_Works(BetaAnalyticsCostGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsCostGroupBy.Actor, 0, "actor")]
    [InlineData(BetaAnalyticsCostGroupBy.ActorType, 1, "actor_type")]
    [InlineData(BetaAnalyticsCostGroupBy.AgentID, 2, "agent_id")]
    [InlineData(BetaAnalyticsCostGroupBy.ApiKeyID, 3, "api_key_id")]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagCategory, 4, "claude_tag_category")]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagUserID, 5, "claude_tag_user_id")]
    [InlineData(BetaAnalyticsCostGroupBy.ContextWindow, 6, "context_window")]
    [InlineData(BetaAnalyticsCostGroupBy.CostType, 7, "cost_type")]
    [InlineData(BetaAnalyticsCostGroupBy.DeploymentID, 8, "deployment_id")]
    [InlineData(BetaAnalyticsCostGroupBy.EnvironmentID, 9, "environment_id")]
    [InlineData(BetaAnalyticsCostGroupBy.InferenceGeo, 10, "inference_geo")]
    [InlineData(BetaAnalyticsCostGroupBy.Model, 11, "model")]
    [InlineData(BetaAnalyticsCostGroupBy.OrganizationID, 12, "organization_id")]
    [InlineData(BetaAnalyticsCostGroupBy.Product, 13, "product")]
    [InlineData(BetaAnalyticsCostGroupBy.RbacGroupID, 14, "rbac_group_id")]
    [InlineData(BetaAnalyticsCostGroupBy.ServiceTier, 15, "service_tier")]
    [InlineData(BetaAnalyticsCostGroupBy.SessionID, 16, "session_id")]
    [InlineData(BetaAnalyticsCostGroupBy.SlackChannelID, 17, "slack_channel_id")]
    [InlineData(BetaAnalyticsCostGroupBy.Speed, 18, "speed")]
    [InlineData(BetaAnalyticsCostGroupBy.TokenType, 19, "token_type")]
    [InlineData(BetaAnalyticsCostGroupBy.UserProfileID, 20, "user_profile_id")]
    [InlineData(BetaAnalyticsCostGroupBy.WorkspaceID, 21, "workspace_id")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaAnalyticsCostGroupBy rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostGroupBy> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
