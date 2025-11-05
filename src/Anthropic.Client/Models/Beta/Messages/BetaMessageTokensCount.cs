using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMessageTokensCount>))]
public sealed record class BetaMessageTokensCount : ModelBase, IFromRaw<BetaMessageTokensCount>
{
    /// <summary>
    /// Information about context management applied to the message.
    /// </summary>
    public required BetaCountTokensContextManagementResponse? ContextManagement
    {
        get
        {
            if (!this.Properties.TryGetValue("context_management", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCountTokensContextManagementResponse?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["context_management"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total number of tokens across the provided list of messages, system prompt,
    /// and tools.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "input_tokens",
                        "Missing required argument"
                    )
                );

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
        this.ContextManagement?.Validate();
        _ = this.InputTokens;
    }

    public BetaMessageTokensCount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageTokensCount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageTokensCount FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
