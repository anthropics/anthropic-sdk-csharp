using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<OutputTokensDetails, OutputTokensDetailsFromRaw>))]
public sealed record class OutputTokensDetails : JsonModel
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

    public OutputTokensDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputTokensDetails(OutputTokensDetails outputTokensDetails)
        : base(outputTokensDetails) { }
#pragma warning restore CS8618

    public OutputTokensDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputTokensDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputTokensDetailsFromRaw.FromRawUnchecked"/>
    public static OutputTokensDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OutputTokensDetails(long thinkingTokens)
        : this()
    {
        this.ThinkingTokens = thinkingTokens;
    }
}

class OutputTokensDetailsFromRaw : IFromRawJson<OutputTokensDetails>
{
    /// <inheritdoc/>
    public OutputTokensDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OutputTokensDetails.FromRawUnchecked(rawData);
}
