using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Organization.Plugins;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins.Shares;

/// <summary>
/// List the shares the owner of a member-owned Plugin has given — to every member
/// of the organization, to an RBAC Group, or to one member — most recently granted first.
///
/// <para>Shares are read-only in this API: members give and withdraw them in claude.ai,
/// and who gave a share is recorded on the Compliance API activity feed rather than
/// on the share. An organization-owned Plugin has installation settings instead,
/// so this path returns 404 for one.</para>
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
public record class ShareListParams : ParamsBase
{
    public string? PluginID { get; init; }

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
                this._rawQueryData.Remove("limit");
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
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
    /// Only shares with this kind of target: `organization` (every member), `rbac_group`
    /// (one RBAC Group), or `organization_member` (one member).
    /// </summary>
    public ApiEnum<string, TargetType>? TargetType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TargetType>>("target_type");
        }
        init { this._rawQueryData.Set("target_type", value); }
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
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ShareListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShareListParams(ShareListParams shareListParams)
        : base(shareListParams)
    {
        this.PluginID = shareListParams.PluginID;
    }
#pragma warning restore CS8618

    public ShareListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShareListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pluginID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PluginID = pluginID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ShareListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pluginID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pluginID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PluginID"] = JsonSerializer.SerializeToElement(this.PluginID),
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

    public virtual bool Equals(ShareListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PluginID?.Equals(other.PluginID) ?? other.PluginID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/plugins/{0}/shares",
                    ParamsBase.EncodePathSegment(this.PluginID, nameof(this.PluginID))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        ShareService.AddDefaultHeaders(request);
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
/// Only shares with this kind of target: `organization` (every member), `rbac_group`
/// (one RBAC Group), or `organization_member` (one member).
/// </summary>
[JsonConverter(typeof(TargetTypeConverter))]
public enum TargetType
{
    Organization,
    OrganizationMember,
    RbacGroup,
}

sealed class TargetTypeConverter : JsonConverter<TargetType>
{
    public override TargetType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => TargetType.Organization,
            "organization_member" => TargetType.OrganizationMember,
            "rbac_group" => TargetType.RbacGroup,
            _ => (TargetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TargetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TargetType.Organization => "organization",
                TargetType.OrganizationMember => "organization_member",
                TargetType.RbacGroup => "rbac_group",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
