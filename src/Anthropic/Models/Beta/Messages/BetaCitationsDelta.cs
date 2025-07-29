using Anthropic = Anthropic;
using BetaCitationsDeltaProperties = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaCitationsDelta>))]
public sealed record class BetaCitationsDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCitationsDelta>
{
    public required BetaCitationsDeltaProperties::Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "citation",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaCitationsDeltaProperties::Citation>(element)
                ?? throw new System::ArgumentNullException("citation");
        }
        set { this.Properties["citation"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Citation.Validate();
    }

    public BetaCitationsDelta()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCitationsDelta(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationsDelta FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
