using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaCitationsDeltaProperties = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaCitationsDelta>))]
public sealed record class BetaCitationsDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCitationsDelta>
{
    public required BetaCitationsDeltaProperties::Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "citation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaCitationsDeltaProperties::Citation>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("citation");
        }
        set { this.Properties["citation"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public override void Validate()
    {
        this.Citation.Validate();
    }

    public BetaCitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationsDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaCitationsDelta(BetaCitationsDeltaProperties::Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}
