using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEnvironmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEnvironmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnvironmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new environment with the specified configuration.
    /// </summary>
    Task<BetaEnvironment> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific environment by ID.
    /// </summary>
    Task<BetaEnvironment> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>
    Task<BetaEnvironment> Retrieve(
        string environmentID,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing environment's configuration.
    /// </summary>
    Task<BetaEnvironment> Update(
        EnvironmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EnvironmentUpdateParams, CancellationToken)"/>
    Task<BetaEnvironment> Update(
        string environmentID,
        EnvironmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List environments with pagination support.
    /// </summary>
    Task<EnvironmentListPage> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an environment by ID. Returns a confirmation of the deletion.
    /// </summary>
    Task<BetaEnvironmentDeleteResponse> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EnvironmentDeleteParams, CancellationToken)"/>
    Task<BetaEnvironmentDeleteResponse> Delete(
        string environmentID,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive an environment by ID. Archived environments cannot be used to create new
    /// sessions.
    /// </summary>
    Task<BetaEnvironment> Archive(
        EnvironmentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EnvironmentArchiveParams, CancellationToken)"/>
    Task<BetaEnvironment> Archive(
        string environmentID,
        EnvironmentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEnvironmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEnvironmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnvironmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.Create(EnvironmentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaEnvironment>> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments/{environment_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaEnvironment>> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EnvironmentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaEnvironment>> Retrieve(
        string environmentID,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.Update(EnvironmentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaEnvironment>> Update(
        EnvironmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EnvironmentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaEnvironment>> Update(
        string environmentID,
        EnvironmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/environments?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.List(EnvironmentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EnvironmentListPage>> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/environments/{environment_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.Delete(EnvironmentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaEnvironmentDeleteResponse>> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EnvironmentDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaEnvironmentDeleteResponse>> Delete(
        string environmentID,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/environments/{environment_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IEnvironmentService.Archive(EnvironmentArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaEnvironment>> Archive(
        EnvironmentArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EnvironmentArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaEnvironment>> Archive(
        string environmentID,
        EnvironmentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
