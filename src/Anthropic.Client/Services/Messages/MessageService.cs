using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Services.Messages.Batches;

namespace Anthropic.Client.Services.Messages;

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
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Message>().ConfigureAwait(false);
    }

    public async IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters
    )
    {
        parameters.BodyProperties["stream"] = JsonSerializer.Deserialize<JsonElement>("true");
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message))
        {
            yield return message.MessageDeserializeMethod<RawMessageStreamEvent>();
        }
    }

    public async Task<MessageTokensCount> CountTokens(MessageCountTokensParams parameters)
    {
        HttpRequest<MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<MessageTokensCount>().ConfigureAwait(false);
    }
}
