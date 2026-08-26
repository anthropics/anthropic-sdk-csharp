using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ServiceAccounts;

/// <summary>
/// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
/// login --scope org:admin` or a workload identity federation rule; Admin API keys
/// are not accepted. See [Manage WIF with the Admin API](/docs/en/manage-claude/wif-admin-api).
///
/// <para>Update a service account.</para>
///
/// <para>Only `description` and `organization_role` are mutable; `name` cannot be
/// changed. Archived service accounts cannot be updated; this returns 400. Setting
/// `organization_role` to `admin` (even when unchanged) requires an interactive credential
/// (a user OAuth token or a Console session).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ServiceAccountUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ServiceAccountID { get; init; }

    /// <summary>
    /// Replaces the description. Omit to leave unchanged; send `null` to clear (the
    /// field is stored as an empty string).
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Replaces the org-level role. Omit or send `null` to leave unchanged.
    /// </summary>
    public ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>? OrganizationRole
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, ServiceAccountUpdateParamsOrganizationRole>
            >("organization_role");
        }
        init { this._rawBodyData.Set("organization_role", value); }
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

    public ServiceAccountUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServiceAccountUpdateParams(ServiceAccountUpdateParams serviceAccountUpdateParams)
        : base(serviceAccountUpdateParams)
    {
        this.ServiceAccountID = serviceAccountUpdateParams.ServiceAccountID;

        this._rawBodyData = new(serviceAccountUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ServiceAccountUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServiceAccountUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string serviceAccountID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ServiceAccountID = serviceAccountID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ServiceAccountUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string serviceAccountID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            serviceAccountID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ServiceAccountID"] = JsonSerializer.SerializeToElement(this.ServiceAccountID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ServiceAccountUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ServiceAccountID?.Equals(other.ServiceAccountID)
                ?? other.ServiceAccountID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/organizations/service_accounts/{0}", this.ServiceAccountID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// Replaces the org-level role. Omit or send `null` to leave unchanged.
/// </summary>
[JsonConverter(typeof(ServiceAccountUpdateParamsOrganizationRoleConverter))]
public enum ServiceAccountUpdateParamsOrganizationRole
{
    Admin,
    Developer,
}

sealed class ServiceAccountUpdateParamsOrganizationRoleConverter
    : JsonConverter<ServiceAccountUpdateParamsOrganizationRole>
{
    public override ServiceAccountUpdateParamsOrganizationRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => ServiceAccountUpdateParamsOrganizationRole.Admin,
            "developer" => ServiceAccountUpdateParamsOrganizationRole.Developer,
            _ => (ServiceAccountUpdateParamsOrganizationRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceAccountUpdateParamsOrganizationRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceAccountUpdateParamsOrganizationRole.Admin => "admin",
                ServiceAccountUpdateParamsOrganizationRole.Developer => "developer",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
