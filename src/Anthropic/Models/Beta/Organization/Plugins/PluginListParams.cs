using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Organization;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// List the Plugins created under the organization, newest first: those in the organization's
/// own plugin marketplaces and those in members' personal plugin marketplaces.
///
/// <para>Plugins in members' personal marketplaces are listed with the same detail
/// as the organization's own, and their files can be downloaded through the version
/// archive endpoint, which records each such download on the Compliance API activity feed.</para>
///
/// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or `read:org_audit`
/// scope, or a Compliance Access Key with the `read:compliance_org_data` scope.</para>
///
/// <para>Every request must include the beta header `anthropic-beta: ce-plugins-2026-09-01`.
/// A request without it returns `404`, exactly as if the endpoint did not exist.
/// The Plugins API is in beta and is available to Claude Enterprise organizations
/// only. It is not available to Claude Platform (Claude Console) organizations, or
/// to organizations with HIPAA readiness enabled.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PluginListParams : ParamsBase
{
    /// <summary>
    /// RFC 3339 timestamp bound; combine [gte], [gt], [lte], [lt].
    /// </summary>
    public System::DateTimeOffset? CreatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gt]");
        }
        init { this._rawQueryData.Set("created_at[gt]", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp bound; combine [gte], [gt], [lte], [lt].
    /// </summary>
    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gte]");
        }
        init { this._rawQueryData.Set("created_at[gte]", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp bound; combine [gte], [gt], [lte], [lt].
    /// </summary>
    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lt]");
        }
        init { this._rawQueryData.Set("created_at[lt]", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp bound; combine [gte], [gt], [lte], [lt].
    /// </summary>
    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lte]");
        }
        init { this._rawQueryData.Set("created_at[lte]", value); }
    }

    /// <summary>
    /// Number of items to return per page.
    ///
    /// <para>Defaults to `20`. Ranges from `1` to `100`.</para>
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
    /// Only Plugins in this plugin marketplace (prefixed `marketplace_`).
    /// </summary>
    public string? MarketplaceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("marketplace_id");
        }
        init { this._rawQueryData.Set("marketplace_id", value); }
    }

    /// <summary>
    /// For a `read:org_audit` or `read:compliance_org_data` key created for all of
    /// a parent organization's linked organizations: a child organization of that
    /// parent to read instead of the organization the key was created in, given as
    /// the organization's UUID or its `org_`-prefixed ID. A value that is neither
    /// returns a 400; an organization that is not a child of the key's parent, or
    /// where the Plugins API is not available, returns a 404. Any other key may pass
    /// only its own organization's ID here; another organization returns a 404.
    /// </summary>
    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    /// <summary>
    /// `organization` for Plugins in the organization's plugin marketplaces, `user`
    /// for Plugins in members' personal plugin marketplaces.
    /// </summary>
    public ApiEnum<string, OwnerType>? OwnerType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, OwnerType>>("owner_type");
        }
        init { this._rawQueryData.Set("owner_type", value); }
    }

    /// <summary>
    /// Only Plugins in this member's personal plugin marketplaces (prefixed `user_`);
    /// a removed member's ID is accepted.
    /// </summary>
    public string? OwnerUserID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("owner_user_id");
        }
        init { this._rawQueryData.Set("owner_user_id", value); }
    }

    /// <summary>
    /// Optionally set to the `next_page` token from the previous response.
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
    /// This endpoint is in beta: requests must send `ce-plugins-2026-09-01` in this header.
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

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/plugins"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        PluginService.AddDefaultHeaders(request);
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

/// <summary>
/// `organization` for Plugins in the organization's plugin marketplaces, `user` for
/// Plugins in members' personal plugin marketplaces.
/// </summary>
[JsonConverter(typeof(OwnerTypeConverter))]
public enum OwnerType
{
    Organization,
    User,
}

sealed class OwnerTypeConverter : JsonConverter<OwnerType>
{
    public override OwnerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => OwnerType.Organization,
            "user" => OwnerType.User,
            _ => (OwnerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OwnerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OwnerType.Organization => "organization",
                OwnerType.User => "user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
