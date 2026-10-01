using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// The tokens that a dream has used so far.
///
/// <para>The counts are zero while the dream is `pending` and update while it is
/// `running`. They can keep changing after a cancel.</para>
///
/// <para>See the [Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#billing)
/// for how dreams are billed. See the [prompt caching guide](https://platform.claude.com/docs/en/build-with-claude/prompt-caching#tracking-cache-performance)
/// for how the input token counts add up.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamUsage, BetaDreamUsageFromRaw>))]
public sealed record class BetaDreamUsage : JsonModel
{
    /// <summary>
    /// The dream's input tokens that were written to the prompt cache, for both the
    /// 5-minute and 1-hour cache durations.
    /// </summary>
    public required int CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The dream's input tokens that were read from the prompt cache.
    /// </summary>
    public required int CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The dream's input tokens that weren't read from or written to the prompt cache.
    /// </summary>
    public required int InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// The tokens that the model generated for the dream.
    /// </summary>
    public required int OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
    }

    public BetaDreamUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamUsage(BetaDreamUsage betaDreamUsage)
        : base(betaDreamUsage) { }
#pragma warning restore CS8618

    public BetaDreamUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamUsageFromRaw.FromRawUnchecked"/>
    public static BetaDreamUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDreamUsageFromRaw : IFromRawJson<BetaDreamUsage>
{
    /// <inheritdoc/>
    public BetaDreamUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDreamUsage.FromRawUnchecked(rawData);
}
