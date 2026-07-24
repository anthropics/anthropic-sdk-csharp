using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to a single tool the caller declared directly in ``tools[]``. Does
/// not accept the composed ``{server}_{name}`` form the server assigns to MCP-resolved
/// tools — use ``mcp_tool_reference`` or ``mcp_toolset_reference`` for those.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaToolChangeToolReference, BetaToolChangeToolReferenceFromRaw>)
)]
public sealed record class BetaToolChangeToolReference : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_reference")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolChangeToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChangeToolReference(BetaToolChangeToolReference betaToolChangeToolReference)
        : base(betaToolChangeToolReference) { }
#pragma warning restore CS8618

    public BetaToolChangeToolReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChangeToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChangeToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaToolChangeToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolChangeToolReference(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaToolChangeToolReferenceFromRaw : IFromRawJson<BetaToolChangeToolReference>
{
    /// <inheritdoc/>
    public BetaToolChangeToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolChangeToolReference.FromRawUnchecked(rawData);
}
