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
using Anthropic.Services.Beta.Organization.Plugins;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

/// <summary>
/// Set or change an organization-owned Plugin's installation setting for the whole
/// organization or for one RBAC Group.
///
/// <para>Writing the value a target already holds of its own changes nothing.</para>
///
/// <para>A member-owned Plugin has shares instead of installation settings, so this
/// path returns 404 for one.</para>
///
/// <para>Send a Plugin's installation-setting writes one at a time. If several writes
/// for the same Plugin arrive at the same time, the server handles them one after
/// another and can answer some of them with `503` instead of applying them. That
/// `503` carries `x-should-retry: true`, and the write is safe to repeat: wait a
/// second or two, then send it again.</para>
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
public record class InstallationSettingSetParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string PluginID { get; init; }

    public string? Target { get; init; }

    /// <summary>
    /// The installation setting the target is to hold for this Plugin: one of `required`,
    /// `auto_install`, `available`, `not_available`.
    /// </summary>
    public required ApiEnum<string, InstallationPreference> InstallationPreference
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, InstallationPreference>>(
                "installation_preference"
            );
        }
        init { this._rawBodyData.Set("installation_preference", value); }
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

    public InstallationSettingSetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstallationSettingSetParams(InstallationSettingSetParams installationSettingSetParams)
        : base(installationSettingSetParams)
    {
        this.PluginID = installationSettingSetParams.PluginID;
        this.Target = installationSettingSetParams.Target;

        this._rawBodyData = new(installationSettingSetParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InstallationSettingSetParams(
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
    InstallationSettingSetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string pluginID,
        string target
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PluginID = pluginID;
        this.Target = target;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InstallationSettingSetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string pluginID,
        string target
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InstallationSettingSetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.PluginID.Equals(other.PluginID)
            && (this.Target?.Equals(other.Target) ?? other.Target == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
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

/// <summary>
/// The installation setting the target is to hold for this Plugin: one of `required`,
/// `auto_install`, `available`, `not_available`.
/// </summary>
[JsonConverter(typeof(InstallationPreferenceConverter))]
public enum InstallationPreference
{
    AutoInstall,
    Available,
    NotAvailable,
    Required,
}

sealed class InstallationPreferenceConverter : JsonConverter<InstallationPreference>
{
    public override InstallationPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_install" => InstallationPreference.AutoInstall,
            "available" => InstallationPreference.Available,
            "not_available" => InstallationPreference.NotAvailable,
            "required" => InstallationPreference.Required,
            _ => (InstallationPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InstallationPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InstallationPreference.AutoInstall => "auto_install",
                InstallationPreference.Available => "available",
                InstallationPreference.NotAvailable => "not_available",
                InstallationPreference.Required => "required",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
