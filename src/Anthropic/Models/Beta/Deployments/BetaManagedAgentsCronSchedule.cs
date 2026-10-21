using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// 5-field POSIX cron schedule with computed runtime timestamps.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsCronSchedule, BetaManagedAgentsCronScheduleFromRaw>)
)]
public sealed record class BetaManagedAgentsCronSchedule : JsonModel
{
    /// <summary>
    /// 5-field POSIX cron expression: minute hour day-of-month month day-of-week
    /// (e.g., "0 9 * * 1-5" for weekdays at 9am). Day-of-week is 0-7 where 0 and
    /// 7 both mean Sunday. Extended cron syntax - seconds or year fields, and the
    /// special characters L, W, #, and ? - is not supported, nor are predefined shortcuts (@daily).
    /// </summary>
    public required string Expression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expression");
        }
        init { this._rawData.Set("expression", value); }
    }

    /// <summary>
    /// IANA timezone identifier (e.g., "America/Los_Angeles", "UTC").
    /// </summary>
    public required string Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

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
    /// Time the most recent scheduled run actually started. Null until one completes;
    /// preserved after the deployment is archived. Manual runs do not update this.
    /// </summary>
    public DateTimeOffset? LastRunAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_run_at");
        }
        init { this._rawData.Set("last_run_at", value); }
    }

    /// <summary>
    /// Up to 5 timestamps of upcoming cron occurrences. Non-empty for active and
    /// paused deployments (reflects what the schedule would do if unpaused); empty
    /// once the deployment is archived (`archived_at` set). Each fire is offset
    /// by a small per-schedule jitter, so a run will actually start at or shortly
    /// after its listed time.
    /// </summary>
    public IReadOnlyList<DateTimeOffset>? UpcomingRunsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DateTimeOffset>>(
                "upcoming_runs_at"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("upcoming_runs_at");
                return;
            }

            this._rawData.Set<ImmutableArray<DateTimeOffset>?>(
                "upcoming_runs_at",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Expression;
        _ = this.Timezone;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("cron")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.LastRunAt;
        _ = this.UpcomingRunsAt;
    }

    public BetaManagedAgentsCronSchedule()
    {
        this.Type = JsonSerializer.SerializeToElement("cron");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCronSchedule(
        BetaManagedAgentsCronSchedule betaManagedAgentsCronSchedule
    )
        : base(betaManagedAgentsCronSchedule) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCronSchedule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("cron");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCronSchedule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCronScheduleFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCronSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCronScheduleFromRaw : IFromRawJson<BetaManagedAgentsCronSchedule>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCronSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCronSchedule.FromRawUnchecked(rawData);
}
