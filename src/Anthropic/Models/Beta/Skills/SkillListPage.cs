using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Skills;

public sealed class SkillListPage(
    ISkillService service,
    SkillListParams parameters,
    SkillListPageResponse response
) : IPage<SkillListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<SkillListResponse> Items
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
    async Task<IPage<SkillListResponse>> IPage<SkillListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<SkillListPage> Next(CancellationToken cancellationToken = default)
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
