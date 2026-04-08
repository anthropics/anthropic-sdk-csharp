using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Services.Beta.Agents;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionService Versions { get; }

    /// <summary>
    /// Create Agent
    /// </summary>
    Task<BetaManagedAgentsAgent> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Agent
    /// </summary>
    Task<BetaManagedAgentsAgent> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsAgent> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Agent
    /// </summary>
    Task<BetaManagedAgentsAgent> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsAgent> Update(
        string agentID,
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Agents
    /// </summary>
    Task<AgentListPage> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Agent
    /// </summary>
    Task<BetaManagedAgentsAgent> Archive(
        AgentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(AgentArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsAgent> Archive(
        string agentID,
        AgentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVersionServiceWithRawResponse Versions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents?beta=true</c>, but is otherwise the
    /// same as <see cref="IAgentService.Create(AgentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsAgent>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agents/{agent_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsAgent>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsAgent>> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents/{agent_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsAgent>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsAgent>> Update(
        string agentID,
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agents?beta=true</c>, but is otherwise the
    /// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentListPage>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents/{agent_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IAgentService.Archive(AgentArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsAgent>> Archive(
        AgentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(AgentArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsAgent>> Archive(
        string agentID,
        AgentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
