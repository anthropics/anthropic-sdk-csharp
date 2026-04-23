using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.MemoryStores;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IMemoryStoreService.List(MemoryStoreListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class MemoryStoreListPage(
    IMemoryStoreServiceWithRawResponse service,
    MemoryStoreListParams parameters,
    MemoryStoreListPageResponse response
) : IPage<BetaManagedAgentsMemoryStore>
{
    /// <inheritdoc/>
    public IReadOnlyList<BetaManagedAgentsMemoryStore> Items
    {
        get { return response.Data ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.NextPage != null;
        }
        catch (AnthropicInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<BetaManagedAgentsMemoryStore>> IPage<BetaManagedAgentsMemoryStore>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<MemoryStoreListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextPage ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { Page = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not MemoryStoreListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
