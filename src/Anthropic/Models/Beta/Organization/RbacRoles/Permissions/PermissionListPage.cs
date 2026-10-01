using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Organization.RbacRoles;

namespace Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IPermissionService.List(PermissionListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class PermissionListPage(
    IPermissionServiceWithRawResponse service,
    PermissionListParams parameters,
    PermissionListPageResponse response
) : IPage<BetaRbacRolePermission>
{
    /// <inheritdoc/>
    public IReadOnlyList<BetaRbacRolePermission> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return response.NextPage != null;
        }
        catch (AnthropicInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<BetaRbacRolePermission>> IPage<BetaRbacRolePermission>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<PermissionListPage> Next(CancellationToken cancellationToken = default)
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
        if (obj is not PermissionListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
