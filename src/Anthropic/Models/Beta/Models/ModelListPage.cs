using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IModelService.List(ModelListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ModelListPage(
    IModelServiceWithRawResponse service,
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
            if (this.Items.Count == 0)
            {
                return false;
            }
            if (response.HasMore == false)
            {
                return false;
            }
            if (parameters.BeforeID != null)
            {
                return response.FirstID != null;
            }
            return response.LastID != null;
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
        if (parameters.BeforeID != null)
        {
            var previousCursor =
                response.FirstID ?? throw new InvalidOperationException("Cannot request next page");
            using var previousResponse = await service
                .List(parameters with { BeforeID = previousCursor }, cancellationToken)
                .ConfigureAwait(false);
            return await previousResponse.Deserialize(cancellationToken).ConfigureAwait(false);
        }
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
        if (obj is not ModelListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
