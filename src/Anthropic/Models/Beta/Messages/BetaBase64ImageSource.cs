using Anthropic = Anthropic;
using BetaBase64ImageSourceProperties = Anthropic.Models.Beta.Messages.BetaBase64ImageSourceProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaBase64ImageSource>))]
public sealed record class BetaBase64ImageSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaBase64ImageSource>
{
    public required string Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required BetaBase64ImageSourceProperties::MediaType MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "media_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaBase64ImageSourceProperties::MediaType>(
                    element
                ) ?? throw new System::ArgumentNullException("media_type");
        }
        set { this.Properties["media_type"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.Data;
        this.MediaType.Validate();
    }

    public BetaBase64ImageSource()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaBase64ImageSource(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaBase64ImageSource FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
