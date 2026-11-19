using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConfigurationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the organization's Claude Code managed settings mode and RBAC Group
    /// order.
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
    Task<BetaClaudeCodeManagedSettingsConfiguration> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change the organization's Claude Code managed settings mode, the RBAC Group
    /// order, or both, in one atomic write.
    ///
    /// <para>To change the order, send `rbac_group_order` with the
    /// `rbac_group_order_version` from the read the change is based on. If the order
    /// has changed since that read, the request returns `409`: read it again and retry.
    /// To switch modes only if the order has not changed, send the current
    /// `rbac_group_order` and `rbac_group_order_version` with the new `mode`.</para>
    ///
    /// <para>A switch to `rbac_groups` mode with no RBAC Group settings and no default
    /// settings copies the organization settings into a new default, in the same write,
    /// so members keep the settings they had. The copy does not follow later changes to
    /// the organization settings. If the organization settings cannot be copied, the
    /// request returns `400` and changes nothing. If they cannot be read, are over 1
    /// MiB or are not valid, setting the default settings first avoids the copy.</para>
    ///
    /// <para>After a switch to `rbac_groups` mode, a member in no listed RBAC Group
    /// receives the default settings, or no settings if no default is set, not the
    /// organization settings.</para>
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
    /// <exception cref="AnthropicBetaRequestBodyTimeoutException"/>
    /// <exception cref="AnthropicBetaSettingsDocumentLimitExceededException"/>
    /// <exception cref="AnthropicBetaSettingsHistoryLimitExceededException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    Task<BetaClaudeCodeManagedSettingsConfiguration> Update(
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConfigurationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConfigurationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_code/managed_settings/configuration</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Retrieve(ConfigurationRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeManagedSettingsConfiguration>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_code/managed_settings/configuration</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Update(ConfigurationUpdateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeCodeManagedSettingsConfiguration>> Update(
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
