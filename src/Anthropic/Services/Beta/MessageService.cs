using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta.Messages;

namespace Anthropic.Services.Beta;

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

    /// <summary>
    /// The options of the client that this service makes its calls with, which the spans of a tool
    /// runner over this service follow, when that client is the SDK's own. The client's public
    /// interface does not have all of them.
    /// </summary>
    internal ClientOptions? ClientOptions
    {
        get { return (this._client as AnthropicClient)?.Options; }
    }

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
    public async Task<HttpResponse<BetaMessage>> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        MessageServiceHelpers.WarnIfDeprecatedThinkingConfig(parameters);

        // The options are made before the span starts, so that a request that they refuse, such
        // as one that needs streaming, fails without a span to leave open.
        var client = this._client.WithOptions(options =>
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
        );
        var (span, requestContent) = RequestAttributes.StartMessagesCreateSpan(
            this._client,
            parameters,
            stream: false
        );
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Span = span,
        };
        var response = await client.Execute(request, cancellationToken).ConfigureAwait(false);
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
                ResponseAttributes.SetMessagesCreateResponseAttributes(
                    span,
                    requestContent,
                    betaMessage
                );
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
        MessageServiceHelpers.WarnIfDeprecatedThinkingConfig(parameters);

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

        // The options are made before the span starts, so that a request that they refuse, such
        // as one that needs streaming, fails without a span to leave open.
        var client = this._client.WithOptions(options =>
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
        );
        var (span, requestContent) = RequestAttributes.StartMessagesCreateSpan(
            this._client,
            parameters,
            stream: true
        );
        // The time to the first chunk runs from here, on the monotonic clock.
        var startTimestamp = Stopwatch.GetTimestamp();
        HttpRequest<MessageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Span = span,
        };
        var response = await client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<BetaRawMessageStreamEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var betaMessage in Sse.Enumerate<BetaRawMessageStreamEvent>(
                    response.RawMessage,
                    token
                )
            )
            {
                if (this._client.ResponseValidation)
                {
                    betaMessage.Validate();
                }
                yield return betaMessage;
            }
        }
        if (span == null)
        {
            // No span: the events are read as they are, with nothing made to record them.
            return new(response, Enumerate);
        }
        var streamedMessage = StreamRecording.BetaStreamedMessage(this._client);
        return new(
            response,
            token =>
                StreamRecording.RecordStreamedMessage(
                    span,
                    requestContent,
                    startTimestamp,
                    Enumerate(token),
                    streamedMessage,
                    token
                )
        )
        {
            HasReadEndEvent = () => streamedMessage.ReachedMessageStop,
        };
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaMessageTokensCount>> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        MessageServiceHelpers.WarnIfDeprecatedThinkingConfig(parameters);

        var span = RequestAttributes.StartCountTokensSpan(
            this._client,
            parameters,
            parameters.RawBodyData
        );
        HttpRequest<MessageCountTokensParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Span = span,
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
                ResponseAttributes.SetCountTokensResponseAttributes(span, betaMessageTokensCount);
                return betaMessageTokensCount;
            }
        );
    }
}
