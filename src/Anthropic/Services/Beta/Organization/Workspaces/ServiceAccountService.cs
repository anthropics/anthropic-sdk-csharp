using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;
using ServiceAccounts = Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Services.Beta.Organization.Workspaces;

/// <inheritdoc/>
public sealed class ServiceAccountService : IServiceAccountService
{
    readonly Lazy<IServiceAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IServiceAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IServiceAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ServiceAccountService(this._client.WithOptions(modifier));
    }

    public ServiceAccountService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ServiceAccountServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ServiceAccountListPage> List(
        ServiceAccountListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ServiceAccountListPage> List(
        string workspaceID,
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Add(
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ServiceAccounts::BetaServiceAccountWorkspaceMember> Add(
        string workspaceID,
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ServiceAccountRemoveResponse> Remove(
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ServiceAccountRemoveResponse> Remove(
        string serviceAccountID,
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ServiceAccountServiceWithRawResponse : IServiceAccountServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IServiceAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ServiceAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ServiceAccountServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Retrieve(
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ServiceAccountID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ServiceAccountID' cannot be null");
        }

        HttpRequest<ServiceAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaServiceAccountWorkspaceMember = await response
                    .Deserialize<ServiceAccounts::BetaServiceAccountWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccountWorkspaceMember.Validate();
                }
                return betaServiceAccountWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Update(
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ServiceAccountID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ServiceAccountID' cannot be null");
        }

        HttpRequest<ServiceAccountUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaServiceAccountWorkspaceMember = await response
                    .Deserialize<ServiceAccounts::BetaServiceAccountWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccountWorkspaceMember.Validate();
                }
                return betaServiceAccountWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ServiceAccountListPage>> List(
        ServiceAccountListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<ServiceAccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ServiceAccountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ServiceAccountListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ServiceAccountListPage>> List(
        string workspaceID,
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Add(
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<ServiceAccountAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaServiceAccountWorkspaceMember = await response
                    .Deserialize<ServiceAccounts::BetaServiceAccountWorkspaceMember>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccountWorkspaceMember.Validate();
                }
                return betaServiceAccountWorkspaceMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ServiceAccounts::BetaServiceAccountWorkspaceMember>> Add(
        string workspaceID,
        ServiceAccountAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ServiceAccountRemoveResponse>> Remove(
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ServiceAccountID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ServiceAccountID' cannot be null");
        }

        HttpRequest<ServiceAccountRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var serviceAccount = await response
                    .Deserialize<ServiceAccountRemoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    serviceAccount.Validate();
                }
                return serviceAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ServiceAccountRemoveResponse>> Remove(
        string serviceAccountID,
        ServiceAccountRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }
}
