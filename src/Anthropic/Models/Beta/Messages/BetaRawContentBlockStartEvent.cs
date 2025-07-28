using Anthropic = Anthropic;
using BetaRawContentBlockStartEventProperties = Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaRawContentBlockStartEvent>))]
public sealed record class BetaRawContentBlockStartEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRawContentBlockStartEvent>
{
    /// <summary>
    /// Response model for a file uploaded to the container.
    /// </summary>
    public required BetaRawContentBlockStartEventProperties::ContentBlock ContentBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("content_block", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content_block",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaRawContentBlockStartEventProperties::ContentBlock>(
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

    public BetaRawContentBlockStartEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaRawContentBlockStartEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawContentBlockStartEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
