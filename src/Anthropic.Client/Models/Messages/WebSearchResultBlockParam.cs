using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

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
                throw new AnthropicInvalidDataException(
                    "'encrypted_content' cannot be null",
                    new ArgumentOutOfRangeException(
                        "encrypted_content",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'encrypted_content' cannot be null",
                    new ArgumentNullException("encrypted_content")
                );
        }
        set
        {
            this.Properties["encrypted_content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentNullException("title")
                );
        }
        set
        {
            this.Properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? PageAge
    {
        get
        {
            if (!this.Properties.TryGetValue("page_age", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["page_age"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
