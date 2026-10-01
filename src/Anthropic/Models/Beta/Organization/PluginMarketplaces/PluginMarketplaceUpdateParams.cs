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
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

/// <summary>
/// Set the default installation setting of one of the organization's own plugin
/// marketplaces. Every Plugin in it without a setting of its own gets this default
/// as its organization-wide setting, including Plugins added later.
///
/// <para>Pass it as `default_installation_preference`. A member's personal marketplace
/// cannot be updated here (403).</para>
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
public record class PluginMarketplaceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? MarketplaceID { get; init; }

    /// <summary>
    /// The organization-wide installation setting every Plugin in the marketplace
    /// without one of its own gets: one of `required`, `auto_install`, `available`,
    /// `not_available`. Once set it can be changed but not removed.
    /// </summary>
    public required ApiEnum<string, DefaultInstallationPreference> DefaultInstallationPreference
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, DefaultInstallationPreference>
            >("default_installation_preference");
        }
        init { this._rawBodyData.Set("default_installation_preference", value); }
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

    public PluginMarketplaceUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginMarketplaceUpdateParams(
        PluginMarketplaceUpdateParams pluginMarketplaceUpdateParams
    )
        : base(pluginMarketplaceUpdateParams)
    {
        this.MarketplaceID = pluginMarketplaceUpdateParams.MarketplaceID;

        this._rawBodyData = new(pluginMarketplaceUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PluginMarketplaceUpdateParams(
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
    PluginMarketplaceUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string marketplaceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.MarketplaceID = marketplaceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PluginMarketplaceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string marketplaceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            marketplaceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MarketplaceID"] = JsonSerializer.SerializeToElement(this.MarketplaceID),
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

    public virtual bool Equals(PluginMarketplaceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MarketplaceID?.Equals(other.MarketplaceID) ?? other.MarketplaceID == null)
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
                    "/v1/organizations/plugin_marketplaces/{0}",
                    ParamsBase.EncodePathSegment(this.MarketplaceID, nameof(this.MarketplaceID))
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
        PluginMarketplaceService.AddDefaultHeaders(request);
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
/// The organization-wide installation setting every Plugin in the marketplace without
/// one of its own gets: one of `required`, `auto_install`, `available`, `not_available`.
/// Once set it can be changed but not removed.
/// </summary>
[JsonConverter(typeof(DefaultInstallationPreferenceConverter))]
public enum DefaultInstallationPreference
{
    AutoInstall,
    Available,
    NotAvailable,
    Required,
}

sealed class DefaultInstallationPreferenceConverter : JsonConverter<DefaultInstallationPreference>
{
    public override DefaultInstallationPreference Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_install" => DefaultInstallationPreference.AutoInstall,
            "available" => DefaultInstallationPreference.Available,
            "not_available" => DefaultInstallationPreference.NotAvailable,
            "required" => DefaultInstallationPreference.Required,
            _ => (DefaultInstallationPreference)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultInstallationPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DefaultInstallationPreference.AutoInstall => "auto_install",
                DefaultInstallationPreference.Available => "available",
                DefaultInstallationPreference.NotAvailable => "not_available",
                DefaultInstallationPreference.Required => "required",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
