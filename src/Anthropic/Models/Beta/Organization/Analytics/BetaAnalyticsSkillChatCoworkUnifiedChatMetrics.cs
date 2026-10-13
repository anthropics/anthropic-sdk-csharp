using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A skill's use in chat conversations recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics,
        BetaAnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsSkillChatCoworkUnifiedChatMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `chat_metrics.distinct_conversation_skill_used_count`, for
    /// activity recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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

    public BetaAnalyticsSkillChatCoworkUnifiedChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillChatCoworkUnifiedChatMetrics(
        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics betaAnalyticsSkillChatCoworkUnifiedChatMetrics
    )
        : base(betaAnalyticsSkillChatCoworkUnifiedChatMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillChatCoworkUnifiedChatMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillChatCoworkUnifiedChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsSkillChatCoworkUnifiedChatMetrics(long? distinctConversationSkillUsedCount)
        : this()
    {
        this.DistinctConversationSkillUsedCount = distinctConversationSkillUsedCount;
    }
}

class BetaAnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw
    : IFromRawJson<BetaAnalyticsSkillChatCoworkUnifiedChatMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillChatCoworkUnifiedChatMetrics.FromRawUnchecked(rawData);
}
