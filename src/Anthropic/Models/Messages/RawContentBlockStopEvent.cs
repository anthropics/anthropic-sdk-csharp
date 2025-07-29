using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<RawContentBlockStopEvent>))]
public sealed record class RawContentBlockStopEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<RawContentBlockStopEvent>
{
    public required long Index
    {
        get
        {
            if (!this.Properties.TryGetValue("index", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("index", "Missing required argument");

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["index"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.Index;
    }

    public RawContentBlockStopEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_stop\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RawContentBlockStopEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawContentBlockStopEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
