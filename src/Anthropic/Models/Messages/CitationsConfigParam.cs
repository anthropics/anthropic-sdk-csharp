using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<CitationsConfigParam>))]
public sealed record class CitationsConfigParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<CitationsConfigParam>
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

    public CitationsConfigParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsConfigParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationsConfigParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
