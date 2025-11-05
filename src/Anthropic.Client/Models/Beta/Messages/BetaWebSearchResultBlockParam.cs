using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebSearchResultBlockParam>))]
public sealed record class BetaWebSearchResultBlockParam
    : ModelBase,
        IFromRaw<BetaWebSearchResultBlockParam>
{
    public required string EncryptedContent
    {
        get
        {
            if (!this._properties.TryGetValue("encrypted_content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'encrypted_content' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "encrypted_content",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'encrypted_content' cannot be null",
                    new System::ArgumentNullException("encrypted_content")
                );
        }
        init
        {
            this._properties["encrypted_content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Title
    {
        get
        {
            if (!this._properties.TryGetValue("title", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'title' cannot be null",
                    new System::ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'title' cannot be null",
                    new System::ArgumentNullException("title")
                );
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string URL
    {
        get
        {
            if (!this._properties.TryGetValue("url", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
                );
        }
        init
        {
            this._properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? PageAge
    {
        get
        {
            if (!this._properties.TryGetValue("page_age", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["page_age"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.Title;
        _ = this.Type;
        _ = this.URL;
        _ = this.PageAge;
    }

    public BetaWebSearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
    }

    public BetaWebSearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchResultBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaWebSearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
