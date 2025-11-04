using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Messages.Batches;

namespace Anthropic.Client.Services.Beta.Messages.Batches;

public sealed class BatchService : IBatchService
{
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public BatchService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<BetaMessageBatch> Create(BatchCreateParams parameters)
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaMessageBatch = await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async Task<BetaMessageBatch> Retrieve(BatchRetrieveParams parameters)
    {
        HttpRequest<BatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaMessageBatch = await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async Task<BatchListPageResponse> List(BatchListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<BatchListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<BatchListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<BetaDeletedMessageBatch> Delete(BatchDeleteParams parameters)
    {
        HttpRequest<BatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaDeletedMessageBatch = await response
            .Deserialize<BetaDeletedMessageBatch>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaDeletedMessageBatch.Validate();
        }
        return betaDeletedMessageBatch;
    }

    public async Task<BetaMessageBatch> Cancel(BatchCancelParams parameters)
    {
        HttpRequest<BatchCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var betaMessageBatch = await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    public async IAsyncEnumerable<BetaMessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters
    )
    {
        HttpRequest<BatchResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        await foreach (var message in SseMessage.GetEnumerable(response.Message))
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
