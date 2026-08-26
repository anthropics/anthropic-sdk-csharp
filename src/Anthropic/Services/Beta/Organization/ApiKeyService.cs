using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ApiKeys;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ApiKeyService : IApiKeyService
{
    readonly Lazy<IApiKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyService(this._client.WithOptions(modifier));
    }

    public ApiKeyService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ApiKeyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaApiKey> Retrieve(
        ApiKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaApiKey> Retrieve(
        string apiKeyID,
        ApiKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ApiKeyID = apiKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaApiKey> Update(
        ApiKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaApiKey> Update(
        string apiKeyID,
        ApiKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ApiKeyID = apiKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiKeyListPage> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ApiKeyServiceWithRawResponse : IApiKeyServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ApiKeyServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaApiKey>> Retrieve(
        ApiKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ApiKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ApiKeyID' cannot be null");
        }

        HttpRequest<ApiKeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaApiKey = await response
                    .Deserialize<BetaApiKey>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaApiKey.Validate();
                }
                return betaApiKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaApiKey>> Retrieve(
        string apiKeyID,
        ApiKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ApiKeyID = apiKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaApiKey>> Update(
        ApiKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ApiKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ApiKeyID' cannot be null");
        }

        HttpRequest<ApiKeyUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaApiKey = await response
                    .Deserialize<BetaApiKey>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaApiKey.Validate();
                }
                return betaApiKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaApiKey>> Update(
        string apiKeyID,
        ApiKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ApiKeyID = apiKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyListPage>> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ApiKeyListParams> request = new()
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
                    .Deserialize<ApiKeyListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ApiKeyListPage(this, parameters, page);
            }
        );
    }
}
