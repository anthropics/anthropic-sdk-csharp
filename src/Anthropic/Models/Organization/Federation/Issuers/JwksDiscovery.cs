using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Federation.Issuers;

/// <summary>
/// JWKS via the issuer's OIDC discovery document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JwksDiscovery, JwksDiscoveryFromRaw>))]
public sealed record class JwksDiscovery : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional custom CA (PEM) for TLS verification of the JWKS fetch.
    /// </summary>
    public string? CACertPem
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ca_cert_pem");
        }
        init { this._rawData.Set("ca_cert_pem", value); }
    }

    /// <summary>
    /// Set when the discovery URL differs from `issuer_url`.
    /// </summary>
    public string? DiscoveryBase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discovery_base");
        }
        init { this._rawData.Set("discovery_base", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("discovery")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.CACertPem;
        _ = this.DiscoveryBase;
    }

    public JwksDiscovery()
    {
        this.Type = JsonSerializer.SerializeToElement("discovery");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JwksDiscovery(JwksDiscovery jwksDiscovery)
        : base(jwksDiscovery) { }
#pragma warning restore CS8618

    public JwksDiscovery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("discovery");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JwksDiscovery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JwksDiscoveryFromRaw.FromRawUnchecked"/>
    public static JwksDiscovery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JwksDiscoveryFromRaw : IFromRawJson<JwksDiscovery>
{
    /// <inheritdoc/>
    public JwksDiscovery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JwksDiscovery.FromRawUnchecked(rawData);
}
