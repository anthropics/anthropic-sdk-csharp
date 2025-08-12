using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<ThinkingConfigDisabled>))]
public sealed record class ThinkingConfigDisabled
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ThinkingConfigDisabled>
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

    public ThinkingConfigDisabled()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigDisabled(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThinkingConfigDisabled FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
