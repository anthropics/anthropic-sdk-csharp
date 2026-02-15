using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Messages;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IBatchService.List(BatchListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class BatchListPage(
    IBatchServiceWithRawResponse service,
    BatchListParams parameters,
    BatchListPageResponse response
) : IPage<MessageBatch>
{
    /// <inheritdoc/>
    public IReadOnlyList<MessageBatch> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.LastID != null;
        }
        catch (AnthropicInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<MessageBatch>> IPage<MessageBatch>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<BatchListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.LastID ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { AfterID = nextCursor }, cancellationToken)
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
        if (obj is not BatchListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
