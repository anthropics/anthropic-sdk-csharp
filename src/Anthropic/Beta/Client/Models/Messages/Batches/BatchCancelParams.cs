using System;
using System.Net.Http;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

/// <summary>
/// Batches may be canceled any time before processing ends. Once cancellation is
/// initiated, the batch enters a `canceling` state, at which time the system may
/// complete any in-progress, non-interruptible requests before finalizing cancellation.
///
/// The number of canceled requests is specified in `request_counts`. To determine
/// which requests were canceled, check the individual results within the batch. Note
/// that cancellation may not result in any canceled requests if they were non-interruptible.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchCancelParams : ParamsBase
{
    public required string MessageBatchID;

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/batches/{0}/cancel", this.MessageBatchID)
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
