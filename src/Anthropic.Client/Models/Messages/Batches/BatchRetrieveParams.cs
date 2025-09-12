using System;
using System.Net.Http;

namespace Anthropic.Client.Models.Messages.Batches;

/// <summary>
/// This endpoint is idempotent and can be used to poll for Message Batch completion.
/// To access the results of a Message Batch, make a request to the `results_url`
/// field in the response.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchRetrieveParams : ParamsBase
{
    public required string MessageBatchID;

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/batches/{0}", this.MessageBatchID)
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
