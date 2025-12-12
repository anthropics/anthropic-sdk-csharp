using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CacheCreation, CacheCreationFromRaw>))]
public sealed record class CacheCreation : ModelBase
{
    /// <summary>
    /// The number of input tokens used to create the 1 hour cache entry.
    /// </summary>
    public required long Ephemeral1hInputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "ephemeral_1h_input_tokens"); }
        init { ModelBase.Set(this._rawData, "ephemeral_1h_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the 5 minute cache entry.
    /// </summary>
    public required long Ephemeral5mInputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "ephemeral_5m_input_tokens"); }
        init { ModelBase.Set(this._rawData, "ephemeral_5m_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public CacheCreation() { }

    public CacheCreation(CacheCreation cacheCreation)
        : base(cacheCreation) { }

    public CacheCreation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheCreation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheCreationFromRaw.FromRawUnchecked"/>
    public static CacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CacheCreationFromRaw : IFromRaw<CacheCreation>
{
    /// <inheritdoc/>
    public CacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CacheCreation.FromRawUnchecked(rawData);
}
