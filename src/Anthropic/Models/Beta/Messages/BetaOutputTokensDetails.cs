using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaOutputTokensDetails, BetaOutputTokensDetailsFromRaw>))]
public sealed record class BetaOutputTokensDetails : JsonModel
{
    /// <summary>
    /// Number of output tokens the model generated as internal reasoning, including
    /// the thinking-block delimiter tokens.
    ///
    /// <para>Reflects the raw reasoning the model produced, not the (possibly shorter)
    /// summarized thinking text returned in the response body. Computed by re-tokenizing
    /// the raw reasoning text, so it may differ from the model's exact generation
    /// count by a small number of tokens. Always ≤ `output_tokens`; `output_tokens
    /// - thinking_tokens` approximates the non-reasoning output.</para>
    /// </summary>
    public required long ThinkingTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("thinking_tokens");
        }
        init { this._rawData.Set("thinking_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ThinkingTokens;
    }

    public BetaOutputTokensDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOutputTokensDetails(BetaOutputTokensDetails betaOutputTokensDetails)
        : base(betaOutputTokensDetails) { }
#pragma warning restore CS8618

    public BetaOutputTokensDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOutputTokensDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOutputTokensDetailsFromRaw.FromRawUnchecked"/>
    public static BetaOutputTokensDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOutputTokensDetails(long thinkingTokens)
        : this()
    {
        this.ThinkingTokens = thinkingTokens;
    }
}

class BetaOutputTokensDetailsFromRaw : IFromRawJson<BetaOutputTokensDetails>
{
    /// <inheritdoc/>
    public BetaOutputTokensDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOutputTokensDetails.FromRawUnchecked(rawData);
}
