using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Models;

public sealed class ModelListPage(
    IModelService service,
    ModelListParams parameters,
    ModelListPageResponse response
) : IPage<BetaModelInfo>
{
    /// <inheritdoc/>
    public IReadOnlyList<BetaModelInfo> Items
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
    async Task<IPage<BetaModelInfo>> IPage<BetaModelInfo>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ModelListPage> Next(CancellationToken cancellationToken = default)
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
