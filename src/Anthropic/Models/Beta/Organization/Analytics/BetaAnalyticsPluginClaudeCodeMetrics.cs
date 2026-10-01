using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Code activity metrics for a single plugin on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsPluginClaudeCodeMetrics,
        BetaAnalyticsPluginClaudeCodeMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsPluginClaudeCodeMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Claude Code sessions in which the plugin was invoked.
    /// Null on aggregated rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSessionPluginUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_plugin_used_count");
        }
        init { this._rawData.Set("distinct_session_plugin_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctSessionPluginUsedCount;
    }

    public BetaAnalyticsPluginClaudeCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsPluginClaudeCodeMetrics(
        BetaAnalyticsPluginClaudeCodeMetrics betaAnalyticsPluginClaudeCodeMetrics
    )
        : base(betaAnalyticsPluginClaudeCodeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsPluginClaudeCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsPluginClaudeCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsPluginClaudeCodeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsPluginClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsPluginClaudeCodeMetrics(long? distinctSessionPluginUsedCount)
        : this()
    {
        this.DistinctSessionPluginUsedCount = distinctSessionPluginUsedCount;
    }
}

class BetaAnalyticsPluginClaudeCodeMetricsFromRaw
    : IFromRawJson<BetaAnalyticsPluginClaudeCodeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsPluginClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsPluginClaudeCodeMetrics.FromRawUnchecked(rawData);
}
