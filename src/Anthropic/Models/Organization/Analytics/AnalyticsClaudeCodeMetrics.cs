using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Claude Code activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsClaudeCodeMetrics, AnalyticsClaudeCodeMetricsFromRaw>)
)]
public sealed record class AnalyticsClaudeCodeMetrics : JsonModel
{
    /// <summary>
    /// Core Claude Code activity metrics for a single user on a given day.
    /// </summary>
    public required AnalyticsCoreCodeMetrics CoreMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsCoreCodeMetrics>("core_metrics");
        }
        init { this._rawData.Set("core_metrics", value); }
    }

    /// <summary>
    /// Per-tool accepted/rejected counts for Claude Code file modification tools.
    /// </summary>
    public required AnalyticsToolActions ToolActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsToolActions>("tool_actions");
        }
        init { this._rawData.Set("tool_actions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CoreMetrics.Validate();
        this.ToolActions.Validate();
    }

    public AnalyticsClaudeCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsClaudeCodeMetrics(AnalyticsClaudeCodeMetrics analyticsClaudeCodeMetrics)
        : base(analyticsClaudeCodeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsClaudeCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsClaudeCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsClaudeCodeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsClaudeCodeMetricsFromRaw : IFromRawJson<AnalyticsClaudeCodeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsClaudeCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsClaudeCodeMetrics.FromRawUnchecked(rawData);
}
