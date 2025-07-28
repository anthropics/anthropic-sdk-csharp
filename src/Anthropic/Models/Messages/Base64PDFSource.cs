using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<Base64PDFSource>))]
public sealed record class Base64PDFSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<Base64PDFSource>
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

    public Json::JsonElement MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "media_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
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
        if (
            !this.MediaType.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"application/pdf\"")
            )
        )
        {
            throw new System::Exception();
        }
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"base64\"")))
        {
            throw new System::Exception();
        }
    }

    public Base64PDFSource()
    {
        this.MediaType = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"application/pdf\"");
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Base64PDFSource(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Base64PDFSource FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
