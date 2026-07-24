using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to every tool in the named MCP server's toolset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaToolChangeMcpToolsetReference,
        BetaToolChangeMcpToolsetReferenceFromRaw
    >)
)]
public sealed record class BetaToolChangeMcpToolsetReference : JsonModel
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

    public BetaToolChangeMcpToolsetReference()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_toolset_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChangeMcpToolsetReference(
        BetaToolChangeMcpToolsetReference betaToolChangeMcpToolsetReference
    )
        : base(betaToolChangeMcpToolsetReference) { }
#pragma warning restore CS8618

    public BetaToolChangeMcpToolsetReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_toolset_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChangeMcpToolsetReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChangeMcpToolsetReferenceFromRaw.FromRawUnchecked"/>
    public static BetaToolChangeMcpToolsetReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolChangeMcpToolsetReference(string serverName)
        : this()
    {
        this.ServerName = serverName;
    }
}

class BetaToolChangeMcpToolsetReferenceFromRaw : IFromRawJson<BetaToolChangeMcpToolsetReference>
{
    /// <inheritdoc/>
    public BetaToolChangeMcpToolsetReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolChangeMcpToolsetReference.FromRawUnchecked(rawData);
}
