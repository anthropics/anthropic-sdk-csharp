using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<CitationPageLocation>))]
public sealed record class CitationPageLocation
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CitationPageLocation>
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

    public required long DocumentIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("document_index", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "document_index",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["document_index"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? DocumentTitle
    {
        get
        {
            if (!this.Properties.TryGetValue("document_title", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "document_title",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["document_title"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long EndPageNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("end_page_number", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "end_page_number",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_page_number"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "file_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["file_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long StartPageNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("start_page_number", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "start_page_number",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["start_page_number"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndPageNumber;
        _ = this.FileID;
        _ = this.StartPageNumber;
    }

    public CitationPageLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationPageLocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationPageLocation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
