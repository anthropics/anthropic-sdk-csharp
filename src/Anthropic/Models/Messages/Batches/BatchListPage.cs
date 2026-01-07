using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Messages;

namespace Anthropic.Models.Messages.Batches;

public sealed class BatchListPage(
    IBatchService service,
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
        return await service
            .List(parameters with { AfterID = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
