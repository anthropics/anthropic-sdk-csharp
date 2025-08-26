using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextDelta>))]
public sealed record class BetaTextDelta : ModelBase, IFromRaw<BetaTextDelta>
{
    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out JsonElement element))
                throw new ArgumentOutOfRangeException("text", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("text");
        }
        set
        {
            this.Properties["text"] = JsonSerializer.SerializeToElement(
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
        _ = this.Text;
    }

    public BetaTextDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaTextDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaTextDelta(string text)
        : this()
    {
        this.Text = text;
    }
}
