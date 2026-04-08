using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Services.Beta.Sessions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Events
    /// </summary>
    Task<EventListPage> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EventListParams, CancellationToken)"/>
    Task<EventListPage> List(
        string sessionID,
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send Events
    /// </summary>
    Task<BetaManagedAgentsSendSessionEvents> Send(
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(EventSendParams, CancellationToken)"/>
    Task<BetaManagedAgentsSendSessionEvents> Send(
        string sessionID,
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stream Events
    /// </summary>
    IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> StreamStreaming(
        EventStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StreamStreaming(EventStreamParams, CancellationToken)"/>
    IAsyncEnumerable<BetaManagedAgentsStreamSessionEvents> StreamStreaming(
        string sessionID,
        EventStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/events?beta=true</c>, but is otherwise the
    /// same as <see cref="IEventService.List(EventListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventListPage>> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EventListParams, CancellationToken)"/>
    Task<HttpResponse<EventListPage>> List(
        string sessionID,
        EventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}/events?beta=true</c>, but is otherwise the
    /// same as <see cref="IEventService.Send(EventSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSendSessionEvents>> Send(
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(EventSendParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSendSessionEvents>> Send(
        string sessionID,
        EventSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/events/stream?beta=true</c>, but is otherwise the
    /// same as <see cref="IEventService.StreamStreaming(EventStreamParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<BetaManagedAgentsStreamSessionEvents>> StreamStreaming(
        EventStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StreamStreaming(EventStreamParams, CancellationToken)"/>
    Task<StreamingHttpResponse<BetaManagedAgentsStreamSessionEvents>> StreamStreaming(
        string sessionID,
        EventStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
