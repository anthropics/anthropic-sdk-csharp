using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Services.Beta.MemoryStores;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemoryVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// GetMemoryVersion
    /// </summary>
    Task<BetaManagedAgentsMemoryVersion> Retrieve(
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryVersionRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemoryVersion> Retrieve(
        string memoryVersionID,
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// ListMemoryVersions
    /// </summary>
    Task<MemoryVersionListPage> List(
        MemoryVersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryVersionListParams, CancellationToken)"/>
    Task<MemoryVersionListPage> List(
        string memoryStoreID,
        MemoryVersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// RedactMemoryVersion
    /// </summary>
    Task<BetaManagedAgentsMemoryVersion> Redact(
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Redact(MemoryVersionRedactParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemoryVersion> Redact(
        string memoryVersionID,
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMemoryVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores/{memory_store_id}/memory_versions/{memory_version_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryVersionService.Retrieve(MemoryVersionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Retrieve(
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryVersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Retrieve(
        string memoryVersionID,
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores/{memory_store_id}/memory_versions?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryVersionService.List(MemoryVersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemoryVersionListPage>> List(
        MemoryVersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryVersionListParams, CancellationToken)"/>
    Task<HttpResponse<MemoryVersionListPage>> List(
        string memoryStoreID,
        MemoryVersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores/{memory_store_id}/memory_versions/{memory_version_id}/redact?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryVersionService.Redact(MemoryVersionRedactParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Redact(
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Redact(MemoryVersionRedactParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Redact(
        string memoryVersionID,
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    );
}
