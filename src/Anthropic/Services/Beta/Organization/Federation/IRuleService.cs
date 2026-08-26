using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;
using Rules = Anthropic.Services.Beta.Organization.Federation.Rules;

namespace Anthropic.Services.Beta.Organization.Federation;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRuleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRuleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Rules::IWorkspaceService Workspaces { get; }

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Create a federation rule owned by your organization.</para>
    ///
    /// <para>The referenced issuer and the target service account must already exist in
    /// the same organization; invalid references are rejected with a 400 error. The
    /// workspace reference is validated. Membership is not checked at rule creation:
    /// token exchange resolves a single enabled workspace per call and is rejected
    /// unless the target service account is a member of that workspace (it is
    /// implicitly a member of the default workspace). Rules on well-known shared
    /// issuers (GitHub Actions, GitLab, Buildkite, Terraform Cloud, Google) must
    /// constrain tenant identity via an identity-bearing claim, a tenant-pinning
    /// subject prefix (such as `repo:YOUR_ORG/...`), or a CEL condition referencing one
    /// of those identity claims (e.g. `claims.repository_owner`). OAuth callers may
    /// only manage rules whose `oauth_scope` is `workspace:developer` or
    /// `workspace:inference`; other scopes require a Console session.</para>
    /// </summary>
    Task<BetaFederationRule> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Retrieve a federation rule by its ID (`fdrl_...`).</para>
    /// </summary>
    Task<BetaFederationRule> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleRetrieveParams, CancellationToken)"/>
    Task<BetaFederationRule> Retrieve(
        string federationRuleID,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Partially update a federation rule.</para>
    ///
    /// <para>`issuer_id` is immutable. `match` and `target` are replaced as whole
    /// objects when set. Referenced service accounts and workspaces must exist in your
    /// organization; invalid references are rejected with a 400 error. Archived rules
    /// cannot be updated; this returns 400. Create a new rule instead. Rules on
    /// well-known shared issuers (GitHub Actions, GitLab, Buildkite, Terraform Cloud,
    /// Google) must constrain tenant identity via an identity-bearing claim, a
    /// tenant-pinning subject prefix (such as `repo:YOUR_ORG/...`), or a CEL condition
    /// referencing one of those identity claims (e.g. `claims.repository_owner`). On
    /// these issuers the requirement is re-checked on every update; if an existing
    /// rule's stored match does not yet constrain tenant identity, any update (even a
    /// rename or description change) must also supply a conforming `match` in the same
    /// request. OAuth callers may only manage rules whose `oauth_scope` is
    /// `workspace:developer` or `workspace:inference`; other scopes require a Console
    /// session.</para>
    /// </summary>
    Task<BetaFederationRule> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleUpdateParams, CancellationToken)"/>
    Task<BetaFederationRule> Update(
        string federationRuleID,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>List federation rules in your organization.</para>
    ///
    /// <para>Optionally filter by issuer with `issuer_id`. Archived rules are excluded
    /// unless `include_archived=true`.</para>
    /// </summary>
    Task<RuleListPage> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Requires an OAuth access token with the `org:admin` scope**, from `ant auth
    /// login --scope org:admin` or a workload identity federation rule; Admin API keys
    /// are not accepted. See [Manage WIF with the Admin
    /// API](/docs/en/manage-claude/wif-admin-api).
    ///
    /// <para>Archive a federation rule.</para>
    ///
    /// <para>Token exchange through this rule stops immediately. Idempotent;
    /// re-archiving returns the rule with its original `archived_at`. Archiving clears
    /// the rule's workspace targeting (`workspace_id` and `workspace_ids` are emptied).
    /// Tokens already minted before archive remain valid until they expire. OAuth
    /// callers may only manage rules whose `oauth_scope` is `workspace:developer` or
    /// `workspace:inference`; other scopes require a Console session.</para>
    /// </summary>
    Task<BetaFederationRule> Archive(
        RuleArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(RuleArchiveParams, CancellationToken)"/>
    Task<BetaFederationRule> Archive(
        string federationRuleID,
        RuleArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRuleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRuleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Rules::IWorkspaceServiceWithRawResponse Workspaces { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_rules?beta=true</c>, but is otherwise the
    /// same as <see cref="IRuleService.Create(RuleCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationRule>> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/federation_rules/{federation_rule_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IRuleService.Retrieve(RuleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationRule>> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationRule>> Retrieve(
        string federationRuleID,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_rules/{federation_rule_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IRuleService.Update(RuleUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationRule>> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationRule>> Update(
        string federationRuleID,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/federation_rules?beta=true</c>, but is otherwise the
    /// same as <see cref="IRuleService.List(RuleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleListPage>> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/federation_rules/{federation_rule_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IRuleService.Archive(RuleArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaFederationRule>> Archive(
        RuleArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(RuleArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaFederationRule>> Archive(
        string federationRuleID,
        RuleArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
