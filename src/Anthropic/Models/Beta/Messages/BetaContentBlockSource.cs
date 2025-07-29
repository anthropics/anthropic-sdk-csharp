using Anthropic = Anthropic;
using BetaContentBlockSourceProperties = Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaContentBlockSource>))]
public sealed record class BetaContentBlockSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaContentBlockSource>
{
    public required BetaContentBlockSourceProperties::Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaContentBlockSourceProperties::Content>(
                    element
                ) ?? throw new System::ArgumentNullException("content");
        }
        set { this.Properties["content"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Content.Validate();
    }

    public BetaContentBlockSource()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"content\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaContentBlockSource(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContentBlockSource FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
