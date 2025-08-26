using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Beta.Client.Models.Models;

namespace Anthropic.Beta.Client.Services.Models;

public sealed class ModelService : IModelService
{
    readonly IAnthropicClient _client;

    public ModelService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<ModelInfo> Retrieve(ModelRetrieveParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ModelInfo>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<ModelListPageResponse> List(ModelListParams? parameters = null)
    {
        parameters ??= new();

        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ModelListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
