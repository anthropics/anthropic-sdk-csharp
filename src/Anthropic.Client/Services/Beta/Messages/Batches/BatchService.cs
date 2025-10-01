using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Messages.Batches;

namespace Anthropic.Client.Services.Beta.Messages.Batches;

public sealed class BatchService : IBatchService
{
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
        return await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
    }

    public async Task<BetaMessageBatch> Retrieve(BatchRetrieveParams parameters)
    {
        HttpRequest<BatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
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
        return await response.Deserialize<BatchListPageResponse>().ConfigureAwait(false);
    }

    public async Task<BetaDeletedMessageBatch> Delete(BatchDeleteParams parameters)
    {
        HttpRequest<BatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BetaDeletedMessageBatch>().ConfigureAwait(false);
    }

    public async Task<BetaMessageBatch> Cancel(BatchCancelParams parameters)
    {
        HttpRequest<BatchCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BetaMessageBatch>().ConfigureAwait(false);
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
            yield return message.MessageDeserializeMethod<BetaMessageBatchIndividualResponse>();
        }
    }
}
