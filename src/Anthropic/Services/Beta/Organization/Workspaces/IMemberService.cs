using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;
using Anthropic.Models.Beta.Organization.Workspaces.Members;

namespace Anthropic.Services.Beta.Organization.Workspaces;

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
    /// Get Workspace Member
    /// </summary>
    Task<BetaWorkspaceMember> Retrieve(
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemberRetrieveParams, CancellationToken)"/>
    Task<BetaWorkspaceMember> Retrieve(
        string userID,
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Workspace Member
    /// </summary>
    Task<BetaWorkspaceMember> Update(
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemberUpdateParams, CancellationToken)"/>
    Task<BetaWorkspaceMember> Update(
        string userID,
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Workspace Members
    /// </summary>
    Task<MemberListPage> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemberListParams, CancellationToken)"/>
    Task<MemberListPage> List(
        string workspaceID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create Workspace Member
    /// </summary>
    Task<BetaWorkspaceMember> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(MemberAddParams, CancellationToken)"/>
    Task<BetaWorkspaceMember> Add(
        string workspaceID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Workspace Member
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
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}/members/{user_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.Retrieve(MemberRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspaceMember>> Retrieve(
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspaceMember>> Retrieve(
        string userID,
        MemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/members/{user_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.Update(MemberUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspaceMember>> Update(
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspaceMember>> Update(
        string userID,
        MemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}/members?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.List(MemberListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemberListPage>> List(
        MemberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemberListParams, CancellationToken)"/>
    Task<HttpResponse<MemberListPage>> List(
        string workspaceID,
        MemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/members?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemberService.Add(MemberAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspaceMember>> Add(
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(MemberAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspaceMember>> Add(
        string workspaceID,
        MemberAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/workspaces/{workspace_id}/members/{user_id}?beta=true</c>, but is otherwise the
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
