using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaCacheCreation, BetaCacheCreationFromRaw>))]
public sealed record class BetaCacheCreation : JsonModel
{
    /// <summary>
    /// The number of input tokens used to create the 1 hour cache entry.
    /// </summary>
    public required long Ephemeral1hInputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "ephemeral_1h_input_tokens"); }
        init { JsonModel.Set(this._rawData, "ephemeral_1h_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the 5 minute cache entry.
    /// </summary>
    public required long Ephemeral5mInputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "ephemeral_5m_input_tokens"); }
        init { JsonModel.Set(this._rawData, "ephemeral_5m_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public BetaCacheCreation() { }

    public BetaCacheCreation(BetaCacheCreation betaCacheCreation)
        : base(betaCacheCreation) { }

    public BetaCacheCreation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheCreation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheCreationFromRaw.FromRawUnchecked"/>
    public static BetaCacheCreation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCacheCreationFromRaw : IFromRawJson<BetaCacheCreation>
{
    /// <inheritdoc/>
    public BetaCacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCacheCreation.FromRawUnchecked(rawData);
}
