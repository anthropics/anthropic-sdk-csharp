using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaThinkingConfigDisabled>))]
public sealed record class BetaThinkingConfigDisabled
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaThinkingConfigDisabled>
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

    public BetaThinkingConfigDisabled()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"disabled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingConfigDisabled(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaThinkingConfigDisabled FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
