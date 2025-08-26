using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingDelta>))]
public sealed record class BetaThinkingDelta : ModelBase, IFromRaw<BetaThinkingDelta>
{
    public required string Thinking
    {
        get
        {
            if (!this.Properties.TryGetValue("thinking", out JsonElement element))
                throw new ArgumentOutOfRangeException("thinking", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("thinking");
        }
        set
        {
            this.Properties["thinking"] = JsonSerializer.SerializeToElement(
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
        _ = this.Thinking;
    }

    public BetaThinkingDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaThinkingDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaThinkingDelta(string thinking)
        : this()
    {
        this.Thinking = thinking;
    }
}
