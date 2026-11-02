using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A connector's use in chat conversations recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorChatCoworkUnifiedChatMetrics,
        AnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorChatCoworkUnifiedChatMetrics : JsonModel
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

    public AnalyticsConnectorChatCoworkUnifiedChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorChatCoworkUnifiedChatMetrics(
        AnalyticsConnectorChatCoworkUnifiedChatMetrics analyticsConnectorChatCoworkUnifiedChatMetrics
    )
        : base(analyticsConnectorChatCoworkUnifiedChatMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorChatCoworkUnifiedChatMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorChatCoworkUnifiedChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorChatCoworkUnifiedChatMetrics(
        long? distinctConversationConnectorUsedCount
    )
        : this()
    {
        this.DistinctConversationConnectorUsedCount = distinctConversationConnectorUsedCount;
    }
}

class AnalyticsConnectorChatCoworkUnifiedChatMetricsFromRaw
    : IFromRawJson<AnalyticsConnectorChatCoworkUnifiedChatMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorChatCoworkUnifiedChatMetrics.FromRawUnchecked(rawData);
}
