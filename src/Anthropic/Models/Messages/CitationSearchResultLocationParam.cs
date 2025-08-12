using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<CitationSearchResultLocationParam>))]
public sealed record class CitationSearchResultLocationParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CitationSearchResultLocationParam>
{
    public required string CitedText
    {
        get
        {
            if (!this.Properties.TryGetValue("cited_text", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "cited_text",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("cited_text");
        }
        set { this.Properties["cited_text"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long EndBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("end_block_index", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "end_block_index",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_block_index"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long SearchResultIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("search_result_index", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "search_result_index",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["search_result_index"] = JsonSerializer.SerializeToElement(value); }
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

    public required long StartBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("start_block_index", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "start_block_index",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["start_block_index"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "title",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
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

    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EndBlockIndex;
        _ = this.SearchResultIndex;
        _ = this.Source;
        _ = this.StartBlockIndex;
        _ = this.Title;
    }

    public CitationSearchResultLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationSearchResultLocationParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationSearchResultLocationParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
