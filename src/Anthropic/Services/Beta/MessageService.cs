using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta.Messages;

namespace Anthropic.Services.Beta;

public sealed class MessageService : global::Anthropic.Services.Beta.IMessageService
{
    public global::Anthropic.Services.Beta.IMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Anthropic.Services.Beta.MessageService(
            this._client.WithOptions(modifier)
        );
    }

    internal readonly IAnthropicClient _client;

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

    public async Task<BetaMessage> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout = options.Timeout ?? TimeSpan.FromMinutes(10),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaMessage = await response
            .DeserializeAsync<BetaMessage>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessage.Validate();
        }
        return betaMessage;
    }

    public async IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var rawBodyData = Enumerable.ToDictionary(parameters.RawBodyData, e => e.Key, e => e.Value);
        rawBodyData["stream"] = JsonSerializer.Deserialize<JsonElement>("true");
        parameters = MessageCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );

        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout = options.Timeout ?? TimeSpan.FromMinutes(10),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message, cancellationToken))
        {
            var betaMessage = message.Deserialize<BetaRawMessageStreamEvent>();
            if (this._client.ResponseValidation)
            {
                betaMessage.Validate();
            }
            yield return betaMessage;
        }
    }

    public async Task<BetaMessageTokensCount> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaMessageTokensCount = await response
            .DeserializeAsync<BetaMessageTokensCount>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageTokensCount.Validate();
        }
        return betaMessageTokensCount;
    }
}
