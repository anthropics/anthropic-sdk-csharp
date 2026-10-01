using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude.ai activity metrics for a single skill on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsSkillChatMetrics, BetaAnalyticsSkillChatMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsSkillChatMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct conversations in which the skill was used. A skill counts
    /// as used only when it is explicitly activated — the model (or the user, via
    /// the skill's slash command) invokes it, reading its instructions into context
    /// as part of that activation. Skills that are merely installed or listed as
    /// available, or whose content reaches the context without an activation (preloaded,
    /// hook-injected, or read as a plain file), are not counted. Approximate (HLL,
    /// typical error &lt;2%) in date-range mode. Null on aggregated rows where a
    /// distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConversationSkillUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_conversation_skill_used_count");
        }
        init { this._rawData.Set("distinct_conversation_skill_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctConversationSkillUsedCount;
    }

    public BetaAnalyticsSkillChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillChatMetrics(
        BetaAnalyticsSkillChatMetrics betaAnalyticsSkillChatMetrics
    )
        : base(betaAnalyticsSkillChatMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillChatMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillChatMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsSkillChatMetrics(long? distinctConversationSkillUsedCount)
        : this()
    {
        this.DistinctConversationSkillUsedCount = distinctConversationSkillUsedCount;
    }
}

class BetaAnalyticsSkillChatMetricsFromRaw : IFromRawJson<BetaAnalyticsSkillChatMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillChatMetrics.FromRawUnchecked(rawData);
}
