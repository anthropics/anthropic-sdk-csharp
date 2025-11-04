using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Messages.Batches;

namespace Anthropic.Client.Services.Messages.Batches;

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

    public async Task<MessageBatch> Create(BatchCreateParams parameters)
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messageBatch = await response.Deserialize<MessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
    }

    public async Task<MessageBatch> Retrieve(BatchRetrieveParams parameters)
    {
        HttpRequest<BatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messageBatch = await response.Deserialize<MessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
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

    public async Task<DeletedMessageBatch> Delete(BatchDeleteParams parameters)
    {
        HttpRequest<BatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deletedMessageBatch = await response
            .Deserialize<DeletedMessageBatch>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deletedMessageBatch.Validate();
        }
        return deletedMessageBatch;
    }

    public async Task<MessageBatch> Cancel(BatchCancelParams parameters)
    {
        HttpRequest<BatchCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messageBatch = await response.Deserialize<MessageBatch>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
    }

    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
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
            var messageBatchIndividualResponse =
                message.Deserialize<MessageBatchIndividualResponse>();
            if (this._client.ResponseValidation)
            {
                messageBatchIndividualResponse.Validate();
            }
            yield return messageBatchIndividualResponse;
        }
    }
}
