using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;
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
    Task<BetaWorkspace> Create(
        WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Workspace
    /// </summary>
    Task<BetaWorkspace> Retrieve(
        WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkspaceRetrieveParams, CancellationToken)"/>
    Task<BetaWorkspace> Retrieve(
        string workspaceID,
        WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Workspace
    /// </summary>
    Task<BetaWorkspace> Update(
        WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkspaceUpdateParams, CancellationToken)"/>
    Task<BetaWorkspace> Update(
        string workspaceID,
        WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Workspaces
    /// </summary>
    Task<WorkspaceListPage> List(
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Workspace
    /// </summary>
    Task<BetaWorkspace> Archive(
        WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(WorkspaceArchiveParams, CancellationToken)"/>
    Task<BetaWorkspace> Archive(
        string workspaceID,
        WorkspaceArchiveParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Create(WorkspaceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspace>> Create(
        WorkspaceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Retrieve(WorkspaceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspace>> Retrieve(
        WorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkspaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspace>> Retrieve(
        string workspaceID,
        WorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Update(WorkspaceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspace>> Update(
        WorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkspaceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspace>> Update(
        string workspaceID,
        WorkspaceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.List(WorkspaceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Archive(WorkspaceArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaWorkspace>> Archive(
        WorkspaceArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(WorkspaceArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaWorkspace>> Archive(
        string workspaceID,
        WorkspaceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
