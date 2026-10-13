using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A connector's use in chat conversations recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics,
        BetaAnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `chat_metrics.distinct_conversation_connector_used_count`,
    /// for activity recorded while members had Chat and Cowork unified turned on.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConversationConnectorUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "distinct_conversation_connector_used_count"
            );
        }
        init { this._rawData.Set("distinct_conversation_connector_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctConversationConnectorUsedCount;
    }

    public BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics(
        BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics betaAnalyticsConnectorChatCoworkUnifiedChatMetrics
    )
        : base(betaAnalyticsConnectorChatCoworkUnifiedChatMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics(
        long? distinctConversationConnectorUsedCount
    )
        : this()
    {
        this.DistinctConversationConnectorUsedCount = distinctConversationConnectorUsedCount;
    }
}

class BetaAnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw
    : IFromRawJson<BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorChatCoworkUnifiedChatMetrics.FromRawUnchecked(rawData);
}
