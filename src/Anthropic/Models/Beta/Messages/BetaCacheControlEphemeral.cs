using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaCacheControlEphemeralProperties = Anthropic.Models.Beta.Messages.BetaCacheControlEphemeralProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaCacheControlEphemeral>))]
public sealed record class BetaCacheControlEphemeral
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCacheControlEphemeral>
{
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
            if (!this.Properties.TryGetValue("ttl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeralProperties::TTL?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["ttl"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.TTL?.Validate();
    }

    public BetaCacheControlEphemeral()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheControlEphemeral(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCacheControlEphemeral FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
