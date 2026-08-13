using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to a single MCP tool by its server and remote name — the same ``server_name``/``name``
/// pair ``mcp_tool_use`` carries.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaToolChangeMcpToolReference,
        BetaToolChangeMcpToolReferenceFromRaw
    >)
)]
public sealed record class BetaToolChangeMcpToolReference : JsonModel
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

    public BetaToolChangeMcpToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChangeMcpToolReference(
        BetaToolChangeMcpToolReference betaToolChangeMcpToolReference
    )
        : base(betaToolChangeMcpToolReference) { }
#pragma warning restore CS8618

    public BetaToolChangeMcpToolReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChangeMcpToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChangeMcpToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaToolChangeMcpToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolChangeMcpToolReferenceFromRaw : IFromRawJson<BetaToolChangeMcpToolReference>
{
    /// <inheritdoc/>
    public BetaToolChangeMcpToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolChangeMcpToolReference.FromRawUnchecked(rawData);
}
