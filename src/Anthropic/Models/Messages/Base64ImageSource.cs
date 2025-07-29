using Anthropic = Anthropic;
using Base64ImageSourceProperties = Anthropic.Models.Messages.Base64ImageSourceProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<Base64ImageSource>))]
public sealed record class Base64ImageSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<Base64ImageSource>
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

    public required Base64ImageSourceProperties::MediaType MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "media_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Base64ImageSourceProperties::MediaType>(element)
                ?? throw new System::ArgumentNullException("media_type");
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

    public Base64ImageSource()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Base64ImageSource(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Base64ImageSource FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
