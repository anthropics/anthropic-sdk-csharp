using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores;
using Anthropic.Services.Beta.MemoryStores;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemoryStoreService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryStoreServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryStoreService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMemoryService Memories { get; }

    IMemoryVersionService MemoryVersions { get; }

    /// <summary>
    /// Create a memory store
    /// </summary>
    Task<BetaManagedAgentsMemoryStore> Create(
        MemoryStoreCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a memory store
    /// </summary>
    Task<BetaManagedAgentsMemoryStore> Retrieve(
        MemoryStoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryStoreRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemoryStore> Retrieve(
        string memoryStoreID,
        MemoryStoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a memory store
    /// </summary>
    Task<BetaManagedAgentsMemoryStore> Update(
        MemoryStoreUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemoryStoreUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemoryStore> Update(
        string memoryStoreID,
        MemoryStoreUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List memory stores
    /// </summary>
    Task<MemoryStoreListPage> List(
        MemoryStoreListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a memory store
    /// </summary>
    Task<BetaManagedAgentsDeletedMemoryStore> Delete(
        MemoryStoreDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MemoryStoreDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeletedMemoryStore> Delete(
        string memoryStoreID,
        MemoryStoreDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a memory store
    /// </summary>
    Task<BetaManagedAgentsMemoryStore> Archive(
        MemoryStoreArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(MemoryStoreArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemoryStore> Archive(
        string memoryStoreID,
        MemoryStoreArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMemoryStoreService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryStoreServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryStoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMemoryServiceWithRawResponse Memories { get; }

    IMemoryVersionServiceWithRawResponse MemoryVersions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.Create(MemoryStoreCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Create(
        MemoryStoreCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores/{memory_store_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.Retrieve(MemoryStoreRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Retrieve(
        MemoryStoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryStoreRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Retrieve(
        string memoryStoreID,
        MemoryStoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores/{memory_store_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.Update(MemoryStoreUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Update(
        MemoryStoreUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemoryStoreUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Update(
        string memoryStoreID,
        MemoryStoreUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.List(MemoryStoreListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemoryStoreListPage>> List(
        MemoryStoreListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/memory_stores/{memory_store_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.Delete(MemoryStoreDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeletedMemoryStore>> Delete(
        MemoryStoreDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MemoryStoreDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeletedMemoryStore>> Delete(
        string memoryStoreID,
        MemoryStoreDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores/{memory_store_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryStoreService.Archive(MemoryStoreArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Archive(
        MemoryStoreArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(MemoryStoreArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemoryStore>> Archive(
        string memoryStoreID,
        MemoryStoreArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
