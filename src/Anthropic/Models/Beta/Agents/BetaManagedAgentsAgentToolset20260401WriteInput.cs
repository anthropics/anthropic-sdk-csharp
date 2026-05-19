using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `write` tool. Writes (overwriting) the entire file contents.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401WriteInput,
        BetaManagedAgentsAgentToolset20260401WriteInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401WriteInput : JsonModel
{
    /// <summary>
    /// Full file contents to write.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Path of the file to write.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.FilePath;
    }

    public BetaManagedAgentsAgentToolset20260401WriteInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401WriteInput(
        BetaManagedAgentsAgentToolset20260401WriteInput betaManagedAgentsAgentToolset20260401WriteInput
    )
        : base(betaManagedAgentsAgentToolset20260401WriteInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401WriteInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401WriteInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401WriteInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401WriteInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolset20260401WriteInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401WriteInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401WriteInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401WriteInput.FromRawUnchecked(rawData);
}
