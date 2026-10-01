using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Federation.Issuers;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Retrieve a federation issuer by its ID (`fdis_...`).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IssuerRetrieveParams : ParamsBase
{
    public string? FederationIssuerID { get; init; }

    public IssuerRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IssuerRetrieveParams(IssuerRetrieveParams issuerRetrieveParams)
        : base(issuerRetrieveParams)
    {
        this.FederationIssuerID = issuerRetrieveParams.FederationIssuerID;
    }
#pragma warning restore CS8618

    public IssuerRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IssuerRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string federationIssuerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.FederationIssuerID = federationIssuerID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IssuerRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string federationIssuerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            federationIssuerID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FederationIssuerID"] = JsonSerializer.SerializeToElement(
                        this.FederationIssuerID
                    ),
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

    public virtual bool Equals(IssuerRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.FederationIssuerID?.Equals(other.FederationIssuerID)
                ?? other.FederationIssuerID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/federation_issuers/{0}",
                    ParamsBase.EncodePathSegment(
                        this.FederationIssuerID,
                        nameof(this.FederationIssuerID)
                    )
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
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
