using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-user activity data for a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsUserActivity, BetaAnalyticsUserActivityFromRaw>)
)]
public sealed record class BetaAnalyticsUserActivity : JsonModel
{
    /// <summary>
    /// Claude.ai activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsChatMetrics ChatMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsChatMetrics>("chat_metrics");
        }
        init { this._rawData.Set("chat_metrics", value); }
    }

    /// <summary>
    /// Claude Code activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsClaudeCodeMetrics ClaudeCodeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsClaudeCodeMetrics>(
                "claude_code_metrics"
            );
        }
        init { this._rawData.Set("claude_code_metrics", value); }
    }

    /// <summary>
    /// Cowork activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsCoworkMetrics CoworkMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsCoworkMetrics>("cowork_metrics");
        }
        init { this._rawData.Set("cowork_metrics", value); }
    }

    /// <summary>
    /// Claude Design activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsDesignMetrics DesignMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsDesignMetrics>("design_metrics");
        }
        init { this._rawData.Set("design_metrics", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day, broken out
    /// by Office product.
    /// </summary>
    public required BetaAnalyticsOfficeMetrics OfficeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsOfficeMetrics>("office_metrics");
        }
        init { this._rawData.Set("office_metrics", value); }
    }

    /// <summary>
    /// Claude Science activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsScienceMetrics ScienceMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsScienceMetrics>("science_metrics");
        }
        init { this._rawData.Set("science_metrics", value); }
    }

    /// <summary>
    /// Number of web searches performed
    /// </summary>
    public required long WebSearchCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("web_search_count");
        }
        init { this._rawData.Set("web_search_count", value); }
    }

    /// <summary>
    /// Activity recorded while the member had Chat and Cowork unified (Cowork's features
    /// inside claude.ai chat) turned on, split into `chat` (chat activity) and `sessions`
    /// (Cowork activity). Omitted from the response on deployments that do not offer
    /// Chat and Cowork unified.
    /// </summary>
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetrics? ChatCoworkUnifiedMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnalyticsUserActivityChatCoworkUnifiedMetrics>(
                "chat_cowork_unified_metrics"
            );
        }
        init { this._rawData.Set("chat_cowork_unified_metrics", value); }
    }

    /// <summary>
    /// Number of distinct active users represented by this row. Only set for grouped
    /// rollups (`group_by[]`); null for per-user rows. In date-range mode, recomputed
    /// as an exact distinct count of the group's active members over the requested
    /// window, never a sum of per-day values.
    /// </summary>
    public long? DistinctUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_user_count");
        }
        init { this._rawData.Set("distinct_user_count", value); }
    }

    /// <summary>
    /// Most recent UTC day (YYYY-MM-DD) on which the user had any counted activity,
    /// within the requested window: equal to the requested `date` in single-day
    /// mode, and to the latest active day from `starting_date` (inclusive) to `ending_date`
    /// (exclusive) in date-range rollup mode — never a day earlier than the window
    /// start. On filtered requests (`filter[]`) only days matching the filter count:
    /// with `filter[]=rbac_group_id:{id}` it is the last day the user was active
    /// while a member of that group, consistent with the row's other metrics. On
    /// grouped (`group_by[]`) rows it is the latest day any member of the group was
    /// active (the requested `date` in single-day mode). Omitted from the response
    /// while last-activity reporting is not enabled for this organization.
    /// </summary>
    public string? LastActivityDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_activity_date");
        }
        init { this._rawData.Set("last_activity_date", value); }
    }

    /// <summary>
    /// Tagged RBAC group identifier (`rbac_group_...`), matching the spend-limits
    /// API spelling. Present only when the request grouped by `rbac_group_id`.
    /// </summary>
    public string? RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Resolved RBAC group display name, alongside `rbac_group_id` when name resolution
    /// is available. Null if the group has been deleted or its name could not be
    /// resolved; `rbac_group_id` remains the stable key.
    /// </summary>
    public string? RbacGroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_name");
        }
        init { this._rawData.Set("rbac_group_name", value); }
    }

    /// <summary>
    /// The user this row describes. Null on rows aggregated across users.
    /// </summary>
    public BetaAnalyticsUser? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnalyticsUser>("user");
        }
        init { this._rawData.Set("user", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChatMetrics.Validate();
        this.ClaudeCodeMetrics.Validate();
        this.CoworkMetrics.Validate();
        this.DesignMetrics.Validate();
        this.OfficeMetrics.Validate();
        this.ScienceMetrics.Validate();
        _ = this.WebSearchCount;
        this.ChatCoworkUnifiedMetrics?.Validate();
        _ = this.DistinctUserCount;
        _ = this.LastActivityDate;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        this.User?.Validate();
    }

    public BetaAnalyticsUserActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUserActivity(BetaAnalyticsUserActivity betaAnalyticsUserActivity)
        : base(betaAnalyticsUserActivity) { }
#pragma warning restore CS8618

    public BetaAnalyticsUserActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUserActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserActivityFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUserActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserActivityFromRaw : IFromRawJson<BetaAnalyticsUserActivity>
{
    /// <inheritdoc/>
    public BetaAnalyticsUserActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUserActivity.FromRawUnchecked(rawData);
}

/// <summary>
/// Activity recorded while the member had Chat and Cowork unified (Cowork's features
/// inside claude.ai chat) turned on, split into `chat` (chat activity) and `sessions`
/// (Cowork activity). Omitted from the response on deployments that do not offer
/// Chat and Cowork unified.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsUserActivityChatCoworkUnifiedMetrics,
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsUserActivityChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// Chat activity recorded while members had Chat and Cowork unified turned on.
    /// </summary>
    public required BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// Cowork session activity recorded while members had Chat and Cowork unified
    /// turned on.
    /// </summary>
    public required BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions>(
                "sessions"
            );
        }
        init { this._rawData.Set("sessions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Chat.Validate();
        this.Sessions.Validate();
    }

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetrics(
        BetaAnalyticsUserActivityChatCoworkUnifiedMetrics betaAnalyticsUserActivityChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsUserActivityChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUserActivityChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserActivityChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUserActivityChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsUserActivityChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUserActivityChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Chat activity recorded while members had Chat and Cowork unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat,
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChatFromRaw
    >)
)]
public sealed record class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat : JsonModel
{
    /// <summary>
    /// Same measure as `chat_metrics.connectors_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long ConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("connectors_used_count");
        }
        init { this._rawData.Set("connectors_used_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_artifacts_created_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Exact in date-range
    /// mode: a creation belongs to exactly one day, so the per-day counts never
    /// overlap and their sum over the window is the exact count of distinct creations
    /// in it.
    /// </summary>
    public required long DistinctArtifactsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("distinct_artifacts_created_count");
        }
        init { this._rawData.Set("distinct_artifacts_created_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_connectors_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_connectors_used_count");
        }
        init { this._rawData.Set("distinct_connectors_used_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_conversation_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConversationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_conversation_count");
        }
        init { this._rawData.Set("distinct_conversation_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_files_uploaded_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctFilesUploadedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_files_uploaded_count");
        }
        init { this._rawData.Set("distinct_files_uploaded_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_projects_created_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Exact in date-range
    /// mode: a creation belongs to exactly one day, so the per-day counts never
    /// overlap and their sum over the window is the exact count of distinct creations
    /// in it.
    /// </summary>
    public required long DistinctProjectsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("distinct_projects_created_count");
        }
        init { this._rawData.Set("distinct_projects_created_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_projects_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctProjectsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_projects_used_count");
        }
        init { this._rawData.Set("distinct_projects_used_count", value); }
    }

    /// <summary>
    /// Always null: shared-artifact views are not currently measured.
    /// </summary>
    public required long? DistinctSharedArtifactsViewedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_shared_artifacts_viewed_count");
        }
        init { this._rawData.Set("distinct_shared_artifacts_viewed_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.distinct_skills_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
    /// </summary>
    public required long? DistinctSkillsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_skills_used_count");
        }
        init { this._rawData.Set("distinct_skills_used_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.message_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("message_count");
        }
        init { this._rawData.Set("message_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.shared_conversations_viewed_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long SharedConversationsViewedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("shared_conversations_viewed_count");
        }
        init { this._rawData.Set("shared_conversations_viewed_count", value); }
    }

    /// <summary>
    /// Same measure as `chat_metrics.thinking_message_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long ThinkingMessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("thinking_message_count");
        }
        init { this._rawData.Set("thinking_message_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectorsUsedCount;
        _ = this.DistinctArtifactsCreatedCount;
        _ = this.DistinctConnectorsUsedCount;
        _ = this.DistinctConversationCount;
        _ = this.DistinctFilesUploadedCount;
        _ = this.DistinctProjectsCreatedCount;
        _ = this.DistinctProjectsUsedCount;
        _ = this.DistinctSharedArtifactsViewedCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.MessageCount;
        _ = this.SharedConversationsViewedCount;
        _ = this.ThinkingMessageCount;
    }

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat(
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat betaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
    )
        : base(betaAnalyticsUserActivityChatCoworkUnifiedMetricsChat) { }
#pragma warning restore CS8618

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChatFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChatFromRaw
    : IFromRawJson<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat>
{
    /// <inheritdoc/>
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat.FromRawUnchecked(rawData);
}

/// <summary>
/// Cowork session activity recorded while members had Chat and Cowork unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions,
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessionsFromRaw
    >)
)]
public sealed record class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.action_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long ActionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("action_count");
        }
        init { this._rawData.Set("action_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.artifacts_created_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Exact in date-range mode:
    /// a creation belongs to exactly one day, so the per-day counts never overlap
    /// and their sum over the window is the exact count of distinct creations in it.
    /// </summary>
    public required long ArtifactsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("artifacts_created_count");
        }
        init { this._rawData.Set("artifacts_created_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.connectors_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long ConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("connectors_used_count");
        }
        init { this._rawData.Set("connectors_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.dispatch_turn_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long DispatchTurnCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("dispatch_turn_count");
        }
        init { this._rawData.Set("dispatch_turn_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.distinct_connectors_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_connectors_used_count");
        }
        init { this._rawData.Set("distinct_connectors_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
    /// </summary>
    public required long? DistinctSessionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_count");
        }
        init { this._rawData.Set("distinct_session_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.distinct_skills_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSkillsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_skills_used_count");
        }
        init { this._rawData.Set("distinct_skills_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.message_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("message_count");
        }
        init { this._rawData.Set("message_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.skills_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long SkillsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skills_used_count");
        }
        init { this._rawData.Set("skills_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.distinct_plugins_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public long? DistinctPluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_plugins_used_count");
        }
        init { this._rawData.Set("distinct_plugins_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.edit_tool_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public long? EditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("edit_tool_count");
        }
        init { this._rawData.Set("edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.file_edit_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public long? FileEditCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_edit_count");
        }
        init { this._rawData.Set("file_edit_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.multi_edit_tool_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public long? MultiEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("multi_edit_tool_count");
        }
        init { this._rawData.Set("multi_edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.notebook_edit_tool_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public long? NotebookEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("notebook_edit_tool_count");
        }
        init { this._rawData.Set("notebook_edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.plugins_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public long? PluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plugins_used_count");
        }
        init { this._rawData.Set("plugins_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.sessions_with_file_edits_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public long? SessionsWithFileEditsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sessions_with_file_edits_count");
        }
        init { this._rawData.Set("sessions_with_file_edits_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.write_tool_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public long? WriteToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("write_tool_count");
        }
        init { this._rawData.Set("write_tool_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActionCount;
        _ = this.ArtifactsCreatedCount;
        _ = this.ConnectorsUsedCount;
        _ = this.DispatchTurnCount;
        _ = this.DistinctConnectorsUsedCount;
        _ = this.DistinctSessionCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.MessageCount;
        _ = this.SkillsUsedCount;
        _ = this.DistinctPluginsUsedCount;
        _ = this.EditToolCount;
        _ = this.FileEditCount;
        _ = this.MultiEditToolCount;
        _ = this.NotebookEditToolCount;
        _ = this.PluginsUsedCount;
        _ = this.SessionsWithFileEditsCount;
        _ = this.WriteToolCount;
    }

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions(
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions betaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
    )
        : base(betaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions) { }
#pragma warning restore CS8618

    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessionsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessionsFromRaw
    : IFromRawJson<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions>
{
    /// <inheritdoc/>
    public BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions.FromRawUnchecked(rawData);
}
