using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Federation.Issuers;

/// <summary>
/// JWKS fetched from a fixed endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaJwksExplicitUrl, BetaJwksExplicitUrlFromRaw>))]
public sealed record class BetaJwksExplicitUrl : JsonModel
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
    /// JWKS endpoint.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("explicit_url")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.CACertPem;
    }

    public BetaJwksExplicitUrl()
    {
        this.Type = JsonSerializer.SerializeToElement("explicit_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaJwksExplicitUrl(BetaJwksExplicitUrl betaJwksExplicitUrl)
        : base(betaJwksExplicitUrl) { }
#pragma warning restore CS8618

    public BetaJwksExplicitUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("explicit_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaJwksExplicitUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaJwksExplicitUrlFromRaw.FromRawUnchecked"/>
    public static BetaJwksExplicitUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaJwksExplicitUrl(string url)
        : this()
    {
        this.Url = url;
    }
}

class BetaJwksExplicitUrlFromRaw : IFromRawJson<BetaJwksExplicitUrl>
{
    /// <inheritdoc/>
    public BetaJwksExplicitUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaJwksExplicitUrl.FromRawUnchecked(rawData);
}
