using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<PlainTextSource>))]
public sealed record class PlainTextSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<PlainTextSource>
{
    public required string Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "data",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "media_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["media_type"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Data;
    }

    public PlainTextSource()
    {
        this.MediaType = JsonSerializer.Deserialize<JsonElement>("\"text/plain\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlainTextSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlainTextSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PlainTextSource(string data)
        : this()
    {
        this.Data = data;
    }
}
