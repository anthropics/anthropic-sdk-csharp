using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Services.Beta.Organization.Plugins;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPluginService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPluginServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionService Versions { get; }

    IInstallationSettingService InstallationSettings { get; }

    IShareService Shares { get; }

    /// <summary>
    /// Create an organization-owned Plugin and its first version by uploading the
    /// version's files.
    ///
    /// <para>The upload is `multipart/form-data`: the version's files (`files`, each
    /// part sent as `files[]`), with an optional `marketplace_id` and `release_notes`.
    /// The manifest's `name` becomes the Plugin's `name`, and `display_name`,
    /// `description` and `manifest_version` come from the manifest too.</para>
    ///
    /// <para>`name` may contain lowercase letters (from any alphabet), digits, and
    /// hyphens, up to 64 characters. Uppercase letters, spaces, underscores, and other
    /// punctuation are rejected.</para>
    ///
    /// <para>The `name` must be unique within the marketplace: a name already taken
    /// returns a 409 with `error_code` `plugin_name_taken` and, when a Plugin holds it,
    /// that Plugin's ID in `details.plugin_id`. A Plugin going into the organization's
    /// library marketplace is also refused with a 409 when one of its skills has the
    /// name of an organization skill (a skill an administrator uploaded for the whole
    /// organization in claude.ai): `error_code` `skill_name_taken`, with that name in
    /// `details.skill_name`; rename the skill, or remove the organization skill in
    /// claude.ai. A 503 with `error_code` `registration_pending` means the Plugin and
    /// its version were stored (their IDs are in `details`) but are not yet usable in
    /// claude.ai: do not retry the create (the retry would return `plugin_name_taken`);
    /// create a version on the stored Plugin instead, which completes it.</para>
    ///
    /// <para>For a worked example, see [Create a
    /// plugin](/docs/en/manage-claude/plugins-api#create-a-plugin) in the Plugins API
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
    Task<BetaPlugin> Create(
        PluginCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Plugin by ID.
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
    Task<BetaPlugin> Retrieve(
        PluginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PluginRetrieveParams, CancellationToken)"/>
    Task<BetaPlugin> Retrieve(
        string pluginID,
        PluginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change which stored version of an organization-owned Plugin is served to
    /// members, for example to roll back to an earlier one. This pins the served
    /// version: later uploads are stored but no longer change what is served, and
    /// pinning cannot currently be undone, here or in claude.ai.
    ///
    /// <para>Pass the version as `served_version_id`: an earlier one to roll back, a
    /// later one to start serving a version that was stored without being served, or
    /// the one already served to pin it without changing what is served. No new version
    /// is created.</para>
    ///
    /// <para>When the organization has content scanning enabled, a version whose scan
    /// is still running is refused with a 409 (`error_code` `scan_pending`; retry once
    /// the scan finishes) and one whose scan failed, errored or reached no verdict with
    /// a 400 (`scan_failed`; a `warn` is accepted). When the Plugin is in the
    /// organization's library marketplace, a version other than the one served is also
    /// refused with a 409 when one of its skills has a name that an organization skill
    /// (one an administrator uploaded for the whole organization in claude.ai) has
    /// since taken: `error_code` `skill_name_taken`, with that name in
    /// `details.skill_name`. A member-owned Plugin cannot be updated here (403).</para>
    ///
    /// <para>This endpoint does not write installation settings; they are written at
    /// `/v1/organizations/plugins/{plugin_id}/installation_settings/{target}`.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPlugin> Update(
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PluginUpdateParams, CancellationToken)"/>
    Task<BetaPlugin> Update(
        string pluginID,
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the Plugins created under the organization, newest first: those in the
    /// organization's own plugin marketplaces and those in members' personal plugin
    /// marketplaces.
    ///
    /// <para>Plugins in members' personal marketplaces are listed with the same detail
    /// as the organization's own, and their files can be downloaded through the version
    /// archive endpoint, which records each such download on the Compliance API
    /// activity feed.</para>
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
    Task<PluginListPage> List(
        PluginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a Plugin and every version it holds, exactly as when an
    /// administrator deletes it in claude.ai. The Plugin may belong to the organization
    /// or to a member, including a member who has since left the organization.
    ///
    /// <para>An organization-owned Plugin's installation settings go with it; a
    /// member-owned Plugin's shares are withdrawn and its owner no longer has it.</para>
    ///
    /// <para>To take an organization-owned Plugin out of use reversibly, set its
    /// organization-wide installation setting to `not_available` instead (and remove or
    /// change any group settings, which override it for their members). Only a Plugin
    /// in a `manual` marketplace can be deleted here; one synchronized from a
    /// repository is removed by removing it from the repository (400).</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaDeletedPlugin> Delete(
        PluginDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PluginDeleteParams, CancellationToken)"/>
    Task<BetaDeletedPlugin> Delete(
        string pluginID,
        PluginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPluginService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPluginServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPluginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionServiceWithRawResponse Versions { get; }

    IInstallationSettingServiceWithRawResponse InstallationSettings { get; }

    IShareServiceWithRawResponse Shares { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugins?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.Create(PluginCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPlugin>> Create(
        PluginCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.Retrieve(PluginRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPlugin>> Retrieve(
        PluginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PluginRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaPlugin>> Retrieve(
        string pluginID,
        PluginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugins/{plugin_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.Update(PluginUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPlugin>> Update(
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PluginUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaPlugin>> Update(
        string pluginID,
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.List(PluginListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PluginListPage>> List(
        PluginListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/plugins/{plugin_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IPluginService.Delete(PluginDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedPlugin>> Delete(
        PluginDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PluginDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedPlugin>> Delete(
        string pluginID,
        PluginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
