using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Usage;

/// <summary>
/// The dimension values one usage row is broken out by; each is null unless its dimension
/// is in `group_by[]`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsUsageGroup, BetaAnalyticsUsageGroupFromRaw>))]
public sealed record class BetaAnalyticsUsageGroup : JsonModel
{
    /// <summary>
    /// The identity the usage is attributed to: the user if one is attributed, else
    /// the service account, else the federated (cloud-platform) identity, else the
    /// API key. Populated only when `actor` is in `group_by[]`; null for usage with
    /// no attributable identity, and for users' and federated identities' usage when
    /// the reader is a member who can see only some workspaces. Distinct identities
    /// the server cannot render also read null, each as its own row.
    /// </summary>
    public required BetaAnalyticsActor? Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnalyticsActor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    /// <summary>
    /// Kind of identity the usage is attributed to; matches `actor.type` when `actor`
    /// is set. Populated only when `actor_type` is in `group_by[]`.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsActorType>? ActorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsActorType>>(
                "actor_type"
            );
        }
        init { this._rawData.Set("actor_type", value); }
    }

    /// <summary>
    /// Claude Managed Agents agent whose session incurred the usage. Populated only
    /// when `agent_id` is in `group_by[]`; null for usage outside a managed session.
    /// </summary>
    public required string? AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("agent_id");
        }
        init { this._rawData.Set("agent_id", value); }
    }

    /// <summary>
    /// API key that authenticated the requests, as a tagged API key ID, whichever
    /// identity `actor` resolves to. Populated only when `api_key_id` is in `group_by[]`;
    /// null for usage not authenticated by an API key.
    /// </summary>
    public required string? ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_key_id");
        }
        init { this._rawData.Set("api_key_id", value); }
    }

    /// <summary>
    /// Claude Tag (Claude in Slack) spend category: `engaged` (a person addressed
    /// Claude in a channel or thread), `proactive` (Claude responded without being
    /// addressed), `scheduled` (a scheduled routine ran), `monitoring` (Claude watching
    /// a channel it was asked to monitor), or `dm` (direct messages with Claude).
    /// Populated only when `claude_tag_category` is in `group_by[]`; null for usage
    /// that is not Claude Tag. Direct-message usage is billed to the individual
    /// user and is reported under that user's product, not under `claude_tag`. New
    /// categories may be added over time.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsClaudeTagCategory>? ClaudeTagCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>(
                "claude_tag_category"
            );
        }
        init { this._rawData.Set("claude_tag_category", value); }
    }

    /// <summary>
    /// Slack user ID (for example `U0123ABCDEF`) of the member the Claude Tag (Claude
    /// in Slack) usage is attributed to, not a claude.ai user ID. Populated only
    /// when `claude_tag_user_id` is in `group_by[]`; null for usage that is not Claude
    /// Tag and for Claude Tag usage that is not attributed to a single user (for
    /// example `monitoring`, and `proactive` usage Claude initiated), so per-user
    /// rows can sum to less than the Claude Tag total. Cannot be combined with `group_by[]=rbac_group_id`
    /// or the `rbac_group_ids[]` filter.
    /// </summary>
    public required string? ClaudeTagUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("claude_tag_user_id");
        }
        init { this._rawData.Set("claude_tag_user_id", value); }
    }

    /// <summary>
    /// Context-window pricing tier of the usage or cost. Null unless `context_window`
    /// is in `group_by[]`; it can also be null on grouped rows with no context-window
    /// tier, such as code execution.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsContextWindow>? ContextWindow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsContextWindow>>(
                "context_window"
            );
        }
        init { this._rawData.Set("context_window", value); }
    }

    /// <summary>
    /// Deployment that started the Claude Managed Agents session. Populated only
    /// when `deployment_id` is in `group_by[]`; null for usage outside a managed
    /// session and for sessions no deployment started.
    /// </summary>
    public required string? DeploymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("deployment_id");
        }
        init { this._rawData.Set("deployment_id", value); }
    }

    /// <summary>
    /// Claude Managed Agents environment the session ran in. Populated only when
    /// `environment_id` is in `group_by[]`; null for usage outside a managed session.
    /// </summary>
    public required string? EnvironmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment_id");
        }
        init { this._rawData.Set("environment_id", value); }
    }

    /// <summary>
    /// Inference region of the usage or cost. Null unless `inference_geo` is in
    /// `group_by[]`; it can also be null on grouped rows where the region is not
    /// set (the rows that `inference_geos[]=not_available` matches).
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsUsageCostInferenceGeo>? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageCostInferenceGeo>
            >("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// Model that produced the usage or cost, as a model name in the form the `models[]`
    /// filter accepts (for example, `claude-opus-5-5`). Null unless `model` is in
    /// `group_by[]`; it can also be null on grouped rows whose usage or cost is
    /// not attributed to a specific model, such as code execution.
    /// </summary>
    public required string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Product surface that produced the usage or cost. Null unless product is in
    /// `group_by[]`; it can also be null on grouped rows whose usage cannot be attributed
    /// to a known surface. Values include `chat`, `claude_code`, `cowork`, `office_agent`,
    /// `claude_in_chrome`, `claude_design`, `claude_tag`, and `chat_cowork_unified`.
    /// `claude_tag` is Claude Tag, the Claude product in Slack. `chat_cowork_unified`
    /// is Chat and Cowork unified, Cowork's features inside claude.ai chat: chat
    /// and Cowork usage by a member who has it turned on is reported under this
    /// value instead of `chat` or `cowork`. It is accepted as a filter only on deployments
    /// that offer Chat and Cowork unified. Some unattributed usage is reported as "other".
    /// </summary>
    public required string? Product
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product");
        }
        init { this._rawData.Set("product", value); }
    }

    /// <summary>
    /// RBAC group (team) the usage is attributed to, in the public tagged `rbac_group_...`
    /// spelling — the same spelling the activity resources use for this key, so
    /// the same team has one id across resources and it round-trips as an `rbac_group_ids[]`
    /// filter value. Populated only when `rbac_group_id` is in `group_by[]`. Any-membership
    /// semantics: a user in several groups contributes their full usage to each
    /// of those groups' rows, so the named-group rows overlap and their sum can exceed
    /// the org total. A null value is the single unassigned row: users in no group
    /// on that (UTC) day. For the true org total, run the same query without `group_by[]`.
    /// </summary>
    public required string? RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Service tier the usage was served at. Populated only when `service_tier` is
    /// in `group_by[]`; null for usage with no service tier (for example, code execution)
    /// and for Claude Enterprise usage.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsServiceTier>>(
                "service_tier"
            );
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// Claude Managed Agents session that incurred the usage. Populated only when
    /// `session_id` is in `group_by[]`; null for usage outside a managed session.
    /// </summary>
    public required string? SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Slack channel the usage originated from. Populated only when `slack_channel_id`
    /// is in `group_by[]`; null for usage outside Slack (and for rows recorded before
    /// channel attribution was enabled).
    /// </summary>
    public required string? SlackChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slack_channel_id");
        }
        init { this._rawData.Set("slack_channel_id", value); }
    }

    /// <summary>
    /// Inference speed mode of the usage or cost: `fast` or `standard`. Null unless
    /// `speed` is in `group_by[]`.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsSpeed>>("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <summary>
    /// User profile the usage was attributed to, as a tagged `uprof_` ID. Populated
    /// only when `user_profile_id` is in `group_by[]`; null for usage that named
    /// no profile and for Claude Enterprise usage.
    /// </summary>
    public required string? UserProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_profile_id");
        }
        init { this._rawData.Set("user_profile_id", value); }
    }

    /// <summary>
    /// Workspace the usage occurred in, as a tagged workspace ID, including the
    /// organization's default workspace. Populated only when `workspace_id` is in
    /// `group_by[]`; null for Claude Enterprise usage.
    /// </summary>
    public required string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Actor?.Validate();
        this.ActorType?.Validate();
        _ = this.AgentID;
        _ = this.ApiKeyID;
        this.ClaudeTagCategory?.Validate();
        _ = this.ClaudeTagUserID;
        this.ContextWindow?.Validate();
        _ = this.DeploymentID;
        _ = this.EnvironmentID;
        this.InferenceGeo?.Validate();
        _ = this.Model;
        _ = this.Product;
        _ = this.RbacGroupID;
        this.ServiceTier?.Validate();
        _ = this.SessionID;
        _ = this.SlackChannelID;
        this.Speed?.Validate();
        _ = this.UserProfileID;
        _ = this.WorkspaceID;
    }

    public BetaAnalyticsUsageGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageGroup(BetaAnalyticsUsageGroup betaAnalyticsUsageGroup)
        : base(betaAnalyticsUsageGroup) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageGroupFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageGroupFromRaw : IFromRawJson<BetaAnalyticsUsageGroup>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageGroup.FromRawUnchecked(rawData);
}
