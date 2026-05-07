using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;
using Threads = Anthropic.Services.Beta.Sessions.Threads;

namespace Anthropic.Services.Beta.Sessions;

/// <inheritdoc/>
public sealed class ThreadService : IThreadService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IThreadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IThreadServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IThreadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ThreadService(this._client.WithOptions(modifier));
    }

    public ThreadService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ThreadServiceWithRawResponse(client.WithRawResponse));
        _events = new(() => new Threads::EventService(client));
    }

    readonly Lazy<Threads::IEventService> _events;
    public Threads::IEventService Events
    {
        get { return _events.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSessionThread> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSessionThread> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ThreadID = threadID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ThreadListPage> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ThreadListPage> List(
        string sessionID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSessionThread> Archive(
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSessionThread> Archive(
        string threadID,
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { ThreadID = threadID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ThreadServiceWithRawResponse : IThreadServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IThreadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ThreadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ThreadServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _events = new(() => new Threads::EventServiceWithRawResponse(client));
    }

    readonly Lazy<Threads::IEventServiceWithRawResponse> _events;
    public Threads::IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSessionThread>> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ThreadID' cannot be null");
        }

        HttpRequest<ThreadRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSessionThread = await response
                    .Deserialize<BetaManagedAgentsSessionThread>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSessionThread.Validate();
                }
                return betaManagedAgentsSessionThread;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSessionThread>> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ThreadID = threadID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ThreadListPage>> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ThreadListParams> request = new()
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
                    .Deserialize<ThreadListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ThreadListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ThreadListPage>> List(
        string sessionID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSessionThread>> Archive(
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ThreadID' cannot be null");
        }

        HttpRequest<ThreadArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSessionThread = await response
                    .Deserialize<BetaManagedAgentsSessionThread>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSessionThread.Validate();
                }
                return betaManagedAgentsSessionThread;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSessionThread>> Archive(
        string threadID,
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { ThreadID = threadID }, cancellationToken);
    }
}
