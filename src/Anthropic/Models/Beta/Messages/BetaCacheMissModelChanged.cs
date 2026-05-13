using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCacheMissModelChanged, BetaCacheMissModelChangedFromRaw>)
)]
public sealed record class BetaCacheMissModelChanged : JsonModel
{
    /// <summary>
    /// Approximate number of input tokens that would have been read from cache had
    /// the prefix matched the previous request.
    /// </summary>
    public required long CacheMissedInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_missed_input_tokens");
        }
        init { this._rawData.Set("cache_missed_input_tokens", value); }
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
        _ = this.CacheMissedInputTokens;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("model_changed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCacheMissModelChanged()
    {
        this.Type = JsonSerializer.SerializeToElement("model_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCacheMissModelChanged(BetaCacheMissModelChanged betaCacheMissModelChanged)
        : base(betaCacheMissModelChanged) { }
#pragma warning restore CS8618

    public BetaCacheMissModelChanged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("model_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheMissModelChanged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheMissModelChangedFromRaw.FromRawUnchecked"/>
    public static BetaCacheMissModelChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCacheMissModelChanged(long cacheMissedInputTokens)
        : this()
    {
        this.CacheMissedInputTokens = cacheMissedInputTokens;
    }
}

class BetaCacheMissModelChangedFromRaw : IFromRawJson<BetaCacheMissModelChanged>
{
    /// <inheritdoc/>
    public BetaCacheMissModelChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCacheMissModelChanged.FromRawUnchecked(rawData);
}
