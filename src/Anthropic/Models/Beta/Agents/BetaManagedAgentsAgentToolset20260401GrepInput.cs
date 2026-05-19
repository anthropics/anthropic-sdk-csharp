using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `grep` tool. Searches file contents for a regular expression,
/// returning matching lines.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401GrepInput,
        BetaManagedAgentsAgentToolset20260401GrepInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401GrepInput : JsonModel
{
    /// <summary>
    /// Regular expression to search for.
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

    public BetaManagedAgentsAgentToolset20260401GrepInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401GrepInput(
        BetaManagedAgentsAgentToolset20260401GrepInput betaManagedAgentsAgentToolset20260401GrepInput
    )
        : base(betaManagedAgentsAgentToolset20260401GrepInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401GrepInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401GrepInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401GrepInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401GrepInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401GrepInput(string pattern)
        : this()
    {
        this.Pattern = pattern;
    }
}

class BetaManagedAgentsAgentToolset20260401GrepInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401GrepInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401GrepInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401GrepInput.FromRawUnchecked(rawData);
}
