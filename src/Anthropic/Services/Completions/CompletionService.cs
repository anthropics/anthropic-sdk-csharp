using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Completions;
using Anthropic = Anthropic;

namespace Anthropic.Services.Completions;

public sealed class CompletionService : ICompletionService
{
    readonly Anthropic::IAnthropicClient _client;

    public CompletionService(Anthropic::IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<Completion> Create(CompletionCreateParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
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

        return JsonSerializer.Deserialize<Completion>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async IAsyncEnumerable<Completion> CreateStreaming(CompletionCreateParams parameters)
    {
        parameters.BodyProperties["stream"] = JsonSerializer.Deserialize<JsonElement>("true");
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
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

        await foreach (var message in Anthropic::SseMessage.GetEnumerable(response))
        {
            yield return JsonSerializer.Deserialize<Completion>(
                message.Data,
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
        }
    }
}
