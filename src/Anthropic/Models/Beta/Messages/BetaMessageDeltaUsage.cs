using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaMessageDeltaUsage, BetaMessageDeltaUsageFromRaw>))]
public sealed record class BetaMessageDeltaUsage : JsonModel
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Per-iteration token usage breakdown.
    ///
    /// <para>Each entry represents one sampling iteration, with its own input/output
    /// token counts and cache statistics. This allows you to: - Determine which
    /// iterations exceeded long context thresholds (>=200k tokens) - Calculate the
    /// true context window size from the last iteration - Understand token accumulation
    /// across server-side tool use loops</para>
    /// </summary>
    public required IReadOnlyList<UnnamedSchemaWithArrayParent0>? Iterations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UnnamedSchemaWithArrayParent0>>(
                "iterations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0>?>(
                "iterations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The cumulative number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaServerToolUsage>("server_tool_use");
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        foreach (var item in this.Iterations ?? [])
        {
            item.Validate();
        }
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public BetaMessageDeltaUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMessageDeltaUsage(BetaMessageDeltaUsage betaMessageDeltaUsage)
        : base(betaMessageDeltaUsage) { }
#pragma warning restore CS8618

    public BetaMessageDeltaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageDeltaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BetaMessageDeltaUsageFromRaw : IFromRawJson<BetaMessageDeltaUsage>
{
    /// <inheritdoc/>
    public BetaMessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageDeltaUsage.FromRawUnchecked(rawData);
}
