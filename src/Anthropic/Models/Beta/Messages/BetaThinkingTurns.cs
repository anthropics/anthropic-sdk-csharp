using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingTurns, BetaThinkingTurnsFromRaw>))]
public sealed record class BetaThinkingTurns : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required long Value
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BetaThinkingTurns()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"");
    }

    public BetaThinkingTurns(BetaThinkingTurns betaThinkingTurns)
        : base(betaThinkingTurns) { }

    public BetaThinkingTurns(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingTurns(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaThinkingTurnsFromRaw : IFromRaw<BetaThinkingTurns>
{
    /// <inheritdoc/>
    public BetaThinkingTurns FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingTurns.FromRawUnchecked(rawData);
}
