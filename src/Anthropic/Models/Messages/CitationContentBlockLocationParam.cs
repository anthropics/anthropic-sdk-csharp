using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<CitationContentBlockLocationParam>))]
public sealed record class CitationContentBlockLocationParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CitationContentBlockLocationParam>
{
    public required string CitedText
    {
        get
        {
            if (!this.Properties.TryGetValue("cited_text", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cited_text",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("cited_text");
        }
        set { this.Properties["cited_text"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long DocumentIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("document_index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "document_index",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["document_index"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? DocumentTitle
    {
        get
        {
            if (!this.Properties.TryGetValue("document_title", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "document_title",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["document_title"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long EndBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("end_block_index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_block_index",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["end_block_index"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long StartBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("start_block_index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_block_index",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["start_block_index"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndBlockIndex;
        _ = this.StartBlockIndex;
    }

    public CitationContentBlockLocationParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"content_block_location\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CitationContentBlockLocationParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationContentBlockLocationParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
