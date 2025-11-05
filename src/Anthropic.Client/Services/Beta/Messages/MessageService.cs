using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Services.Beta.Messages.Batches;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Services.Beta.Messages;

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

    public async Task<Messages::BetaMessage> Create(Messages::MessageCreateParams parameters)
    {
        HttpRequest<Messages::MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaMessage = await response.Deserialize<Messages::BetaMessage>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessage.Validate();
        }
        return betaMessage;
    }

    public async IAsyncEnumerable<Messages::BetaRawMessageStreamEvent> CreateStreaming(
        Messages::MessageCreateParams parameters
    )
    {
        Dictionary<string, JsonElement> bodyProperties = new(parameters.BodyProperties)
        {
            ["stream"] = JsonSerializer.Deserialize<JsonElement>("true"),
        };
        parameters = Messages::MessageCreateParams.FromRawUnchecked(
            parameters.HeaderProperties,
            parameters.QueryProperties,
            bodyProperties
        );
        HttpRequest<Messages::MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message))
        {
            var betaMessage = message.Deserialize<Messages::BetaRawMessageStreamEvent>();
            if (this._client.ResponseValidation)
            {
                betaMessage.Validate();
            }
            yield return betaMessage;
        }
    }

    public async Task<Messages::BetaMessageTokensCount> CountTokens(
        Messages::MessageCountTokensParams parameters
    )
    {
        HttpRequest<Messages::MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaMessageTokensCount = await response
            .Deserialize<Messages::BetaMessageTokensCount>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageTokensCount.Validate();
        }
        return betaMessageTokensCount;
    }
}
