using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using RawContentBlockStartEventProperties = Anthropic.Models.Messages.RawContentBlockStartEventProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<RawContentBlockStartEvent>))]
public sealed record class RawContentBlockStartEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<RawContentBlockStartEvent>
{
    public required RawContentBlockStartEventProperties::ContentBlock ContentBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("content_block", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content_block",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<RawContentBlockStartEventProperties::ContentBlock>(
                    element
                ) ?? throw new System::ArgumentNullException("content_block");
        }
        set { this.Properties["content_block"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.ContentBlock.Validate();
        _ = this.Index;
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_start\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public RawContentBlockStartEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RawContentBlockStartEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawContentBlockStartEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
