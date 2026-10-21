using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-tool accepted/rejected counts for Claude Code file modification tools.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsToolActions, BetaAnalyticsToolActionsFromRaw>)
)]
public sealed record class BetaAnalyticsToolActions : JsonModel
{
    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required BetaAnalyticsToolActionCounts EditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsToolActionCounts>("edit_tool");
        }
        init { this._rawData.Set("edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required BetaAnalyticsToolActionCounts MultiEditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsToolActionCounts>("multi_edit_tool");
        }
        init { this._rawData.Set("multi_edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required BetaAnalyticsToolActionCounts NotebookEditTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsToolActionCounts>(
                "notebook_edit_tool"
            );
        }
        init { this._rawData.Set("notebook_edit_tool", value); }
    }

    /// <summary>
    /// Accepted/rejected counts for a single Claude Code tool type.
    /// </summary>
    public required BetaAnalyticsToolActionCounts WriteTool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsToolActionCounts>("write_tool");
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

    public BetaAnalyticsToolActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsToolActions(BetaAnalyticsToolActions betaAnalyticsToolActions)
        : base(betaAnalyticsToolActions) { }
#pragma warning restore CS8618

    public BetaAnalyticsToolActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsToolActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsToolActionsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsToolActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsToolActionsFromRaw : IFromRawJson<BetaAnalyticsToolActions>
{
    /// <inheritdoc/>
    public BetaAnalyticsToolActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsToolActions.FromRawUnchecked(rawData);
}
