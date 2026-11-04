using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Organization.ExternalKeys;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.UserProfiles;
using OrganizationWorkspaces = Anthropic.Models.Beta.Organization.Workspaces;
using Workspaces = Anthropic.Services.Beta.Organization.Workspaces;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWorkspaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkspaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Workspaces::IRateLimitService RateLimits { get; }

    Workspaces::IMemberService Members { get; }

    Workspaces::IServiceAccountService ServiceAccounts { get; }

    /// <summary>
    /// Create Workspace
    /// </summary>
    /// <exception cref="AnthropicKeyProfileMismatchException">
    /// The External Key is bound to a user profile, and the Workspace does not have
    /// that user profile. A Workspace can use only a key bound to its own user profile
    /// or a key that isn't bound to one.
    /// </exception>
    /// <exception cref="AnthropicUserProfileNotFoundException">
    /// The request depends on a user profile that does not exist in the organization or
    /// is no longer active. The request either names this user profile by ID, or names
    /// a resource, such as an External Key, that is bound to it.
    /// </exception>
    /// <exception cref="AnthropicWorkspacePolicyViolationException">
    /// The request breaks the organization's Workspace Policy. The message says which
    /// rule it broke; an organization admin can see and change the policy in the
    /// Console.
    /// </exception>
    /// <exception cref="AnthropicExternalKeyChangedException">
    /// The external key changed while the request was validating it. Send the request
    /// again.
    /// </exception>
    Task<OrganizationWorkspaces::BetaWorkspace> Create(
        OrganizationWorkspaces::WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Workspace
    /// </summary>
    Task<OrganizationWorkspaces::BetaWorkspace> Retrieve(
        OrganizationWorkspaces::WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrganizationWorkspaces::WorkspaceRetrieveParams, CancellationToken)"/>
    Task<OrganizationWorkspaces::BetaWorkspace> Retrieve(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Workspace
    /// </summary>
    /// <exception cref="AnthropicKeyProfileMismatchException">
    /// The External Key is bound to a user profile, and the Workspace does not have
    /// that user profile. A Workspace can use only a key bound to its own user profile
    /// or a key that isn't bound to one.
    /// </exception>
    /// <exception cref="AnthropicUserProfileNotFoundException">
    /// The request depends on a user profile that does not exist in the organization or
    /// is no longer active. The request either names this user profile by ID, or names
    /// a resource, such as an External Key, that is bound to it.
    /// </exception>
    /// <exception cref="AnthropicWorkspacePolicyViolationException">
    /// The request breaks the organization's Workspace Policy. The message says which
    /// rule it broke; an organization admin can see and change the policy in the
    /// Console.
    /// </exception>
    /// <exception cref="AnthropicExternalKeyChangedException">
    /// The external key changed while the request was validating it. Send the request
    /// again.
    /// </exception>
    Task<OrganizationWorkspaces::BetaWorkspace> Update(
        OrganizationWorkspaces::WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(OrganizationWorkspaces::WorkspaceUpdateParams, CancellationToken)"/>
    Task<OrganizationWorkspaces::BetaWorkspace> Update(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Workspaces
    /// </summary>
    Task<OrganizationWorkspaces::WorkspaceListPage> List(
        OrganizationWorkspaces::WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Workspace
    /// </summary>
    Task<OrganizationWorkspaces::BetaWorkspace> Archive(
        OrganizationWorkspaces::WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(OrganizationWorkspaces::WorkspaceArchiveParams, CancellationToken)"/>
    Task<OrganizationWorkspaces::BetaWorkspace> Archive(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkspaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkspaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Workspaces::IRateLimitServiceWithRawResponse RateLimits { get; }

    Workspaces::IMemberServiceWithRawResponse Members { get; }

    Workspaces::IServiceAccountServiceWithRawResponse ServiceAccounts { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Create(OrganizationWorkspaces::WorkspaceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Create(
        OrganizationWorkspaces::WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Retrieve(OrganizationWorkspaces::WorkspaceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Retrieve(
        OrganizationWorkspaces::WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrganizationWorkspaces::WorkspaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Retrieve(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Update(OrganizationWorkspaces::WorkspaceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Update(
        OrganizationWorkspaces::WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(OrganizationWorkspaces::WorkspaceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Update(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.List(OrganizationWorkspaces::WorkspaceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationWorkspaces::WorkspaceListPage>> List(
        OrganizationWorkspaces::WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/archive</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Archive(OrganizationWorkspaces::WorkspaceArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Archive(
        OrganizationWorkspaces::WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(OrganizationWorkspaces::WorkspaceArchiveParams, CancellationToken)"/>
    Task<HttpResponse<OrganizationWorkspaces::BetaWorkspace>> Archive(
        string workspaceID,
        OrganizationWorkspaces::WorkspaceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
