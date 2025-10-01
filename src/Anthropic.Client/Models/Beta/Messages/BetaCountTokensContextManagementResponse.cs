using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCountTokensContextManagementResponse>))]
public sealed record class BetaCountTokensContextManagementResponse
    : ModelBase,
        IFromRaw<BetaCountTokensContextManagementResponse>
{
    /// <summary>
    /// The original token count before context management was applied
    /// </summary>
    public required long OriginalInputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("original_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'original_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "original_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["original_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.OriginalInputTokens;
    }

    public BetaCountTokensContextManagementResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCountTokensContextManagementResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCountTokensContextManagementResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaCountTokensContextManagementResponse(long originalInputTokens)
        : this()
    {
        this.OriginalInputTokens = originalInputTokens;
    }
}
