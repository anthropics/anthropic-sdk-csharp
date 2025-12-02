using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Services.Beta.Messages;

/// <inheritdoc />
public sealed class BatchService : IBatchService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "message-batches-2024-09-24");
    }

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

    /// <inheritdoc/>
    public async Task<BetaMessageBatch> Retrieve(
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
        var betaMessageBatch = await response
            .Deserialize<BetaMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    /// <inheritdoc/>
    public async Task<BetaMessageBatch> Retrieve(
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
    public async Task<BetaDeletedMessageBatch> Delete(
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
        var betaDeletedMessageBatch = await response
            .Deserialize<BetaDeletedMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaDeletedMessageBatch.Validate();
        }
        return betaDeletedMessageBatch;
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedMessageBatch> Delete(
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
    public async Task<BetaMessageBatch> Cancel(
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
        var betaMessageBatch = await response
            .Deserialize<BetaMessageBatch>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            betaMessageBatch.Validate();
        }
        return betaMessageBatch;
    }

    /// <inheritdoc/>
    public async Task<BetaMessageBatch> Cancel(
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
    public async IAsyncEnumerable<BetaMessageBatchIndividualResponse> ResultsStreaming(
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
        await foreach (
            var betaMessageBatchIndividualResponse in Sse.Enumerate<BetaMessageBatchIndividualResponse>(
                response.Message,
                cancellationToken
            )
        )
        {
            if (this._client.ResponseValidation)
            {
                betaMessageBatchIndividualResponse.Validate();
            }
            yield return betaMessageBatchIndividualResponse;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<BetaMessageBatchIndividualResponse> ResultsStreaming(
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
