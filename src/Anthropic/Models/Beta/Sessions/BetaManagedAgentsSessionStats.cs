using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Timing statistics for a session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSessionStats, BetaManagedAgentsSessionStatsFromRaw>)
)]
public sealed record class BetaManagedAgentsSessionStats : JsonModel
{
    /// <summary>
    /// Cumulative time in seconds the session spent in running status. Excludes idle time.
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
    /// Elapsed time since session creation in seconds. For terminated sessions,
    /// frozen at the final update.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveSeconds;
        _ = this.DurationSeconds;
    }

    public BetaManagedAgentsSessionStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionStats(
        BetaManagedAgentsSessionStats betaManagedAgentsSessionStats
    )
        : base(betaManagedAgentsSessionStats) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionStatsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionStatsFromRaw : IFromRawJson<BetaManagedAgentsSessionStats>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionStats FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionStats.FromRawUnchecked(rawData);
}
