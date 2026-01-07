using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Models;

namespace Anthropic.Services;

/// <inheritdoc/>
public sealed class ModelService : IModelService
{
    /// <inheritdoc/>
    public IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ModelInfo> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var modelInfo = await response
            .Deserialize<ModelInfo>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            modelInfo.Validate();
        }
        return modelInfo;
    }

    /// <inheritdoc/>
    public async Task<ModelInfo> Retrieve(
        string modelID,
        ModelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ModelID = modelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ModelListPage> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ModelListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new ModelListPage(this, parameters, page);
    }
}
