using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins.Versions;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a version to an organization-owned Plugin by uploading the new version's
    /// files; it becomes the version served to members unless the Plugin's served
    /// version has been pinned.
    ///
    /// <para>The upload is the same `multipart/form-data` as creating a Plugin: the
    /// version's files (`files`, each part sent as `files[]`) and optional
    /// `release_notes`. The uploaded manifest's `name` must equal the Plugin's `name`.
    /// Returns the stored version; read the Plugin back to see which version it serves.</para>
    ///
    /// <para>Only a Plugin in a `manual` marketplace takes uploads; a Plugin
    /// synchronized from a repository gets its versions from the repository. When the
    /// Plugin is in the organization's library marketplace, a version that adds a skill
    /// with the name of an organization skill (a skill an administrator uploaded for
    /// the whole organization in claude.ai) is refused with a 409: `error_code`
    /// `skill_name_taken`, with that name in `details.skill_name`. A 503 with
    /// `error_code` `registration_pending` means the version was stored but is not yet
    /// usable; a later version create on the Plugin completes it.</para>
    ///
    /// <para>For a worked example, see [Create a
    /// version](/docs/en/manage-claude/plugins-api#create-a-version) in the Plugins API
    /// guide.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginVersion> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(VersionCreateParams, CancellationToken)"/>
    Task<BetaPluginVersion> Create(
        string pluginID,
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve one version of a Plugin by its ID, or the Plugin's newest version.
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `read:org_audit` scope, or a Compliance Access Key with the
    /// `read:compliance_org_data` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginVersion> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<BetaPluginVersion> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List a Plugin's versions, newest first.
    ///
    /// <para>The first item of the first page is the version the Plugin's
    /// `latest_version_id` refers to.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `read:org_audit` scope, or a Compliance Access Key with the
    /// `read:compliance_org_data` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<VersionListPage> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<VersionListPage> List(
        string pluginID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download one version's `.zip` archive, exactly as stored. Each download of a
    /// Plugin from a member's personal plugin marketplace is recorded on the Compliance
    /// API activity feed.
    ///
    /// <para>The response body is the archive (`Content-Type: application/zip`), sent
    /// as an attachment whose filename is derived from the Plugin's name; name saved
    /// files from the IDs in the request path, since that filename is not unique.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `read:plugins` or
    /// `read:org_audit` scope, or a Compliance Access Key with the
    /// `read:compliance_org_data` scope.</para>
    ///
    /// <para>Every read scope above (`read:plugins`, `read:org_audit`, and
    /// `read:compliance_org_data`) can download the files of plugins in members'
    /// personal marketplaces, including files that claude.ai's admin settings do not
    /// show, and a `read:org_audit` or `read:compliance_org_data` key created for all
    /// of your parent organization's linked organizations can do this in any
    /// organization under it that has access to this API, by passing `organization_id`.
    /// Each such download records a `claude_plugin_archive_accessed` event on the
    /// Compliance API activity feed, identifying the key, the plugin, the version, and
    /// the member. Downloads of organization-owned plugins are not recorded.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Download(
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(VersionDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string version,
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugins/{plugin_id}/versions?beta=true</c>, but is otherwise the
    /// same as <see cref="IVersionService.Create(VersionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginVersion>> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(VersionCreateParams, CancellationToken)"/>
    Task<HttpResponse<BetaPluginVersion>> Create(
        string pluginID,
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}/versions/{version}?beta=true</c>, but is otherwise the
    /// same as <see cref="IVersionService.Retrieve(VersionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginVersion>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaPluginVersion>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}/versions?beta=true</c>, but is otherwise the
    /// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionListPage>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<VersionListPage>> List(
        string pluginID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}/versions/{version}/content?beta=true</c>, but is otherwise the
    /// same as <see cref="IVersionService.Download(VersionDownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Download(
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(VersionDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string version,
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    );
}
