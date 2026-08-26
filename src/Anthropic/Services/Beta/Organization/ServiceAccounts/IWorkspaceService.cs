using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts;
using Anthropic.Models.Beta.Organization.ServiceAccounts.Workspaces;

namespace Anthropic.Services.Beta.Organization.ServiceAccounts;

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

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>List the workspaces a service account is a member of.</para>
    ///
    /// <para>Each entry includes the service account's `workspace_role` in that
    /// workspace. Use `limit` and the `next_page` cursor to paginate. When the service
    /// account has no explicit default-workspace membership, the implicit (`implicit:
    /// true`) membership is returned as the first entry on the first page; with
    /// `limit=1` the first page may return up to 2 entries (the implicit entry plus one
    /// explicit membership) so a pagination cursor can be derived. Memberships are
    /// returned only while the service account is active. Without a `page` cursor, an
    /// archived service account returns an empty list. A `page` cursor that does not
    /// match an active membership returns a 400 invalid-request error. A cursor stops
    /// matching when the membership is removed, the workspace is deleted, or the
    /// service account is archived. Restart pagination from the first page to recover.</para>
    /// </summary>
    Task<WorkspaceListPage> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<WorkspaceListPage> List(
        string serviceAccountID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Add a service account to a workspace with the given `workspace_role`.</para>
    ///
    /// <para>Mirror of `POST /workspaces/{workspace_id}/service_accounts`, addressed
    /// from the service-account side; both create the same membership. If the service
    /// account is already an explicit member of the workspace, its `workspace_role` is
    /// replaced with the value supplied here. Archived workspaces return 400. Archived
    /// service accounts cannot be added and are rejected.</para>
    /// </summary>
    Task<BetaServiceAccountWorkspaceMember> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<BetaServiceAccountWorkspaceMember> Add(
        string serviceAccountID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Remove a service account from a workspace.</para>
    ///
    /// <para>Mirror of `DELETE
    /// /workspaces/{workspace_id}/service_accounts/{service_account_id}`, addressed
    /// from the service-account side. Removal is idempotent (returns 200 even if the
    /// membership was already removed). A DELETE against the implicit default-workspace
    /// membership returns 200 but is a no-op and the membership persists; deleting an
    /// explicit default-workspace row reverts to the implicit `workspace_user`
    /// membership. Archived workspaces return 400.</para>
    /// </summary>
    Task<WorkspaceRemoveResponse> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(WorkspaceRemoveParams, CancellationToken)"/>
    Task<WorkspaceRemoveResponse> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/service_accounts/{service_account_id}/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.List(WorkspaceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<HttpResponse<WorkspaceListPage>> List(
        string serviceAccountID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/service_accounts/{service_account_id}/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Add(WorkspaceAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaServiceAccountWorkspaceMember>> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaServiceAccountWorkspaceMember>> Add(
        string serviceAccountID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/service_accounts/{service_account_id}/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Remove(WorkspaceRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspaceRemoveResponse>> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(WorkspaceRemoveParams, CancellationToken)"/>
    Task<HttpResponse<WorkspaceRemoveResponse>> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
