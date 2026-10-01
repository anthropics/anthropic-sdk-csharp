using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacGroups.Members;

namespace Anthropic.Services.Beta.Organization.RbacGroups;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List members of an RBAC Group.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<MemberListPage> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemberListParams, CancellationToken)"/>
    Task<MemberListPage> List(
        string rbacGroupID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a User to an RBAC Group. Membership of groups provisioned by an identity
    /// provider (source type `"scim"`) cannot be modified via the API while an
    /// organization in the tenant uses SCIM provisioning.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<BetaRbacGroupMember> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(MemberAddParams, CancellationToken)"/>
    Task<BetaRbacGroupMember> Add(
        string rbacGroupID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a User from an RBAC Group. Membership of groups provisioned by an
    /// identity provider (source type `"scim"`) cannot be modified via the API while an
    /// organization in the tenant uses SCIM provisioning.
    ///
    /// <para>The RBAC Groups API is available to Claude Enterprise organizations only.</para>
    /// </summary>
    Task<MemberRemoveResponse> Remove(
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(MemberRemoveParams, CancellationToken)"/>
    Task<MemberRemoveResponse> Remove(
        string userID,
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMemberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/rbac_groups/{rbac_group_id}/members?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.List(MemberListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemberListPage>> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemberListParams, CancellationToken)"/>
    Task<HttpResponse<MemberListPage>> List(
        string rbacGroupID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/rbac_groups/{rbac_group_id}/members?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.Add(MemberAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaRbacGroupMember>> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(MemberAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaRbacGroupMember>> Add(
        string rbacGroupID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/rbac_groups/{rbac_group_id}/members/{user_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.Remove(MemberRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemberRemoveResponse>> Remove(
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(MemberRemoveParams, CancellationToken)"/>
    Task<HttpResponse<MemberRemoveResponse>> Remove(
        string userID,
        MemberRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
