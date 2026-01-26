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

/// <inheritdoc/>
public sealed class BatchService : IBatchService
{
    readonly Lazy<IBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    public BatchService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MessageBatch> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageBatch> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageBatch> Retrieve(
        string messageBatchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BatchListPage> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DeletedMessageBatch> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeletedMessageBatch> Delete(
        string messageBatchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { MessageBatchID = messageBatchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageBatch> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageBatch> Cancel(
        string messageBatchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { MessageBatchID = messageBatchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<MessageBatchIndividualResponse> ResultsStreaming(
        BatchResultsParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ResultsStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var messageBatchIndividualResponse in response.Enumerate(cancellationToken))
        {
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

/// <inheritdoc/>
public sealed class BatchServiceWithRawResponse : IBatchServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageBatch>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messageBatch = await response
                    .Deserialize<MessageBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messageBatch.Validate();
                }
                return messageBatch;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageBatch>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messageBatch = await response
                    .Deserialize<MessageBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messageBatch.Validate();
                }
                return messageBatch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageBatch>> Retrieve(
        string messageBatchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<BatchListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BatchListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeletedMessageBatch>> Delete(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deletedMessageBatch = await response
                    .Deserialize<DeletedMessageBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deletedMessageBatch.Validate();
                }
                return deletedMessageBatch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeletedMessageBatch>> Delete(
        string messageBatchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { MessageBatchID = messageBatchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageBatch>> Cancel(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messageBatch = await response
                    .Deserialize<MessageBatch>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messageBatch.Validate();
                }
                return messageBatch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageBatch>> Cancel(
        string messageBatchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { MessageBatchID = messageBatchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<MessageBatchIndividualResponse>> ResultsStreaming(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<MessageBatchIndividualResponse> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var messageBatchIndividualResponse in Jsonl.Enumerate<MessageBatchIndividualResponse>(
                    response.RawMessage,
                    token
                )
            )
            {
                if (this._client.ResponseValidation)
                {
                    messageBatchIndividualResponse.Validate();
                }
                yield return messageBatchIndividualResponse;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<MessageBatchIndividualResponse>> ResultsStreaming(
        string messageBatchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResultsStreaming(
            parameters with
            {
                MessageBatchID = messageBatchID,
            },
            cancellationToken
        );
    }
}
