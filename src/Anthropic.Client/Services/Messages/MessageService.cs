using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Services.Messages.Batches;
using Messages = Anthropic.Client.Models.Messages;

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

    public async Task<Messages::Message> Create(Messages::MessageCreateParams parameters)
    {
        HttpRequest<Messages::MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var message = await response.Deserialize<Messages::Message>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            message.Validate();
        }
        return message;
    }

    public async IAsyncEnumerable<Messages::RawMessageStreamEvent> CreateStreaming(
        Messages::MessageCreateParams parameters
    )
    {
        parameters.BodyProperties["stream"] = JsonSerializer.Deserialize<JsonElement>("true");
        HttpRequest<Messages::MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message))
        {
            var deserializedMessage = message.Deserialize<Messages::RawMessageStreamEvent>();
            if (this._client.ResponseValidation)
            {
                deserializedMessage.Validate();
            }
            yield return deserializedMessage;
        }
    }

    public async Task<Messages::MessageTokensCount> CountTokens(
        Messages::MessageCountTokensParams parameters
    )
    {
        HttpRequest<Messages::MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messageTokensCount = await response
            .Deserialize<Messages::MessageTokensCount>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageTokensCount.Validate();
        }
        return messageTokensCount;
    }
}
