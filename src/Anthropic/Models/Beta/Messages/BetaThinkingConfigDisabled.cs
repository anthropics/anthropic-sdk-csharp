using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaThinkingConfigDisabled>))]
public sealed record class BetaThinkingConfigDisabled
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaThinkingConfigDisabled>
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

    public override void Validate()
    {
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"disabled\"")))
        {
            throw new System::Exception();
        }
    }

    public BetaThinkingConfigDisabled()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"disabled\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaThinkingConfigDisabled(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaThinkingConfigDisabled FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
