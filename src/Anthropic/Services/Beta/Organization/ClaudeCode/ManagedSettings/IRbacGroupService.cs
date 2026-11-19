using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;
using RbacGroups = Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRbacGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRbacGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve an RBAC Group's Claude Code managed settings.
    ///
    /// <para>**Accepted credentials:** an organization-level Admin API key with the
    /// `read:claude_code_managed_settings` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-claude-code-managed-settings-2026-10-06`. A request without it, or from an
    /// organization not enabled for this beta, returns `404`. The Claude Code Managed
    /// Settings API is in beta and is available to Claude Enterprise organizations
    /// only.</para>
    /// </summary>
    /// <exception cref="AnthropicBetaCmekFeatureUnsupportedException"/>
    /// <exception cref="AnthropicCmekKeyDisabledException"/>
    /// <exception cref="AnthropicBetaRbacGroupManagedSettingsNotFoundException"/>
    Task<BetaClaudeCodeRbacGroupManagedSettings> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>
    Task<BetaClaudeCodeRbacGroupManagedSettings> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the RBAC Groups that have Claude Code managed settings, highest precedence
    /// first.
    ///
    /// <para>Each entry gives the group's status and timestamps, not its settings. The
    /// list includes deleted groups that still have settings, and leaves out the
    /// default settings. If the order changes between pages, the request returns `409`:
    /// list again from the first page.</para>
    ///
    /// <para>**Accepted credentials:** an organization-level Admin API key with the
    /// `read:claude_code_managed_settings` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-claude-code-managed-settings-2026-10-06`. A request without it, or from an
    /// organization not enabled for this beta, returns `404`. The Claude Code Managed
    /// Settings API is in beta and is available to Claude Enterprise organizations
    /// only.</para>
    /// </summary>
    Task<RbacGroupListPage> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an RBAC Group's Claude Code managed settings and remove the group from
    /// `rbac_group_order`.
    ///
    /// <para>A group with no settings returns `404` with the error code
    /// `rbac_group_managed_settings_not_found`. That code on a retry of a delete that
    /// returned `503` means the settings are gone.</para>
    ///
    /// <para>**Accepted credentials:** an organization-level Admin API key with the
    /// `write:claude_code_managed_settings` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-claude-code-managed-settings-2026-10-06`. A request without it, or from an
    /// organization not enabled for this beta, returns `404`. The Claude Code Managed
    /// Settings API is in beta and is available to Claude Enterprise organizations
    /// only.</para>
    ///
    /// <para>A write that returns `503` may have applied. Retrying it is safe.</para>
    /// </summary>
    /// <exception cref="AnthropicCmekKeyDisabledException"/>
    /// <exception cref="AnthropicBetaSettingsHistoryLimitExceededException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    /// <exception cref="AnthropicBetaRbacGroupManagedSettingsNotFoundException"/>
    Task<BetaDeletedClaudeCodeRbacGroupManagedSettings> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RbacGroupDeleteParams, CancellationToken)"/>
    Task<BetaDeletedClaudeCodeRbacGroupManagedSettings> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or replace an RBAC Group's Claude Code managed settings.
    ///
    /// <para>New settings join the end of `rbac_group_order`, and existing settings
    /// keep their place. Until the group is moved up, its members who also belong to an
    /// earlier group keep that group's settings. In `organization` mode a write changes
    /// no member's settings until the organization switches to `rbac_groups` mode. Once
    /// a group has settings, that switch no longer copies the organization settings
    /// into default settings, so members in no RBAC Group in `rbac_group_order` receive
    /// no settings unless you set the default settings before the switch.</para>
    ///
    /// <para>Get the group's ID from the RBAC Groups API. One key can hold
    /// `read:rbac_groups` and `write:claude_code_managed_settings`.</para>
    ///
    /// <para>**Accepted credentials:** an organization-level Admin API key with the
    /// `write:claude_code_managed_settings` scope.</para>
    ///
    /// <para>Every request must include the beta header `anthropic-beta:
    /// ce-claude-code-managed-settings-2026-10-06`. A request without it, or from an
    /// organization not enabled for this beta, returns `404`. The Claude Code Managed
    /// Settings API is in beta and is available to Claude Enterprise organizations
    /// only.</para>
    ///
    /// <para>A write that returns `503` may have applied. Retrying it is safe.</para>
    /// </summary>
    /// <exception cref="AnthropicBetaCmekFeatureUnsupportedException"/>
    /// <exception cref="AnthropicCmekKeyDisabledException"/>
    /// <exception cref="AnthropicBetaRbacGroupOrderLimitExceededException"/>
    /// <exception cref="AnthropicBetaRequestBodyTimeoutException"/>
    /// <exception cref="AnthropicBetaSettingsDocumentLimitExceededException"/>
    /// <exception cref="AnthropicBetaSettingsHistoryLimitExceededException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    /// <exception cref="RbacGroups::AnthropicBetaRbacGroupNotFoundException"/>
    Task<BetaClaudeCodeRbacGroupManagedSettings> Set(
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(RbacGroupSetParams, CancellationToken)"/>
    Task<BetaClaudeCodeRbacGroupManagedSettings> Set(
        string rbacGroupID,
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRbacGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRbacGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_code/managed_settings/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RbacGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_code/managed_settings/rbac_groups</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.List(RbacGroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RbacGroupListPage>> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/claude_code/managed_settings/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Delete(RbacGroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedClaudeCodeRbacGroupManagedSettings>> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RbacGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedClaudeCodeRbacGroupManagedSettings>> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_code/managed_settings/rbac_groups/{rbac_group_id}</c>, but is otherwise the
    /// same as <see cref="IRbacGroupService.Set(RbacGroupSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Set(
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(RbacGroupSetParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Set(
        string rbacGroupID,
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    );
}
