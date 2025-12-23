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

/// <inheritdoc/>
public sealed class MessageService : IMessageService
{
    /// <inheritdoc/>
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
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
        // Note: We use try-finally instead of 'using' to ensure the response is not disposed
        // before the IAsyncEnumerable is fully consumed. With 'using', the response would be
        // disposed when the method returns the IAsyncEnumerable, not when iteration completes.
        // See: https://github.com/anthropics/anthropic-sdk-csharp/issues/80
        var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout = options.Timeout ?? TimeSpan.FromMinutes(10),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);
        try
        {
            await foreach (
                var message in Sse.Enumerate<RawMessageStreamEvent>(response.Message, cancellationToken)
            )
            {
                if (this._client.ResponseValidation)
                {
                    message.Validate();
                }
                yield return message;
            }
        }
        finally
        {
            response.Dispose();
        }
    }

    /// <inheritdoc/>
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
