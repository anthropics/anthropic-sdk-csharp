using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacGroups;
using Anthropic.Services.Organization.RbacGroups;

namespace Anthropic.Services.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRbacGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRbacGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMemberService Members { get; }

    /// <summary>
    /// Create an RBAC Group in the Claude Enterprise tenant. Groups created via the API
    /// have source type `"direct"`.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<RbacGroup> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an RBAC Group by ID.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<RbacGroup> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>
    Task<RbacGroup> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an RBAC Group's name. Groups provisioned by an identity provider (source
    /// type `"scim"`) cannot be modified via the API while an organization in the
    /// tenant uses SCIM provisioning.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<RbacGroup> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RbacGroupUpdateParams, CancellationToken)"/>
    Task<RbacGroup> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List RBAC Groups in the Claude Enterprise tenant.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<RbacGroupListPage> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an RBAC Group. Groups provisioned by an identity provider (source type
    /// `"scim"`) cannot be deleted via the API while an organization in the tenant uses
    /// SCIM provisioning.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    /// <exception cref="AnthropicRbacGroupGrantsOwnerAccessException">
    /// A role attached to an RBAC Group in the request grants owner access, so this API
    /// does not add members to that group (directly or through an invite), remove its
    /// members, or delete it. Make the change in the organization's admin settings in
    /// Claude.
    /// </exception>
    /// <exception cref="AnthropicRbacGroupOwnerAccessUnconfirmedException">
    /// The API could not finish checking whether an RBAC Group in the request grants
    /// owner access, so it made no change. Retrying the same request will not help.
    /// Make the change in the organization's admin settings in Claude.
    /// </exception>
    Task<DeletedRbacGroup> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RbacGroupDeleteParams, CancellationToken)"/>
    Task<DeletedRbacGroup> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRbacGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRbacGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMemberServiceWithRawResponse Members { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/rbac_groups</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Create(RbacGroupCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacGroup>> Create(
        RbacGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacGroup>> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RbacGroup>> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Update(RbacGroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacGroup>> Update(
        RbacGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RbacGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RbacGroup>> Update(
        string rbacGroupID,
        RbacGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_groups</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.List(RbacGroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacGroupListPage>> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Delete(RbacGroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeletedRbacGroup>> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RbacGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DeletedRbacGroup>> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
