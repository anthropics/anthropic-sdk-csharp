using System;
using System.Net.Http;

namespace Anthropic.Client.Models.Messages.Batches;

/// <summary>
/// Streams the results of a Message Batch as a `.jsonl` file.
///
/// Each line in the file is a JSON object containing the result of a single request
/// in the Message Batch. Results are not guaranteed to be in the same order as requests.
/// Use the `custom_id` field to match results to requests.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchResultsParams : ParamsBase
{
    public required string MessageBatchID;

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/batches/{0}/results", this.MessageBatchID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IAnthropicClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
