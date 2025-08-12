using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Models;
using Anthropic = Anthropic;

namespace Anthropic.Services.Models;

public sealed class ModelService : IModelService
{
    readonly Anthropic::IAnthropicClient _client;

    public ModelService(Anthropic::IAnthropicClient client)
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
            throw new Anthropic::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ModelInfo>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<ModelListPageResponse> List(ModelListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Anthropic::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<ModelListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
