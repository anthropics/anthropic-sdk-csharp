using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The reprice was applied: the retry is billed as if the conversation had been
/// on the retry model all along.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaFallbackCreditRedeemed, BetaFallbackCreditRedeemedFromRaw>)
)]
public sealed record class BetaFallbackCreditRedeemed : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("redeemed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFallbackCreditRedeemed()
    {
        this.Type = JsonSerializer.SerializeToElement("redeemed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackCreditRedeemed(BetaFallbackCreditRedeemed betaFallbackCreditRedeemed)
        : base(betaFallbackCreditRedeemed) { }
#pragma warning restore CS8618

    public BetaFallbackCreditRedeemed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("redeemed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackCreditRedeemed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackCreditRedeemedFromRaw.FromRawUnchecked"/>
    public static BetaFallbackCreditRedeemed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFallbackCreditRedeemedFromRaw : IFromRawJson<BetaFallbackCreditRedeemed>
{
    /// <inheritdoc/>
    public BetaFallbackCreditRedeemed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackCreditRedeemed.FromRawUnchecked(rawData);
}
