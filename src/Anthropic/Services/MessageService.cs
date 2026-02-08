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
    readonly Lazy<IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    internal readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

    public MessageService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MessageServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var message in response.Enumerate(cancellationToken))
        {
            yield return message;
        }
    }

    /// <inheritdoc/>
    public async Task<MessageTokensCount> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CountTokens(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessageServiceWithRawResponse : IMessageServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessageServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _batches = new(() => new BatchServiceWithRawResponse(client));
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batches;
    public IBatchServiceWithRawResponse Batches
    {
        get { return _batches.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Message>> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout =
                        options.Timeout
                        ?? ClientOptions.TimeoutFromMaxTokens(
                            parameters.MaxTokens,
                            isStreaming: false,
                            parameters.Model
                        ),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var message = await response.Deserialize<Message>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    message.Validate();
                }
                return message;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<RawMessageStreamEvent>> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawBodyData["stream"] = JsonSerializer.SerializeToElement(true);
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
        var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout =
                        options.Timeout
                        ?? ClientOptions.TimeoutFromMaxTokens(
                            parameters.MaxTokens,
                            isStreaming: true,
                            parameters.Model
                        ),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);

        async IAsyncEnumerable<RawMessageStreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var message in Sse.Enumerate<RawMessageStreamEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    message.Validate();
                }
                yield return message;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageTokensCount>> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messageTokensCount = await response
                    .Deserialize<MessageTokensCount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messageTokensCount.Validate();
                }
                return messageTokensCount;
            }
        );
    }
}
