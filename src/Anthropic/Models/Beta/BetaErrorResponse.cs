using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaErrorResponse>))]
public sealed record class BetaErrorResponse
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaErrorResponse>
{
    public required BetaError Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("error", "Missing required argument");

            return Json::JsonSerializer.Deserialize<BetaError>(element)
                ?? throw new System::ArgumentNullException("error");
        }
        set { this.Properties["error"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Error.Validate();
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"error\"")))
        {
            throw new System::Exception();
        }
    }

    public BetaErrorResponse()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"error\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaErrorResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaErrorResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
