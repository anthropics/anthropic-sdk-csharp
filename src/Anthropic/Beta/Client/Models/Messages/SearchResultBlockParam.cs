using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<SearchResultBlockParam>))]
public sealed record class SearchResultBlockParam : ModelBase, IFromRaw<SearchResultBlockParam>
{
    public required List<TextBlockParam> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new ArgumentOutOfRangeException("content", "Missing required argument");

            return JsonSerializer.Deserialize<List<TextBlockParam>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("content");
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                throw new ArgumentOutOfRangeException("source", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("source");
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
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
                throw new ArgumentOutOfRangeException("title", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("title");
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
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CitationsConfigParam?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["citations"] = JsonSerializer.SerializeToElement(
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
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public SearchResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SearchResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
