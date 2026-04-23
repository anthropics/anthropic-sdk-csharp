using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Services.Beta.MemoryStores;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMemoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMemoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// CreateMemory
    /// </summary>
    Task<BetaManagedAgentsMemory> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MemoryCreateParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemory> Create(
        string memoryStoreID,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// GetMemory
    /// </summary>
    Task<BetaManagedAgentsMemory> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemory> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// UpdateMemory
    /// </summary>
    Task<BetaManagedAgentsMemory> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemoryUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsMemory> Update(
        string memoryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// ListMemories
    /// </summary>
    Task<MemoryListPage> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<MemoryListPage> List(
        string memoryStoreID,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// DeleteMemory
    /// </summary>
    Task<BetaManagedAgentsDeletedMemory> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MemoryDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeletedMemory> Delete(
        string memoryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMemoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMemoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMemoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores/{memory_store_id}/memories?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Create(MemoryCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemory>> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MemoryCreateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemory>> Create(
        string memoryStoreID,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores/{memory_store_id}/memories/{memory_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Retrieve(MemoryRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemory>> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MemoryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemory>> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/memory_stores/{memory_store_id}/memories/{memory_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Update(MemoryUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsMemory>> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(MemoryUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsMemory>> Update(
        string memoryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/memory_stores/{memory_store_id}/memories?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryService.List(MemoryListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MemoryListPage>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MemoryListParams, CancellationToken)"/>
    Task<HttpResponse<MemoryListPage>> List(
        string memoryStoreID,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/memory_stores/{memory_store_id}/memories/{memory_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IMemoryService.Delete(MemoryDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeletedMemory>> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MemoryDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeletedMemory>> Delete(
        string memoryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
