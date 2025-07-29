using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<SignatureDelta>))]
public sealed record class SignatureDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<SignatureDelta>
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
    }

    public SignatureDelta()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"signature_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    SignatureDelta(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SignatureDelta FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
