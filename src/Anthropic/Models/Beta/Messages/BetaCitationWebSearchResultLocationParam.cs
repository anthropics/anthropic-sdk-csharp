using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::ModelConverter<BetaCitationWebSearchResultLocationParam>)
)]
public sealed record class BetaCitationWebSearchResultLocationParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCitationWebSearchResultLocationParam>
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

    public required string EncryptedIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("encrypted_index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "encrypted_index",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("encrypted_index");
        }
        set { this.Properties["encrypted_index"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("url", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("url");
        }
        set { this.Properties["url"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EncryptedIndex;
        _ = this.Title;
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>(
                    "\"web_search_result_location\""
                )
            )
        )
        {
            throw new System::Exception();
        }
        _ = this.URL;
    }

    public BetaCitationWebSearchResultLocationParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"web_search_result_location\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCitationWebSearchResultLocationParam(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationWebSearchResultLocationParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
