using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<RawMessageStopEvent>))]
public sealed record class RawMessageStopEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<RawMessageStopEvent>
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
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"message_stop\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public RawMessageStopEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"message_stop\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RawMessageStopEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawMessageStopEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
