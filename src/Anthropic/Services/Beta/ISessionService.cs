using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Services.Beta.Sessions;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISessionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISessionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEventService Events { get; }

    IResourceService Resources { get; }

    /// <summary>
    /// Create Session
    /// </summary>
    Task<BetaManagedAgentsSession> Create(
        SessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Session
    /// </summary>
    Task<BetaManagedAgentsSession> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SessionRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsSession> Retrieve(
        string sessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Session
    /// </summary>
    Task<BetaManagedAgentsSession> Update(
        SessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SessionUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsSession> Update(
        string sessionID,
        SessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Sessions
    /// </summary>
    Task<SessionListPage> List(
        SessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Session
    /// </summary>
    Task<BetaManagedAgentsDeletedSession> Delete(
        SessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SessionDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeletedSession> Delete(
        string sessionID,
        SessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Session
    /// </summary>
    Task<BetaManagedAgentsSession> Archive(
        SessionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(SessionArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsSession> Archive(
        string sessionID,
        SessionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISessionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISessionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISessionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEventServiceWithRawResponse Events { get; }

    IResourceServiceWithRawResponse Resources { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.Create(SessionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSession>> Create(
        SessionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.Retrieve(SessionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSession>> Retrieve(
        SessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SessionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSession>> Retrieve(
        string sessionID,
        SessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.Update(SessionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSession>> Update(
        SessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SessionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSession>> Update(
        string sessionID,
        SessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.List(SessionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SessionListPage>> List(
        SessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/sessions/{session_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.Delete(SessionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeletedSession>> Delete(
        SessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SessionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeletedSession>> Delete(
        string sessionID,
        SessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="ISessionService.Archive(SessionArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSession>> Archive(
        SessionArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(SessionArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSession>> Archive(
        string sessionID,
        SessionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
