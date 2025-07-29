using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaToolChoiceNone>))]
public sealed record class BetaToolChoiceNone
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaToolChoiceNone>
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

    public BetaToolChoiceNone()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"none\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaToolChoiceNone(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolChoiceNone FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
