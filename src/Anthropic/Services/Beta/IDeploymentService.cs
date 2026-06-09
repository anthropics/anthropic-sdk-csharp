using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.DeploymentRuns;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDeploymentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDeploymentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeployment> Retrieve(
        string deploymentID,
        DeploymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Update(
        DeploymentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DeploymentUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeployment> Update(
        string deploymentID,
        DeploymentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Deployments
    /// </summary>
    Task<DeploymentListPage> List(
        DeploymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Archive(
        DeploymentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DeploymentArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeployment> Archive(
        string deploymentID,
        DeploymentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pause Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Pause(
        DeploymentPauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pause(DeploymentPauseParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeployment> Pause(
        string deploymentID,
        DeploymentPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run Deployment Now
    /// </summary>
    Task<BetaManagedAgentsDeploymentRun> Run(
        DeploymentRunParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Run(DeploymentRunParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeploymentRun> Run(
        string deploymentID,
        DeploymentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unpause Deployment
    /// </summary>
    Task<BetaManagedAgentsDeployment> Unpause(
        DeploymentUnpauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unpause(DeploymentUnpauseParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeployment> Unpause(
        string deploymentID,
        DeploymentUnpauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDeploymentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDeploymentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDeploymentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Create(DeploymentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/deployments/{deployment_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Retrieve(DeploymentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DeploymentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Retrieve(
        string deploymentID,
        DeploymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments/{deployment_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Update(DeploymentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Update(
        DeploymentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DeploymentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Update(
        string deploymentID,
        DeploymentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/deployments?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.List(DeploymentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeploymentListPage>> List(
        DeploymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments/{deployment_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Archive(DeploymentArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Archive(
        DeploymentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DeploymentArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Archive(
        string deploymentID,
        DeploymentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments/{deployment_id}/pause?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Pause(DeploymentPauseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Pause(
        DeploymentPauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pause(DeploymentPauseParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Pause(
        string deploymentID,
        DeploymentPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments/{deployment_id}/run?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Run(DeploymentRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Run(
        DeploymentRunParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Run(DeploymentRunParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Run(
        string deploymentID,
        DeploymentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/deployments/{deployment_id}/unpause?beta=true</c>, but is otherwise the
    /// same as <see cref="IDeploymentService.Unpause(DeploymentUnpauseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Unpause(
        DeploymentUnpauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unpause(DeploymentUnpauseParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeployment>> Unpause(
        string deploymentID,
        DeploymentUnpauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
