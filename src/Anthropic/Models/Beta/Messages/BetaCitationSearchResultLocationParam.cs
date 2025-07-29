using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::ModelConverter<BetaCitationSearchResultLocationParam>)
)]
public sealed record class BetaCitationSearchResultLocationParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCitationSearchResultLocationParam>
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

    public required long SearchResultIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("search_result_index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "search_result_index",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["search_result_index"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required string Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("source");
        }
        set { this.Properties["source"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public required string? Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("title", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["title"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.EndBlockIndex;
        _ = this.SearchResultIndex;
        _ = this.Source;
        _ = this.StartBlockIndex;
        _ = this.Title;
    }

    public BetaCitationSearchResultLocationParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"search_result_location\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCitationSearchResultLocationParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationSearchResultLocationParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
