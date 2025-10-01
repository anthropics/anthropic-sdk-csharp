using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties;

namespace Anthropic.Client.Models.Beta.Messages.Batches;

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
    public required List<Request> Requests
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("requests", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'requests' cannot be null",
                    new ArgumentOutOfRangeException("requests", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Request>>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'requests' cannot be null",
                    new ArgumentNullException("requests")
                );
        }
        set
        {
            this.BodyProperties["requests"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public List<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("betas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, AnthropicBeta>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.HeaderProperties["betas"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches?beta=true"
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IAnthropicClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
