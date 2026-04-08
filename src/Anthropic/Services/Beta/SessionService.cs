using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Services.Beta.Sessions;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class SessionService : ISessionService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<ISessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SessionService(this._client.WithOptions(modifier));
    }

    public SessionService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SessionServiceWithRawResponse(client.WithRawResponse));
        _events = new(() => new EventService(client));
        _resources = new(() => new ResourceService(client));
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IResourceService> _resources;
    public IResourceService Resources
    {
        get { return _resources.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSession> Create(
        SessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSession> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSession> Retrieve(
        string sessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSession> Update(
        SessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSession> Update(
        string sessionID,
        SessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SessionListPage> List(
        SessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeletedSession> Delete(
        SessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeletedSession> Delete(
        string sessionID,
        SessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsSession> Archive(
        SessionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsSession> Archive(
        string sessionID,
        SessionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { SessionID = sessionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SessionServiceWithRawResponse : ISessionServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISessionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SessionServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _events = new(() => new EventServiceWithRawResponse(client));
        _resources = new(() => new ResourceServiceWithRawResponse(client));
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IResourceServiceWithRawResponse> _resources;
    public IResourceServiceWithRawResponse Resources
    {
        get { return _resources.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSession>> Create(
        SessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSession = await response
                    .Deserialize<BetaManagedAgentsSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSession.Validate();
                }
                return betaManagedAgentsSession;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSession>> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<SessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSession = await response
                    .Deserialize<BetaManagedAgentsSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSession.Validate();
                }
                return betaManagedAgentsSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSession>> Retrieve(
        string sessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSession>> Update(
        SessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<SessionUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSession = await response
                    .Deserialize<BetaManagedAgentsSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSession.Validate();
                }
                return betaManagedAgentsSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSession>> Update(
        string sessionID,
        SessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionListPage>> List(
        SessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SessionListParams> request = new()
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
                    .Deserialize<SessionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SessionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeletedSession>> Delete(
        SessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<SessionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeletedSession = await response
                    .Deserialize<BetaManagedAgentsDeletedSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeletedSession.Validate();
                }
                return betaManagedAgentsDeletedSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeletedSession>> Delete(
        string sessionID,
        SessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsSession>> Archive(
        SessionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<SessionArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsSession = await response
                    .Deserialize<BetaManagedAgentsSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsSession.Validate();
                }
                return betaManagedAgentsSession;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsSession>> Archive(
        string sessionID,
        SessionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { SessionID = sessionID }, cancellationToken);
    }
}
