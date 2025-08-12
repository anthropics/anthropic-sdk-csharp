using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic = Anthropic;
using BatchCreateParamsProperties = Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties;
using Beta = Anthropic.Models.Beta;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// Send a batch of Message creation requests.
///
/// The Message Batches API can be used to process multiple Messages API requests
/// at once. Once a Message Batch is created, it begins processing immediately. Batches
/// can take up to 24 hours to complete.
///
/// Learn more about the Message Batches API in our [user guide](/en/docs/build-with-claude/batch-processing)
/// </summary>
public sealed record class BatchCreateParams : Anthropic::ParamsBase
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

            return JsonSerializer.Deserialize<List<BatchCreateParamsProperties::Request>>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("requests");
        }
        set { this.BodyProperties["requests"] = JsonSerializer.SerializeToElement(value); }
    }

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
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches?beta=true"
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

    public void AddHeadersToRequest(HttpRequestMessage request, Anthropic::IAnthropicClient client)
    {
        Anthropic::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Anthropic::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
