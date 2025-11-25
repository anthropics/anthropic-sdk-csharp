using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaCountTokensContextManagementResponse,
        BetaCountTokensContextManagementResponseFromRaw
    >)
)]
public sealed record class BetaCountTokensContextManagementResponse : ModelBase
{
    /// <summary>
    /// The original token count before context management was applied
    /// </summary>
    public required long OriginalInputTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("original_input_tokens", out JsonElement element))
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
            this._rawData["original_input_tokens"] = JsonSerializer.SerializeToElement(
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCountTokensContextManagementResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaCountTokensContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCountTokensContextManagementResponse(long originalInputTokens)
        : this()
    {
        this.OriginalInputTokens = originalInputTokens;
    }
}

class BetaCountTokensContextManagementResponseFromRaw
    : IFromRaw<BetaCountTokensContextManagementResponse>
{
    public BetaCountTokensContextManagementResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCountTokensContextManagementResponse.FromRawUnchecked(rawData);
}
