using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaURLPDFSource>))]
public sealed record class BetaURLPDFSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaURLPDFSource>
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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "url",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.URL;
    }

    public BetaURLPDFSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaURLPDFSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaURLPDFSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaURLPDFSource(string url)
        : this()
    {
        this.URL = url;
    }
}
