using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Beta.Client.Models.Beta.Messages.BetaCitationsDeltaProperties;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationsDelta>))]
public sealed record class BetaCitationsDelta : ModelBase, IFromRaw<BetaCitationsDelta>
{
    public required Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out JsonElement element))
                throw new ArgumentOutOfRangeException("citation", "Missing required argument");

            return JsonSerializer.Deserialize<Citation>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("citation");
        }
        set
        {
            this.Properties["citation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    public BetaCitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}
