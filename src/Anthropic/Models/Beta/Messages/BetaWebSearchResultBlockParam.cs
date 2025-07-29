using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaWebSearchResultBlockParam>))]
public sealed record class BetaWebSearchResultBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaWebSearchResultBlockParam>
{
    public required string EncryptedContent
    {
        get
        {
            if (!this.Properties.TryGetValue("encrypted_content", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "encrypted_content",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("encrypted_content");
        }
        set
        {
            this.Properties["encrypted_content"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required string Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("title", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("title");
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

    public string? PageAge
    {
        get
        {
            if (!this.Properties.TryGetValue("page_age", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["page_age"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EncryptedContent;
        _ = this.Title;
        _ = this.URL;
        _ = this.PageAge;
    }

    public BetaWebSearchResultBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"web_search_result\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaWebSearchResultBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebSearchResultBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
