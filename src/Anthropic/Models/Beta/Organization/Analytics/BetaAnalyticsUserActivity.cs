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
    public required BetaAnalyticsChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsChatCoworkUnifiedChatMetrics>("chat");
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// Cowork session activity recorded while members had Chat and Cowork unified
    /// turned on.
    /// </summary>
    public required BetaAnalyticsChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsChatCoworkUnifiedSessionsMetrics>(
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
