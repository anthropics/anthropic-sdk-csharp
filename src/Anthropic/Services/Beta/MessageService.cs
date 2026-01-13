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

/// <inheritdoc/>
public sealed class MessageService : global::Anthropic.Services.Beta.IMessageService
{
    readonly Lazy<global::Anthropic.Services.Beta.IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::Anthropic.Services.Beta.IMessageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    internal readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public global::Anthropic.Services.Beta.IMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Anthropic.Services.Beta.MessageService(
            this._client.WithOptions(modifier)
        );
    }

    public MessageService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::Anthropic.Services.Beta.MessageServiceWithRawResponse(
                client.WithRawResponse
            )
        );
        _batches = new(() => new BatchService(client));
    }

    readonly Lazy<IBatchService> _batches;
    public IBatchService Batches
    {
        get { return _batches.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaMessage> Create(
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
    public async IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var betaMessage in response.Enumerate(cancellationToken))
        {
            yield return betaMessage;
        }
    }

    /// <inheritdoc/>
    public async Task<BetaMessageTokensCount> CountTokens(
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
public sealed class MessageServiceWithRawResponse
    : global::Anthropic.Services.Beta.IMessageServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::Anthropic.Services.Beta.IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Anthropic.Services.Beta.MessageServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
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
    public async Task<HttpResponse<BetaMessage>> Create(
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
                    Timeout = options.Timeout ?? TimeSpan.FromMinutes(10),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaMessage = await response
                    .Deserialize<BetaMessage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaMessage.Validate();
                }
                return betaMessage;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<BetaRawMessageStreamEvent>> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        var rawBodyData = Enumerable.ToDictionary(
            parameters.RawBodyData,
            (e) => e.Key,
            (e) => e.Value
        );
        ;
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
        var response = await this
            ._client.WithOptions(options =>
                options with
                {
                    Timeout = options.Timeout ?? TimeSpan.FromMinutes(10),
                }
            )
            .Execute(request, cancellationToken)
            .ConfigureAwait(false);

        async IAsyncEnumerable<BetaRawMessageStreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var betaMessage in Sse.Enumerate<BetaRawMessageStreamEvent>(response.Message, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    betaMessage.Validate();
                }
                yield return betaMessage;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaMessageTokensCount>> CountTokens(
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
                var betaMessageTokensCount = await response
                    .Deserialize<BetaMessageTokensCount>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaMessageTokensCount.Validate();
                }
                return betaMessageTokensCount;
            }
        );
    }
}
