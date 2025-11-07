using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Models;

namespace Anthropic.Client.Services.Models;

public sealed class ModelService : IModelService
{
    public IModelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ModelService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<ModelInfo> Retrieve(
        ModelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<ModelListPageResponse> List(
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
        return page;
    }
}
