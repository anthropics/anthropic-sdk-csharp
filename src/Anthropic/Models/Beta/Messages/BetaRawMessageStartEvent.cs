using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaRawMessageStartEvent>))]
public sealed record class BetaRawMessageStartEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRawMessageStartEvent>
{
    public required BetaMessage Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaMessage>(element)
                ?? throw new System::ArgumentNullException("message");
        }
        set { this.Properties["message"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Message.Validate();
    }

    public BetaRawMessageStartEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"message_start\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaRawMessageStartEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawMessageStartEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
