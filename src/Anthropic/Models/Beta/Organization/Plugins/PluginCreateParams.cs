using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// Create an organization-owned Plugin and its first version by uploading the version's files.
///
/// <para>The upload is `multipart/form-data`: the version's files (`files`, each
/// part sent as `files[]`), with an optional `marketplace_id` and `release_notes`.
/// The manifest's `name` becomes the Plugin's `name`, and `display_name`, `description`
/// and `manifest_version` come from the manifest too.</para>
///
/// <para>`name` may contain lowercase letters (from any alphabet), digits, and hyphens,
/// up to 64 characters. Uppercase letters, spaces, underscores, and other punctuation
/// are rejected.</para>
///
/// <para>The `name` must be unique within the marketplace: a name already taken
/// returns a 409 with `error_code` `plugin_name_taken` and, when a Plugin holds it,
/// that Plugin's ID in `details.plugin_id`. A Plugin going into the organization's
/// library marketplace is also refused with a 409 when one of its skills has the
/// name of an organization skill (a skill an administrator uploaded for the whole
/// organization in claude.ai): `error_code` `skill_name_taken`, with that name in
/// `details.skill_name`; rename the skill, or remove the organization skill in claude.ai.
/// A 503 with `error_code` `registration_pending` means the Plugin and its version
/// were stored (their IDs are in `details`) but are not yet usable in claude.ai:
/// do not retry the create (the retry would return `plugin_name_taken`); create a
/// version on the stored Plugin instead, which completes it.</para>
///
/// <para>For a worked example, see [Create a plugin](/docs/en/manage-claude/plugins-api#create-a-plugin)
/// in the Plugins API guide.</para>
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
public record class PluginCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The version's files: one part per file, the part's filename being the file's
    /// path within the Plugin (for example `skills/review-pr/SKILL.md`), or a single
    /// `.zip` or `.plugin` archive holding them all. On the wire each part is named
    /// `files[]`, and a part named plain `files` is not read; with cURL, `-F 'files[]=@SKILL.md;filename=skills/review-pr/SKILL.md'`.
    /// The files must include the manifest, `.claude-plugin/plugin.json`.
    /// </summary>
    public required IReadOnlyList<BinaryContent> Files
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<BinaryContent>>("files");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BinaryContent>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the organization-owned plugin marketplace to create the Plugin in (prefixed
    /// `marketplace_`). It must be a `manual` marketplace, one whose Plugins are
    /// uploaded rather than synchronized from a repository. When omitted, the Plugin
    /// is created in the organization's library marketplace, an organization-owned
    /// `manual` marketplace created on first use.
    /// </summary>
    public string? MarketplaceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("marketplace_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("marketplace_id", value);
        }
    }

    /// <summary>
    /// Release notes stored with the version and shown in its version history in
    /// claude.ai; up to 5,000 characters.
    /// </summary>
    public string? ReleaseNotes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("release_notes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("release_notes", value);
        }
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

    public PluginCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PluginCreateParams(PluginCreateParams pluginCreateParams)
        : base(pluginCreateParams)
    {
        this._rawBodyData = new(pluginCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PluginCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PluginCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PluginCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
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
                new Dictionary<string, MultipartJsonElement>()
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

    public virtual bool Equals(PluginCreateParams? other)
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
        var queryString = this.QueryString(options);
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/plugins")
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
    }

    internal override bool IsBodyRepeatable() =>
        MultipartJsonSerializer.IsRepeatable(this.RawBodyData);

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
