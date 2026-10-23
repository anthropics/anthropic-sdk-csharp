using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.Usage;

[JsonConverter(typeof(BetaAnalyticsUsageGroupByConverter))]
public enum BetaAnalyticsUsageGroupBy
{
    Actor,
    ActorType,
    AgentID,
    ApiKeyID,
    ClaudeTagCategory,
    ClaudeTagUserID,
    ContextWindow,
    DeploymentID,
    EnvironmentID,
    InferenceGeo,
    Model,
    Product,
    RbacGroupID,
    ServiceTier,
    SessionID,
    SlackChannelID,
    Speed,
    UserProfileID,
    WorkspaceID,
}

sealed class BetaAnalyticsUsageGroupByConverter : JsonConverter<BetaAnalyticsUsageGroupBy>
{
    public override BetaAnalyticsUsageGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "actor" => BetaAnalyticsUsageGroupBy.Actor,
            "actor_type" => BetaAnalyticsUsageGroupBy.ActorType,
            "agent_id" => BetaAnalyticsUsageGroupBy.AgentID,
            "api_key_id" => BetaAnalyticsUsageGroupBy.ApiKeyID,
            "claude_tag_category" => BetaAnalyticsUsageGroupBy.ClaudeTagCategory,
            "claude_tag_user_id" => BetaAnalyticsUsageGroupBy.ClaudeTagUserID,
            "context_window" => BetaAnalyticsUsageGroupBy.ContextWindow,
            "deployment_id" => BetaAnalyticsUsageGroupBy.DeploymentID,
            "environment_id" => BetaAnalyticsUsageGroupBy.EnvironmentID,
            "inference_geo" => BetaAnalyticsUsageGroupBy.InferenceGeo,
            "model" => BetaAnalyticsUsageGroupBy.Model,
            "product" => BetaAnalyticsUsageGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsUsageGroupBy.RbacGroupID,
            "service_tier" => BetaAnalyticsUsageGroupBy.ServiceTier,
            "session_id" => BetaAnalyticsUsageGroupBy.SessionID,
            "slack_channel_id" => BetaAnalyticsUsageGroupBy.SlackChannelID,
            "speed" => BetaAnalyticsUsageGroupBy.Speed,
            "user_profile_id" => BetaAnalyticsUsageGroupBy.UserProfileID,
            "workspace_id" => BetaAnalyticsUsageGroupBy.WorkspaceID,
            _ => (BetaAnalyticsUsageGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageGroupBy.Actor => "actor",
                BetaAnalyticsUsageGroupBy.ActorType => "actor_type",
                BetaAnalyticsUsageGroupBy.AgentID => "agent_id",
                BetaAnalyticsUsageGroupBy.ApiKeyID => "api_key_id",
                BetaAnalyticsUsageGroupBy.ClaudeTagCategory => "claude_tag_category",
                BetaAnalyticsUsageGroupBy.ClaudeTagUserID => "claude_tag_user_id",
                BetaAnalyticsUsageGroupBy.ContextWindow => "context_window",
                BetaAnalyticsUsageGroupBy.DeploymentID => "deployment_id",
                BetaAnalyticsUsageGroupBy.EnvironmentID => "environment_id",
                BetaAnalyticsUsageGroupBy.InferenceGeo => "inference_geo",
                BetaAnalyticsUsageGroupBy.Model => "model",
                BetaAnalyticsUsageGroupBy.Product => "product",
                BetaAnalyticsUsageGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsUsageGroupBy.ServiceTier => "service_tier",
                BetaAnalyticsUsageGroupBy.SessionID => "session_id",
                BetaAnalyticsUsageGroupBy.SlackChannelID => "slack_channel_id",
                BetaAnalyticsUsageGroupBy.Speed => "speed",
                BetaAnalyticsUsageGroupBy.UserProfileID => "user_profile_id",
                BetaAnalyticsUsageGroupBy.WorkspaceID => "workspace_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
