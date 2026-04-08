using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// An interrupt event that pauses agent execution and returns control to the user.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserInterruptEvent,
        BetaManagedAgentsUserInterruptEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserInterruptEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsUserInterruptEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserInterruptEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.ProcessedAt;
    }

    public BetaManagedAgentsUserInterruptEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEvent(
        BetaManagedAgentsUserInterruptEvent betaManagedAgentsUserInterruptEvent
    )
        : base(betaManagedAgentsUserInterruptEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserInterruptEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserInterruptEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserInterruptEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserInterruptEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserInterruptEventFromRaw : IFromRawJson<BetaManagedAgentsUserInterruptEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserInterruptEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserInterruptEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUserInterruptEventTypeConverter))]
public enum BetaManagedAgentsUserInterruptEventType
{
    UserInterrupt,
}

sealed class BetaManagedAgentsUserInterruptEventTypeConverter
    : JsonConverter<BetaManagedAgentsUserInterruptEventType>
{
    public override BetaManagedAgentsUserInterruptEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.interrupt" => BetaManagedAgentsUserInterruptEventType.UserInterrupt,
            _ => (BetaManagedAgentsUserInterruptEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserInterruptEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserInterruptEventType.UserInterrupt => "user.interrupt",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
