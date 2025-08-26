using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationsConfigParam>))]
public sealed record class CitationsConfigParam : ModelBase, IFromRaw<CitationsConfigParam>
{
    public bool? Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
