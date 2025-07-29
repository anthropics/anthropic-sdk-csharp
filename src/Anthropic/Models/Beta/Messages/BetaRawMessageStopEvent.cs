using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaRawMessageStopEvent>))]
public sealed record class BetaRawMessageStopEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRawMessageStopEvent>
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

    public BetaRawMessageStopEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"message_stop\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaRawMessageStopEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawMessageStopEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
