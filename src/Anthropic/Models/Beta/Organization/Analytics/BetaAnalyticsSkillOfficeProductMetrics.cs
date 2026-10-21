using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single skill on a given day within one Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSkillOfficeProductMetrics,
        BetaAnalyticsSkillOfficeProductMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsSkillOfficeProductMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Office Agent sessions in which the skill was used. A skill
    /// counts as used only when it is explicitly activated — the model (or the user,
    /// via the skill's slash command) invokes it, reading its instructions into
    /// context as part of that activation. Skills that are merely installed or listed
    /// as available, or whose content reaches the context without an activation
    /// (preloaded, hook-injected, or read as a plain file), are not counted. Approximate
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

    public BetaAnalyticsSkillOfficeProductMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillOfficeProductMetrics(
        BetaAnalyticsSkillOfficeProductMetrics betaAnalyticsSkillOfficeProductMetrics
    )
        : base(betaAnalyticsSkillOfficeProductMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillOfficeProductMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillOfficeProductMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillOfficeProductMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsSkillOfficeProductMetrics(long? distinctSessionSkillUsedCount)
        : this()
    {
        this.DistinctSessionSkillUsedCount = distinctSessionSkillUsedCount;
    }
}

class BetaAnalyticsSkillOfficeProductMetricsFromRaw
    : IFromRawJson<BetaAnalyticsSkillOfficeProductMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillOfficeProductMetrics.FromRawUnchecked(rawData);
}
