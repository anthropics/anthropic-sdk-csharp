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
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

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
        var message = await response.Deserialize<Message>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            message.Validate();
        }
        return message;
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
            var deserializedMessage = message.Deserialize<RawMessageStreamEvent>();
            if (this._client.ResponseValidation)
            {
                deserializedMessage.Validate();
            }
            yield return deserializedMessage;
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
        var messageTokensCount = await response
            .Deserialize<MessageTokensCount>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageTokensCount.Validate();
        }
        return messageTokensCount;
    }
}
