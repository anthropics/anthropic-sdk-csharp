using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to every tool in the named MCP server's toolset, as a ``compaction``
/// block's ``tool_changes`` entry reports it. Send it back unchanged with the block.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaResponseToolChangeMcpToolsetReference,
        BetaResponseToolChangeMcpToolsetReferenceFromRaw
    >)
)]
public sealed record class BetaResponseToolChangeMcpToolsetReference : JsonModel
{
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
        _ = this.ServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_toolset_reference")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaResponseToolChangeMcpToolsetReference()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_toolset_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseToolChangeMcpToolsetReference(
        BetaResponseToolChangeMcpToolsetReference betaResponseToolChangeMcpToolsetReference
    )
        : base(betaResponseToolChangeMcpToolsetReference) { }
#pragma warning restore CS8618

    public BetaResponseToolChangeMcpToolsetReference(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_toolset_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseToolChangeMcpToolsetReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolChangeMcpToolsetReferenceFromRaw.FromRawUnchecked"/>
    public static BetaResponseToolChangeMcpToolsetReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaResponseToolChangeMcpToolsetReference(string serverName)
        : this()
    {
        this.ServerName = serverName;
    }
}

class BetaResponseToolChangeMcpToolsetReferenceFromRaw
    : IFromRawJson<BetaResponseToolChangeMcpToolsetReference>
{
    /// <inheritdoc/>
    public BetaResponseToolChangeMcpToolsetReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaResponseToolChangeMcpToolsetReference.FromRawUnchecked(rawData);
}
