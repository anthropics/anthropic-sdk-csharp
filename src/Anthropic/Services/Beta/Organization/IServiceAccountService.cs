using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts;
using ServiceAccounts = Anthropic.Services.Beta.Organization.ServiceAccounts;

namespace Anthropic.Services.Beta.Organization;

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

    ServiceAccounts::IWorkspaceService Workspaces { get; }

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Create a service account.</para>
    ///
    /// <para>A service account is a named workload identity that federation rules
    /// target. `organization_role` is `developer` (default) or `admin`; a rule may only
    /// be created or retargeted to grant `org:admin` scope when the target's
    /// `organization_role` is `admin`. Creating an `admin`-role service account
    /// requires an interactive credential (a user OAuth token or a Console session) — a
    /// workload may only create `developer`-role service accounts.</para>
    /// </summary>
    Task<BetaServiceAccount> Create(
        ServiceAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Retrieve a service account by its ID (`svac_...`).</para>
    /// </summary>
    Task<BetaServiceAccount> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>
    Task<BetaServiceAccount> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Update a service account.</para>
    ///
    /// <para>Only `description` and `organization_role` are mutable; `name` cannot be
    /// changed. Archived service accounts cannot be updated; this returns 400. Setting
    /// `organization_role` to `admin` (even when unchanged) requires an interactive
    /// credential (a user OAuth token or a Console session).</para>
    /// </summary>
    Task<BetaServiceAccount> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ServiceAccountUpdateParams, CancellationToken)"/>
    Task<BetaServiceAccount> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>List service accounts in the caller's organization.</para>
    ///
    /// <para>Results are ordered by creation time, newest first. Use `limit` and the
    /// `next_page` cursor to paginate; set `include_archived=true` to include archived
    /// service accounts.</para>
    /// </summary>
    Task<ServiceAccountListPage> List(
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Archive a service account.</para>
    ///
    /// <para>Idempotent; re-archiving returns the service account with its original
    /// `archived_at`. Rejected with 400 if any live (non-archived) federation rule
    /// still targets this service account, same as issuer archival; archive those rules
    /// first or change their target to another service account.</para>
    /// </summary>
    Task<BetaServiceAccount> Archive(
        ServiceAccountArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ServiceAccountArchiveParams, CancellationToken)"/>
    Task<BetaServiceAccount> Archive(
        string serviceAccountID,
        ServiceAccountArchiveParams? parameters = null,
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

    ServiceAccounts::IWorkspaceServiceWithRawResponse Workspaces { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/service_accounts?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Create(ServiceAccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaServiceAccount>> Create(
        ServiceAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/service_accounts/{service_account_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaServiceAccount>> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ServiceAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaServiceAccount>> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/service_accounts/{service_account_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Update(ServiceAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaServiceAccount>> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ServiceAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaServiceAccount>> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/service_accounts?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.List(ServiceAccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ServiceAccountListPage>> List(
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/service_accounts/{service_account_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IServiceAccountService.Archive(ServiceAccountArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaServiceAccount>> Archive(
        ServiceAccountArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ServiceAccountArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaServiceAccount>> Archive(
        string serviceAccountID,
        ServiceAccountArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
