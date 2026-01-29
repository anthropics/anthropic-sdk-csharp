using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaThinkingTurns, BetaThinkingTurnsFromRaw>))]
public sealed record class BetaThinkingTurns : JsonModel
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

    public required long Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thinking_turns")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BetaThinkingTurns()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking_turns");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingTurns(BetaThinkingTurns betaThinkingTurns)
        : base(betaThinkingTurns) { }
#pragma warning restore CS8618

    public BetaThinkingTurns(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking_turns");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingTurns(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingTurnsFromRaw.FromRawUnchecked"/>
    public static BetaThinkingTurns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaThinkingTurns(long value)
        : this()
    {
        this.Value = value;
    }
}

class BetaThinkingTurnsFromRaw : IFromRawJson<BetaThinkingTurns>
{
    /// <inheritdoc/>
    public BetaThinkingTurns FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingTurns.FromRawUnchecked(rawData);
}
