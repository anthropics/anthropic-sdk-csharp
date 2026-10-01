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

namespace Anthropic.Models.Beta.Organization.Analytics.Plugins;

/// <summary>
/// Get per-plugin install + invocation usage for a given day, with pagination.
///
/// <para>Returns plugin usage metrics for the organization across Cowork and Claude
/// Code, sorted by plugin name. The `plugin_name` value `third-party` is an aggregate
/// bucket, not a plugin: it collects plugin activity, from either surface, for which
/// the reporting client did not provide a plugin name — so an organization's own
/// plugins can contribute both to their own named rows and to this bucket. Use `group_by[]`
/// to break usage out per member, per RBAC group, or per product surface (Cowork
/// / Claude Code), and `filter[]` to scope results; the parameter descriptions list
/// the supported dimensions. Requires an API key with the `read:analytics` scope.
/// `starting_date` / `ending_date` select range-rollup mode like `/skills`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PluginListParams : ParamsBase
{
    /// <summary>
    /// UTC date in YYYY-MM-DD format. The day to get plugin usage for. Data is typically
    /// available with a 1-day lag (varies by query; the error for a too-recent date
    /// names the latest available day) and may be revised by a few percent over the
    /// following days. No earlier than 2026-01-01.
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
    /// dimensions on this endpoint: `plugin_name`, `product`, `rbac_group_id`, `user_id`.
    /// Value forms: `plugin_name` matches case-insensitively; `product` is `claude_code`
    /// or `cowork` (the only surfaces with plugin attribution); `rbac_group_id`
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
    /// Dimensions to break results out by (e.g. `group_by[]=user_id`). Supported
    /// on this endpoint: `product`, `rbac_group_id`, `user_id`. On this endpoint
    /// `product` takes the values `claude_code` or `cowork` only (the surfaces with
    /// plugin attribution). Grouped rows carry the requested dimension values as
    /// additional fields and paginate like ungrouped responses via `next_page`;
    /// an unsupported dimension returns 400. `rbac_group_id` attributes a user to
    /// every group they held at any point during each covered UTC day, so grouped
    /// rows are not an exclusive partition and can sum above org-level totals. At
    /// most 100 entries.
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

    public PluginListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginListParams(PluginListParams pluginListParams)
        : base(pluginListParams) { }
#pragma warning restore CS8618

    public PluginListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PluginListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PluginListParams FromRawUnchecked(
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

    public virtual bool Equals(PluginListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/plugins"
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
    Product,
    RbacGroupID,
    UserID,
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
            "product" => GroupBy.Product,
            "rbac_group_id" => GroupBy.RbacGroupID,
            "user_id" => GroupBy.UserID,
            _ => (GroupBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, GroupBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupBy.Product => "product",
                GroupBy.RbacGroupID => "rbac_group_id",
                GroupBy.UserID => "user_id",
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
