using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<SearchResultBlockParam>))]
public sealed record class SearchResultBlockParam : ModelBase, IFromRaw<SearchResultBlockParam>
{
    public required List<TextBlockParam> Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<TextBlockParam>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
                );
        }
        init
        {
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Source
    {
        get
        {
            if (!this._properties.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentNullException("source")
                );
        }
        init
        {
            this._properties["source"] = JsonSerializer.SerializeToElement(
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
                    new ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentNullException("title")
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
                    new ArgumentOutOfRangeException("type", "Missing required argument")
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            if (!this._properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CitationsConfigParam?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"search_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public SearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

    public SearchResultBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchResultBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SearchResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
