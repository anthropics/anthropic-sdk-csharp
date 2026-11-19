using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

/// <summary>
/// Change the organization's Claude Code managed settings mode, the RBAC Group order,
/// or both, in one atomic write.
///
/// <para>To change the order, send `rbac_group_order` with the `rbac_group_order_version`
/// from the read the change is based on. If the order has changed since that read,
/// the request returns `409`: read it again and retry. To switch modes only if the
/// order has not changed, send the current `rbac_group_order` and `rbac_group_order_version`
/// with the new `mode`.</para>
///
/// <para>A switch to `rbac_groups` mode with no RBAC Group settings and no default
/// settings copies the organization settings into a new default, in the same write,
/// so members keep the settings they had. The copy does not follow later changes
/// to the organization settings. If the organization settings cannot be copied, the
/// request returns `400` and changes nothing. If they cannot be read, are over 1
/// MiB or are not valid, setting the default settings first avoids the copy.</para>
///
/// <para>After a switch to `rbac_groups` mode, a member in no listed RBAC Group receives
/// the default settings, or no settings if no default is set, not the organization settings.</para>
///
/// <para>**Accepted credentials:** an organization-level Admin API key with the `write:claude_code_managed_settings` scope.</para>
///
/// <para>Every request must include the beta header `anthropic-beta: ce-claude-code-managed-settings-2026-10-06`.
/// A request without it, or from an organization not enabled for this beta, returns
/// `404`. The Claude Code Managed Settings API is in beta and is available to Claude
/// Enterprise organizations only.</para>
///
/// <para>A write that returns `503` may have applied. Retrying it is safe.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConfigurationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The new mode, as an object such as `{"type": "rbac_groups"}`.
    /// </summary>
    public BetaClaudeCodeManagedSettingsModeParam? Mode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BetaClaudeCodeManagedSettingsModeParam>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("mode");
                return;
            }

            this._rawBodyData.Set("mode", value);
        }
    }

    /// <summary>
    /// Every RBAC Group that has settings, each listed once, in the new order, highest
    /// precedence first. Requires `rbac_group_order_version`.
    /// </summary>
    public IReadOnlyList<string>? RbacGroupOrder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("rbac_group_order");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("rbac_group_order");
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "rbac_group_order",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The `rbac_group_order_version` from the read this change is based on. Requires `rbac_group_order`.
    /// </summary>
    public string? RbacGroupOrderVersion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rbac_group_order_version");
        }
        init
        {
            if (value == null)
            {
                this._rawBodyData.Remove("rbac_group_order_version");
                return;
            }

            this._rawBodyData.Set("rbac_group_order_version", value);
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `ce-claude-code-managed-settings-2026-10-06`
    /// in this header.
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

    public ConfigurationUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationUpdateParams(ConfigurationUpdateParams configurationUpdateParams)
        : base(configurationUpdateParams)
    {
        this._rawBodyData = new(configurationUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ConfigurationUpdateParams(
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
    ConfigurationUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConfigurationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ConfigurationUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + "/v1/organizations/claude_code/managed_settings/configuration"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/claude_code/managed_settings/configuration";

    internal override HttpContent? BodyContent()
    {
        return ParamsBase.JsonBodyContent(this.RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        ConfigurationService.AddDefaultHeaders(request);
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
