using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

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
            if (!this._properties.TryGetValue("original_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'original_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "original_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["original_input_tokens"] = JsonSerializer.SerializeToElement(
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

    public BetaCountTokensContextManagementResponse(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCountTokensContextManagementResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaCountTokensContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaCountTokensContextManagementResponse(long originalInputTokens)
        : this()
    {
        this.OriginalInputTokens = originalInputTokens;
    }
}
