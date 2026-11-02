using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Claude Code activity metrics for a single connector on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorClaudeCodeMetrics,
        AnalyticsConnectorClaudeCodeMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorClaudeCodeMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Claude Code sessions in which the connector was used.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSessionConnectorUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_connector_used_count");
        }
        init { this._rawData.Set("distinct_session_connector_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctSessionConnectorUsedCount;
    }

    public AnalyticsConnectorClaudeCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorClaudeCodeMetrics(
        AnalyticsConnectorClaudeCodeMetrics analyticsConnectorClaudeCodeMetrics
    )
        : base(analyticsConnectorClaudeCodeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorClaudeCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorClaudeCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorClaudeCodeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorClaudeCodeMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class AnalyticsConnectorClaudeCodeMetricsFromRaw : IFromRawJson<AnalyticsConnectorClaudeCodeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorClaudeCodeMetrics.FromRawUnchecked(rawData);
}
