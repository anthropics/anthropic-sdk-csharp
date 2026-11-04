using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Organization;
using Anthropic.Models.Organization.Invites;
using Anthropic.Models.Organization.RbacGroups;
using Invites = Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInviteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInviteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInviteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Invite a user to join the organization by email.
    ///
    /// <para>On plans that draw members from a finite pool of purchased seats, the
    /// invite automatically consumes a seat from the lowest tier with availability;
    /// there is no seat-tier parameter. When no seat is free the request fails with a
    /// 400 error rather than purchasing a seat.</para>
    /// </summary>
    /// <exception cref="AnthropicAlreadyMemberException">
    /// The email address already belongs to a user in the organization. The message
    /// names the user.
    /// </exception>
    /// <exception cref="AnthropicCannotInviteEmailsWithUnverifiedDomainsException">
    /// The email address's domain is not one of the verified domains of the
    /// organization's parent organization.
    /// </exception>
    /// <exception cref="AnthropicEmailDomainNotAllowedException">
    /// The organization restricts invites to an allowed list of email domains, and the
    /// list is empty or does not include the email address's domain.
    /// </exception>
    /// <exception cref="AnthropicInviteAlreadyExistsException">
    /// A pending invite already exists for the email address. The message names the
    /// invite.
    /// </exception>
    /// <exception cref="AnthropicOrgMemberLimitExceededException">
    /// The organization has reached the member limit that Anthropic set for it. Pending
    /// invites count toward the limit.
    /// </exception>
    /// <exception cref="AnthropicRbacGroupGrantsOwnerAccessException">
    /// A role attached to an RBAC Group in the request grants owner access, so this API
    /// does not add members to that group (directly or through an invite), remove its
    /// members, or delete it. Make the change in the organization's admin settings in
    /// Claude.
    /// </exception>
    /// <exception cref="AnthropicRbacGroupOwnerAccessUnconfirmedException">
    /// The API could not finish checking whether an RBAC Group in the request grants
    /// owner access (the check reached a fixed limit), so it made no change. Retrying
    /// the same request will not help. Make the change in the organization's admin
    /// settings in Claude.
    /// </exception>
    Task<Invites::BetaOrganizationInvite> Create(
        Invites::InviteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an invite by ID.
    /// </summary>
    Task<Invites::BetaOrganizationInvite> Retrieve(
        Invites::InviteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Invites::InviteRetrieveParams, CancellationToken)"/>
    Task<Invites::BetaOrganizationInvite> Retrieve(
        string inviteID,
        Invites::InviteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's invites.
    /// </summary>
    Task<Invites::InviteListPage> List(
        Invites::InviteListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a pending invite.
    /// </summary>
    Task<Invites::InviteDeleteResponse> Delete(
        Invites::InviteDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(Invites::InviteDeleteParams, CancellationToken)"/>
    Task<Invites::InviteDeleteResponse> Delete(
        string inviteID,
        Invites::InviteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInviteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInviteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInviteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/invites</c>, but is otherwise the
    /// same as <see cref="IInviteService.Create(Invites::InviteCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invites::BetaOrganizationInvite>> Create(
        Invites::InviteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/invites/{invite_id}</c>, but is otherwise the
    /// same as <see cref="IInviteService.Retrieve(Invites::InviteRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invites::BetaOrganizationInvite>> Retrieve(
        Invites::InviteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Invites::InviteRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Invites::BetaOrganizationInvite>> Retrieve(
        string inviteID,
        Invites::InviteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/invites</c>, but is otherwise the
    /// same as <see cref="IInviteService.List(Invites::InviteListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invites::InviteListPage>> List(
        Invites::InviteListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/invites/{invite_id}</c>, but is otherwise the
    /// same as <see cref="IInviteService.Delete(Invites::InviteDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Invites::InviteDeleteResponse>> Delete(
        Invites::InviteDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(Invites::InviteDeleteParams, CancellationToken)"/>
    Task<HttpResponse<Invites::InviteDeleteResponse>> Delete(
        string inviteID,
        Invites::InviteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
