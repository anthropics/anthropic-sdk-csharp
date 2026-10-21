using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins.Shares;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IShareService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IShareServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShareService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the shares the owner of a member-owned Plugin has given — to every member
    /// of the organization, to an RBAC Group, or to one member — most recently granted
    /// first.
    ///
    /// <para>Shares are read-only in this API: members give and withdraw them in
    /// claude.ai, and who gave a share is recorded on the Compliance API activity feed
    /// rather than on the share. An organization-owned Plugin has installation settings
    /// instead, so this path returns 404 for one.</para>
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
    Task<ShareListPage> List(
        ShareListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ShareListParams, CancellationToken)"/>
    Task<ShareListPage> List(
        string pluginID,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IShareService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IShareServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShareServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/plugins/{plugin_id}/shares?beta=true</c>, but is otherwise the
    /// same as <see cref="IShareService.List(ShareListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShareListPage>> List(
        ShareListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ShareListParams, CancellationToken)"/>
    Task<HttpResponse<ShareListPage>> List(
        string pluginID,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
