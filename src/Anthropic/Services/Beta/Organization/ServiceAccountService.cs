using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ServiceAccounts;
using ServiceAccounts = Anthropic.Services.Beta.Organization.ServiceAccounts;

namespace Anthropic.Services.Beta.Organization;

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
        _workspaces = new(() => new ServiceAccounts::WorkspaceService(client));
    }

    readonly Lazy<ServiceAccounts::IWorkspaceService> _workspaces;
    public ServiceAccounts::IWorkspaceService Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaServiceAccount> Create(
        ServiceAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaServiceAccount> Retrieve(
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
    public Task<BetaServiceAccount> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaServiceAccount> Update(
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
    public Task<BetaServiceAccount> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaServiceAccount> Archive(
        ServiceAccountArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaServiceAccount> Archive(
        string serviceAccountID,
        ServiceAccountArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
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

        _workspaces = new(() => new ServiceAccounts::WorkspaceServiceWithRawResponse(client));
    }

    readonly Lazy<ServiceAccounts::IWorkspaceServiceWithRawResponse> _workspaces;
    public ServiceAccounts::IWorkspaceServiceWithRawResponse Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaServiceAccount>> Create(
        ServiceAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ServiceAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaServiceAccount = await response
                    .Deserialize<BetaServiceAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccount.Validate();
                }
                return betaServiceAccount;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaServiceAccount>> Retrieve(
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
                var betaServiceAccount = await response
                    .Deserialize<BetaServiceAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccount.Validate();
                }
                return betaServiceAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaServiceAccount>> Retrieve(
        string serviceAccountID,
        ServiceAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaServiceAccount>> Update(
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
                var betaServiceAccount = await response
                    .Deserialize<BetaServiceAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccount.Validate();
                }
                return betaServiceAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaServiceAccount>> Update(
        string serviceAccountID,
        ServiceAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
        ServiceAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
    public async Task<HttpResponse<BetaServiceAccount>> Archive(
        ServiceAccountArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ServiceAccountID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ServiceAccountID' cannot be null");
        }

        HttpRequest<ServiceAccountArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaServiceAccount = await response
                    .Deserialize<BetaServiceAccount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaServiceAccount.Validate();
                }
                return betaServiceAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaServiceAccount>> Archive(
        string serviceAccountID,
        ServiceAccountArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                ServiceAccountID = serviceAccountID,
            },
            cancellationToken
        );
    }
}
