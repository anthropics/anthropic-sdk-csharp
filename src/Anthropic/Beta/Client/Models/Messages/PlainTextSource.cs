using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<PlainTextSource>))]
public sealed record class PlainTextSource : ModelBase, IFromRaw<PlainTextSource>
{
    public required string Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("data");
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("media_type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["media_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
