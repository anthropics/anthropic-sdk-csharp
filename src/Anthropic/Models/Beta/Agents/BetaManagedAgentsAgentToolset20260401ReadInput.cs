using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `read` tool. Reads file contents relative to the runner's
/// working directory (or absolute when the runner permits).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401ReadInput,
        BetaManagedAgentsAgentToolset20260401ReadInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401ReadInput : JsonModel
{
    /// <summary>
    /// Path of the file to read.
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
    /// Optional `[start_line, end_line]` 1-indexed inclusive range. When omitted
    /// the entire file is returned. `end_line` of 0 or negative means "to end of
    /// file".
    /// </summary>
    public IReadOnlyList<long>? ViewRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("view_range");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "view_range",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FilePath;
        _ = this.ViewRange;
    }

    public BetaManagedAgentsAgentToolset20260401ReadInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401ReadInput(
        BetaManagedAgentsAgentToolset20260401ReadInput betaManagedAgentsAgentToolset20260401ReadInput
    )
        : base(betaManagedAgentsAgentToolset20260401ReadInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401ReadInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401ReadInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401ReadInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401ReadInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401ReadInput(string filePath)
        : this()
    {
        this.FilePath = filePath;
    }
}

class BetaManagedAgentsAgentToolset20260401ReadInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401ReadInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401ReadInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401ReadInput.FromRawUnchecked(rawData);
}
