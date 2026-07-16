using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Tunnels.Certificates;

/// <summary>
/// A CA certificate attached to a tunnel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaTunnelCertificate, BetaTunnelCertificateFromRaw>))]
public sealed record class BetaTunnelCertificate : JsonModel
{
    /// <summary>
    /// Unique identifier for the certificate, prefixed with `tcrt_`.
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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Lowercase hex SHA-256 fingerprint of the certificate's DER encoding.
    /// </summary>
    public required string Fingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fingerprint");
        }
        init { this._rawData.Set("fingerprint", value); }
    }

    /// <summary>
    /// ID of the tunnel the certificate is registered against.
    /// </summary>
    public required string TunnelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tunnel_id");
        }
        init { this._rawData.Set("tunnel_id", value); }
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
        _ = this.ExpiresAt;
        _ = this.Fingerprint;
        _ = this.TunnelID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("tunnel_certificate")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTunnelCertificate()
    {
        this.Type = JsonSerializer.SerializeToElement("tunnel_certificate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTunnelCertificate(BetaTunnelCertificate betaTunnelCertificate)
        : base(betaTunnelCertificate) { }
#pragma warning restore CS8618

    public BetaTunnelCertificate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tunnel_certificate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTunnelCertificate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTunnelCertificateFromRaw.FromRawUnchecked"/>
    public static BetaTunnelCertificate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTunnelCertificateFromRaw : IFromRawJson<BetaTunnelCertificate>
{
    /// <inheritdoc/>
    public BetaTunnelCertificate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTunnelCertificate.FromRawUnchecked(rawData);
}
