using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Services.Beta.Vaults;

/// <inheritdoc/>
public sealed class CredentialService : ICredentialService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<ICredentialServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICredentialServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ICredentialService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CredentialService(this._client.WithOptions(modifier));
    }

    public CredentialService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CredentialServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsCredential> Create(
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsCredential> Create(
        string vaultID,
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsCredential> Retrieve(
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsCredential> Retrieve(
        string credentialID,
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsCredential> Update(
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsCredential> Update(
        string credentialID,
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CredentialListPage> List(
        CredentialListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CredentialListPage> List(
        string vaultID,
        CredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeletedCredential> Delete(
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeletedCredential> Delete(
        string credentialID,
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsCredential> Archive(
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsCredential> Archive(
        string credentialID,
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { CredentialID = credentialID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CredentialServiceWithRawResponse : ICredentialServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CredentialServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CredentialServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsCredential>> Create(
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<CredentialCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsCredential = await response
                    .Deserialize<BetaManagedAgentsCredential>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsCredential.Validate();
                }
                return betaManagedAgentsCredential;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsCredential>> Create(
        string vaultID,
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsCredential>> Retrieve(
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CredentialID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CredentialID' cannot be null");
        }

        HttpRequest<CredentialRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsCredential = await response
                    .Deserialize<BetaManagedAgentsCredential>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsCredential.Validate();
                }
                return betaManagedAgentsCredential;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsCredential>> Retrieve(
        string credentialID,
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsCredential>> Update(
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CredentialID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CredentialID' cannot be null");
        }

        HttpRequest<CredentialUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsCredential = await response
                    .Deserialize<BetaManagedAgentsCredential>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsCredential.Validate();
                }
                return betaManagedAgentsCredential;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsCredential>> Update(
        string credentialID,
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialListPage>> List(
        CredentialListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VaultID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.VaultID' cannot be null");
        }

        HttpRequest<CredentialListParams> request = new()
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
                    .Deserialize<CredentialListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CredentialListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CredentialListPage>> List(
        string vaultID,
        CredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { VaultID = vaultID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeletedCredential>> Delete(
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CredentialID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CredentialID' cannot be null");
        }

        HttpRequest<CredentialDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeletedCredential = await response
                    .Deserialize<BetaManagedAgentsDeletedCredential>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeletedCredential.Validate();
                }
                return betaManagedAgentsDeletedCredential;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeletedCredential>> Delete(
        string credentialID,
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { CredentialID = credentialID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsCredential>> Archive(
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CredentialID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CredentialID' cannot be null");
        }

        HttpRequest<CredentialArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsCredential = await response
                    .Deserialize<BetaManagedAgentsCredential>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsCredential.Validate();
                }
                return betaManagedAgentsCredential;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsCredential>> Archive(
        string credentialID,
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { CredentialID = credentialID }, cancellationToken);
    }
}
