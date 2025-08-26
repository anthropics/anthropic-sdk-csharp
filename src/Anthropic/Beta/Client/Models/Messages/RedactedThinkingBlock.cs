using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RedactedThinkingBlock>))]
public sealed record class RedactedThinkingBlock : ModelBase, IFromRaw<RedactedThinkingBlock>
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

    public RedactedThinkingBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RedactedThinkingBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RedactedThinkingBlock FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public RedactedThinkingBlock(string data)
        : this()
    {
        this.Data = data;
    }
}
