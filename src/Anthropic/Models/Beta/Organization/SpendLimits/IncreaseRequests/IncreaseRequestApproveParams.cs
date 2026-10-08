using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

/// <summary>
/// Approve a pending spend limit increase request.
///
/// <para>Writes a per-user spend limit at `amount` for the requester and transitions
/// the request to `approved`. `period` defaults to the period the member was blocked
/// on. Anthropic emails the requester unless `suppress_notification` is set.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IncreaseRequestApproveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SpendLimitIncreaseRequestID { get; init; }

    /// <summary>
    /// New per-user spend limit as a non-negative integer decimal string (minor units).
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("amount");
        }
        init { this._rawBodyData.Set("amount", value); }
    }

    public ApiEnum<string, BetaSpendLimitPeriod>? Period
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BetaSpendLimitPeriod>>(
                "period"
            );
        }
        init { this._rawBodyData.Set("period", value); }
    }

    public bool? SuppressNotification
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("suppress_notification");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("suppress_notification");
                return;
            }

            this._rawBodyData.Set("suppress_notification", value);
        }
    }

    public IncreaseRequestApproveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncreaseRequestApproveParams(IncreaseRequestApproveParams increaseRequestApproveParams)
        : base(increaseRequestApproveParams)
    {
        this.SpendLimitIncreaseRequestID = increaseRequestApproveParams.SpendLimitIncreaseRequestID;

        this._rawBodyData = new(increaseRequestApproveParams._rawBodyData);
    }
#pragma warning restore CS8618

    public IncreaseRequestApproveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncreaseRequestApproveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string spendLimitIncreaseRequestID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IncreaseRequestApproveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string spendLimitIncreaseRequestID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(IncreaseRequestApproveParams? other)
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
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/spend_limit_increase_requests/{0}/approve",
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
