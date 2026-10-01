using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Code activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsClaudeCodeMetrics,
        BetaAnalyticsClaudeCodeMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsClaudeCodeMetrics : JsonModel
{
    /// <summary>
    /// Core Claude Code activity metrics for a single user on a given day.
    /// </summary>
    public required BetaAnalyticsCoreCodeMetrics CoreMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsCoreCodeMetrics>("core_metrics");
        }
        init { this._rawData.Set("core_metrics", value); }
    }

    /// <summary>
    /// Per-tool accepted/rejected counts for Claude Code file modification tools.
    /// </summary>
    public required BetaAnalyticsToolActions ToolActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsToolActions>("tool_actions");
        }
        init { this._rawData.Set("tool_actions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CoreMetrics.Validate();
        this.ToolActions.Validate();
    }

    public BetaAnalyticsClaudeCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsClaudeCodeMetrics(
        BetaAnalyticsClaudeCodeMetrics betaAnalyticsClaudeCodeMetrics
    )
        : base(betaAnalyticsClaudeCodeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsClaudeCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsClaudeCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsClaudeCodeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsClaudeCodeMetricsFromRaw : IFromRawJson<BetaAnalyticsClaudeCodeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsClaudeCodeMetrics.FromRawUnchecked(rawData);
}
