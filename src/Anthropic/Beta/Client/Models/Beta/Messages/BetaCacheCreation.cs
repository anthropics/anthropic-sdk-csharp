using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCacheCreation>))]
public sealed record class BetaCacheCreation : ModelBase, IFromRaw<BetaCacheCreation>
{
    /// <summary>
    /// The number of input tokens used to create the 1 hour cache entry.
    /// </summary>
    public required long Ephemeral1hInputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("ephemeral_1h_input_tokens", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "ephemeral_1h_input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ephemeral_1h_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens used to create the 5 minute cache entry.
    /// </summary>
    public required long Ephemeral5mInputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("ephemeral_5m_input_tokens", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "ephemeral_5m_input_tokens",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ephemeral_5m_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public BetaCacheCreation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheCreation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCacheCreation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
