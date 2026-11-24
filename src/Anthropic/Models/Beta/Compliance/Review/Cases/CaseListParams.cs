using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// List the review cases of every organization that the API key can reach, newest
/// first by default. Both open and closed cases are returned unless `status` is set.
///
/// <para>To sync, store the largest `updated_at` you have read, and send it as the
/// at-or-after filter on `updated_at`, sorted by `updated_at` ascending. That finds
/// new cases, newly closed cases, and cases with a new notice. Read every page,
/// match results by `id`, and store the new largest value after the last page.</para>
///
/// <para>A request with the `anthropic-user-profile-id` header and no `user_profile_id`
/// parameter returns a 400 error.</para>
///
/// <para>An Admin API key with the `read:compliance_review_cases` scope can call
/// this endpoint.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CaseListParams : ParamsBase
{
    /// <summary>
    /// Return only cases whose `created_at` is after this time.
    /// </summary>
    public DateTimeOffset? CreatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gt]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("created_at[gt]");
                return;
            }

            this._rawQueryData.Set("created_at[gt]", value);
        }
    }

    /// <summary>
    /// Return only cases whose `created_at` is at or after this time.
    /// </summary>
    public DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[gte]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("created_at[gte]");
                return;
            }

            this._rawQueryData.Set("created_at[gte]", value);
        }
    }

    /// <summary>
    /// Return only cases whose `created_at` is before this time.
    /// </summary>
    public DateTimeOffset? CreatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lt]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("created_at[lt]");
                return;
            }

            this._rawQueryData.Set("created_at[lt]", value);
        }
    }

    /// <summary>
    /// Return only cases whose `created_at` is at or before this time.
    /// </summary>
    public DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at[lte]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("created_at[lte]");
                return;
            }

            this._rawQueryData.Set("created_at[lte]", value);
        }
    }

    /// <summary>
    /// Number of cases to return per page, between 1 and 100. Defaults to 20.
    /// </summary>
    public int? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<int>("limit");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("limit");
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Sort direction, by `order_by` and then by `id`. Defaults to `desc`.
    /// </summary>
    public ApiEnum<string, BetaComplianceReviewOrder>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, BetaComplianceReviewOrder>>(
                "order"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("order");
                return;
            }

            this._rawQueryData.Set("order", value);
        }
    }

    /// <summary>
    /// The field to sort by. Defaults to `created_at`.
    /// </summary>
    public ApiEnum<string, BetaComplianceReviewCaseOrderBy>? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaComplianceReviewCaseOrderBy>
            >("order_by");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("order_by");
                return;
            }

            this._rawQueryData.Set("order_by", value);
        }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `next_page`. Leave it out to get
    /// the first page. A cursor works only with the filters and sort order of the
    /// request that returned it.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("page");
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Return only cases with this status. Leave it out to get both open and closed cases.
    /// </summary>
    public ApiEnum<string, BetaComplianceReviewCaseStatusFilter>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaComplianceReviewCaseStatusFilter>
            >("status");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("status");
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Return only cases whose `updated_at` is after this time.
    /// </summary>
    public DateTimeOffset? UpdatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("updated_at[gt]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("updated_at[gt]");
                return;
            }

            this._rawQueryData.Set("updated_at[gt]", value);
        }
    }

    /// <summary>
    /// Return cases whose `updated_at` is at or after this time. Cases slightly
    /// older than this time are also returned, so that a sync misses no change.
    /// </summary>
    public DateTimeOffset? UpdatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("updated_at[gte]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("updated_at[gte]");
                return;
            }

            this._rawQueryData.Set("updated_at[gte]", value);
        }
    }

    /// <summary>
    /// Return only cases whose `updated_at` is before this time.
    /// </summary>
    public DateTimeOffset? UpdatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("updated_at[lt]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("updated_at[lt]");
                return;
            }

            this._rawQueryData.Set("updated_at[lt]", value);
        }
    }

    /// <summary>
    /// Return only cases whose `updated_at` is at or before this time.
    /// </summary>
    public DateTimeOffset? UpdatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("updated_at[lte]");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("updated_at[lte]");
                return;
            }

            this._rawQueryData.Set("updated_at[lte]", value);
        }
    }

    /// <summary>
    /// Return only cases where a message's `user_profile_id` is this ID, including
    /// cases that also have messages of other user profiles. A case stops matching
    /// once its messages' `user_profile_id` is null. An ID that matches no reachable
    /// case returns no cases. A request that sends the `anthropic-user-profile-id`
    /// header without this parameter returns a 400 error.
    /// </summary>
    public string? UserProfileID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("user_profile_id");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("user_profile_id");
                return;
            }

            this._rawQueryData.Set("user_profile_id", value);
        }
    }

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
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CaseListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CaseListParams(CaseListParams caseListParams)
        : base(caseListParams) { }
#pragma warning restore CS8618

    public CaseListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CaseListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CaseListParams FromRawUnchecked(
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

    public virtual bool Equals(CaseListParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/compliance/review/cases"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/compliance/review/cases";

    internal override IReadOnlyList<string> QueryParams =>
        [
            "created_at[gt]",
            "created_at[gte]",
            "created_at[lt]",
            "created_at[lte]",
            "limit",
            "order",
            "order_by",
            "page",
            "status",
            "updated_at[gt]",
            "updated_at[gte]",
            "updated_at[lt]",
            "updated_at[lte]",
            "user_profile_id",
        ];

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
