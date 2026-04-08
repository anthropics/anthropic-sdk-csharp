using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Services.Beta.Sessions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IResourceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IResourceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResourceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Session Resource
    /// </summary>
    Task<ResourceRetrieveResponse> Retrieve(
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ResourceRetrieveParams, CancellationToken)"/>
    Task<ResourceRetrieveResponse> Retrieve(
        string resourceID,
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Session Resource
    /// </summary>
    Task<ResourceUpdateResponse> Update(
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ResourceUpdateParams, CancellationToken)"/>
    Task<ResourceUpdateResponse> Update(
        string resourceID,
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Session Resources
    /// </summary>
    Task<ResourceListPage> List(
        ResourceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ResourceListParams, CancellationToken)"/>
    Task<ResourceListPage> List(
        string sessionID,
        ResourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Session Resource
    /// </summary>
    Task<BetaManagedAgentsDeleteSessionResource> Delete(
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ResourceDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeleteSessionResource> Delete(
        string resourceID,
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add Session Resource
    /// </summary>
    Task<BetaManagedAgentsFileResource> Add(
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ResourceAddParams, CancellationToken)"/>
    Task<BetaManagedAgentsFileResource> Add(
        string sessionID,
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IResourceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IResourceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IResourceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/resources/{resource_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IResourceService.Retrieve(ResourceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ResourceRetrieveResponse>> Retrieve(
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ResourceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ResourceRetrieveResponse>> Retrieve(
        string resourceID,
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}/resources/{resource_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IResourceService.Update(ResourceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ResourceUpdateResponse>> Update(
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ResourceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ResourceUpdateResponse>> Update(
        string resourceID,
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sessions/{session_id}/resources?beta=true</c>, but is otherwise the
    /// same as <see cref="IResourceService.List(ResourceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ResourceListPage>> List(
        ResourceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ResourceListParams, CancellationToken)"/>
    Task<HttpResponse<ResourceListPage>> List(
        string sessionID,
        ResourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/sessions/{session_id}/resources/{resource_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IResourceService.Delete(ResourceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeleteSessionResource>> Delete(
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ResourceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeleteSessionResource>> Delete(
        string resourceID,
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sessions/{session_id}/resources?beta=true</c>, but is otherwise the
    /// same as <see cref="IResourceService.Add(ResourceAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsFileResource>> Add(
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ResourceAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsFileResource>> Add(
        string sessionID,
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    );
}
