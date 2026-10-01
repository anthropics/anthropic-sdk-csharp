using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Services.Beta.Organization.RbacRoles;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPermissionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPermissionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPermissionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the permissions an RBAC Role grants.
    ///
    /// <para>The RBAC Roles API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<PermissionListPage> List(
        PermissionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PermissionListParams, CancellationToken)"/>
    Task<PermissionListPage> List(
        string rbacRoleID,
        PermissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPermissionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPermissionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPermissionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_roles/{rbac_role_id}/permissions?beta=true</c>, but is otherwise the
    /// same as <see cref="IPermissionService.List(PermissionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PermissionListPage>> List(
        PermissionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PermissionListParams, CancellationToken)"/>
    Task<HttpResponse<PermissionListPage>> List(
        string rbacRoleID,
        PermissionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
