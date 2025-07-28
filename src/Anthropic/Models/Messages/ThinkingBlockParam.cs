using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<ThinkingBlockParam>))]
public sealed record class ThinkingBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ThinkingBlockParam>
{
    public required string Signature
    {
        get
        {
            if (!this.Properties.TryGetValue("signature", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "signature",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("signature");
        }
        set { this.Properties["signature"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Thinking
    {
        get
        {
            if (!this.Properties.TryGetValue("thinking", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "thinking",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("thinking");
        }
        set { this.Properties["thinking"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.Signature;
        _ = this.Thinking;
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"thinking\"")))
        {
            throw new System::Exception();
        }
    }

    public ThinkingBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"thinking\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ThinkingBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThinkingBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
