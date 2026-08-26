using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;
using ServiceAccounts = Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Services.Beta.Organization.Workspaces;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IServiceAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IServiceAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IServiceAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Retrieve a service account's membership in a workspace.</para>
    ///
    /// <para>Returns the membership record, including the service account's
    /// `workspace_role` in this workspace. Archived workspaces return 400. For the
    /// default workspace, returns the implicit (`implicit: true`) membership when no
    /// explicit membership exists; an explicitly added membership is returned with its
    /// assigned role. An archived service account returns 404.</para>
    /// </summary>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Change a service account's role in a workspace.</para>
    ///
    /// <para>The new `workspace_role` replaces the current one. Only explicit
    /// memberships can be updated; to set a role on the implicit default-workspace
    /// membership, add the service account explicitly with `POST
    /// /workspaces/{workspace_id}/service_accounts`. Archived workspaces return 400.
    /// Archived service accounts cannot be updated and are rejected.</para>
    /// </summary>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ServiceAccountUpdateParams, CancellationToken)"/>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>List the service accounts that are members of a workspace.</para>
    ///
    /// <para>Each entry includes the service account's `workspace_role`. Use `limit`
    /// and the `next_page` cursor to paginate. Archived workspaces return 400; use `GET
    /// /service_accounts/{id}/workspaces` to audit memberships of an archived
    /// workspace. The implicit default-workspace membership is not included in this
    /// list. Memberships of archived service accounts are omitted from the results.</para>
    /// </summary>
    Task<ServiceAccountListPage> List(
        ServiceAccountListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ServiceAccountListParams, CancellationToken)"/>
    Task<ServiceAccountListPage> List(
        string workspaceID,
        ServiceAccountListParams? parameters = null,
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
    /// <para>The role determines what the service account can do in the workspace and
    /// which workspace-scoped permissions it can be granted when authenticating through
    /// federation. Every service account is already an implicit `workspace_user` member
    /// of the default workspace; adding it explicitly assigns a chosen role. If the
    /// service account is already an explicit member of the workspace, its
    /// `workspace_role` is replaced with the value supplied here. Archived workspaces
    /// return 400. Archived service accounts cannot be added and are rejected.</para>
    /// </summary>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Add(
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ServiceAccountAddParams, CancellationToken)"/>
    Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Add(
        string workspaceID,
        ServiceAccountAddParams parameters,
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
    /// <para>Removal is idempotent (returns 200 even if the membership was already
    /// removed). A DELETE against the implicit default-workspace membership returns 200
    /// but is a no-op and the membership persists; deleting an explicit
    /// default-workspace row reverts to the implicit `workspace_user` membership.
    /// Archived workspaces return 400.</para>
    /// </summary>
    Task<ServiceAccountRemoveResponse> Remove(
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ServiceAccountRemoveParams, CancellationToken)"/>
    Task<ServiceAccountRemoveResponse> Remove(
        string serviceAccountID,
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IServiceAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IServiceAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IServiceAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}/service_accounts/{service_account_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/service_accounts/{service_account_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Update(ServiceAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ServiceAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/workspaces/{workspace_id}/service_accounts?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.List(ServiceAccountListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccountListPage>> List(
        ServiceAccountListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ServiceAccountListParams, CancellationToken)"/>
    Task<HttpResponse<ServiceAccountListPage>> List(
        string workspaceID,
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/workspaces/{workspace_id}/service_accounts?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Add(ServiceAccountAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Add(
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ServiceAccountAddParams, CancellationToken)"/>
    Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Add(
        string workspaceID,
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/workspaces/{workspace_id}/service_accounts/{service_account_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Remove(ServiceAccountRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccountRemoveResponse>> Remove(
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ServiceAccountRemoveParams, CancellationToken)"/>
    Task<HttpResponse<ServiceAccountRemoveResponse>> Remove(
        string serviceAccountID,
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
