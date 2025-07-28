using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<GatewayTimeoutError>))]
public sealed record class GatewayTimeoutError
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<GatewayTimeoutError>
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
        if (
            !this.Type.Equals(
                Json::JsonSerializer.Deserialize<Json::JsonElement>("\"timeout_error\"")
            )
        )
        {
            throw new System::Exception();
        }
    }

    public GatewayTimeoutError()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"timeout_error\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    GatewayTimeoutError(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GatewayTimeoutError FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
