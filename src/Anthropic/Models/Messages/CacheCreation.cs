using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CacheCreation, CacheCreationFromRaw>))]
public sealed record class CacheCreation : JsonModel
{
    /// <summary>
    /// The number of input tokens used to create the 1 hour cache entry.
    /// </summary>
    public required long Ephemeral1hInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ephemeral_1h_input_tokens");
        }
        init { this._rawData.Set("ephemeral_1h_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the 5 minute cache entry.
    /// </summary>
    public required long Ephemeral5mInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ephemeral_5m_input_tokens");
        }
        init { this._rawData.Set("ephemeral_5m_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public CacheCreation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CacheCreation(CacheCreation cacheCreation)
        : base(cacheCreation) { }
#pragma warning restore CS8618

    public CacheCreation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheCreation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheCreationFromRaw.FromRawUnchecked"/>
    public static CacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CacheCreationFromRaw : IFromRawJson<CacheCreation>
{
    /// <inheritdoc/>
    public CacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CacheCreation.FromRawUnchecked(rawData);
}
