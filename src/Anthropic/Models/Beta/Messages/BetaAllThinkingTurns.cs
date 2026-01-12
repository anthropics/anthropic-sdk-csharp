using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaAllThinkingTurns, BetaAllThinkingTurnsFromRaw>))]
public sealed record class BetaAllThinkingTurns : JsonModel
{
    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"all\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAllThinkingTurns()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"all\"");
    }

    public BetaAllThinkingTurns(BetaAllThinkingTurns betaAllThinkingTurns)
        : base(betaAllThinkingTurns) { }

    public BetaAllThinkingTurns(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"all\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAllThinkingTurns(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAllThinkingTurnsFromRaw.FromRawUnchecked"/>
    public static BetaAllThinkingTurns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAllThinkingTurnsFromRaw : IFromRawJson<BetaAllThinkingTurns>
{
    /// <inheritdoc/>
    public BetaAllThinkingTurns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAllThinkingTurns.FromRawUnchecked(rawData);
}
