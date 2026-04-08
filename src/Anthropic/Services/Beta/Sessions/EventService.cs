using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Services.Beta.Sessions;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    public EventService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EventListPage> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventListPage> List(
        string sessionID,
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSendSessionEvents> Send(
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSendSessionEvents> Send(
        string sessionID,
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> StreamStreaming(
        EventStreamParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StreamStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var betaManagedAgentsStreamSessionEvents in response.Enumerate(cancellationToken)
        )
        {
            yield return betaManagedAgentsStreamSessionEvents;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> StreamStreaming(
        string sessionID,
        EventStreamParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.StreamStreaming(
                parameters with
                {
                    SessionID = sessionID,
                },
                cancellationToken
            )
        )
        {
            yield return item;
        }
    }
}

/// <inheritdoc/>
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventListPage>> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<EventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<EventListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EventListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventListPage>> List(
        string sessionID,
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSendSessionEvents>> Send(
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<EventSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSendSessionEvents = await response
                    .Deserialize<BetaManagedAgentsSendSessionEvents>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSendSessionEvents.Validate();
                }
                return betaManagedAgentsSendSessionEvents;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSendSessionEvents>> Send(
        string sessionID,
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<BetaManagedAgentsStreamSessionEvents>> StreamStreaming(
        EventStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<EventStreamParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var betaManagedAgentsStreamSessionEvents in Sse.Enumerate<BetaManagedAgentsStreamSessionEvents>(
                    response.RawMessage,
                    token
                )
            )
            {
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsStreamSessionEvents.Validate();
                }
                yield return betaManagedAgentsStreamSessionEvents;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<BetaManagedAgentsStreamSessionEvents>> StreamStreaming(
        string sessionID,
        EventStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StreamStreaming(parameters with { SessionID = sessionID }, cancellationToken);
    }
}
