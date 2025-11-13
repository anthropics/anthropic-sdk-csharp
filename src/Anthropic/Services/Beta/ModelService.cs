using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Services.Beta;

public sealed class ModelService : global::Anthropic.Services.Beta.IModelService
{
    public global::Anthropic.Services.Beta.IModelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Anthropic.Services.Beta.ModelService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<BetaModelInfo> Retrieve(
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
        var betaModelInfo = await response
            .Deserialize<BetaModelInfo>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaModelInfo.Validate();
        }
        return betaModelInfo;
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
