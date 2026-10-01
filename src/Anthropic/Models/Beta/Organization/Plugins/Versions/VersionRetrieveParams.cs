using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Plugins;

namespace Anthropic.Models.Beta.Organization.Plugins.Versions;

/// <summary>
/// Retrieve one version of a Plugin by its ID, or the Plugin's newest version.
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
public record class VersionRetrieveParams : ParamsBase
{
    public required string PluginID { get; init; }

    public string? Version { get; init; }

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

    public VersionRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionRetrieveParams(VersionRetrieveParams versionRetrieveParams)
        : base(versionRetrieveParams)
    {
        this.PluginID = versionRetrieveParams.PluginID;
        this.Version = versionRetrieveParams.Version;
    }
#pragma warning restore CS8618

    public VersionRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pluginID,
        string version
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PluginID = pluginID;
        this.Version = version;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VersionRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pluginID,
        string version
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pluginID,
            version
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PluginID"] = JsonSerializer.SerializeToElement(this.PluginID),
                    ["Version"] = JsonSerializer.SerializeToElement(this.Version),
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

    public virtual bool Equals(VersionRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.PluginID.Equals(other.PluginID)
            && (this.Version?.Equals(other.Version) ?? other.Version == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/plugins/{0}/versions/{1}",
                    ParamsBase.EncodePathSegment(this.PluginID, nameof(this.PluginID)),
                    ParamsBase.EncodePathSegment(this.Version, nameof(this.Version))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        VersionService.AddDefaultHeaders(request);
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
