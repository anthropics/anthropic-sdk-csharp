using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

[JsonConverter(typeof(BetaAnalyticsCostGroupByConverter))]
public enum BetaAnalyticsCostGroupBy
{
    Actor,
    ActorType,
    AgentID,
    ApiKeyID,
    ClaudeTagCategory,
    ClaudeTagUserID,
    ContextWindow,
    CostType,
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
    TokenType,
    UserProfileID,
    WorkspaceID,
}

sealed class BetaAnalyticsCostGroupByConverter : JsonConverter<BetaAnalyticsCostGroupBy>
{
    public override BetaAnalyticsCostGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "actor" => BetaAnalyticsCostGroupBy.Actor,
            "actor_type" => BetaAnalyticsCostGroupBy.ActorType,
            "agent_id" => BetaAnalyticsCostGroupBy.AgentID,
            "api_key_id" => BetaAnalyticsCostGroupBy.ApiKeyID,
            "claude_tag_category" => BetaAnalyticsCostGroupBy.ClaudeTagCategory,
            "claude_tag_user_id" => BetaAnalyticsCostGroupBy.ClaudeTagUserID,
            "context_window" => BetaAnalyticsCostGroupBy.ContextWindow,
            "cost_type" => BetaAnalyticsCostGroupBy.CostType,
            "deployment_id" => BetaAnalyticsCostGroupBy.DeploymentID,
            "environment_id" => BetaAnalyticsCostGroupBy.EnvironmentID,
            "inference_geo" => BetaAnalyticsCostGroupBy.InferenceGeo,
            "model" => BetaAnalyticsCostGroupBy.Model,
            "product" => BetaAnalyticsCostGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsCostGroupBy.RbacGroupID,
            "service_tier" => BetaAnalyticsCostGroupBy.ServiceTier,
            "session_id" => BetaAnalyticsCostGroupBy.SessionID,
            "slack_channel_id" => BetaAnalyticsCostGroupBy.SlackChannelID,
            "speed" => BetaAnalyticsCostGroupBy.Speed,
            "token_type" => BetaAnalyticsCostGroupBy.TokenType,
            "user_profile_id" => BetaAnalyticsCostGroupBy.UserProfileID,
            "workspace_id" => BetaAnalyticsCostGroupBy.WorkspaceID,
            _ => (BetaAnalyticsCostGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsCostGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsCostGroupBy.Actor => "actor",
                BetaAnalyticsCostGroupBy.ActorType => "actor_type",
                BetaAnalyticsCostGroupBy.AgentID => "agent_id",
                BetaAnalyticsCostGroupBy.ApiKeyID => "api_key_id",
                BetaAnalyticsCostGroupBy.ClaudeTagCategory => "claude_tag_category",
                BetaAnalyticsCostGroupBy.ClaudeTagUserID => "claude_tag_user_id",
                BetaAnalyticsCostGroupBy.ContextWindow => "context_window",
                BetaAnalyticsCostGroupBy.CostType => "cost_type",
                BetaAnalyticsCostGroupBy.DeploymentID => "deployment_id",
                BetaAnalyticsCostGroupBy.EnvironmentID => "environment_id",
                BetaAnalyticsCostGroupBy.InferenceGeo => "inference_geo",
                BetaAnalyticsCostGroupBy.Model => "model",
                BetaAnalyticsCostGroupBy.Product => "product",
                BetaAnalyticsCostGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsCostGroupBy.ServiceTier => "service_tier",
                BetaAnalyticsCostGroupBy.SessionID => "session_id",
                BetaAnalyticsCostGroupBy.SlackChannelID => "slack_channel_id",
                BetaAnalyticsCostGroupBy.Speed => "speed",
                BetaAnalyticsCostGroupBy.TokenType => "token_type",
                BetaAnalyticsCostGroupBy.UserProfileID => "user_profile_id",
                BetaAnalyticsCostGroupBy.WorkspaceID => "workspace_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
