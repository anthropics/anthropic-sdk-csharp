using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Services.Messages;

/// <inheritdoc />
public sealed class BatchService : IBatchService
{
    /// <inheritdoc/>
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public BatchService(IAnthropicClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<MessageBatch> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageBatchID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MessageBatchID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<MessageBatch> Retrieve(
        string messageBatchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<DeletedMessageBatch> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageBatchID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MessageBatchID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<DeletedMessageBatch> Delete(
        string messageBatchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Delete(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MessageBatch> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageBatchID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MessageBatchID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<MessageBatch> Cancel(
        string messageBatchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Cancel(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageBatchID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MessageBatchID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        string messageBatchID,
        BatchResultsParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.ResultsStreaming(
                parameters with
                {
                    MessageBatchID = messageBatchID,
                },
                cancellationToken
            )
        )
        {
            yield return item;
        }
    }
}
