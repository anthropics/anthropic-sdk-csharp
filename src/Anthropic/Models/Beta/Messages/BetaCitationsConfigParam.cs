using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaCitationsConfigParam>))]
public sealed record class BetaCitationsConfigParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCitationsConfigParam>
{
    public bool? Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["enabled"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaCitationsConfigParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsConfigParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationsConfigParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
