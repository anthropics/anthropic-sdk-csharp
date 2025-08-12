using System.Net.Http;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Delete a Message Batch.
///
/// Message Batches can only be deleted once they've finished processing. If you'd
/// like to delete an in-progress batch, you must first cancel it.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchDeleteParams : Anthropic::ParamsBase
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
