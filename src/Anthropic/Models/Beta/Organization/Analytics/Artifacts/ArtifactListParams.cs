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

namespace Anthropic.Models.Beta.Organization.Analytics.Artifacts;

/// <summary>
/// Get artifact-creation activity for a given day, broken out by MIME type.
///
/// <para>Returns the full (`artifact_type`, `is_shared`) cube for the organization;
/// `next_page` is null except for grouped queries, which paginate. The cube can be
/// broken out per product, per member, or per RBAC group via `group_by[]`, and scoped
/// via `filter[]`. Requires an API key with the `read:analytics` scope.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ArtifactListParams : ParamsBase
{
    /// <summary>
    /// UTC date in YYYY-MM-DD format. The day to get artifact activity for. Data
    /// is typically available with a 1-day lag (varies by query; the error for a
    /// too-recent date names the latest available day) and may be revised by a few
    /// percent over the following days. No earlier than 2026-01-01.
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("date");
        }
        init { this._rawQueryData.Set("date", value); }
    }

    /// <summary>
    /// Filters as `dimension:value`, e.g. `filter[]=rbac_group_id:{id}`. Repeat
    /// the param for OR within a dimension and across dimensions for AND. Supported
    /// dimensions on this endpoint: `artifact_type`, `is_shared`, `product`, `rbac_group_id`,
    /// `user_id`. Value forms: `artifact_type` is a canonical artifact MIME type
    /// (e.g. `text/markdown`) or `other`; `is_shared` is `true` or `false`; `product`
    /// is `chat_cowork_unified`, `chat`, `claude_code`, or `cowork` (the surfaces
    /// that create artifacts); `rbac_group_id` takes the tagged id (`rbac_group_...`,
    /// as emitted in responses and by the spend-limits API) or a bare group UUID,
    /// and matches users who held the group at any point during each covered UTC
    /// day (time-of-usage attribution); `user_id` takes a tagged user id (`user_...`),
    /// as emitted in responses. An unsupported dimension returns 400. At most 100
    /// entries. `chat_cowork_unified` is accepted as a `product` value only on deployments
    /// that offer Chat and Cowork unified.
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
    /// Dimensions to break results out by: `product`, `user_id` and/or `rbac_group_id`.
    /// The ungrouped artifact-type cube is finite and returned in full; grouped queries
    /// multiply the cube and paginate via `next_page`. `product` takes the values
    /// `chat_cowork_unified`, `chat`, `claude_code`, or `cowork` (the surfaces that
    /// create artifacts). `rbac_group_id` attributes a user to every group they held
    /// at any point during the requested UTC day, so grouped rows are not an exclusive
    /// partition. At most 100 entries.
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
    /// Maximum rows to return (1-1000, default 100). The ungrouped artifact-type
    /// cube is finite and returned in full; `limit` is the page size only when `group_by[]`
    /// multiplies the cube.
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
    /// Opaque cursor from a previous response's `next_page` field. Only valid with
    /// `group_by[]` — the ungrouped cube is never paginated.
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

    public ArtifactListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactListParams(ArtifactListParams artifactListParams)
        : base(artifactListParams) { }
#pragma warning restore CS8618

    public ArtifactListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ArtifactListParams FromRawUnchecked(
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

    public virtual bool Equals(ArtifactListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/artifacts"
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
