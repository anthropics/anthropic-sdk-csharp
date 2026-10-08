using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Summaries;

/// <summary>
/// Get organization-wide activity summaries for a date range.
///
/// <para>Returns one entry per day from `starting_date` (inclusive) to `ending_date`
/// (exclusive) in `data`, the same `data` / `next_page` envelope as the other analytics
/// list endpoints; the series is currently returned in full, so `next_page` is always
/// null. Data is typically available with a 1-day lag and may be revised by a few
/// percent over the following days: when `ending_date` is omitted it defaults to
/// the most recent available day + 1, so the last entry covers the most recent available
/// day. The series can be scoped to an RBAC group via `filter[]=rbac_group_id:{id}`.
/// Available to organizations on a Claude Enterprise plan. Requires an API key with
/// the `read:analytics` scope.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SummaryListParams : ParamsBase
{
    /// <summary>
    /// UTC date in YYYY-MM-DD format. Start of the date range (inclusive). Data
    /// is typically available with a 1-day lag (varies by query; the error for a
    /// too-recent date names the latest available day) and may be revised by a few
    /// percent over the following days. No earlier than 2026-01-01.
    /// </summary>
    public required string StartingDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("starting_date");
        }
        init { this._rawQueryData.Set("starting_date", value); }
    }

    /// <summary>
    /// UTC date in YYYY-MM-DD format. End of the date range (exclusive). Data is
    /// typically available with a 1-day lag, so this can be at most today — which
    /// is also the default when omitted, making the last entry cover the most recent
    /// available day. Data may be revised by a few percent over the following days.
    /// The range may span at most 366 days.
    /// </summary>
    public string? EndingDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("ending_date");
        }
        init { this._rawQueryData.Set("ending_date", value); }
    }

    /// <summary>
    /// Filters as `dimension:value`. Only `rbac_group_id` is supported (e.g. `filter[]=rbac_group_id:{id}`);
    /// repeat the param to OR across groups. Scopes the whole day series to members
    /// of the matching group(s), re-aggregated from member-level activity — org-wide
    /// seat/invite fields and the adoption rates derived from them are null on scoped
    /// rows. `rbac_group_id` accepts the tagged id (`rbac_group_...`, as emitted
    /// in responses and by the spend-limits API) or a bare group UUID, and matches
    /// users who held the group at any point during each UTC day (time-of-usage
    /// attribution). At most 100 entries.
    /// </summary>
    public IReadOnlyList<string>? Filter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("filter");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "filter",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of results per page (1-1000, default 100). The day series (at most
    /// 366 entries) is currently returned in full in a single page, so `limit` does
    /// not yet shorten it.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init { this._rawQueryData.Set("limit", value); }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `next_page` field. `next_page` is
    /// currently always null, so there is never a cursor to send.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init { this._rawQueryData.Set("page", value); }
    }

    public SummaryListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SummaryListParams(SummaryListParams summaryListParams)
        : base(summaryListParams) { }
#pragma warning restore CS8618

    public SummaryListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SummaryListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SummaryListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(SummaryListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/summaries"
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
