using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;
using System = System;

namespace Anthropic.Models.Beta.Files;

/// <summary>
/// Upload File
/// </summary>
public sealed record class FileUploadParams : Anthropic::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The file to upload
    /// </summary>
    public required string File
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("file", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("file", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("file");
        }
        set { this.BodyProperties["file"] = JsonSerializer.SerializeToElement(value); }
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

    public override System::Uri Url(Anthropic::IAnthropicClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/files?beta=true"
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
