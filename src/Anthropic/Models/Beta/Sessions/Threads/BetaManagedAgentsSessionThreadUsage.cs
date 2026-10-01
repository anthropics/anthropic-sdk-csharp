using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// Cumulative token usage for a session thread across all turns.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadUsage,
        BetaManagedAgentsSessionThreadUsageFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadUsage : JsonModel
{
    /// <summary>
    /// Cumulative time in seconds this thread spent in running status. Equal to
    /// `stats.active_seconds`; surfaced here so a thread's usage carries every quantity
    /// its cost is priced on.
    /// </summary>
    public double? ActiveSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("active_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active_seconds", value);
        }
    }

    /// <summary>
    /// Tokens used to create prompt cache entries, broken down by cache TTL.
    /// </summary>
    public BetaManagedAgentsCacheCreationUsage? CacheCreation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsCacheCreationUsage>(
                "cache_creation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cache_creation", value);
        }
    }

    /// <summary>
    /// Total tokens read from prompt cache.
    /// </summary>
    public int? CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("cache_read_input_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cache_read_input_tokens", value);
        }
    }

    /// <summary>
    /// Total input tokens consumed across all turns.
    /// </summary>
    public int? InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("input_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input_tokens", value);
        }
    }

    /// <summary>
    /// Cumulative list cost of this thread across all turns, priced at public list
    /// rates. Absent until cost tracking is available for the thread. Each figure
    /// is rounded to the nearest cent independently and the session's aggregate
    /// `usage.list_cost` additionally includes session runtime, so per-thread costs
    /// do not sum exactly to the session figure; the session figure is authoritative
    /// and is what a budget is enforced against.
    /// </summary>
    public BetaMonetaryAmount? ListCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaMonetaryAmount>("list_cost");
        }
        init { this._rawData.Set("list_cost", value); }
    }

    /// <summary>
    /// Total output tokens generated across all turns.
    /// </summary>
    public int? OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("output_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("output_tokens", value);
        }
    }

    /// <summary>
    /// Cumulative server-executed tool usage across all turns of this thread. Absent
    /// until server-tool tracking is available for the thread.
    /// </summary>
    public BetaManagedAgentsServerToolUsage? ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsServerToolUsage>(
                "server_tool_use"
            );
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveSeconds;
        this.CacheCreation?.Validate();
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        this.ListCost?.Validate();
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public BetaManagedAgentsSessionThreadUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadUsage(
        BetaManagedAgentsSessionThreadUsage betaManagedAgentsSessionThreadUsage
    )
        : base(betaManagedAgentsSessionThreadUsage) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadUsageFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadUsageFromRaw : IFromRawJson<BetaManagedAgentsSessionThreadUsage>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadUsage.FromRawUnchecked(rawData);
}
