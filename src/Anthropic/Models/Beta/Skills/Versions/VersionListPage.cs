using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Skills;

namespace Anthropic.Models.Beta.Skills.Versions;

public sealed class VersionListPage(
    IVersionService service,
    VersionListParams parameters,
    VersionListPageResponse response
) : IPage<VersionListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<VersionListResponse> Items
    {
        get { return response.Data; }
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
    async Task<IPage<VersionListResponse>> IPage<VersionListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<VersionListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextPage ?? throw new InvalidOperationException("Cannot request next page");
        return await service
            .List(parameters with { Page = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
