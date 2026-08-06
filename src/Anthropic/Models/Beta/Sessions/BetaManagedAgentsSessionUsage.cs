using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Cumulative token usage for a session across all turns.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSessionUsage, BetaManagedAgentsSessionUsageFromRaw>)
)]
public sealed record class BetaManagedAgentsSessionUsage : JsonModel
{
    /// <summary>
    /// Cumulative time in seconds during which the session had at least one thread
    /// in running status. Overlapping activity from concurrent threads is counted
    /// once, unlike `stats.active_seconds`, which sums each thread's own active
    /// time. This is the duration the session's runtime cost is priced on.
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
    /// Prompt-cache creation token usage broken down by cache lifetime.
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
    /// A monetary amount in a specific currency.
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
    /// Cumulative count of server-executed tool invocations, broken down by tool.
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

    public BetaManagedAgentsSessionUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionUsage(
        BetaManagedAgentsSessionUsage betaManagedAgentsSessionUsage
    )
        : base(betaManagedAgentsSessionUsage) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionUsageFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionUsageFromRaw : IFromRawJson<BetaManagedAgentsSessionUsage>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionUsage.FromRawUnchecked(rawData);
}
