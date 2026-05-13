using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCacheMissToolsChanged, BetaCacheMissToolsChangedFromRaw>)
)]
public sealed record class BetaCacheMissToolsChanged : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tools_changed")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCacheMissToolsChanged()
    {
        this.Type = JsonSerializer.SerializeToElement("tools_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCacheMissToolsChanged(BetaCacheMissToolsChanged betaCacheMissToolsChanged)
        : base(betaCacheMissToolsChanged) { }
#pragma warning restore CS8618

    public BetaCacheMissToolsChanged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tools_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheMissToolsChanged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheMissToolsChangedFromRaw.FromRawUnchecked"/>
    public static BetaCacheMissToolsChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCacheMissToolsChanged(long cacheMissedInputTokens)
        : this()
    {
        this.CacheMissedInputTokens = cacheMissedInputTokens;
    }
}

class BetaCacheMissToolsChangedFromRaw : IFromRawJson<BetaCacheMissToolsChanged>
{
    /// <inheritdoc/>
    public BetaCacheMissToolsChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCacheMissToolsChanged.FromRawUnchecked(rawData);
}
