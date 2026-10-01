using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// Change which stored version of an organization-owned Plugin is served to members,
/// for example to roll back to an earlier one. This pins the served version: later
/// uploads are stored but no longer change what is served, and pinning cannot currently
/// be undone, here or in claude.ai.
///
/// <para>Pass the version as `served_version_id`: an earlier one to roll back, a
/// later one to start serving a version that was stored without being served, or
/// the one already served to pin it without changing what is served. No new version
/// is created.</para>
///
/// <para>When the organization has content scanning enabled, a version whose scan
/// is still running is refused with a 409 (`error_code` `scan_pending`; retry once
/// the scan finishes) and one whose scan failed, errored or reached no verdict with
/// a 400 (`scan_failed`; a `warn` is accepted). When the Plugin is in the organization's
/// library marketplace, a version other than the one served is also refused with
/// a 409 when one of its skills has a name that an organization skill (one an administrator
/// uploaded for the whole organization in claude.ai) has since taken: `error_code`
/// `skill_name_taken`, with that name in `details.skill_name`. A member-owned Plugin
/// cannot be updated here (403).</para>
///
/// <para>This endpoint does not write installation settings; they are written at `/v1/organizations/plugins/{plugin_id}/installation_settings/{target}`.</para>
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
public record class PluginUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PluginID { get; init; }

    /// <summary>
    /// Serve this version of the Plugin (prefixed `pluginver_`) and pin the served
    /// version to it; `latest` is not accepted.
    /// </summary>
    public required string ServedVersionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("served_version_id");
        }
        init { this._rawBodyData.Set("served_version_id", value); }
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

    public PluginUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginUpdateParams(PluginUpdateParams pluginUpdateParams)
        : base(pluginUpdateParams)
    {
        this.PluginID = pluginUpdateParams.PluginID;

        this._rawBodyData = new(pluginUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PluginUpdateParams(
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
    PluginUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string pluginID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PluginID = pluginID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PluginUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string pluginID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PluginUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PluginID?.Equals(other.PluginID) ?? other.PluginID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/plugins/{0}",
                    ParamsBase.EncodePathSegment(this.PluginID, nameof(this.PluginID))
                )
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
