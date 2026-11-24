using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <inheritdoc/>
public sealed class ItemService : IItemService
{
    readonly Lazy<IItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    public ItemService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaComplianceReviewItem> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaComplianceReviewItem> Retrieve(
        string itemID,
        ItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ItemID = itemID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ItemServiceWithRawResponse : IItemServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ItemServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaComplianceReviewItem>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.compliance.review.items.retrieve",
            SpanResourceIds = [new("anthropic.compliance.review.item.id", parameters.ItemID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaComplianceReviewItem = await response
                    .Deserialize<BetaComplianceReviewItem>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaComplianceReviewItem.Validate();
                }
                return betaComplianceReviewItem;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaComplianceReviewItem>> Retrieve(
        string itemID,
        ItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ItemID = itemID }, cancellationToken);
    }
}
