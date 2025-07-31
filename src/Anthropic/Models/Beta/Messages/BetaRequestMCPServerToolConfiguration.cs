using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestMCPServerToolConfiguration>))]
public sealed record class BetaRequestMCPServerToolConfiguration
    : ModelBase,
        IFromRaw<BetaRequestMCPServerToolConfiguration>
{
    public List<string>? AllowedTools
    {
        get
        {
            if (!this.Properties.TryGetValue("allowed_tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["allowed_tools"] = JsonSerializer.SerializeToElement(value); }
    }

    public bool? Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["enabled"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.AllowedTools ?? [])
        {
            _ = item;
        }
        _ = this.Enabled;
    }

    public BetaRequestMCPServerToolConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMCPServerToolConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRequestMCPServerToolConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
