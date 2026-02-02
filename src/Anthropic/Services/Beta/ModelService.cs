using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class ModelService : IModelService
{
    readonly Lazy<IModelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IModelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelService(this._client.WithOptions(modifier));
    }

    public ModelService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ModelServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaModelInfo> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaModelInfo> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ModelID = modelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ModelListPage> List(
        ModelListParams? parameters = null,
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
public sealed class ModelServiceWithRawResponse : IModelServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IModelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ModelServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaModelInfo>> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ModelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ModelID' cannot be null");
        }

        HttpRequest<ModelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaModelInfo = await response
                    .Deserialize<BetaModelInfo>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaModelInfo.Validate();
                }
                return betaModelInfo;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaModelInfo>> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ModelID = modelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ModelListPage>> List(
        ModelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ModelListParams> request = new()
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
                    .Deserialize<ModelListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ModelListPage(this, parameters, page);
            }
        );
    }
}
