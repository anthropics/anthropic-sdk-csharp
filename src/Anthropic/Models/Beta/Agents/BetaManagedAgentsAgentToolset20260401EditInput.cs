using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `edit` tool. Performs a string replacement in the named
/// file; by default `old_string` must occur exactly once.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401EditInput,
        BetaManagedAgentsAgentToolset20260401EditInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401EditInput : JsonModel
{
    /// <summary>
    /// Path of the file to edit.
    /// </summary>
    public required string FilePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_path");
        }
        init { this._rawData.Set("file_path", value); }
    }

    /// <summary>
    /// Replacement text.
    /// </summary>
    public required string NewString
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("new_string");
        }
        init { this._rawData.Set("new_string", value); }
    }

    /// <summary>
    /// Substring to find and replace.
    /// </summary>
    public required string OldString
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("old_string");
        }
        init { this._rawData.Set("old_string", value); }
    }

    /// <summary>
    /// When true, replace every occurrence of `old_string` instead of requiring
    /// a unique match.
    /// </summary>
    public bool? ReplaceAll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("replace_all");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replace_all", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FilePath;
        _ = this.NewString;
        _ = this.OldString;
        _ = this.ReplaceAll;
    }

    public BetaManagedAgentsAgentToolset20260401EditInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401EditInput(
        BetaManagedAgentsAgentToolset20260401EditInput betaManagedAgentsAgentToolset20260401EditInput
    )
        : base(betaManagedAgentsAgentToolset20260401EditInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401EditInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401EditInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401EditInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401EditInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolset20260401EditInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401EditInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401EditInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401EditInput.FromRawUnchecked(rawData);
}
