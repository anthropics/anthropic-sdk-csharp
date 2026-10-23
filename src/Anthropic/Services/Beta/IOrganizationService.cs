using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Organization = Anthropic.Services.Beta.Organization;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrganizationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Organization::IApiKeyService ApiKeys { get; }

    Organization::IExternalKeyService ExternalKeys { get; }

    Organization::IFederationService Federation { get; }

    Organization::IInviteService Invites { get; }

    Organization::IServiceAccountService ServiceAccounts { get; }

    Organization::IUserService Users { get; }

    Organization::IWorkspaceService Workspaces { get; }

    Organization::IRateLimitService RateLimits { get; }

    Organization::IComplianceSettingService ComplianceSettings { get; }

    Organization::IAnalyticsService Analytics { get; }

    Organization::ISpendLimitService SpendLimits { get; }

    Organization::IRbacGroupService RbacGroups { get; }

    Organization::IRbacRoleService RbacRoles { get; }

    Organization::IPluginService Plugins { get; }

    Organization::IPluginMarketplaceService PluginMarketplaces { get; }

    Organization::ITelemetryDestinationService TelemetryDestinations { get; }

    Organization::IWebhookService Webhooks { get; }

    Organization::IClaudeTagService ClaudeTag { get; }

    /// <summary>
    /// Retrieve information about the organization associated with the authenticated
    /// API key.
    /// </summary>
    Task<BetaOrganization> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOrganizationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOrganizationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Organization::IApiKeyServiceWithRawResponse ApiKeys { get; }

    Organization::IExternalKeyServiceWithRawResponse ExternalKeys { get; }

    Organization::IFederationServiceWithRawResponse Federation { get; }

    Organization::IInviteServiceWithRawResponse Invites { get; }

    Organization::IServiceAccountServiceWithRawResponse ServiceAccounts { get; }

    Organization::IUserServiceWithRawResponse Users { get; }

    Organization::IWorkspaceServiceWithRawResponse Workspaces { get; }

    Organization::IRateLimitServiceWithRawResponse RateLimits { get; }

    Organization::IComplianceSettingServiceWithRawResponse ComplianceSettings { get; }

    Organization::IAnalyticsServiceWithRawResponse Analytics { get; }

    Organization::ISpendLimitServiceWithRawResponse SpendLimits { get; }

    Organization::IRbacGroupServiceWithRawResponse RbacGroups { get; }

    Organization::IRbacRoleServiceWithRawResponse RbacRoles { get; }

    Organization::IPluginServiceWithRawResponse Plugins { get; }

    Organization::IPluginMarketplaceServiceWithRawResponse PluginMarketplaces { get; }

    Organization::ITelemetryDestinationServiceWithRawResponse TelemetryDestinations { get; }

    Organization::IWebhookServiceWithRawResponse Webhooks { get; }

    Organization::IClaudeTagServiceWithRawResponse ClaudeTag { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/me</c>, but is otherwise the
    /// same as <see cref="IOrganizationService.Retrieve(OrganizationRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganization>> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
