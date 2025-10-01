using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Messages;
using Anthropic.Client.Services.Beta.Messages.Batches;

namespace Anthropic.Client.Services.Beta.Messages;

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

    public async Task<BetaMessage> Create(MessageCreateParams parameters)
    {
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BetaMessage>().ConfigureAwait(false);
    }

    public async IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(
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
            yield return message.MessageDeserializeMethod<BetaRawMessageStreamEvent>();
        }
    }

    public async Task<BetaMessageTokensCount> CountTokens(MessageCountTokensParams parameters)
    {
        HttpRequest<MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BetaMessageTokensCount>().ConfigureAwait(false);
    }
}
