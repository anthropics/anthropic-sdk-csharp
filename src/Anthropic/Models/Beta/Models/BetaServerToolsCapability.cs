using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Web search and code execution tool support, with one entry per tool.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaServerToolsCapability, BetaServerToolsCapabilityFromRaw>)
)]
public sealed record class BetaServerToolsCapability : JsonModel
{
    /// <summary>
    /// Whether the model supports the code execution tool: true when the model supports
    /// at least one version of the tool, not necessarily every version.
    /// </summary>
    public required BetaCapabilitySupport CodeExecution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("code_execution");
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
    public required BetaCapabilitySupport WebSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCapabilitySupport>("web_search");
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

    public BetaServerToolsCapability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServerToolsCapability(BetaServerToolsCapability betaServerToolsCapability)
        : base(betaServerToolsCapability) { }
#pragma warning restore CS8618

    public BetaServerToolsCapability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolsCapability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServerToolsCapabilityFromRaw.FromRawUnchecked"/>
    public static BetaServerToolsCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaServerToolsCapabilityFromRaw : IFromRawJson<BetaServerToolsCapability>
{
    /// <inheritdoc/>
    public BetaServerToolsCapability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaServerToolsCapability.FromRawUnchecked(rawData);
}
