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
/// A session thread has yielded and is awaiting input. Emitted on the thread's own
/// stream and cross-posted to the primary stream for child threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadStatusIdleEvent,
        BetaManagedAgentsSessionThreadStatusIdleEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadStatusIdleEvent : JsonModel
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
    /// Name of the agent the thread runs.
    /// </summary>
    public required string AgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agent_name");
        }
        init { this._rawData.Set("agent_name", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
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

    /// <summary>
    /// Public sthr_ ID of the thread that went idle.
    /// </summary>
    public required string SessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_thread_id");
        }
        init { this._rawData.Set("session_thread_id", value); }
    }

    /// <summary>
    /// The agent completed its turn naturally and is ready for the next user message.
    /// </summary>
    public required BetaManagedAgentsSessionThreadStatusIdleEventStopReason StopReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>(
                "stop_reason"
            );
        }
        init { this._rawData.Set("stop_reason", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadStatusIdleEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentName;
        _ = this.ProcessedAt;
        _ = this.SessionThreadID;
        this.StopReason.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionThreadStatusIdleEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadStatusIdleEvent(
        BetaManagedAgentsSessionThreadStatusIdleEvent betaManagedAgentsSessionThreadStatusIdleEvent
    )
        : base(betaManagedAgentsSessionThreadStatusIdleEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadStatusIdleEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadStatusIdleEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadStatusIdleEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadStatusIdleEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadStatusIdleEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionThreadStatusIdleEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadStatusIdleEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadStatusIdleEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// The agent completed its turn naturally and is ready for the next user message.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionThreadStatusIdleEventStopReasonConverter))]
public record class BetaManagedAgentsSessionThreadStatusIdleEventStopReason : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionEndTurn value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionRequiresAction value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionRetriesExhausted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionThreadStatusIdleEventStopReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionEndTurn"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionEndTurn(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionEndTurn`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionEndTurn(
        [NotNullWhen(true)] out BetaManagedAgentsSessionEndTurn? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionEndTurn;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionRequiresAction"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionRequiresAction(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionRequiresAction`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionRequiresAction(
        [NotNullWhen(true)] out BetaManagedAgentsSessionRequiresAction? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionRequiresAction;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionRetriesExhausted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsSessionRetriesExhausted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionRetriesExhausted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsSessionRetriesExhausted(
        [NotNullWhen(true)] out BetaManagedAgentsSessionRetriesExhausted? value
    )
    {
        value = this.Value as BetaManagedAgentsSessionRetriesExhausted;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaManagedAgentsSessionEndTurn value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRequiresAction value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRetriesExhausted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionEndTurn> betaManagedAgentsSessionEndTurn,
        System::Action<BetaManagedAgentsSessionRequiresAction> betaManagedAgentsSessionRequiresAction,
        System::Action<BetaManagedAgentsSessionRetriesExhausted> betaManagedAgentsSessionRetriesExhausted
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionEndTurn value:
                betaManagedAgentsSessionEndTurn(value);
                break;
            case BetaManagedAgentsSessionRequiresAction value:
                betaManagedAgentsSessionRequiresAction(value);
                break;
            case BetaManagedAgentsSessionRetriesExhausted value:
                betaManagedAgentsSessionRetriesExhausted(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionThreadStatusIdleEventStopReason"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaManagedAgentsSessionEndTurn value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRequiresAction value) =&gt; {...},
    ///     (BetaManagedAgentsSessionRetriesExhausted value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionEndTurn, T> betaManagedAgentsSessionEndTurn,
        System::Func<
            BetaManagedAgentsSessionRequiresAction,
            T
        > betaManagedAgentsSessionRequiresAction,
        System::Func<
            BetaManagedAgentsSessionRetriesExhausted,
            T
        > betaManagedAgentsSessionRetriesExhausted
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionEndTurn value => betaManagedAgentsSessionEndTurn(value),
            BetaManagedAgentsSessionRequiresAction value => betaManagedAgentsSessionRequiresAction(
                value
            ),
            BetaManagedAgentsSessionRetriesExhausted value =>
                betaManagedAgentsSessionRetriesExhausted(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionThreadStatusIdleEventStopReason"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionEndTurn value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionRequiresAction value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionThreadStatusIdleEventStopReason(
        BetaManagedAgentsSessionRetriesExhausted value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionThreadStatusIdleEventStopReason"
            );
        }
        this.Switch(
            (betaManagedAgentsSessionEndTurn) => betaManagedAgentsSessionEndTurn.Validate(),
            (betaManagedAgentsSessionRequiresAction) =>
                betaManagedAgentsSessionRequiresAction.Validate(),
            (betaManagedAgentsSessionRetriesExhausted) =>
                betaManagedAgentsSessionRetriesExhausted.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionThreadStatusIdleEventStopReason? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionEndTurn _ => 0,
            BetaManagedAgentsSessionRequiresAction _ => 1,
            BetaManagedAgentsSessionRetriesExhausted _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionThreadStatusIdleEventStopReasonConverter
    : JsonConverter<BetaManagedAgentsSessionThreadStatusIdleEventStopReason>
{
    public override BetaManagedAgentsSessionThreadStatusIdleEventStopReason? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "end_turn":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionEndTurn>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "requires_action":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionRequiresAction>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "retries_exhausted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsSessionRetriesExhausted>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaManagedAgentsSessionThreadStatusIdleEventStopReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadStatusIdleEventStopReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionThreadStatusIdleEventTypeConverter))]
public enum BetaManagedAgentsSessionThreadStatusIdleEventType
{
    SessionThreadStatusIdle,
}

sealed class BetaManagedAgentsSessionThreadStatusIdleEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionThreadStatusIdleEventType>
{
    public override BetaManagedAgentsSessionThreadStatusIdleEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.thread_status_idle" =>
                BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle,
            _ => (BetaManagedAgentsSessionThreadStatusIdleEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadStatusIdleEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionThreadStatusIdleEventType.SessionThreadStatusIdle =>
                    "session.thread_status_idle",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
