using System.Net.Http;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// This endpoint is idempotent and can be used to poll for Message Batch completion.
/// To access the results of a Message Batch, make a request to the `results_url`
/// field in the response.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchRetrieveParams : Anthropic::ParamsBase
{
    public required string MessageBatchID;

    public override global::System.Uri Url(Anthropic::IAnthropicClient client)
    {
        return new global::System.UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/batches/{0}", this.MessageBatchID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, Anthropic::IAnthropicClient client)
    {
        Anthropic::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Anthropic::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
