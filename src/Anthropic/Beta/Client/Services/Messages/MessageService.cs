using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Beta.Client.Models.Messages;
using Anthropic.Beta.Client.Services.Messages.Batches;

namespace Anthropic.Beta.Client.Services.Messages;

public sealed class MessageService : IMessageService
{
    readonly IAnthropicClient _client;

    public MessageService(IAnthropicClient client)
    {
        _client = client;
        _batches = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batches;
    public IBatchService Batches
    {
        get { return _batches.Value; }
    }

    public async Task<Message> Create(MessageCreateParams parameters)
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
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Message>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters
    )
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
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        await foreach (var message in SseMessage.GetEnumerable(response))
        {
            yield return JsonSerializer.Deserialize<RawMessageStreamEvent>(
                message.Data,
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
        }
    }

    public async Task<MessageTokensCount> CountTokens(MessageCountTokensParams parameters)
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
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<MessageTokensCount>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
