using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Models;

namespace Anthropic.Client.Services.Beta.Models;

public sealed class ModelService : IModelService
{
    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<BetaModelInfo> Retrieve(ModelRetrieveParams parameters)
    {
        HttpRequest<ModelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaModelInfo = await response.Deserialize<BetaModelInfo>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaModelInfo.Validate();
        }
        return betaModelInfo;
    }

    public async Task<ModelListPageResponse> List(ModelListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ModelListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<ModelListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
