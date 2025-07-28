using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using ImageBlockParamProperties = Anthropic.Models.Messages.ImageBlockParamProperties;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<ImageBlockParam>))]
public sealed record class ImageBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ImageBlockParam>
{
    public required ImageBlockParamProperties::Source Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ImageBlockParamProperties::Source>(element)
                ?? throw new System::ArgumentNullException("source");
        }
        set { this.Properties["source"] = Json::JsonSerializer.SerializeToElement(value); }
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Source.Validate();
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"image\"")))
        {
            throw new System::Exception();
        }
        this.CacheControl?.Validate();
    }

    public ImageBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ImageBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ImageBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
