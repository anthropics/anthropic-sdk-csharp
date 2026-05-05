using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;
using Anthropic.Models.Beta.Sessions.Threads.Events;

namespace Anthropic.Services.Beta.Sessions.Threads;

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
        string threadID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { ThreadID = threadID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<BetaManagedAgentsStreamSessionThreadEvents> StreamStreaming(
        EventStreamParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StreamStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (
            var betaManagedAgentsStreamSessionThreadEvents in response.Enumerate(cancellationToken)
        )
        {
            yield return betaManagedAgentsStreamSessionThreadEvents;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<BetaManagedAgentsStreamSessionThreadEvents> StreamStreaming(
        string threadID,
        EventStreamParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var item in this.StreamStreaming(
                parameters with
                {
                    ThreadID = threadID,
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
        if (parameters.ThreadID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ThreadID' cannot be null");
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
        string threadID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { ThreadID = threadID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        StreamingHttpResponse<BetaManagedAgentsStreamSessionThreadEvents>
    > StreamStreaming(EventStreamParams parameters, CancellationToken cancellationToken = default)
    {
        if (parameters.ThreadID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ThreadID' cannot be null");
        }

        HttpRequest<EventStreamParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<BetaManagedAgentsStreamSessionThreadEvents> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var betaManagedAgentsStreamSessionThreadEvents in Sse.Enumerate<BetaManagedAgentsStreamSessionThreadEvents>(
                    response.RawMessage,
                    token
                )
            )
            {
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsStreamSessionThreadEvents.Validate();
                }
                yield return betaManagedAgentsStreamSessionThreadEvents;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<BetaManagedAgentsStreamSessionThreadEvents>> StreamStreaming(
        string threadID,
        EventStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StreamStreaming(parameters with { ThreadID = threadID }, cancellationToken);
    }
}
