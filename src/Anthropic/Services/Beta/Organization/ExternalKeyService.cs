using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ExternalKeyService : IExternalKeyService
{
    readonly Lazy<IExternalKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalKeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IExternalKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalKeyService(this._client.WithOptions(modifier));
    }

    public ExternalKeyService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExternalKeyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaExternalKey> Create(
        ExternalKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaExternalKey> Retrieve(
        ExternalKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaExternalKey> Retrieve(
        string externalKeyID,
        ExternalKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaExternalKey> Update(
        ExternalKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaExternalKey> Update(
        string externalKeyID,
        ExternalKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalKeyListPage> List(
        ExternalKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExternalKeyDeleteResponse> Delete(
        ExternalKeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExternalKeyDeleteResponse> Delete(
        string externalKeyID,
        ExternalKeyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalKeyValidateResponse> Validate(
        ExternalKeyValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Validate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExternalKeyValidateResponse> Validate(
        string externalKeyID,
        ExternalKeyValidateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Validate(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExternalKeyServiceWithRawResponse : IExternalKeyServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalKeyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalKeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalKeyServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalKey>> Create(
        ExternalKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalKeyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalKey = await response
                    .Deserialize<BetaExternalKey>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalKey.Validate();
                }
                return betaExternalKey;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalKey>> Retrieve(
        ExternalKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ExternalKeyID' cannot be null");
        }

        HttpRequest<ExternalKeyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalKey = await response
                    .Deserialize<BetaExternalKey>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalKey.Validate();
                }
                return betaExternalKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaExternalKey>> Retrieve(
        string externalKeyID,
        ExternalKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalKey>> Update(
        ExternalKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ExternalKeyID' cannot be null");
        }

        HttpRequest<ExternalKeyUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalKey = await response
                    .Deserialize<BetaExternalKey>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalKey.Validate();
                }
                return betaExternalKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaExternalKey>> Update(
        string externalKeyID,
        ExternalKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalKeyListPage>> List(
        ExternalKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExternalKeyListParams> request = new()
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
                    .Deserialize<ExternalKeyListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExternalKeyListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalKeyDeleteResponse>> Delete(
        ExternalKeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ExternalKeyID' cannot be null");
        }

        HttpRequest<ExternalKeyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var externalKey = await response
                    .Deserialize<ExternalKeyDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    externalKey.Validate();
                }
                return externalKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExternalKeyDeleteResponse>> Delete(
        string externalKeyID,
        ExternalKeyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalKeyValidateResponse>> Validate(
        ExternalKeyValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalKeyID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ExternalKeyID' cannot be null");
        }

        HttpRequest<ExternalKeyValidateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ExternalKeyValidateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExternalKeyValidateResponse>> Validate(
        string externalKeyID,
        ExternalKeyValidateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Validate(parameters with { ExternalKeyID = externalKeyID }, cancellationToken);
    }
}
