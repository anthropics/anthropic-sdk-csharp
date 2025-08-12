using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Messages.Batches;
using Anthropic = Anthropic;

namespace Anthropic.Services.Messages.Batches;

public sealed class BatchService : IBatchService
{
    readonly Anthropic::IAnthropicClient _client;

    public BatchService(Anthropic::IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<MessageBatch> Create(BatchCreateParams parameters)
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

        return JsonSerializer.Deserialize<MessageBatch>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<MessageBatch> Retrieve(BatchRetrieveParams parameters)
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

        return JsonSerializer.Deserialize<MessageBatch>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<BatchListPageResponse> List(BatchListParams parameters)
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

        return JsonSerializer.Deserialize<BatchListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DeletedMessageBatch> Delete(BatchDeleteParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, parameters.Url(this._client));
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

        return JsonSerializer.Deserialize<DeletedMessageBatch>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<MessageBatch> Cancel(BatchCancelParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client));
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

        return JsonSerializer.Deserialize<MessageBatch>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters
    )
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

        await foreach (var message in Anthropic::SseMessage.GetEnumerable(response))
        {
            yield return JsonSerializer.Deserialize<MessageBatchIndividualResponse>(
                message.Data,
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
        }
    }
}
