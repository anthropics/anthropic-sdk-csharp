using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Tunnels;

/// <summary>
/// An MCP tunnel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaTunnel, BetaTunnelFromRaw>))]
public sealed record class BetaTunnel : JsonModel
{
    /// <summary>
    /// Unique identifier for the tunnel, prefixed with `tnl_`.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Human-readable name for the tunnel (1-255 characters). Null if unset.
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Anthropic-assigned hostname for the tunnel. MCP server URLs whose host is
    /// a subdomain of this value are routed through the tunnel. Globally unique and
    /// never reused, even after the tunnel is archived.
    /// </summary>
    public required string Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
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
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Domain;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tunnel")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTunnel()
    {
        this.Type = JsonSerializer.SerializeToElement("tunnel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTunnel(BetaTunnel betaTunnel)
        : base(betaTunnel) { }
#pragma warning restore CS8618

    public BetaTunnel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tunnel");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTunnel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTunnelFromRaw.FromRawUnchecked"/>
    public static BetaTunnel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTunnelFromRaw : IFromRawJson<BetaTunnel>
{
    /// <inheritdoc/>
    public BetaTunnel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTunnel.FromRawUnchecked(rawData);
}
