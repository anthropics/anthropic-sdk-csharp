using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

/// <summary>
/// Retrieve a spend limit increase request.
///
/// <para>While `pending`, the response includes a live `spend_summary` for the requester
/// at the request's period.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IncreaseRequestRetrieveParams : ParamsBase
{
    public string? SpendLimitIncreaseRequestID { get; init; }

    public IncreaseRequestRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncreaseRequestRetrieveParams(
        IncreaseRequestRetrieveParams increaseRequestRetrieveParams
    )
        : base(increaseRequestRetrieveParams)
    {
        this.SpendLimitIncreaseRequestID =
            increaseRequestRetrieveParams.SpendLimitIncreaseRequestID;
    }
#pragma warning restore CS8618

    public IncreaseRequestRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncreaseRequestRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string spendLimitIncreaseRequestID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IncreaseRequestRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string spendLimitIncreaseRequestID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            spendLimitIncreaseRequestID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SpendLimitIncreaseRequestID"] = JsonSerializer.SerializeToElement(
                        this.SpendLimitIncreaseRequestID
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

    public virtual bool Equals(IncreaseRequestRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.SpendLimitIncreaseRequestID?.Equals(other.SpendLimitIncreaseRequestID)
                ?? other.SpendLimitIncreaseRequestID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/spend_limit_increase_requests/{0}",
                    ParamsBase.EncodePathSegment(
                        this.SpendLimitIncreaseRequestID,
                        nameof(this.SpendLimitIncreaseRequestID)
                    )
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
