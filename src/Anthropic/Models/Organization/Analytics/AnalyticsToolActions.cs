using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Per-tool accepted/rejected counts for Claude Code file modification tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnalyticsToolActions, AnalyticsToolActionsFromRaw>))]
public sealed record class AnalyticsToolActions : JsonModel
{
    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required AnalyticsToolActionCounts EditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsToolActionCounts>("edit_tool");
        }
        init { this._rawData.Set("edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required AnalyticsToolActionCounts MultiEditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsToolActionCounts>("multi_edit_tool");
        }
        init { this._rawData.Set("multi_edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required AnalyticsToolActionCounts NotebookEditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsToolActionCounts>("notebook_edit_tool");
        }
        init { this._rawData.Set("notebook_edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required AnalyticsToolActionCounts WriteTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsToolActionCounts>("write_tool");
        }
        init { this._rawData.Set("write_tool", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.EditTool.Validate();
        this.MultiEditTool.Validate();
        this.NotebookEditTool.Validate();
        this.WriteTool.Validate();
    }

    public AnalyticsToolActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsToolActions(AnalyticsToolActions analyticsToolActions)
        : base(analyticsToolActions) { }
#pragma warning restore CS8618

    public AnalyticsToolActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsToolActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsToolActionsFromRaw.FromRawUnchecked"/>
    public static AnalyticsToolActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsToolActionsFromRaw : IFromRawJson<AnalyticsToolActions>
{
    /// <inheritdoc/>
    public AnalyticsToolActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsToolActions.FromRawUnchecked(rawData);
}
