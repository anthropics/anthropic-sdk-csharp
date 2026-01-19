using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMessageTokensCount, BetaMessageTokensCountFromRaw>))]
public sealed record class BetaMessageTokensCount : JsonModel
{
    /// <summary>
    /// Information about context management applied to the message.
    /// </summary>
    public required BetaCountTokensContextManagementResponse? ContextManagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCountTokensContextManagementResponse>(
                "context_management"
            );
        }
        init { this._rawData.Set("context_management", value); }
    }

    /// <summary>
    /// The total number of tokens across the provided list of messages, system prompt,
    /// and tools.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContextManagement?.Validate();
        _ = this.InputTokens;
    }

    public BetaMessageTokensCount() { }

    public BetaMessageTokensCount(BetaMessageTokensCount betaMessageTokensCount)
        : base(betaMessageTokensCount) { }

    public BetaMessageTokensCount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageTokensCount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageTokensCountFromRaw.FromRawUnchecked"/>
    public static BetaMessageTokensCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageTokensCountFromRaw : IFromRawJson<BetaMessageTokensCount>
{
    /// <inheritdoc/>
    public BetaMessageTokensCount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageTokensCount.FromRawUnchecked(rawData);
}
