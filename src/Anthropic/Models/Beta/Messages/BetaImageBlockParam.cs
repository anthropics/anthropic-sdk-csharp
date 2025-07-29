using Anthropic = Anthropic;
using BetaImageBlockParamProperties = Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaImageBlockParam>))]
public sealed record class BetaImageBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaImageBlockParam>
{
    public required BetaImageBlockParamProperties::Source Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaImageBlockParamProperties::Source>(element)
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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Source.Validate();
        this.CacheControl?.Validate();
    }

    public BetaImageBlockParam()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaImageBlockParam(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaImageBlockParam FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
