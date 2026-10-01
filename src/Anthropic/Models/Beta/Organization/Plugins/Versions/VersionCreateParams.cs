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
/// Add a version to an organization-owned Plugin by uploading the new version's
/// files; it becomes the version served to members unless the Plugin's served version
/// has been pinned.
///
/// <para>The upload is the same `multipart/form-data` as creating a Plugin: the version's
/// files (`files`, each part sent as `files[]`) and optional `release_notes`. The
/// uploaded manifest's `name` must equal the Plugin's `name`. Returns the stored
/// version; read the Plugin back to see which version it serves.</para>
///
/// <para>Only a Plugin in a `manual` marketplace takes uploads; a Plugin synchronized
/// from a repository gets its versions from the repository. When the Plugin is in
/// the organization's library marketplace, a version that adds a skill with the
/// name of an organization skill (a skill an administrator uploaded for the whole
/// organization in claude.ai) is refused with a 409: `error_code` `skill_name_taken`,
/// with that name in `details.skill_name`. A 503 with `error_code` `registration_pending`
/// means the version was stored but is not yet usable; a later version create on
/// the Plugin completes it.</para>
///
/// <para>For a worked example, see [Create a version](/docs/en/manage-claude/plugins-api#create-a-version)
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
public record class VersionCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PluginID { get; init; }

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

    public VersionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionCreateParams(VersionCreateParams versionCreateParams)
        : base(versionCreateParams)
    {
        this.PluginID = versionCreateParams.PluginID;

        this._rawBodyData = new(versionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VersionCreateParams(
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
    VersionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData,
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
    public static VersionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData,
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
                new Dictionary<string, MultipartJsonElement>()
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

    public virtual bool Equals(VersionCreateParams? other)
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
                    "/v1/organizations/plugins/{0}/versions",
                    ParamsBase.EncodePathSegment(this.PluginID, nameof(this.PluginID))
                )
        )
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
