using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaSearchResultBlockParam>))]
public sealed record class BetaSearchResultBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaSearchResultBlockParam>
{
    public required Generic::List<BetaTextBlockParam> Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<BetaTextBlockParam>>(element)
                ?? throw new System::ArgumentNullException("content");
        }
        set { this.Properties["content"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCitationsConfigParam?>(element);
        }
        set { this.Properties["citations"] = Json::JsonSerializer.SerializeToElement(value); }
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
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"search_result\"")
            )
        )
        {
            throw new System::Exception();
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
    }

    public BetaSearchResultBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"search_result\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaSearchResultBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaSearchResultBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
