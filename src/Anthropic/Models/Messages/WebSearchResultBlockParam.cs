using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchResultBlockParam>))]
public sealed record class WebSearchResultBlockParam
    : ModelBase,
        IFromRaw<WebSearchResultBlockParam>
{
    public required string EncryptedContent
    {
        get
        {
            if (!this.Properties.TryGetValue("encrypted_content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "encrypted_content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("encrypted_content");
        }
        set { this.Properties["encrypted_content"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "title",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("title");
        }
        set { this.Properties["title"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "url",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? PageAge
    {
        get
        {
            if (!this.Properties.TryGetValue("page_age", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["page_age"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.Title;
        _ = this.URL;
        _ = this.PageAge;
    }

    public WebSearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
