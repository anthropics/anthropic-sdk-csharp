using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageTokensCount>))]
public sealed record class MessageTokensCount : ModelBase, IFromRaw<MessageTokensCount>
{
    /// <summary>
    /// The total number of tokens across the provided list of messages, system prompt,
    /// and tools.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                throw new ArgumentOutOfRangeException("input_tokens", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.InputTokens;
    }

    public MessageTokensCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageTokensCount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageTokensCount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageTokensCount(long inputTokens)
        : this()
    {
        this.InputTokens = inputTokens;
    }
}
