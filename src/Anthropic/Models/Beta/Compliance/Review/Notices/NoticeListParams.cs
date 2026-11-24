using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Notices;

/// <summary>
/// List Anthropic's notices to the organizations that the API key can reach, newest
/// first by default. A notice is returned only if the API key can read every case
/// in its `case_ids`.
///
/// <para>To poll, store the largest `created_at` you have read, and send it as the
/// at-or-after filter on `created_at`. Read every page, match results by `id`, and
/// store the new largest value after the last page.</para>
///
/// <para>An Admin API key with the `read:compliance_review_cases` scope can call
/// this endpoint.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NoticeListParams : ParamsBase
{
    /// <summary>
    /// Return only notices whose `case_ids` include this case (`rvc_...`). A case
    /// that the API key can't read returns an empty list.
    /// </summary>
    public string? CaseID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("case_id");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("case_id");
                return;
            }

            this._rawQueryData.Set("case_id", value);
        }
    }

    /// <summary>
    /// Return only notices whose `created_at` is after this time.
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
    /// Return notices whose `created_at` is at or after this time. Notices slightly
    /// older than this time are also returned, so that a poll misses no notice.
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
    /// Return only notices whose `created_at` is before this time.
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
    /// Return only notices whose `created_at` is at or before this time.
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
    /// Number of notices to return per page, between 1 and 100. Defaults to 20.
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
    /// Sort direction, by `created_at` and then by `id`. Defaults to `desc`.
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

    public NoticeListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoticeListParams(NoticeListParams noticeListParams)
        : base(noticeListParams) { }
#pragma warning restore CS8618

    public NoticeListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoticeListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NoticeListParams FromRawUnchecked(
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

    public virtual bool Equals(NoticeListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/compliance/review/notices"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/compliance/review/notices";

    internal override IReadOnlyList<string> QueryParams =>
        [
            "case_id",
            "created_at[gt]",
            "created_at[gte]",
            "created_at[lt]",
            "created_at[lte]",
            "limit",
            "order",
            "page",
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
