using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<CacheControlEphemeral>))]
public sealed record class CacheControlEphemeral
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CacheControlEphemeral>
{
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

    public override void Validate() { }

    public CacheControlEphemeral()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CacheControlEphemeral(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CacheControlEphemeral FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
