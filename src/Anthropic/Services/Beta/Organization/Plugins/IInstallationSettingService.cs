using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInstallationSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInstallationSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstallationSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List an organization-owned Plugin's installation settings, which say which
    /// members it is for, most recently created first.
    ///
    /// <para>The list holds the Plugin's own organization-wide setting (absent while
    /// the Plugin inherits its marketplace's default) and each RBAC Group's own
    /// setting. A member-owned Plugin has shares instead, so this path returns 404 for
    /// one.</para>
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
    Task<InstallationSettingListPage> List(
        InstallationSettingListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(InstallationSettingListParams, CancellationToken)"/>
    Task<InstallationSettingListPage> List(
        string pluginID,
        InstallationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an organization-owned Plugin's own installation setting for the whole
    /// organization or for one RBAC Group.
    ///
    /// <para>Removing the `organization` target returns the Plugin to its marketplace's
    /// default installation setting and leaves the groups' settings in place. Removing
    /// a group's setting makes the group's members fall back to the Plugin's
    /// organization-wide setting or to the settings of their other groups.</para>
    ///
    /// <para>A target that holds no setting of its own returns 404 (a Plugin that
    /// already inherits its marketplace's default holds no `organization` setting), and
    /// so does a member-owned Plugin.</para>
    ///
    /// <para>A removal counts as one of the Plugin's installation-setting writes: send
    /// all of those writes one at a time. If several arrive for the same Plugin at the
    /// same time, the server handles them one after another and can answer some of them
    /// with `503` and `x-should-retry: true` instead of applying them; wait a second or
    /// two and send the removal again. A `404` on the repeat means the setting is
    /// already gone.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaDeletedPluginInstallationSetting> Remove(
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(InstallationSettingRemoveParams, CancellationToken)"/>
    Task<BetaDeletedPluginInstallationSetting> Remove(
        string target,
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set or change an organization-owned Plugin's installation setting for the whole
    /// organization or for one RBAC Group.
    ///
    /// <para>Writing the value a target already holds of its own changes nothing.</para>
    ///
    /// <para>A member-owned Plugin has shares instead of installation settings, so this
    /// path returns 404 for one.</para>
    ///
    /// <para>Send a Plugin's installation-setting writes one at a time. If several
    /// writes for the same Plugin arrive at the same time, the server handles them one
    /// after another and can answer some of them with `503` instead of applying them.
    /// That `503` carries `x-should-retry: true`, and the write is safe to repeat: wait
    /// a second or two, then send it again.</para>
    ///
    /// <para>**Accepted credentials:** an Admin API key with the `write:plugins` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-plugins-2026-09-01`. A request without it returns `404`, exactly as if the
    /// endpoint did not exist. The Plugins API is in beta and is available to Claude
    /// Enterprise organizations only. It is not available to Claude Platform (Claude
    /// Console) organizations, or to organizations with HIPAA readiness enabled.</para>
    /// </summary>
    Task<BetaPluginInstallationSetting> Set(
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(InstallationSettingSetParams, CancellationToken)"/>
    Task<BetaPluginInstallationSetting> Set(
        string target,
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInstallationSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInstallationSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstallationSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}/installation_settings?beta=true</c>, but is otherwise the
    /// same as <see cref="IInstallationSettingService.List(InstallationSettingListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InstallationSettingListPage>> List(
        InstallationSettingListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(InstallationSettingListParams, CancellationToken)"/>
    Task<HttpResponse<InstallationSettingListPage>> List(
        string pluginID,
        InstallationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/plugins/{plugin_id}/installation_settings/{target}?beta=true</c>, but is otherwise the
    /// same as <see cref="IInstallationSettingService.Remove(InstallationSettingRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedPluginInstallationSetting>> Remove(
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(InstallationSettingRemoveParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedPluginInstallationSetting>> Remove(
        string target,
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/plugins/{plugin_id}/installation_settings/{target}?beta=true</c>, but is otherwise the
    /// same as <see cref="IInstallationSettingService.Set(InstallationSettingSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaPluginInstallationSetting>> Set(
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(InstallationSettingSetParams, CancellationToken)"/>
    Task<HttpResponse<BetaPluginInstallationSetting>> Set(
        string target,
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    );
}
