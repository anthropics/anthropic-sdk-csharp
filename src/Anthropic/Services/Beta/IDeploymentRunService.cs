using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDeploymentRunService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDeploymentRunServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentRunService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Deployment Run
    /// </summary>
    Task<BetaManagedAgentsDeploymentRun> Retrieve(
        DeploymentRunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRunRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeploymentRun> Retrieve(
        string deploymentRunID,
        DeploymentRunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Deployment Runs
    /// </summary>
    Task<DeploymentRunListPage> List(
        DeploymentRunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDeploymentRunService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDeploymentRunServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentRunServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/deployment_runs/{deployment_run_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentRunService.Retrieve(DeploymentRunRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Retrieve(
        DeploymentRunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRunRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Retrieve(
        string deploymentRunID,
        DeploymentRunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/deployment_runs?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentRunService.List(DeploymentRunListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeploymentRunListPage>> List(
        DeploymentRunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
