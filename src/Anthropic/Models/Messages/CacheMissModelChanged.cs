using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CacheMissModelChanged, CacheMissModelChangedFromRaw>))]
public sealed record class CacheMissModelChanged : JsonModel
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

    public CacheMissModelChanged()
    {
        this.Type = JsonSerializer.SerializeToElement("model_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CacheMissModelChanged(CacheMissModelChanged cacheMissModelChanged)
        : base(cacheMissModelChanged) { }
#pragma warning restore CS8618

    public CacheMissModelChanged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("model_changed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheMissModelChanged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheMissModelChangedFromRaw.FromRawUnchecked"/>
    public static CacheMissModelChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CacheMissModelChanged(long cacheMissedInputTokens)
        : this()
    {
        this.CacheMissedInputTokens = cacheMissedInputTokens;
    }
}

class CacheMissModelChangedFromRaw : IFromRawJson<CacheMissModelChanged>
{
    /// <inheritdoc/>
    public CacheMissModelChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CacheMissModelChanged.FromRawUnchecked(rawData);
}
