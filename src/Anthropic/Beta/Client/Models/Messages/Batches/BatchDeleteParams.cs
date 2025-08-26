using System;
using System.Net.Http;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

/// <summary>
/// Delete a Message Batch.
///
/// Message Batches can only be deleted once they've finished processing. If you'd
/// like to delete an in-progress batch, you must first cancel it.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchDeleteParams : ParamsBase
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
