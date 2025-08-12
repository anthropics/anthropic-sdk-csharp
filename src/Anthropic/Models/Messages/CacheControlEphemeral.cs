using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<CacheControlEphemeral>))]
public sealed record class CacheControlEphemeral
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CacheControlEphemeral>
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

    public override void Validate() { }

    public CacheControlEphemeral()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheControlEphemeral(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CacheControlEphemeral FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
