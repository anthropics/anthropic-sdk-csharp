using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(Anthropic::ModelConverter<BetaToolChoiceNone>))]
public sealed record class BetaToolChoiceNone
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaToolChoiceNone>
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

    public BetaToolChoiceNone()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceNone(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaToolChoiceNone FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
