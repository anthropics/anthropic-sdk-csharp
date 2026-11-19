using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRbacGroupDefaultService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRbacGroupDefaultServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupDefaultService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the default Claude Code managed settings, which members who belong to
    /// no RBAC Group in `rbac_group_order` receive in `rbac_groups` mode.
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
    Task<BetaClaudeCodeRbacGroupDefaultManagedSettings> Retrieve(
        RbacGroupDefaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set or replace the default Claude Code managed settings, or clear them with
    /// `null`.
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
    /// <exception cref="AnthropicBetaRequestBodyTimeoutException"/>
    /// <exception cref="AnthropicBetaSettingsDocumentLimitExceededException"/>
    /// <exception cref="AnthropicBetaSettingsHistoryLimitExceededException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    Task<BetaClaudeCodeRbacGroupDefaultManagedSettings> Update(
        RbacGroupDefaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRbacGroupDefaultService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRbacGroupDefaultServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRbacGroupDefaultServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_code/managed_settings/rbac_group_default</c>, but is otherwise the
    /// same as <see cref="IRbacGroupDefaultService.Retrieve(RbacGroupDefaultRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeRbacGroupDefaultManagedSettings>> Retrieve(
        RbacGroupDefaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_code/managed_settings/rbac_group_default</c>, but is otherwise the
    /// same as <see cref="IRbacGroupDefaultService.Update(RbacGroupDefaultUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeRbacGroupDefaultManagedSettings>> Update(
        RbacGroupDefaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
