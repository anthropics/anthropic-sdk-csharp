using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClearThinking20251015EditResponse,
        BetaClearThinking20251015EditResponseFromRaw
    >)
)]
public sealed record class BetaClearThinking20251015EditResponse : JsonModel
{
    /// <summary>
    /// Number of input tokens cleared by this edit.
    /// </summary>
    public required long ClearedInputTokens
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "cleared_input_tokens"); }
        init { JsonModel.Set(this._rawData, "cleared_input_tokens", value); }
    }

    /// <summary>
    /// Number of thinking turns that were cleared.
    /// </summary>
    public required long ClearedThinkingTurns
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "cleared_thinking_turns"); }
        init { JsonModel.Set(this._rawData, "cleared_thinking_turns", value); }
    }

    /// <summary>
    /// The type of context management edit applied.
    /// </summary>
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClearedInputTokens;
        _ = this.ClearedThinkingTurns;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClearThinking20251015EditResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

    public BetaClearThinking20251015EditResponse(
        BetaClearThinking20251015EditResponse betaClearThinking20251015EditResponse
    )
        : base(betaClearThinking20251015EditResponse) { }

    public BetaClearThinking20251015EditResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearThinking20251015EditResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClearThinking20251015EditResponseFromRaw.FromRawUnchecked"/>
    public static BetaClearThinking20251015EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClearThinking20251015EditResponseFromRaw
    : IFromRawJson<BetaClearThinking20251015EditResponse>
{
    /// <inheritdoc/>
    public BetaClearThinking20251015EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClearThinking20251015EditResponse.FromRawUnchecked(rawData);
}
