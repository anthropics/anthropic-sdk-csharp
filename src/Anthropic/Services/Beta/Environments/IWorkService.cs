using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Services.Beta.Environments;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWorkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Retrieve detailed information about a specific work item.</para>
    /// </summary>
    Task<BetaSelfHostedWork> Retrieve(
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkRetrieveParams, CancellationToken)"/>
    Task<BetaSelfHostedWork> Retrieve(
        string workID,
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Update work item metadata with merge semantics.</para>
    /// </summary>
    Task<BetaSelfHostedWork> Update(
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkUpdateParams, CancellationToken)"/>
    Task<BetaSelfHostedWork> Update(
        string workID,
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>List work items in an environment.</para>
    /// </summary>
    Task<WorkListPage> List(
        WorkListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkListParams, CancellationToken)"/>
    Task<WorkListPage> List(
        string environmentID,
        WorkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Acknowledge receipt of a work item, transitioning it from 'queued' to
    /// 'starting' and removing it from the queue.</para>
    /// </summary>
    Task<BetaSelfHostedWork> Ack(
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Ack(WorkAckParams, CancellationToken)"/>
    Task<BetaSelfHostedWork> Ack(
        string workID,
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Record a heartbeat for a work item to maintain the lease.</para>
    /// </summary>
    Task<BetaSelfHostedWorkHeartbeatResponse> Heartbeat(
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Heartbeat(WorkHeartbeatParams, CancellationToken)"/>
    Task<BetaSelfHostedWorkHeartbeatResponse> Heartbeat(
        string workID,
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Long poll for work items in the queue.</para>
    /// </summary>
    Task<BetaSelfHostedWork?> Poll(
        WorkPollParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Poll(WorkPollParams, CancellationToken)"/>
    Task<BetaSelfHostedWork?> Poll(
        string environmentID,
        WorkPollParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get statistics about the work queue for an environment.
    /// </summary>
    Task<BetaSelfHostedWorkQueueStats> Stats(
        WorkStatsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stats(WorkStatsParams, CancellationToken)"/>
    Task<BetaSelfHostedWorkQueueStats> Stats(
        string environmentID,
        WorkStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Note: these endpoints are called automatically by the pre-built environment
    /// worker provided in the SDKs and CLI, for orchestrating sessions with self-hosted
    /// sandbox environments. They are included here as a reference; you do not need to
    /// invoke them directly.
    ///
    /// <para>Stop a work item, initiating graceful or forced shutdown.</para>
    /// </summary>
    Task<BetaSelfHostedWork> Stop(
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(WorkStopParams, CancellationToken)"/>
    Task<BetaSelfHostedWork> Stop(
        string workID,
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments/{environment_id}/work/{work_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Retrieve(WorkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWork>> Retrieve(
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WorkRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWork>> Retrieve(
        string workID,
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}/work/{work_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Update(WorkUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWork>> Update(
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WorkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWork>> Update(
        string workID,
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments/{environment_id}/work?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.List(WorkListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkListPage>> List(
        WorkListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkListParams, CancellationToken)"/>
    Task<HttpResponse<WorkListPage>> List(
        string environmentID,
        WorkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}/work/{work_id}/ack?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Ack(WorkAckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWork>> Ack(
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Ack(WorkAckParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWork>> Ack(
        string workID,
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}/work/{work_id}/heartbeat?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Heartbeat(WorkHeartbeatParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWorkHeartbeatResponse>> Heartbeat(
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Heartbeat(WorkHeartbeatParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWorkHeartbeatResponse>> Heartbeat(
        string workID,
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments/{environment_id}/work/poll?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Poll(WorkPollParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWork?>> Poll(
        WorkPollParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Poll(WorkPollParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWork?>> Poll(
        string environmentID,
        WorkPollParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments/{environment_id}/work/stats?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Stats(WorkStatsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWorkQueueStats>> Stats(
        WorkStatsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stats(WorkStatsParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWorkQueueStats>> Stats(
        string environmentID,
        WorkStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}/work/{work_id}/stop?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkService.Stop(WorkStopParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSelfHostedWork>> Stop(
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stop(WorkStopParams, CancellationToken)"/>
    Task<HttpResponse<BetaSelfHostedWork>> Stop(
        string workID,
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    );
}
