using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// List User Profiles
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserProfileListParams : ParamsBase
{
    /// <summary>
    /// Return only the user profiles whose `enforcement_status` is one of these values:
    /// `unrestricted`, `pending`, `restricted` or `banned`. Repeat the parameter
    /// to match any of several. With it set, a page may hold fewer than `limit` profiles,
    /// or none, and still carry a `next_page`: the service examines a bounded number
    /// of profiles per request, and only a null `next_page` means the listing is
    /// complete. Rejected with `invalid_request_error` under the `user-profiles-2026-09-04`
    /// and earlier beta headers. Fails with `overloaded_error` when a profile's enforcement
    /// actions cannot be read for the moment.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, UserProfileEnforcementStatus>>? EnforcementStatus
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, UserProfileEnforcementStatus>>
            >("enforcement_status");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("enforcement_status");
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, UserProfileEnforcementStatus>>?>(
                "enforcement_status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum number of user profiles to return, from 1 to 100. Defaults to 20.
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
    /// The sort direction, applied to the field that `order_by` selects. Defaults
    /// to `desc`.
    /// </summary>
    public ApiEnum<string, UserProfileListOrder>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, UserProfileListOrder>>(
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
    /// The field to sort user profiles by, in the direction that `order` sets. Defaults
    /// to `created_at`.
    /// </summary>
    public ApiEnum<string, UserProfileListOrderBy>? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, UserProfileListOrderBy>>(
                "order_by"
            );
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
    /// The cursor for the page to return, taken from `next_page` in a previous response.
    ///
    /// <para>Leave it out to get the first page.</para>
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
    /// Optional header to select the Workspace for this request. The value is a Workspace
    /// ID (for example, `wrkspc_011CZkZaBF1tNoB5wlCeusgy`).
    ///
    /// <para>Only needed for credentials that can act on more than one Workspace.
    /// A credential that belongs to a specific Workspace may omit it; if sent, it
    /// must match that Workspace.</para>
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("anthropic-workspace-id");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-workspace-id");
                return;
            }

            this._rawHeaderData.Set("anthropic-workspace-id", value);
        }
    }

    public UserProfileListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileListParams(UserProfileListParams userProfileListParams)
        : base(userProfileListParams) { }
#pragma warning restore CS8618

    public UserProfileListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserProfileListParams FromRawUnchecked(
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

    public virtual bool Equals(UserProfileListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/user_profiles")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/user_profiles";

    internal override IReadOnlyList<string> QueryParams =>
        ["enforcement_status", "limit", "order", "order_by", "page"];

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
