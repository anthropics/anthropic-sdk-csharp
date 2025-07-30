using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CitationsDeltaProperties = Anthropic.Models.Messages.CitationsDeltaProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationsDelta>))]
public sealed record class CitationsDelta : ModelBase, IFromRaw<CitationsDelta>
{
    public required CitationsDeltaProperties::Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "citation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CitationsDeltaProperties::Citation>(element)
                ?? throw new global::System.ArgumentNullException("citation");
        }
        set { this.Properties["citation"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Citation.Validate();
    }

    public CitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationsDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
