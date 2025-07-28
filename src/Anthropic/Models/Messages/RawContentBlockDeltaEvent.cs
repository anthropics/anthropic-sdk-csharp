using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<RawContentBlockDeltaEvent>))]
public sealed record class RawContentBlockDeltaEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<RawContentBlockDeltaEvent>
{
    public required RawContentBlockDelta Delta
    {
        get
        {
            if (!this.Properties.TryGetValue("delta", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("delta", "Missing required argument");

            return Json::JsonSerializer.Deserialize<RawContentBlockDelta>(element)
                ?? throw new System::ArgumentNullException("delta");
        }
        set { this.Properties["delta"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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
        this.Delta.Validate();
        _ = this.Index;
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_delta\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public RawContentBlockDeltaEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RawContentBlockDeltaEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawContentBlockDeltaEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
