using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<SearchResultBlockParam>))]
public sealed record class SearchResultBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<SearchResultBlockParam>
{
    public required List<TextBlockParam> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<TextBlockParam>>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("content");
        }
        set { this.Properties["content"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("source");
        }
        set { this.Properties["source"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("title");
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

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CitationsConfigParam?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["citations"] = JsonSerializer.SerializeToElement(value); }
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
