using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Tunnels;

namespace Anthropic.Models.Beta.Tunnels.Certificates;

/// <summary>
/// The Tunnels API is in research preview. It requires the `anthropic-beta: mcp-tunnels-2026-06-22`
/// header and may change without a deprecation period. It supersedes the Admin API
/// endpoints at `/v1/organizations/tunnels`, which remain available during a migration window.
///
/// <para>Archives a tunnel certificate, removing it from the set Anthropic trusts
/// for the tunnel. The certificate record is retained. Archiving the last non-archived
/// certificate is permitted; the tunnel rejects MCP traffic until a new certificate
/// is added.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CertificateArchiveParams : ParamsBase
{
    public required string TunnelID { get; init; }

    public string? CertificateID { get; init; }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CertificateArchiveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CertificateArchiveParams(CertificateArchiveParams certificateArchiveParams)
        : base(certificateArchiveParams)
    {
        this.TunnelID = certificateArchiveParams.TunnelID;
        this.CertificateID = certificateArchiveParams.CertificateID;
    }
#pragma warning restore CS8618

    public CertificateArchiveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CertificateArchiveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string tunnelID,
        string certificateID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.TunnelID = tunnelID;
        this.CertificateID = certificateID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CertificateArchiveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string tunnelID,
        string certificateID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            tunnelID,
            certificateID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["TunnelID"] = JsonSerializer.SerializeToElement(this.TunnelID),
                    ["CertificateID"] = JsonSerializer.SerializeToElement(this.CertificateID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CertificateArchiveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.TunnelID.Equals(other.TunnelID)
            && (this.CertificateID?.Equals(other.CertificateID) ?? other.CertificateID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/tunnels/{0}/certificates/{1}/archive",
                    this.TunnelID,
                    this.CertificateID
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        CertificateService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
