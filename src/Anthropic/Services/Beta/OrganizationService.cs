using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Anthropic.Services.Beta.Organization;

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
        _apiKeys = new(() => new ApiKeyService(client));
        _externalKeys = new(() => new ExternalKeyService(client));
        _federation = new(() => new FederationService(client));
        _invites = new(() => new InviteService(client));
        _serviceAccounts = new(() => new ServiceAccountService(client));
        _users = new(() => new UserService(client));
        _workspaces = new(() => new WorkspaceService(client));
        _rateLimits = new(() => new RateLimitService(client));
    }

    readonly Lazy<IApiKeyService> _apiKeys;
    public IApiKeyService ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<IExternalKeyService> _externalKeys;
    public IExternalKeyService ExternalKeys
    {
        get { return _externalKeys.Value; }
    }

    readonly Lazy<IFederationService> _federation;
    public IFederationService Federation
    {
        get { return _federation.Value; }
    }

    readonly Lazy<IInviteService> _invites;
    public IInviteService Invites
    {
        get { return _invites.Value; }
    }

    readonly Lazy<IServiceAccountService> _serviceAccounts;
    public IServiceAccountService ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<IWorkspaceService> _workspaces;
    public IWorkspaceService Workspaces
    {
        get { return _workspaces.Value; }
    }

    readonly Lazy<IRateLimitService> _rateLimits;
    public IRateLimitService RateLimits
    {
        get { return _rateLimits.Value; }
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

        _apiKeys = new(() => new ApiKeyServiceWithRawResponse(client));
        _externalKeys = new(() => new ExternalKeyServiceWithRawResponse(client));
        _federation = new(() => new FederationServiceWithRawResponse(client));
        _invites = new(() => new InviteServiceWithRawResponse(client));
        _serviceAccounts = new(() => new ServiceAccountServiceWithRawResponse(client));
        _users = new(() => new UserServiceWithRawResponse(client));
        _workspaces = new(() => new WorkspaceServiceWithRawResponse(client));
        _rateLimits = new(() => new RateLimitServiceWithRawResponse(client));
    }

    readonly Lazy<IApiKeyServiceWithRawResponse> _apiKeys;
    public IApiKeyServiceWithRawResponse ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    readonly Lazy<IExternalKeyServiceWithRawResponse> _externalKeys;
    public IExternalKeyServiceWithRawResponse ExternalKeys
    {
        get { return _externalKeys.Value; }
    }

    readonly Lazy<IFederationServiceWithRawResponse> _federation;
    public IFederationServiceWithRawResponse Federation
    {
        get { return _federation.Value; }
    }

    readonly Lazy<IInviteServiceWithRawResponse> _invites;
    public IInviteServiceWithRawResponse Invites
    {
        get { return _invites.Value; }
    }

    readonly Lazy<IServiceAccountServiceWithRawResponse> _serviceAccounts;
    public IServiceAccountServiceWithRawResponse ServiceAccounts
    {
        get { return _serviceAccounts.Value; }
    }

    readonly Lazy<IUserServiceWithRawResponse> _users;
    public IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<IWorkspaceServiceWithRawResponse> _workspaces;
    public IWorkspaceServiceWithRawResponse Workspaces
    {
        get { return _workspaces.Value; }
    }

    readonly Lazy<IRateLimitServiceWithRawResponse> _rateLimits;
    public IRateLimitServiceWithRawResponse RateLimits
    {
        get { return _rateLimits.Value; }
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
