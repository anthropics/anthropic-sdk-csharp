using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Models;

/// <summary>
/// Web search and code execution tool support, with one entry per tool.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ServerToolsCapability, ServerToolsCapabilityFromRaw>))]
public sealed record class ServerToolsCapability : JsonModel
{
    /// <summary>
    /// Whether the model supports the code execution tool: true when the model supports
    /// at least one version of the tool, not necessarily every version.
    /// </summary>
    public required CapabilitySupport CodeExecution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("code_execution");
        }
        init { this._rawData.Set("code_execution", value); }
    }

    /// <summary>
    /// Whether this capability is supported by the model.
    /// </summary>
    public required bool Supported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("supported");
        }
        init { this._rawData.Set("supported", value); }
    }

    /// <summary>
    /// Whether the model supports the web search tool: true when the model supports
    /// at least one version of the tool, not necessarily every version.
    /// </summary>
    public required CapabilitySupport WebSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitySupport>("web_search");
        }
        init { this._rawData.Set("web_search", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CodeExecution.Validate();
        _ = this.Supported;
        this.WebSearch.Validate();
    }

    public ServerToolsCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServerToolsCapability(ServerToolsCapability serverToolsCapability)
        : base(serverToolsCapability) { }
#pragma warning restore CS8618

    public ServerToolsCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolsCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolsCapabilityFromRaw.FromRawUnchecked"/>
    public static ServerToolsCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServerToolsCapabilityFromRaw : IFromRawJson<ServerToolsCapability>
{
    /// <inheritdoc/>
    public ServerToolsCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolsCapability.FromRawUnchecked(rawData);
}
