using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaNotFoundError>))]
public sealed record class BetaNotFoundError
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaNotFoundError>
{
    public required string Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("message");
        }
        set { this.Properties["message"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.Message;
    }

    public BetaNotFoundError()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"not_found_error\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaNotFoundError(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaNotFoundError FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
