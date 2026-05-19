using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Statistics about the work queue for an environment.
///
/// <para>Uses Redis Stream consumer group metrics for O(1) queries.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaSelfHostedWorkQueueStats, BetaSelfHostedWorkQueueStatsFromRaw>)
)]
public sealed record class BetaSelfHostedWorkQueueStats : JsonModel
{
    /// <summary>
    /// Number of work items waiting to be picked up (lag from consumer group)
    /// </summary>
    public required long Depth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("depth");
        }
        init { this._rawData.Set("depth", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp of oldest item in the work stream (includes both queued
    /// and pending items), null if stream empty
    /// </summary>
    public required string? OldestQueuedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("oldest_queued_at");
        }
        init { this._rawData.Set("oldest_queued_at", value); }
    }

    /// <summary>
    /// Number of work items being processed (polled but not acknowledged)
    /// </summary>
    public required long Pending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pending");
        }
        init { this._rawData.Set("pending", value); }
    }

    /// <summary>
    /// The type of object
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Number of workers that have polled for work in the last 30 seconds. Requires
    /// worker_id to be sent with poll requests.
    /// </summary>
    public required long? WorkersPolling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("workers_polling");
        }
        init { this._rawData.Set("workers_polling", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Depth;
        _ = this.OldestQueuedAt;
        _ = this.Pending;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("work_queue_stats")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkersPolling;
    }

    public BetaSelfHostedWorkQueueStats()
    {
        this.Type = JsonSerializer.SerializeToElement("work_queue_stats");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWorkQueueStats(BetaSelfHostedWorkQueueStats betaSelfHostedWorkQueueStats)
        : base(betaSelfHostedWorkQueueStats) { }
#pragma warning restore CS8618

    public BetaSelfHostedWorkQueueStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("work_queue_stats");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWorkQueueStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkQueueStatsFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWorkQueueStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedWorkQueueStatsFromRaw : IFromRawJson<BetaSelfHostedWorkQueueStats>
{
    /// <inheritdoc/>
    public BetaSelfHostedWorkQueueStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedWorkQueueStats.FromRawUnchecked(rawData);
}
