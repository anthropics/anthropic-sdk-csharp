using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingDelta, BetaThinkingDeltaFromRaw>))]
public sealed record class BetaThinkingDelta : ModelBase
{
    public required string Thinking
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "thinking"); }
        init { ModelBase.Set(this._rawData, "thinking", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Thinking;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

    public BetaThinkingDelta(BetaThinkingDelta betaThinkingDelta)
        : base(betaThinkingDelta) { }

    public BetaThinkingDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingDeltaFromRaw.FromRawUnchecked"/>
    public static BetaThinkingDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaThinkingDelta(string thinking)
        : this()
    {
        this.Thinking = thinking;
    }
}

class BetaThinkingDeltaFromRaw : IFromRaw<BetaThinkingDelta>
{
    /// <inheritdoc/>
    public BetaThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingDelta.FromRawUnchecked(rawData);
}
