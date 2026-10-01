using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// Delete a spend limit.
///
/// <para>For a Claude Enterprise organization, this deletes a per-user override,
/// and the member falls back to any inherited spend limit at that period. Its seat-tier,
/// group, and organization-level rows cannot be deleted via this endpoint. A Claude
/// Console organization deletes its organization and workspace limits. Deleting
/// them through the API is in an early access preview.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SpendLimitDeleteParams : ParamsBase
{
    public string? SpendLimitID { get; init; }

    public SpendLimitDeleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitDeleteParams(SpendLimitDeleteParams spendLimitDeleteParams)
        : base(spendLimitDeleteParams)
    {
        this.SpendLimitID = spendLimitDeleteParams.SpendLimitID;
    }
#pragma warning restore CS8618

    public SpendLimitDeleteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitDeleteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string spendLimitID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SpendLimitID = spendLimitID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SpendLimitDeleteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string spendLimitID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            spendLimitID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SpendLimitID"] = JsonSerializer.SerializeToElement(this.SpendLimitID),
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

    public virtual bool Equals(SpendLimitDeleteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SpendLimitID?.Equals(other.SpendLimitID) ?? other.SpendLimitID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/spend_limits/{0}",
                    ParamsBase.EncodePathSegment(this.SpendLimitID, nameof(this.SpendLimitID))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
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
