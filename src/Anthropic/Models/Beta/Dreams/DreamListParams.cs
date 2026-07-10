using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// List Dreams
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DreamListParams : ParamsBase
{
    /// <summary>
    /// Return dreams with `created_at` strictly after this timestamp (exclusive lower
    /// bound, RFC 3339). Unset applies no lower bound.
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
                return;
            }

            this._rawQueryData.Set("created_at[gt]", value);
        }
    }

    /// <summary>
    /// Return dreams with `created_at` strictly before this timestamp (exclusive
    /// upper bound, RFC 3339). Unset applies no upper bound.
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
                return;
            }

            this._rawQueryData.Set("created_at[lt]", value);
        }
    }

    /// <summary>
    /// Query parameter for include_archived
    /// </summary>
    public bool? IncludeArchived
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_archived");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_archived", value);
        }
    }

    /// <summary>
    /// Query parameter for limit
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
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Query parameter for page
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
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Filter by lifecycle status. Repeat the parameter to match any of multiple
    /// statuses. Empty applies no status filter.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaDreamStatus>>? Statuses
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaDreamStatus>>
            >("statuses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaDreamStatus>>?>(
                "statuses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DreamListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DreamListParams(DreamListParams dreamListParams)
        : base(dreamListParams) { }
#pragma warning restore CS8618

    public DreamListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DreamListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DreamListParams FromRawUnchecked(
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

    public virtual bool Equals(DreamListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/dreams")
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        DreamService.AddDefaultHeaders(request);
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
