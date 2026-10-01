using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Plugins;

namespace Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

/// <summary>
/// Remove an organization-owned Plugin's own installation setting for the whole
/// organization or for one RBAC Group.
///
/// <para>Removing the `organization` target returns the Plugin to its marketplace's
/// default installation setting and leaves the groups' settings in place. Removing
/// a group's setting makes the group's members fall back to the Plugin's organization-wide
/// setting or to the settings of their other groups.</para>
///
/// <para>A target that holds no setting of its own returns 404 (a Plugin that already
/// inherits its marketplace's default holds no `organization` setting), and so does
/// a member-owned Plugin.</para>
///
/// <para>A removal counts as one of the Plugin's installation-setting writes: send
/// all of those writes one at a time. If several arrive for the same Plugin at the
/// same time, the server handles them one after another and can answer some of them
/// with `503` and `x-should-retry: true` instead of applying them; wait a second
/// or two and send the removal again. A `404` on the repeat means the setting is
/// already gone.</para>
///
/// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
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
public record class InstallationSettingRemoveParams : ParamsBase
{
    public required string PluginID { get; init; }

    public string? Target { get; init; }

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

    public InstallationSettingRemoveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstallationSettingRemoveParams(
        InstallationSettingRemoveParams installationSettingRemoveParams
    )
        : base(installationSettingRemoveParams)
    {
        this.PluginID = installationSettingRemoveParams.PluginID;
        this.Target = installationSettingRemoveParams.Target;
    }
#pragma warning restore CS8618

    public InstallationSettingRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstallationSettingRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string pluginID,
        string target
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PluginID = pluginID;
        this.Target = target;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InstallationSettingRemoveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string pluginID,
        string target
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            pluginID,
            target
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PluginID"] = JsonSerializer.SerializeToElement(this.PluginID),
                    ["Target"] = JsonSerializer.SerializeToElement(this.Target),
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

    public virtual bool Equals(InstallationSettingRemoveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.PluginID.Equals(other.PluginID)
            && (this.Target?.Equals(other.Target) ?? other.Target == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/plugins/{0}/installation_settings/{1}",
                    ParamsBase.EncodePathSegment(this.PluginID, nameof(this.PluginID)),
                    ParamsBase.EncodePathSegment(this.Target, nameof(this.Target))
                )
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        InstallationSettingService.AddDefaultHeaders(request);
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
