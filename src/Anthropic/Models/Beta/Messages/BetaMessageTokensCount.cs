using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

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
            if (!this._rawData.TryGetValue("context_management", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCountTokensContextManagementResponse?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["context_management"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input_tokens' cannot be null",
                    new ArgumentOutOfRangeException("input_tokens", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["input_tokens"] = JsonSerializer.SerializeToElement(
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

    public BetaMessageTokensCount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageTokensCount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaMessageTokensCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
