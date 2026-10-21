using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles;
using Anthropic.Services.Beta.Organization.RbacRoles;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRbacRoleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRbacRoleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacRoleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPermissionService Permissions { get; }

    /// <summary>
    /// Retrieve an RBAC Role by ID.
    ///
    /// <para>The RBAC Roles API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<BetaRbacRole> Retrieve(
        RbacRoleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacRoleRetrieveParams, CancellationToken)"/>
    Task<BetaRbacRole> Retrieve(
        string rbacRoleID,
        RbacRoleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List RBAC Roles in the organization.
    ///
    /// <para>The RBAC Roles API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<RbacRoleListPage> List(
        RbacRoleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRbacRoleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRbacRoleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacRoleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPermissionServiceWithRawResponse Permissions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_roles/{rbac_role_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IRbacRoleService.Retrieve(RbacRoleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaRbacRole>> Retrieve(
        RbacRoleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacRoleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaRbacRole>> Retrieve(
        string rbacRoleID,
        RbacRoleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_roles?beta=true</c>, but is otherwise the
    /// same as <see cref="IRbacRoleService.List(RbacRoleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacRoleListPage>> List(
        RbacRoleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
