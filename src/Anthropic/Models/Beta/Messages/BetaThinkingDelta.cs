using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaThinkingDelta, BetaThinkingDeltaFromRaw>))]
public sealed record class BetaThinkingDelta : JsonModel
{
    public required string Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
    }

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
        _ = this.Thinking;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thinking_delta")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingDelta(BetaThinkingDelta betaThinkingDelta)
        : base(betaThinkingDelta) { }
#pragma warning restore CS8618

    public BetaThinkingDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BetaThinkingDeltaFromRaw : IFromRawJson<BetaThinkingDelta>
{
    /// <inheritdoc/>
    public BetaThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingDelta.FromRawUnchecked(rawData);
}
