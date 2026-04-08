using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults;
using Anthropic.Services.Beta.Vaults;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class VaultService : IVaultService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IVaultServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVaultServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IVaultService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VaultService(this._client.WithOptions(modifier));
    }

    public VaultService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VaultServiceWithRawResponse(client.WithRawResponse));
        _credentials = new(() => new CredentialService(client));
    }

    readonly Lazy<ICredentialService> _credentials;
    public ICredentialService Credentials
    {
        get { return _credentials.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsVault> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsVault> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsVault> Retrieve(
        string vaultID,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsVault> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsVault> Update(
        string vaultID,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VaultListPage> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeletedVault> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeletedVault> Delete(
        string vaultID,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsVault> Archive(
        VaultArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsVault> Archive(
        string vaultID,
        VaultArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { VaultID = vaultID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VaultServiceWithRawResponse : IVaultServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVaultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VaultServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VaultServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _credentials = new(() => new CredentialServiceWithRawResponse(client));
    }

    readonly Lazy<ICredentialServiceWithRawResponse> _credentials;
    public ICredentialServiceWithRawResponse Credentials
    {
        get { return _credentials.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsVault>> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VaultCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsVault = await response
                    .Deserialize<BetaManagedAgentsVault>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsVault.Validate();
                }
                return betaManagedAgentsVault;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsVault>> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<VaultRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsVault = await response
                    .Deserialize<BetaManagedAgentsVault>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsVault.Validate();
                }
                return betaManagedAgentsVault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsVault>> Retrieve(
        string vaultID,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsVault>> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<VaultUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsVault = await response
                    .Deserialize<BetaManagedAgentsVault>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsVault.Validate();
                }
                return betaManagedAgentsVault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsVault>> Update(
        string vaultID,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VaultListPage>> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VaultListParams> request = new()
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
                    .Deserialize<VaultListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new VaultListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeletedVault>> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<VaultDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeletedVault = await response
                    .Deserialize<BetaManagedAgentsDeletedVault>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeletedVault.Validate();
                }
                return betaManagedAgentsDeletedVault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeletedVault>> Delete(
        string vaultID,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsVault>> Archive(
        VaultArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<VaultArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsVault = await response
                    .Deserialize<BetaManagedAgentsVault>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsVault.Validate();
                }
                return betaManagedAgentsVault;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsVault>> Archive(
        string vaultID,
        VaultArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { VaultID = vaultID }, cancellationToken);
    }
}
