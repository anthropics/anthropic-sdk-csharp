using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Services.Beta.Messages;

public sealed class BatchService : IBatchService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "message-batches-2024-09-24");
    }

    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public BatchService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<BetaMessageBatch> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaMessageBatch = await response
            .Deserialize<BetaMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async Task<BetaMessageBatch> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaMessageBatch = await response
            .Deserialize<BetaMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async Task<BatchListPageResponse> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BatchListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<BatchListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<BetaDeletedMessageBatch> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaDeletedMessageBatch = await response
            .Deserialize<BetaDeletedMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaDeletedMessageBatch.Validate();
        }
        return betaDeletedMessageBatch;
    }

    public async Task<BetaMessageBatch> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var betaMessageBatch = await response
            .Deserialize<BetaMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async IAsyncEnumerable<BetaMessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message, cancellationToken))
        {
            var betaMessageBatchIndividualResponse =
                message.Deserialize<BetaMessageBatchIndividualResponse>();
            if (this._client.ResponseValidation)
            {
                betaMessageBatchIndividualResponse.Validate();
            }
            yield return betaMessageBatchIndividualResponse;
        }
    }
}
