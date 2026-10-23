using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Organization = Anthropic.Services.Beta.Organization;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class OrganizationService : IOrganizationService
{
    readonly Lazy<IOrganizationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrganizationService(this._client.WithOptions(modifier));
    }

    public OrganizationService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new OrganizationServiceWithRawResponse(client.WithRawResponse)
        );
        _apiKeys = new(() => new Organization::ApiKeyService(client));
        _externalKeys = new(() => new Organization::ExternalKeyService(client));
        _federation = new(() => new Organization::FederationService(client));
        _invites = new(() => new Organization::InviteService(client));
        _serviceAccounts = new(() => new Organization::ServiceAccountService(client));
        _users = new(() => new Organization::UserService(client));
        _workspaces = new(() => new Organization::WorkspaceService(client));
        _rateLimits = new(() => new Organization::RateLimitService(client));
        _complianceSettings = new(() => new Organization::ComplianceSettingService(client));
        _analytics = new(() => new Organization::AnalyticsService(client));
        _spendLimits = new(() => new Organization::SpendLimitService(client));
        _rbacGroups = new(() => new Organization::RbacGroupService(client));
        _rbacRoles = new(() => new Organization::RbacRoleService(client));
        _plugins = new(() => new Organization::PluginService(client));
        _pluginMarketplaces = new(() => new Organization::PluginMarketplaceService(client));
        _telemetryDestinations = new(() => new Organization::TelemetryDestinationService(client));
        _webhooks = new(() => new Organization::WebhookService(client));
        _claudeTag = new(() => new Organization::ClaudeTagService(client));
    }

    readonly Lazy<Organization::IApiKeyService> _apiKeys;
    public Organization::IApiKeyService ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<Organization::IExternalKeyService> _externalKeys;
    public Organization::IExternalKeyService ExternalKeys
    {
        get { return _externalKeys.Value; }
    }

    readonly Lazy<Organization::IFederationService> _federation;
    public Organization::IFederationService Federation
    {
        get { return _federation.Value; }
    }

    readonly Lazy<Organization::IInviteService> _invites;
    public Organization::IInviteService Invites
    {
        get { return _invites.Value; }
    }

    readonly Lazy<Organization::IServiceAccountService> _serviceAccounts;
    public Organization::IServiceAccountService ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    readonly Lazy<Organization::IUserService> _users;
    public Organization::IUserService Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<Organization::IWorkspaceService> _workspaces;
    public Organization::IWorkspaceService Workspaces
    {
        get { return _workspaces.Value; }
    }

    readonly Lazy<Organization::IRateLimitService> _rateLimits;
    public Organization::IRateLimitService RateLimits
    {
        get { return _rateLimits.Value; }
    }

    readonly Lazy<Organization::IComplianceSettingService> _complianceSettings;
    public Organization::IComplianceSettingService ComplianceSettings
    {
        get { return _complianceSettings.Value; }
    }

    readonly Lazy<Organization::IAnalyticsService> _analytics;
    public Organization::IAnalyticsService Analytics
    {
        get { return _analytics.Value; }
    }

    readonly Lazy<Organization::ISpendLimitService> _spendLimits;
    public Organization::ISpendLimitService SpendLimits
    {
        get { return _spendLimits.Value; }
    }

    readonly Lazy<Organization::IRbacGroupService> _rbacGroups;
    public Organization::IRbacGroupService RbacGroups
    {
        get { return _rbacGroups.Value; }
    }

    readonly Lazy<Organization::IRbacRoleService> _rbacRoles;
    public Organization::IRbacRoleService RbacRoles
    {
        get { return _rbacRoles.Value; }
    }

    readonly Lazy<Organization::IPluginService> _plugins;
    public Organization::IPluginService Plugins
    {
        get { return _plugins.Value; }
    }

    readonly Lazy<Organization::IPluginMarketplaceService> _pluginMarketplaces;
    public Organization::IPluginMarketplaceService PluginMarketplaces
    {
        get { return _pluginMarketplaces.Value; }
    }

    readonly Lazy<Organization::ITelemetryDestinationService> _telemetryDestinations;
    public Organization::ITelemetryDestinationService TelemetryDestinations
    {
        get { return _telemetryDestinations.Value; }
    }

    readonly Lazy<Organization::IWebhookService> _webhooks;
    public Organization::IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<Organization::IClaudeTagService> _claudeTag;
    public Organization::IClaudeTagService ClaudeTag
    {
        get { return _claudeTag.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaOrganization> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OrganizationServiceWithRawResponse : IOrganizationServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOrganizationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OrganizationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OrganizationServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _apiKeys = new(() => new Organization::ApiKeyServiceWithRawResponse(client));
        _externalKeys = new(() => new Organization::ExternalKeyServiceWithRawResponse(client));
        _federation = new(() => new Organization::FederationServiceWithRawResponse(client));
        _invites = new(() => new Organization::InviteServiceWithRawResponse(client));
        _serviceAccounts = new(() =>
            new Organization::ServiceAccountServiceWithRawResponse(client)
        );
        _users = new(() => new Organization::UserServiceWithRawResponse(client));
        _workspaces = new(() => new Organization::WorkspaceServiceWithRawResponse(client));
        _rateLimits = new(() => new Organization::RateLimitServiceWithRawResponse(client));
        _complianceSettings = new(() =>
            new Organization::ComplianceSettingServiceWithRawResponse(client)
        );
        _analytics = new(() => new Organization::AnalyticsServiceWithRawResponse(client));
        _spendLimits = new(() => new Organization::SpendLimitServiceWithRawResponse(client));
        _rbacGroups = new(() => new Organization::RbacGroupServiceWithRawResponse(client));
        _rbacRoles = new(() => new Organization::RbacRoleServiceWithRawResponse(client));
        _plugins = new(() => new Organization::PluginServiceWithRawResponse(client));
        _pluginMarketplaces = new(() =>
            new Organization::PluginMarketplaceServiceWithRawResponse(client)
        );
        _telemetryDestinations = new(() =>
            new Organization::TelemetryDestinationServiceWithRawResponse(client)
        );
        _webhooks = new(() => new Organization::WebhookServiceWithRawResponse(client));
        _claudeTag = new(() => new Organization::ClaudeTagServiceWithRawResponse(client));
    }

    readonly Lazy<Organization::IApiKeyServiceWithRawResponse> _apiKeys;
    public Organization::IApiKeyServiceWithRawResponse ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<Organization::IExternalKeyServiceWithRawResponse> _externalKeys;
    public Organization::IExternalKeyServiceWithRawResponse ExternalKeys
    {
        get { return _externalKeys.Value; }
    }

    readonly Lazy<Organization::IFederationServiceWithRawResponse> _federation;
    public Organization::IFederationServiceWithRawResponse Federation
    {
        get { return _federation.Value; }
    }

    readonly Lazy<Organization::IInviteServiceWithRawResponse> _invites;
    public Organization::IInviteServiceWithRawResponse Invites
    {
        get { return _invites.Value; }
    }

    readonly Lazy<Organization::IServiceAccountServiceWithRawResponse> _serviceAccounts;
    public Organization::IServiceAccountServiceWithRawResponse ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    readonly Lazy<Organization::IUserServiceWithRawResponse> _users;
    public Organization::IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<Organization::IWorkspaceServiceWithRawResponse> _workspaces;
    public Organization::IWorkspaceServiceWithRawResponse Workspaces
    {
        get { return _workspaces.Value; }
    }

    readonly Lazy<Organization::IRateLimitServiceWithRawResponse> _rateLimits;
    public Organization::IRateLimitServiceWithRawResponse RateLimits
    {
        get { return _rateLimits.Value; }
    }

    readonly Lazy<Organization::IComplianceSettingServiceWithRawResponse> _complianceSettings;
    public Organization::IComplianceSettingServiceWithRawResponse ComplianceSettings
    {
        get { return _complianceSettings.Value; }
    }

    readonly Lazy<Organization::IAnalyticsServiceWithRawResponse> _analytics;
    public Organization::IAnalyticsServiceWithRawResponse Analytics
    {
        get { return _analytics.Value; }
    }

    readonly Lazy<Organization::ISpendLimitServiceWithRawResponse> _spendLimits;
    public Organization::ISpendLimitServiceWithRawResponse SpendLimits
    {
        get { return _spendLimits.Value; }
    }

    readonly Lazy<Organization::IRbacGroupServiceWithRawResponse> _rbacGroups;
    public Organization::IRbacGroupServiceWithRawResponse RbacGroups
    {
        get { return _rbacGroups.Value; }
    }

    readonly Lazy<Organization::IRbacRoleServiceWithRawResponse> _rbacRoles;
    public Organization::IRbacRoleServiceWithRawResponse RbacRoles
    {
        get { return _rbacRoles.Value; }
    }

    readonly Lazy<Organization::IPluginServiceWithRawResponse> _plugins;
    public Organization::IPluginServiceWithRawResponse Plugins
    {
        get { return _plugins.Value; }
    }

    readonly Lazy<Organization::IPluginMarketplaceServiceWithRawResponse> _pluginMarketplaces;
    public Organization::IPluginMarketplaceServiceWithRawResponse PluginMarketplaces
    {
        get { return _pluginMarketplaces.Value; }
    }

    readonly Lazy<Organization::ITelemetryDestinationServiceWithRawResponse> _telemetryDestinations;
    public Organization::ITelemetryDestinationServiceWithRawResponse TelemetryDestinations
    {
        get { return _telemetryDestinations.Value; }
    }

    readonly Lazy<Organization::IWebhookServiceWithRawResponse> _webhooks;
    public Organization::IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<Organization::IClaudeTagServiceWithRawResponse> _claudeTag;
    public Organization::IClaudeTagServiceWithRawResponse ClaudeTag
    {
        get { return _claudeTag.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaOrganization>> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OrganizationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.retrieve",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaOrganization = await response
                    .Deserialize<BetaOrganization>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaOrganization.Validate();
                }
                return betaOrganization;
            }
        );
    }
}
