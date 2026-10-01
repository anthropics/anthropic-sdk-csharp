using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.Users;

/// <summary>
/// Get per-user activity for a given day, with cursor-based pagination.
///
/// <para>Returns activity metrics for each user in the organization, sorted by email
/// address. Use `group_by[]` for per-RBAC-group aggregates, or `filter[]` to scope
/// results to specific members, groups, or a chat project. Available to organizations
/// on a Claude Enterprise plan. Requires an API key with the `read:analytics` scope.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserListParams : ParamsBase
{
    /// <summary>
    /// UTC date in YYYY-MM-DD format. The day to get user activity for. Data is
    /// typically available with a 1-day lag (varies by query; the error for a too-recent
    /// date names the latest available day) and may be revised by a few percent
    /// over the following days. No earlier than 2026-01-01.
    /// </summary>
    public string? Date
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("date");
        }
        init { this._rawQueryData.Set("date", value); }
    }

    /// <summary>
    /// UTC date in YYYY-MM-DD format. End of the date range (exclusive); only valid
    /// with `starting_date`. Data is typically available with a 1-day lag (varies
    /// by query; the error for a too-recent date names the latest available day),
    /// so this can be at most today — which is also the default when omitted, resolved
    /// once when the first page is served and reused for the rest of the pagination
    /// sequence. At most 366 days after `starting_date`.
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
    /// Filters as `dimension:value`, e.g. `filter[]=rbac_group_id:{id}`. Repeat
    /// the param for OR within a dimension and across dimensions for AND. Supported
    /// dimensions on this endpoint: `project_id`, `rbac_group_id`, `user_id`. Value
    /// forms: `project_id` takes a tagged project id (`claude_proj_...`) and scopes
    /// each member's row to their claude.ai chat activity within that project (it
    /// cannot be combined with `group_by[]` or an `rbac_group_id` filter); `rbac_group_id`
    /// takes the tagged id (`rbac_group_...`, as emitted in responses and by the
    /// spend-limits API) or a bare group UUID, and matches users who held the group
    /// at any point during each covered UTC day (time-of-usage attribution); `user_id`
    /// takes a tagged user id (`user_...`), as emitted in responses. An unsupported
    /// dimension returns 400. At most 100 entries.
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
    /// Dimensions to break results out by (e.g. `group_by[]=rbac_group_id`). Supported
    /// on this endpoint: `rbac_group_id`. Rows are already per-member, so the one
    /// supported grouping aggregates them per RBAC group instead. Grouped rows carry
    /// the requested dimension values as additional fields and paginate like ungrouped
    /// responses via `next_page`; an unsupported dimension returns 400. `rbac_group_id`
    /// attributes a user to every group they held at any point during each covered
    /// UTC day, so grouped rows are not an exclusive partition and can sum above
    /// org-level totals. At most 100 entries.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, GroupBy>>? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, GroupBy>>>(
                "group_by"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, GroupBy>>?>(
                "group_by",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of results per page (1-1000, default 100).
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
    /// Sort direction: `asc` or `desc`. Defaults to `asc` for the endpoint's sort
    /// column and to `desc` when `order_by` names a metric (a top-N ranking). Applies
    /// to `order_by`, or to the endpoint's default sort field when `order_by` is omitted.
    /// </summary>
    public ApiEnum<string, Order>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Order>>("order");
        }
        init { this._rawQueryData.Set("order", value); }
    }

    /// <summary>
    /// Sort field. Restricted to the endpoint's sort column plus its rankable metrics
    /// (metrics default to descending; a few metrics rank in date-range mode only,
    /// per the endpoint's documented orderable set).
    /// </summary>
    public string? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("order_by");
        }
        init { this._rawQueryData.Set("order_by", value); }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `next_page` field.
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

    /// <summary>
    /// UTC date in YYYY-MM-DD format. Start of a date range (inclusive). Enables
    /// rollup mode: one row per entity aggregated over the whole range — addable
    /// counters are summed across days, and a distinct count is never summed where
    /// summing could double-count (a field's range value is recomputed exactly over
    /// the window, approximate via HLL with typical error under 2%, null, or — for
    /// the creation-event counts, whose per-day values cannot overlap — a per-day
    /// sum that is itself exact; each field's own description says which). Use either
    /// `date` or `starting_date`, not both. Data is typically available with a 1-day
    /// lag (varies by query; the error for a too-recent date names the latest available
    /// day) and may be revised by a few percent over the following days. No earlier
    /// than 2026-01-01.
    /// </summary>
    public string? StartingDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("starting_date");
        }
        init { this._rawQueryData.Set("starting_date", value); }
    }

    public UserListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListParams(UserListParams userListParams)
        : base(userListParams) { }
#pragma warning restore CS8618

    public UserListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserListParams FromRawUnchecked(
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

    public virtual bool Equals(UserListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/users"
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

[JsonConverter(typeof(GroupByConverter))]
public enum GroupBy
{
    RbacGroupID,
}

sealed class GroupByConverter : JsonConverter<GroupBy>
{
    public override GroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rbac_group_id" => GroupBy.RbacGroupID,
            _ => (GroupBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, GroupBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupBy.RbacGroupID => "rbac_group_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort direction: `asc` or `desc`. Defaults to `asc` for the endpoint's sort column
/// and to `desc` when `order_by` names a metric (a top-N ranking). Applies to `order_by`,
/// or to the endpoint's default sort field when `order_by` is omitted.
/// </summary>
[JsonConverter(typeof(OrderConverter))]
public enum Order
{
    Asc,
    Desc,
}

sealed class OrderConverter : JsonConverter<Order>
{
    public override Order Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => Order.Asc,
            "desc" => Order.Desc,
            _ => (Order)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Order.Asc => "asc",
                Order.Desc => "desc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
