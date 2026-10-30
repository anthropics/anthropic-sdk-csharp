using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Claude.ai activity metrics for a single connector on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsConnectorChatMetrics, AnalyticsConnectorChatMetricsFromRaw>)
)]
public sealed record class AnalyticsConnectorChatMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct conversations in which the connector was used. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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

    public AnalyticsConnectorChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorChatMetrics(
        AnalyticsConnectorChatMetrics analyticsConnectorChatMetrics
    )
        : base(analyticsConnectorChatMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorChatMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorChatMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorChatMetrics(long? distinctConversationConnectorUsedCount)
        : this()
    {
        this.DistinctConversationConnectorUsedCount = distinctConversationConnectorUsedCount;
    }
}

class AnalyticsConnectorChatMetricsFromRaw : IFromRawJson<AnalyticsConnectorChatMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorChatMetrics.FromRawUnchecked(rawData);
}
