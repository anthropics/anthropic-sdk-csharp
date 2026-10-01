using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Point-in-time snapshot of a session's cumulative usage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionUsageSnapshot,
        BetaManagedAgentsSessionUsageSnapshotFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionUsageSnapshot : JsonModel
{
    /// <summary>
    /// Cumulative time in seconds during which the session had at least one thread
    /// in running status. Overlapping activity from concurrent threads is counted
    /// once. This is the duration the session's runtime cost is priced on.
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
    /// Cumulative list cost of the session across all turns, priced at public list rates.
    /// </summary>
    public BetaMonetaryAmount? ListCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaMonetaryAmount>("list_cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("list_cost", value);
        }
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
    /// Cumulative server-executed tool usage across all turns.
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("server_tool_use", value);
        }
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

    public BetaManagedAgentsSessionUsageSnapshot() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionUsageSnapshot(
        BetaManagedAgentsSessionUsageSnapshot betaManagedAgentsSessionUsageSnapshot
    )
        : base(betaManagedAgentsSessionUsageSnapshot) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionUsageSnapshot(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionUsageSnapshot(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionUsageSnapshotFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionUsageSnapshot FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionUsageSnapshotFromRaw
    : IFromRawJson<BetaManagedAgentsSessionUsageSnapshot>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionUsageSnapshot FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionUsageSnapshot.FromRawUnchecked(rawData);
}
