using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<ThinkingConfigDisabled>))]
public sealed record class ThinkingConfigDisabled
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ThinkingConfigDisabled>
{
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

    public override void Validate() { }

    public ThinkingConfigDisabled()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"disabled\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ThinkingConfigDisabled(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThinkingConfigDisabled FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
