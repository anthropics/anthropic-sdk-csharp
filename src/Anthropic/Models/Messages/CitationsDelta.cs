using Anthropic = Anthropic;
using CitationsDeltaProperties = Anthropic.Models.Messages.CitationsDeltaProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<CitationsDelta>))]
public sealed record class CitationsDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CitationsDelta>
{
    public required CitationsDeltaProperties::Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "citation",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CitationsDeltaProperties::Citation>(element)
                ?? throw new System::ArgumentNullException("citation");
        }
        set { this.Properties["citation"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Citation.Validate();
    }

    public CitationsDelta()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CitationsDelta(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationsDelta FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
