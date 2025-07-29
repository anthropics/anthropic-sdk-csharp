using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<TextBlockParam>))]
public sealed record class TextBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<TextBlockParam>
{
    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("text", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("text");
        }
        set { this.Properties["text"] = Json::JsonSerializer.SerializeToElement(value); }
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
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Generic::List<TextCitationParam>? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<TextCitationParam>?>(element);
        }
        set { this.Properties["citations"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Text;
        this.CacheControl?.Validate();
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public TextBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TextBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
