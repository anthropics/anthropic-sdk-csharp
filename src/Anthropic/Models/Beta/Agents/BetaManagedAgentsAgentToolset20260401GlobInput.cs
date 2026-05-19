using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `glob` tool. Returns paths matching a doublestar glob pattern,
/// newest first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401GlobInput,
        BetaManagedAgentsAgentToolset20260401GlobInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401GlobInput : JsonModel
{
    /// <summary>
    /// Doublestar glob pattern (e.g. `**/*.go`). Absolute patterns are only permitted
    /// when the runner is configured to allow them.
    /// </summary>
    public required string Pattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pattern");
        }
        init { this._rawData.Set("pattern", value); }
    }

    /// <summary>
    /// Optional directory root to search under. Defaults to the runner's working
    /// directory.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Pattern;
        _ = this.Path;
    }

    public BetaManagedAgentsAgentToolset20260401GlobInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401GlobInput(
        BetaManagedAgentsAgentToolset20260401GlobInput betaManagedAgentsAgentToolset20260401GlobInput
    )
        : base(betaManagedAgentsAgentToolset20260401GlobInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401GlobInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401GlobInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401GlobInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401GlobInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401GlobInput(string pattern)
        : this()
    {
        this.Pattern = pattern;
    }
}

class BetaManagedAgentsAgentToolset20260401GlobInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401GlobInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401GlobInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401GlobInput.FromRawUnchecked(rawData);
}
