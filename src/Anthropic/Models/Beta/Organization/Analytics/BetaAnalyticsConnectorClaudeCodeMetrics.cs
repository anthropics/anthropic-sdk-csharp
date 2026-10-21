using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Code activity metrics for a single connector on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorClaudeCodeMetrics,
        BetaAnalyticsConnectorClaudeCodeMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorClaudeCodeMetrics : JsonModel
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

    public BetaAnalyticsConnectorClaudeCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorClaudeCodeMetrics(
        BetaAnalyticsConnectorClaudeCodeMetrics betaAnalyticsConnectorClaudeCodeMetrics
    )
        : base(betaAnalyticsConnectorClaudeCodeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorClaudeCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorClaudeCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorClaudeCodeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsConnectorClaudeCodeMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class BetaAnalyticsConnectorClaudeCodeMetricsFromRaw
    : IFromRawJson<BetaAnalyticsConnectorClaudeCodeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorClaudeCodeMetrics.FromRawUnchecked(rawData);
}
