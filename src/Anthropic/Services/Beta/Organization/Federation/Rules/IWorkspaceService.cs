using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;
using Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Services.Beta.Organization.Federation.Rules;

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
    /// <para>List workspaces where this federation rule is enabled.</para>
    ///
    /// <para>Returns all workspace enablements in a single response; the `limit` and
    /// `page` parameters are accepted but have no effect, and `next_page` is always
    /// `null`. Returns explicit per-workspace enablements only; for rules with
    /// `applies_to_all_workspaces` or a legacy single `workspace_id`, check those
    /// fields on the rule itself.</para>
    /// </summary>
    Task<WorkspaceListPage> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<WorkspaceListPage> List(
        string federationRuleID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Enable a federation rule for a workspace.</para>
    ///
    /// <para>Idempotent; re-enabling returns the existing enablement. The rule and
    /// workspace must both belong to your organization. Membership of the rule's target
    /// service account in this workspace is not checked at enablement: token exchange
    /// into this workspace is rejected unless the target is a member (it is implicitly
    /// a member of the default workspace). Archived rules are rejected with 400. OAuth
    /// callers may only manage rules whose `oauth_scope` is `workspace:developer` or
    /// `workspace:inference`; other scopes require a Console session.</para>
    /// </summary>
    Task<BetaFederationRuleWorkspace> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<BetaFederationRuleWorkspace> Add(
        string federationRuleID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Disable a federation rule for a workspace.</para>
    ///
    /// <para>Idempotent; succeeds even if the enablement was already removed. OAuth
    /// callers may only manage rules whose `oauth_scope` is `workspace:developer` or
    /// `workspace:inference`; other scopes require a Console session.</para>
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
    /// Returns a raw HTTP response for <c>get /v1/organizations/federation_rules/{federation_rule_id}/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.List(WorkspaceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<HttpResponse<WorkspaceListPage>> List(
        string federationRuleID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_rules/{federation_rule_id}/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Add(WorkspaceAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationRuleWorkspace>> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationRuleWorkspace>> Add(
        string federationRuleID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/federation_rules/{federation_rule_id}/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
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
