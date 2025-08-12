using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;

namespace Anthropic.Models.Beta.Messages.Batches;

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

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public List<Beta::AnthropicBeta>? Betas
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("betas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Beta::AnthropicBeta>?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.HeaderProperties["betas"] = JsonSerializer.SerializeToElement(value); }
    }

    public override global::System.Uri Url(Anthropic::IAnthropicClient client)
    {
        return new global::System.UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/batches/{0}?beta=true", this.MessageBatchID)
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
