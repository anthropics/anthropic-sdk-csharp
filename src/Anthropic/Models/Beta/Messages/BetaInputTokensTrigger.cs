using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaInputTokensTrigger, BetaInputTokensTriggerFromRaw>))]
public sealed record class BetaInputTokensTrigger : JsonModel
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

    public required long ValueValue
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("input_tokens")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValueValue;
    }

    public BetaInputTokensTrigger()
    {
        this.Type = JsonSerializer.SerializeToElement("input_tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInputTokensTrigger(BetaInputTokensTrigger betaInputTokensTrigger)
        : base(betaInputTokensTrigger) { }
#pragma warning restore CS8618

    public BetaInputTokensTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("input_tokens");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputTokensTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInputTokensTriggerFromRaw.FromRawUnchecked"/>
    public static BetaInputTokensTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaInputTokensTrigger(long valueValue)
        : this()
    {
        this.ValueValue = valueValue;
    }
}

class BetaInputTokensTriggerFromRaw : IFromRawJson<BetaInputTokensTrigger>
{
    /// <inheritdoc/>
    public BetaInputTokensTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInputTokensTrigger.FromRawUnchecked(rawData);
}
