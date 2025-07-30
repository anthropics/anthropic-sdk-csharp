using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Anthropic.Models.Beta.Models;

/// <summary>
/// List available models.
///
/// The Models API response can be used to determine which models are available for
/// use in the API. More recently released models are listed first.
/// </summary>
public sealed record class ModelListParams : ParamsBase
{
    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns the
    /// page of results immediately after this object.
    /// </summary>
    public string? AfterID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("after_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["after_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns the
    /// page of results immediately before this object.
    /// </summary>
    public string? BeforeID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("before_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["before_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Number of items to return per page.
    ///
    /// Defaults to `20`. Ranges from `1` to `1000`.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public List<AnthropicBeta>? Betas
    {
        get
        {
            if (!this.HeaderProperties.TryGetValue("betas", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AnthropicBeta>?>(element);
        }
        set { this.HeaderProperties["betas"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IAnthropicClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/models?beta=true")
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
