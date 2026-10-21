using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Periodic snapshot of the session's cumulative usage and tracked list cost.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionUsageEvent,
        BetaManagedAgentsSessionUsageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionUsageEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp when the snapshot was taken.
    /// </summary>
    public required System::DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionUsageEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionUsageEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The session's cumulative usage at the snapshot time.
    /// </summary>
    public required BetaManagedAgentsSessionUsageSnapshot Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionUsageSnapshot>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// The session's configured budget at the snapshot time, or null when the session
    /// has no budget.
    /// </summary>
    public BetaManagedAgentsBudgetLimit? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsBudgetLimit>("budget");
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        this.Type.Validate();
        this.Usage.Validate();
        this.Budget?.Validate();
    }

    public BetaManagedAgentsSessionUsageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionUsageEvent(
        BetaManagedAgentsSessionUsageEvent betaManagedAgentsSessionUsageEvent
    )
        : base(betaManagedAgentsSessionUsageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionUsageEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionUsageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionUsageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionUsageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionUsageEventFromRaw : IFromRawJson<BetaManagedAgentsSessionUsageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionUsageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionUsageEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionUsageEventTypeConverter))]
public enum BetaManagedAgentsSessionUsageEventType
{
    SessionUsage,
}

sealed class BetaManagedAgentsSessionUsageEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionUsageEventType>
{
    public override BetaManagedAgentsSessionUsageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.usage" => BetaManagedAgentsSessionUsageEventType.SessionUsage,
            _ => (BetaManagedAgentsSessionUsageEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionUsageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionUsageEventType.SessionUsage => "session.usage",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
