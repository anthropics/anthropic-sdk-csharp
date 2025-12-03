using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMessageDeltaUsage, BetaMessageDeltaUsageFromRaw>))]
public sealed record class BetaMessageDeltaUsage : ModelBase
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(this.RawData, "cache_creation_input_tokens");
        }
        init { ModelBase.Set(this._rawData, "cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "cache_read_input_tokens"); }
        init { ModelBase.Set(this._rawData, "cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "input_tokens"); }
        init { ModelBase.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { ModelBase.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            return ModelBase.GetNullableClass<BetaServerToolUsage>(this.RawData, "server_tool_use");
        }
        init { ModelBase.Set(this._rawData, "server_tool_use", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public BetaMessageDeltaUsage() { }

    public BetaMessageDeltaUsage(BetaMessageDeltaUsage betaMessageDeltaUsage)
        : base(betaMessageDeltaUsage) { }

    public BetaMessageDeltaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageDeltaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageDeltaUsageFromRaw.FromRawUnchecked"/>
    public static BetaMessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageDeltaUsageFromRaw : IFromRaw<BetaMessageDeltaUsage>
{
    /// <inheritdoc/>
    public BetaMessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageDeltaUsage.FromRawUnchecked(rawData);
}
