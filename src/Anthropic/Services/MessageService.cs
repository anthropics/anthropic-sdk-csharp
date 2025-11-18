using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Messages;
using Anthropic.Services.Messages;

namespace Anthropic.Services;

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

    public async Task<Message> Create(
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
        var message = await response.Deserialize<Message>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            message.Validate();
        }
        return message;
    }

    public async IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
#if NET5_0_OR_GREATER
        Dictionary<string, JsonElement> bodyProperties = new(parameters.BodyProperties)
        {
            ["stream"] = JsonSerializer.Deserialize<JsonElement>("true"),
        };
#else
        var bodyProperties = parameters.BodyProperties.ToDictionary(e => e.Key, e => e.Value);
        bodyProperties["stream"] = JsonSerializer.Deserialize<JsonElement>("true");
#endif
        parameters = MessageCreateParams.FromRawUnchecked(
            parameters.HeaderProperties,
            parameters.QueryProperties,
            bodyProperties
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
            var deserializedMessage = message.Deserialize<RawMessageStreamEvent>();
            if (this._client.ResponseValidation)
            {
                deserializedMessage.Validate();
            }
            yield return deserializedMessage;
        }
    }

    public async Task<MessageTokensCount> CountTokens(
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
        var messageTokensCount = await response
            .Deserialize<MessageTokensCount>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageTokensCount.Validate();
        }
        return messageTokensCount;
    }
}
