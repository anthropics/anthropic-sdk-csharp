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

namespace Anthropic.Models.Beta.Organization.Invites;

/// <summary>
/// List the organization's invites.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InviteListParams : ParamsBase
{
    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns
    /// the page of results immediately after this object.
    /// </summary>
    public string? AfterID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("after_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("after_id", value);
        }
    }

    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns
    /// the page of results immediately before this object.
    /// </summary>
    public string? BeforeID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("before_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("before_id", value);
        }
    }

    /// <summary>
    /// Filter by the email address the Invite was sent to. Matches the same way
    /// as the Users list's `email` filter (normalized, case-insensitive).
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("email", value);
        }
    }

    /// <summary>
    /// Number of items to return per page.
    ///
    /// <para>Defaults to `20`. Ranges from `1` to `1000`.</para>
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
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
    /// Filter to items whose `role` equals one of the supplied values. Repeatable;
    /// values are OR'ed together.
    ///
    /// <para>Accepted values depend on the organization type: Console and API organizations
    /// accept `user`, `developer`, `billing`, `admin`, and `claude_code_user`; Claude
    /// Enterprise organizations accept `user`, `owner`, `primary_owner`, `membership_admin`,
    /// and `managed`.</para>
    /// </summary>
    public IReadOnlyList<string>? Roles
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("roles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "roles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter by Invite status. Repeatable; values are OR'ed together. Omit to return
    /// `pending`, `accepted`, and `expired` Invites alike.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Status>>? Statuses
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Status>>>(
                "statuses"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Status>>?>(
                "statuses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public InviteListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteListParams(InviteListParams inviteListParams)
        : base(inviteListParams) { }
#pragma warning restore CS8618

    public InviteListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InviteListParams FromRawUnchecked(
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

    public virtual bool Equals(InviteListParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/invites")
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

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Accepted,
    Expired,
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => Status.Accepted,
            "expired" => Status.Expired,
            "pending" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Accepted => "accepted",
                Status.Expired => "expired",
                Status.Pending => "pending",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
