using Anthropic = Anthropic;
using BetaCacheControlEphemeralProperties = Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaCacheControlEphemeral>))]
public sealed record class BetaCacheControlEphemeral
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCacheControlEphemeral>
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

    /// <summary>
    /// The time-to-live for the cache control breakpoint.
    ///
    /// This may be one the following values: - `5m`: 5 minutes - `1h`: 1 hour
    ///
    /// Defaults to `5m`.
    /// </summary>
    public BetaCacheControlEphemeralProperties::TTL? TTL
    {
        get
        {
            if (!this.Properties.TryGetValue("ttl", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCacheControlEphemeralProperties::TTL?>(
                element
            );
        }
        set { this.Properties["ttl"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        if (!this.Type.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"ephemeral\"")))
        {
            throw new System::Exception();
        }
        this.TTL?.Validate();
    }

    public BetaCacheControlEphemeral()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaCacheControlEphemeral(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCacheControlEphemeral FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
