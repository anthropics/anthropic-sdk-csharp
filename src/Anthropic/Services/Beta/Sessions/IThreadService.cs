using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Threads;
using Threads = Anthropic.Services.Beta.Sessions.Threads;

namespace Anthropic.Services.Beta.Sessions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IThreadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IThreadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IThreadService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Threads::IEventService Events { get; }

    /// <summary>
    /// Get Session Thread
    /// </summary>
    Task<BetaManagedAgentsSessionThread> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ThreadRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsSessionThread> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Session Threads
    /// </summary>
    Task<ThreadListPage> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ThreadListParams, CancellationToken)"/>
    Task<ThreadListPage> List(
        string sessionID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Session Thread
    /// </summary>
    Task<BetaManagedAgentsSessionThread> Archive(
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ThreadArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsSessionThread> Archive(
        string threadID,
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IThreadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IThreadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IThreadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Threads::IEventServiceWithRawResponse Events { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/threads/{thread_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IThreadService.Retrieve(ThreadRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSessionThread>> Retrieve(
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ThreadRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSessionThread>> Retrieve(
        string threadID,
        ThreadRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/threads?beta=true</c>, but is otherwise the
    /// same as <see cref="IThreadService.List(ThreadListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ThreadListPage>> List(
        ThreadListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ThreadListParams, CancellationToken)"/>
    Task<HttpResponse<ThreadListPage>> List(
        string sessionID,
        ThreadListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}/threads/{thread_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IThreadService.Archive(ThreadArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsSessionThread>> Archive(
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ThreadArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsSessionThread>> Archive(
        string threadID,
        ThreadArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}
