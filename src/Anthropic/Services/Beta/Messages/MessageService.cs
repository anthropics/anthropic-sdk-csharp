using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Anthropic = Anthropic;
using Batches = Anthropic.Services.Beta.Messages.Batches;

namespace Anthropic.Services.Beta.Messages;

public sealed class MessageService : IMessageService
{
    readonly Anthropic::IAnthropicClient _client;

    public MessageService(Anthropic::IAnthropicClient client)
    {
        _client = client;
        _batches = new(() => new Batches::BatchService(client));
    }

    readonly Lazy<Batches::IBatchService> _batches;
    public Batches::IBatchService Batches
    {
        get { return _batches.Value; }
    }

    public async Task<BetaMessage> Create(MessageCreateParams parameters)
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

        return JsonSerializer.Deserialize<BetaMessage>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(
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
            throw new Anthropic::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        await foreach (var message in Anthropic::SseMessage.GetEnumerable(response))
        {
            yield return JsonSerializer.Deserialize<BetaRawMessageStreamEvent>(
                message.Data,
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
        }
    }

    public async Task<BetaMessageTokensCount> CountTokens(MessageCountTokensParams parameters)
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

        return JsonSerializer.Deserialize<BetaMessageTokensCount>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                Anthropic::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
