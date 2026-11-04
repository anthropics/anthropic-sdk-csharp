using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Per-user activity data for a given day.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnalyticsUserActivity, AnalyticsUserActivityFromRaw>))]
public sealed record class AnalyticsUserActivity : JsonModel
{
    /// <summary>
    /// Claude.ai activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsChatMetrics ChatMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsChatMetrics>("chat_metrics");
        }
        init { this._rawData.Set("chat_metrics", value); }
    }

    /// <summary>
    /// Claude Code activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsClaudeCodeMetrics ClaudeCodeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsClaudeCodeMetrics>("claude_code_metrics");
        }
        init { this._rawData.Set("claude_code_metrics", value); }
    }

    /// <summary>
    /// Cowork activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsCoworkMetrics CoworkMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsCoworkMetrics>("cowork_metrics");
        }
        init { this._rawData.Set("cowork_metrics", value); }
    }

    /// <summary>
    /// Claude Design activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsDesignMetrics DesignMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsDesignMetrics>("design_metrics");
        }
        init { this._rawData.Set("design_metrics", value); }
    }

    /// <summary>
    /// Number of distinct active users represented by this row. Only set for grouped
    /// rollups (`group_by[]`); null for per-user rows. In date-range mode, recomputed
    /// as an exact distinct count of the group's active members over the requested
    /// window, never a sum of per-day values.
    /// </summary>
    public required long? DistinctUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_user_count");
        }
        init { this._rawData.Set("distinct_user_count", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day, broken out
    /// by Office product.
    /// </summary>
    public required AnalyticsOfficeMetrics OfficeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsOfficeMetrics>("office_metrics");
        }
        init { this._rawData.Set("office_metrics", value); }
    }

    /// <summary>
    /// Claude Science activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsScienceMetrics ScienceMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsScienceMetrics>("science_metrics");
        }
        init { this._rawData.Set("science_metrics", value); }
    }

    /// <summary>
    /// The user this row describes. Null on rows aggregated across users.
    /// </summary>
    public required AnalyticsUser? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalyticsUser>("user");
        }
        init { this._rawData.Set("user", value); }
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
    /// (Cowork activity). Omitted from the response where Chat and Cowork unified
    /// is not available.
    /// </summary>
    public AnalyticsChatCoworkUnifiedMetrics? ChatCoworkUnifiedMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalyticsChatCoworkUnifiedMetrics>(
                "chat_cowork_unified_metrics"
            );
        }
        init { this._rawData.Set("chat_cowork_unified_metrics", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChatMetrics.Validate();
        this.ClaudeCodeMetrics.Validate();
        this.CoworkMetrics.Validate();
        this.DesignMetrics.Validate();
        _ = this.DistinctUserCount;
        this.OfficeMetrics.Validate();
        this.ScienceMetrics.Validate();
        this.User?.Validate();
        _ = this.WebSearchCount;
        this.ChatCoworkUnifiedMetrics?.Validate();
        _ = this.LastActivityDate;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
    }

    public AnalyticsUserActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsUserActivity(AnalyticsUserActivity analyticsUserActivity)
        : base(analyticsUserActivity) { }
#pragma warning restore CS8618

    public AnalyticsUserActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsUserActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsUserActivityFromRaw.FromRawUnchecked"/>
    public static AnalyticsUserActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsUserActivityFromRaw : IFromRawJson<AnalyticsUserActivity>
{
    /// <inheritdoc/>
    public AnalyticsUserActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsUserActivity.FromRawUnchecked(rawData);
}
