using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<TextDelta>))]
public sealed record class TextDelta : Anthropic::ModelBase, Anthropic::IFromRaw<TextDelta>
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

    public override void Validate()
    {
        _ = this.Text;
    }

    public TextDelta()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"text_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TextDelta(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextDelta FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
