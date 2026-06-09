using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// 5-field POSIX cron schedule with computed runtime timestamps.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsSchedule, BetaManagedAgentsScheduleFromRaw>)
)]
public sealed record class BetaManagedAgentsSchedule : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsScheduleType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsScheduleType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? LastRunAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("last_run_at");
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
    public IReadOnlyList<System::DateTimeOffset>? UpcomingRunsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<System::DateTimeOffset>>(
                "upcoming_runs_at"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<System::DateTimeOffset>?>(
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
        this.Type.Validate();
        _ = this.LastRunAt;
        _ = this.UpcomingRunsAt;
    }

    public BetaManagedAgentsSchedule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSchedule(BetaManagedAgentsSchedule betaManagedAgentsSchedule)
        : base(betaManagedAgentsSchedule) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSchedule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSchedule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsScheduleFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsScheduleFromRaw : IFromRawJson<BetaManagedAgentsSchedule>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSchedule.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsScheduleTypeConverter))]
public enum BetaManagedAgentsScheduleType
{
    Cron,
}

sealed class BetaManagedAgentsScheduleTypeConverter : JsonConverter<BetaManagedAgentsScheduleType>
{
    public override BetaManagedAgentsScheduleType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cron" => BetaManagedAgentsScheduleType.Cron,
            _ => (BetaManagedAgentsScheduleType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsScheduleType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsScheduleType.Cron => "cron",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
