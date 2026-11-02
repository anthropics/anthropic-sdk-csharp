using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A skill's use in Cowork sessions recorded while members had Chat and Cowork unified
/// turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsSkillChatCoworkUnifiedSessionsMetrics,
        AnalyticsSkillChatCoworkUnifiedSessionsMetricsFromRaw
    >)
)]
public sealed record class AnalyticsSkillChatCoworkUnifiedSessionsMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_skill_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSessionSkillUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_skill_used_count");
        }
        init { this._rawData.Set("distinct_session_skill_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctSessionSkillUsedCount;
    }

    public AnalyticsSkillChatCoworkUnifiedSessionsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsSkillChatCoworkUnifiedSessionsMetrics(
        AnalyticsSkillChatCoworkUnifiedSessionsMetrics analyticsSkillChatCoworkUnifiedSessionsMetrics
    )
        : base(analyticsSkillChatCoworkUnifiedSessionsMetrics) { }
#pragma warning restore CS8618

    public AnalyticsSkillChatCoworkUnifiedSessionsMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsSkillChatCoworkUnifiedSessionsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsSkillChatCoworkUnifiedSessionsMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsSkillChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsSkillChatCoworkUnifiedSessionsMetrics(long? distinctSessionSkillUsedCount)
        : this()
    {
        this.DistinctSessionSkillUsedCount = distinctSessionSkillUsedCount;
    }
}

class AnalyticsSkillChatCoworkUnifiedSessionsMetricsFromRaw
    : IFromRawJson<AnalyticsSkillChatCoworkUnifiedSessionsMetrics>
{
    /// <inheritdoc/>
    public AnalyticsSkillChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsSkillChatCoworkUnifiedSessionsMetrics.FromRawUnchecked(rawData);
}
