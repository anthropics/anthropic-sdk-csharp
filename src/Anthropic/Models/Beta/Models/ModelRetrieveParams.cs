using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// Get a specific model.
///
/// The Models API response can be used to determine information about a specific
/// model or resolve a model alias to a model ID.
/// </summary>
public sealed record class ModelRetrieveParams : Anthropic::ParamsBase
{
    public required string ModelID;

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

    public override Uri Url(Anthropic::IAnthropicClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/models/{0}?beta=true", this.ModelID)
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
