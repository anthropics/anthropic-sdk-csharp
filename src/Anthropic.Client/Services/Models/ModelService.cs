using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Models;

namespace Anthropic.Client.Services.Models;

public sealed class ModelService : IModelService
{
    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<ModelInfo> Retrieve(ModelRetrieveParams parameters)
    {
        HttpRequest<ModelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ModelInfo>().ConfigureAwait(false);
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
        return await response.Deserialize<ModelListPageResponse>().ConfigureAwait(false);
    }
}
