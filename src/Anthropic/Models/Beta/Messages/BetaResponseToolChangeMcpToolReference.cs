using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to a single MCP tool, by its server and its name on that server, as
/// a ``compaction`` block's ``tool_changes`` entry reports it. Send it back unchanged
/// with the block.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaResponseToolChangeMcpToolReference,
        BetaResponseToolChangeMcpToolReferenceFromRaw
    >)
)]
public sealed record class BetaResponseToolChangeMcpToolReference : JsonModel
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

    public required string ServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server_name");
        }
        init { this._rawData.Set("server_name", value); }
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
        _ = this.ServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_tool_reference")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaResponseToolChangeMcpToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseToolChangeMcpToolReference(
        BetaResponseToolChangeMcpToolReference betaResponseToolChangeMcpToolReference
    )
        : base(betaResponseToolChangeMcpToolReference) { }
#pragma warning restore CS8618

    public BetaResponseToolChangeMcpToolReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseToolChangeMcpToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolChangeMcpToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaResponseToolChangeMcpToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaResponseToolChangeMcpToolReferenceFromRaw
    : IFromRawJson<BetaResponseToolChangeMcpToolReference>
{
    /// <inheritdoc/>
    public BetaResponseToolChangeMcpToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaResponseToolChangeMcpToolReference.FromRawUnchecked(rawData);
}
