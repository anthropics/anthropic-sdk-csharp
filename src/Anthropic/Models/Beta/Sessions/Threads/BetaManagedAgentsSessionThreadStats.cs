using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Threads;

/// <summary>
/// Timing statistics for a session thread.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadStats,
        BetaManagedAgentsSessionThreadStatsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadStats : JsonModel
{
    /// <summary>
    /// Cumulative time in seconds the thread spent actively running. Excludes idle time.
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
    /// Elapsed time since thread creation in seconds. For archived threads, frozen
    /// at the final update.
    /// </summary>
    public double? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_seconds", value);
        }
    }

    /// <summary>
    /// Time in seconds for the thread to begin running. Zero for child threads, which
    /// start immediately.
    /// </summary>
    public double? StartupSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("startup_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startup_seconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveSeconds;
        _ = this.DurationSeconds;
        _ = this.StartupSeconds;
    }

    public BetaManagedAgentsSessionThreadStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadStats(
        BetaManagedAgentsSessionThreadStats betaManagedAgentsSessionThreadStats
    )
        : base(betaManagedAgentsSessionThreadStats) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadStatsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadStatsFromRaw : IFromRawJson<BetaManagedAgentsSessionThreadStats>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadStats.FromRawUnchecked(rawData);
}
