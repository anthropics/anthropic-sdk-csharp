using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using BatchCreateParamsProperties = Anthropic.Models.Messages.Batches.BatchCreateParamsProperties;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Send a batch of Message creation requests.
///
/// The Message Batches API can be used to process multiple Messages API requests
/// at once. Once a Message Batch is created, it begins processing immediately. Batches
/// can take up to 24 hours to complete.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// List of requests for prompt completion. Each is an individual request to create
    /// a Message.
    /// </summary>
    public required List<BatchCreateParamsProperties::Request> Requests
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("requests", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "requests",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<BatchCreateParamsProperties::Request>>(element)
                ?? throw new global::System.ArgumentNullException("requests");
        }
        set { this.BodyProperties["requests"] = JsonSerializer.SerializeToElement(value); }
    }

    public override global::System.Uri Url(IAnthropicClient client)
    {
        return new global::System.UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches"
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
