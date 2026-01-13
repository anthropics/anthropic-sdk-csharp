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
        BetaClearToolUses20250919EditResponse,
        BetaClearToolUses20250919EditResponseFromRaw
    >)
)]
public sealed record class BetaClearToolUses20250919EditResponse : JsonModel
{
    /// <summary>
    /// Number of input tokens cleared by this edit.
    /// </summary>
    public required long ClearedInputTokens
    {
        get { return this._rawData.GetNotNullStruct<long>("cleared_input_tokens"); }
        init { this._rawData.Set("cleared_input_tokens", value); }
    }

    /// <summary>
    /// Number of tool uses that were cleared.
    /// </summary>
    public required long ClearedToolUses
    {
        get { return this._rawData.GetNotNullStruct<long>("cleared_tool_uses"); }
        init { this._rawData.Set("cleared_tool_uses", value); }
    }

    /// <summary>
    /// The type of context management edit applied.
    /// </summary>
    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClearedInputTokens;
        _ = this.ClearedToolUses;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClearToolUses20250919EditResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

    public BetaClearToolUses20250919EditResponse(
        BetaClearToolUses20250919EditResponse betaClearToolUses20250919EditResponse
    )
        : base(betaClearToolUses20250919EditResponse) { }

    public BetaClearToolUses20250919EditResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_tool_uses_20250919\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919EditResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClearToolUses20250919EditResponseFromRaw.FromRawUnchecked"/>
    public static BetaClearToolUses20250919EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClearToolUses20250919EditResponseFromRaw
    : IFromRawJson<BetaClearToolUses20250919EditResponse>
{
    /// <inheritdoc/>
    public BetaClearToolUses20250919EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClearToolUses20250919EditResponse.FromRawUnchecked(rawData);
}
