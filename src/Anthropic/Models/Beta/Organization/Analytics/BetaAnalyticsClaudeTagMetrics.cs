using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Tag activity metrics for a single linked user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsClaudeTagMetrics, BetaAnalyticsClaudeTagMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsClaudeTagMetrics : JsonModel
{
    /// <summary>
    /// 1 on a day the user was active in Claude Tag in Slack, otherwise 0. Summed
    /// over the window in date-range mode, so it is the number of active days; on
    /// grouped rows, the total of each member's active days. Null when Claude Tag
    /// data cannot be read for the request. Otherwise, 0 on a row filtered by project,
    /// and null on any other row when no covered day was measured.
    /// </summary>
    public required long? ActiveDayCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("active_day_count");
        }
        init { this._rawData.Set("active_day_count", value); }
    }

    /// <summary>
    /// Number of the user's Slack messages that made them active: @-mentions, direct
    /// messages, group direct message asks, and thread posts Claude answered. Other
    /// messages are not counted. Null when Claude Tag data cannot be read for the
    /// request. Otherwise, 0 on a row filtered by project, and null on any other
    /// row when no covered day was measured.
    /// </summary>
    public required long? ActiveMessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("active_message_count");
        }
        init { this._rawData.Set("active_message_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveDayCount;
        _ = this.ActiveMessageCount;
    }

    public BetaAnalyticsClaudeTagMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsClaudeTagMetrics(
        BetaAnalyticsClaudeTagMetrics betaAnalyticsClaudeTagMetrics
    )
        : base(betaAnalyticsClaudeTagMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsClaudeTagMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsClaudeTagMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsClaudeTagMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsClaudeTagMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsClaudeTagMetricsFromRaw : IFromRawJson<BetaAnalyticsClaudeTagMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsClaudeTagMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsClaudeTagMetrics.FromRawUnchecked(rawData);
}
