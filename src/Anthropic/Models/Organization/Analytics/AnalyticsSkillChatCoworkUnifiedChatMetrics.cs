using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A skill's use in chat conversations recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsSkillChatCoworkUnifiedChatMetrics,
        AnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw
    >)
)]
public sealed record class AnalyticsSkillChatCoworkUnifiedChatMetrics : JsonModel
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

    public AnalyticsSkillChatCoworkUnifiedChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsSkillChatCoworkUnifiedChatMetrics(
        AnalyticsSkillChatCoworkUnifiedChatMetrics analyticsSkillChatCoworkUnifiedChatMetrics
    )
        : base(analyticsSkillChatCoworkUnifiedChatMetrics) { }
#pragma warning restore CS8618

    public AnalyticsSkillChatCoworkUnifiedChatMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsSkillChatCoworkUnifiedChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsSkillChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsSkillChatCoworkUnifiedChatMetrics(long? distinctConversationSkillUsedCount)
        : this()
    {
        this.DistinctConversationSkillUsedCount = distinctConversationSkillUsedCount;
    }
}

class AnalyticsSkillChatCoworkUnifiedChatMetricsFromRaw
    : IFromRawJson<AnalyticsSkillChatCoworkUnifiedChatMetrics>
{
    /// <inheritdoc/>
    public AnalyticsSkillChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsSkillChatCoworkUnifiedChatMetrics.FromRawUnchecked(rawData);
}
