using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Users;
using Anthropic.Models.Organization;
using Users = Anthropic.Models.Organization.Users;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a member of the organization by user ID.
    /// </summary>
    Task<BetaOrganizationUser> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<BetaOrganizationUser> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a member's organization role.
    /// </summary>
    Task<BetaOrganizationUser> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<BetaOrganizationUser> Update(
        string userID,
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's members.
    /// </summary>
    Task<UserListPage> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a member from the organization.
    /// </summary>
    /// <exception cref="Users::AnthropicCannotRemoveLastMemberException"/>
    /// <exception cref="AnthropicConcurrentMembershipChangeException"/>
    Task<UserRemoveResponse> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task<UserRemoveResponse> Remove(
        string userID,
        UserRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sign a member out of Claude everywhere, without removing them from the
    /// organization. This ends their sign-in sessions and removes their trusted devices
    /// wherever they use Claude, including other organizations and individual plans. It
    /// also ends the OAuth tokens issued to them for this organization, so apps such as
    /// Claude Code must sign in again.
    ///
    /// <para>A token can take up to an hour to stop working, though it almost always
    /// stops at once. The member keeps their role and can sign in again right away. To
    /// keep them out, remove them from the organization or, if your organization uses
    /// single sign-on, block them in your identity provider. Signing out does not end
    /// API keys, OAuth tokens that were not issued for this organization, or the
    /// member's Claude Code cloud sessions and routines.</para>
    ///
    /// <para>You cannot sign out the organization's primary owner or the person your
    /// API key or token acts for, and a request to sign out another owner, a member
    /// with owner permissions, or a membership admin may be refused. A refused request
    /// returns a `400` or `403` error that says why. If the request returns `503`, send
    /// it again to finish; anything already ended stays ended.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// admin-user-sign-out-2026-10-08`. A request without it returns `400`. Sign-out is
    /// in beta for Claude Enterprise organizations. In an organization where it is not
    /// enabled, a request returns `400` with `error_code`
    /// `organization_not_enrolled_in_beta`. In a Claude Enterprise organization, an API
    /// key needs the `write:members` scope; a key without it gets `403`.</para>
    /// </summary>
    /// <exception cref="AnthropicBetaCannotSignOutPrimaryOwnerException"/>
    /// <exception cref="AnthropicBetaCannotSignOutSelfException"/>
    /// <exception cref="AnthropicBetaOrganizationNotEnrolledInBetaException"/>
    /// <exception cref="AnthropicBetaCannotSignOutManagedMemberException"/>
    /// <exception cref="AnthropicBetaCannotSignOutMembershipAdminException"/>
    /// <exception cref="AnthropicBetaCannotSignOutOwnerException"/>
    /// <exception cref="AnthropicBetaCannotSignOutPrivilegedMemberException"/>
    Task<BetaOrganizationUser> SignOut(
        UserSignOutParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SignOut(UserSignOutParams, CancellationToken)"/>
    Task<BetaOrganizationUser> SignOut(
        string userID,
        UserSignOutParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/users/{user_id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationUser>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationUser>> Retrieve(
        string userID,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/users/{user_id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Update(UserUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationUser>> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationUser>> Update(
        string userID,
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/users</c>, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListPage>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/users/{user_id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Remove(UserRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRemoveResponse>> Remove(
        UserRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(UserRemoveParams, CancellationToken)"/>
    Task<HttpResponse<UserRemoveResponse>> Remove(
        string userID,
        UserRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/users/{user_id}/sign_out</c>, but is otherwise the
    /// same as <see cref="IUserService.SignOut(UserSignOutParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganizationUser>> SignOut(
        UserSignOutParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SignOut(UserSignOutParams, CancellationToken)"/>
    Task<HttpResponse<BetaOrganizationUser>> SignOut(
        string userID,
        UserSignOutParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
