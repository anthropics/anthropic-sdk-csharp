using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

/// <summary>
/// Create or replace an RBAC Group's Claude Code managed settings.
///
/// <para>New settings join the end of `rbac_group_order`, and existing settings
/// keep their place. Until the group is moved up, its members who also belong to
/// an earlier group keep that group's settings. In `organization` mode a write changes
/// no member's settings until the organization switches to `rbac_groups` mode. Once
/// a group has settings, that switch no longer copies the organization settings into
/// default settings, so members in no RBAC Group in `rbac_group_order` receive no
/// settings unless you set the default settings before the switch.</para>
///
/// <para>Get the group's ID from the RBAC Groups API. One key can hold `read:rbac_groups`
/// and `write:claude_code_managed_settings`.</para>
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
public record class RbacGroupSetParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? RbacGroupID { get; init; }

    /// <summary>
    /// The whole settings document, a JSON object of Claude Code managed settings.
    /// It replaces any stored document. At most 1 MiB as the server stores it, which
    /// can be larger than the request body.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Settings
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>>(
                "settings",
                FrozenDictionary.ToFrozenDictionary(value)
            );
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

    public RbacGroupSetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacGroupSetParams(RbacGroupSetParams rbacGroupSetParams)
        : base(rbacGroupSetParams)
    {
        this.RbacGroupID = rbacGroupSetParams.RbacGroupID;

        this._rawBodyData = new(rbacGroupSetParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RbacGroupSetParams(
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
    RbacGroupSetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string rbacGroupID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RbacGroupID = rbacGroupID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RbacGroupSetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string rbacGroupID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            rbacGroupID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["RbacGroupID"] = JsonSerializer.SerializeToElement(this.RbacGroupID),
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

    public virtual bool Equals(RbacGroupSetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RbacGroupID?.Equals(other.RbacGroupID) ?? other.RbacGroupID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/organizations/claude_code/managed_settings/rbac_groups/{0}",
                    ParamsBase.EncodePathSegment(this.RbacGroupID, nameof(this.RbacGroupID))
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route =>
        "/v1/organizations/claude_code/managed_settings/rbac_groups/{rbac_group_id}";

    internal override HttpContent? BodyContent()
    {
        return ParamsBase.JsonBodyContent(this.RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        RbacGroupService.AddDefaultHeaders(request);
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
