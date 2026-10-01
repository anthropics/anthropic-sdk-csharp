using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-day entry in the /summaries response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSingleDayActivitySummary,
        BetaAnalyticsSingleDayActivitySummaryFromRaw
    >)
)]
public sealed record class BetaAnalyticsSingleDayActivitySummary : JsonModel
{
    /// <summary>
    /// Number of seats currently assigned to members. Null when the response is
    /// scoped to an RBAC group — seat assignment is org-wide and has no per-group analogue.
    /// </summary>
    public required long? AssignedSeatCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("assigned_seat_count");
        }
        init { this._rawData.Set("assigned_seat_count", value); }
    }

    /// <summary>
    /// Number of users with Cowork activity on the requested day
    /// </summary>
    public required long CoworkDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cowork_daily_active_user_count");
        }
        init { this._rawData.Set("cowork_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Cowork activity in the 30-day rolling window
    /// </summary>
    public required long CoworkMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cowork_monthly_active_user_count");
        }
        init { this._rawData.Set("cowork_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Cowork activity in the 7-day rolling window
    /// </summary>
    public required long CoworkWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cowork_weekly_active_user_count");
        }
        init { this._rawData.Set("cowork_weekly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with token consumption on the requested day
    /// </summary>
    public required long DailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("daily_active_user_count");
        }
        init { this._rawData.Set("daily_active_user_count", value); }
    }

    /// <summary>
    /// Percentage of assigned seats with activity on the requested day (`DAU / assigned_seat_count
    /// * 100`). Null when the response is scoped to an RBAC group.
    /// </summary>
    public required double? DailyAdoptionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("daily_adoption_rate");
        }
        init { this._rawData.Set("daily_adoption_rate", value); }
    }

    /// <summary>
    /// End of the aggregation period (exclusive), UTC midnight in RFC 3339 format
    /// (e.g. `2026-01-16T00:00:00Z`).
    /// </summary>
    public required DateTimeOffset EndingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("ending_at");
        }
        init { this._rawData.Set("ending_at", value); }
    }

    /// <summary>
    /// Number of users with token consumption in the 30-day rolling window
    /// </summary>
    public required long MonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("monthly_active_user_count");
        }
        init { this._rawData.Set("monthly_active_user_count", value); }
    }

    /// <summary>
    /// Percentage of assigned seats with activity in the 30-day rolling window (`MAU
    /// / assigned_seat_count * 100`). Null when the response is scoped to an RBAC group.
    /// </summary>
    public required double? MonthlyAdoptionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("monthly_adoption_rate");
        }
        init { this._rawData.Set("monthly_adoption_rate", value); }
    }

    /// <summary>
    /// Number of pending invitations to join the organization. Null when the response
    /// is scoped to an RBAC group.
    /// </summary>
    public required long? PendingInviteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pending_invite_count");
        }
        init { this._rawData.Set("pending_invite_count", value); }
    }

    /// <summary>
    /// Start of the aggregation period (inclusive), UTC midnight in RFC 3339 format
    /// (e.g. `2026-01-15T00:00:00Z`).
    /// </summary>
    public required DateTimeOffset StartingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("starting_at");
        }
        init { this._rawData.Set("starting_at", value); }
    }

    /// <summary>
    /// Number of users with token consumption in the 7-day rolling window
    /// </summary>
    public required long WeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("weekly_active_user_count");
        }
        init { this._rawData.Set("weekly_active_user_count", value); }
    }

    /// <summary>
    /// Percentage of assigned seats with activity in the 7-day rolling window (`WAU
    /// / assigned_seat_count * 100`). Null when the response is scoped to an RBAC group.
    /// </summary>
    public required double? WeeklyAdoptionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("weekly_adoption_rate");
        }
        init { this._rawData.Set("weekly_adoption_rate", value); }
    }

    /// <summary>
    /// Number of users with claude.ai (chat) activity on the requested day. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ChatDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chat_daily_active_user_count");
        }
        init { this._rawData.Set("chat_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with claude.ai (chat) activity in the 30-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ChatMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chat_monthly_active_user_count");
        }
        init { this._rawData.Set("chat_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with claude.ai (chat) activity in the 7-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ChatWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chat_weekly_active_user_count");
        }
        init { this._rawData.Set("chat_weekly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Code activity on the requested day. Omitted from
    /// the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ClaudeCodeDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_code_daily_active_user_count");
        }
        init { this._rawData.Set("claude_code_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Code activity in the 30-day rolling window. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ClaudeCodeMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_code_monthly_active_user_count");
        }
        init { this._rawData.Set("claude_code_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Code activity in the 7-day rolling window. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ClaudeCodeWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_code_weekly_active_user_count");
        }
        init { this._rawData.Set("claude_code_weekly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Design activity on the requested day. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ClaudeDesignDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_design_daily_active_user_count");
        }
        init { this._rawData.Set("claude_design_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Design activity in the 30-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ClaudeDesignMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_design_monthly_active_user_count");
        }
        init { this._rawData.Set("claude_design_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Design activity in the 7-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ClaudeDesignWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("claude_design_weekly_active_user_count");
        }
        init { this._rawData.Set("claude_design_weekly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude in Office activity on the requested day. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? OfficeAgentDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("office_agent_daily_active_user_count");
        }
        init { this._rawData.Set("office_agent_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude in Office activity in the 30-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled
    /// for this organization.
    /// </summary>
    public long? OfficeAgentMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("office_agent_monthly_active_user_count");
        }
        init { this._rawData.Set("office_agent_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude in Office activity in the 7-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled
    /// for this organization.
    /// </summary>
    public long? OfficeAgentWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("office_agent_weekly_active_user_count");
        }
        init { this._rawData.Set("office_agent_weekly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Science activity on the requested day. Omitted
    /// from the response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ScienceDailyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("science_daily_active_user_count");
        }
        init { this._rawData.Set("science_daily_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with a Claude Science seat entitlement (per-seat RBAC) at
    /// the time of the daily snapshot. The funnel top; independent of the org-level
    /// Claude Science toggle. Null when the response is scoped to an RBAC group
    /// — entitlement is org-wide and has no per-group analogue. Omitted from the
    /// response while the per-product breakdown is not enabled for this organization.
    /// </summary>
    public long? ScienceEntitledUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("science_entitled_user_count");
        }
        init { this._rawData.Set("science_entitled_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Science activity in the 30-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ScienceMonthlyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("science_monthly_active_user_count");
        }
        init { this._rawData.Set("science_monthly_active_user_count", value); }
    }

    /// <summary>
    /// Number of users with Claude Science activity in the 7-day rolling window.
    /// Omitted from the response while the per-product breakdown is not enabled for
    /// this organization.
    /// </summary>
    public long? ScienceWeeklyActiveUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("science_weekly_active_user_count");
        }
        init { this._rawData.Set("science_weekly_active_user_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssignedSeatCount;
        _ = this.CoworkDailyActiveUserCount;
        _ = this.CoworkMonthlyActiveUserCount;
        _ = this.CoworkWeeklyActiveUserCount;
        _ = this.DailyActiveUserCount;
        _ = this.DailyAdoptionRate;
        _ = this.EndingAt;
        _ = this.MonthlyActiveUserCount;
        _ = this.MonthlyAdoptionRate;
        _ = this.PendingInviteCount;
        _ = this.StartingAt;
        _ = this.WeeklyActiveUserCount;
        _ = this.WeeklyAdoptionRate;
        _ = this.ChatDailyActiveUserCount;
        _ = this.ChatMonthlyActiveUserCount;
        _ = this.ChatWeeklyActiveUserCount;
        _ = this.ClaudeCodeDailyActiveUserCount;
        _ = this.ClaudeCodeMonthlyActiveUserCount;
        _ = this.ClaudeCodeWeeklyActiveUserCount;
        _ = this.ClaudeDesignDailyActiveUserCount;
        _ = this.ClaudeDesignMonthlyActiveUserCount;
        _ = this.ClaudeDesignWeeklyActiveUserCount;
        _ = this.OfficeAgentDailyActiveUserCount;
        _ = this.OfficeAgentMonthlyActiveUserCount;
        _ = this.OfficeAgentWeeklyActiveUserCount;
        _ = this.ScienceDailyActiveUserCount;
        _ = this.ScienceEntitledUserCount;
        _ = this.ScienceMonthlyActiveUserCount;
        _ = this.ScienceWeeklyActiveUserCount;
    }

    public BetaAnalyticsSingleDayActivitySummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSingleDayActivitySummary(
        BetaAnalyticsSingleDayActivitySummary betaAnalyticsSingleDayActivitySummary
    )
        : base(betaAnalyticsSingleDayActivitySummary) { }
#pragma warning restore CS8618

    public BetaAnalyticsSingleDayActivitySummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSingleDayActivitySummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSingleDayActivitySummaryFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSingleDayActivitySummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsSingleDayActivitySummaryFromRaw
    : IFromRawJson<BetaAnalyticsSingleDayActivitySummary>
{
    /// <inheritdoc/>
    public BetaAnalyticsSingleDayActivitySummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSingleDayActivitySummary.FromRawUnchecked(rawData);
}
