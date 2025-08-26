using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawMessageStopEvent>))]
public sealed record class RawMessageStopEvent : ModelBase, IFromRaw<RawMessageStopEvent>
{
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

    public override void Validate() { }

    public RawMessageStopEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageStopEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawMessageStopEvent FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
