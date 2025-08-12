using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaThinkingDelta>))]
public sealed record class BetaThinkingDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaThinkingDelta>
{
    public required string Thinking
    {
        get
        {
            if (!this.Properties.TryGetValue("thinking", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "thinking",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("thinking");
        }
        set { this.Properties["thinking"] = JsonSerializer.SerializeToElement(value); }
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
