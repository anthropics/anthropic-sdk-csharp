using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
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

    public async Task<MessageBatch> Create(
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
        var messageBatch = await response
            .Deserialize<MessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
    }

    public async Task<MessageBatch> Retrieve(
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
        var messageBatch = await response
            .Deserialize<MessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
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

    public async Task<DeletedMessageBatch> Delete(
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
        var deletedMessageBatch = await response
            .Deserialize<DeletedMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deletedMessageBatch.Validate();
        }
        return deletedMessageBatch;
    }

    public async Task<MessageBatch> Cancel(
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
        var messageBatch = await response
            .Deserialize<MessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageBatch.Validate();
        }
        return messageBatch;
    }

    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
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
