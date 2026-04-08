using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Events that were successfully sent to the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSendSessionEvents,
        BetaManagedAgentsSendSessionEventsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSendSessionEvents : JsonModel
{
    /// <summary>
    /// Sent events
    /// </summary>
    public IReadOnlyList<Data>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public BetaManagedAgentsSendSessionEvents() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSendSessionEvents(
        BetaManagedAgentsSendSessionEvents betaManagedAgentsSendSessionEvents
    )
        : base(betaManagedAgentsSendSessionEvents) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSendSessionEvents(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSendSessionEvents(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSendSessionEventsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSendSessionEvents FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSendSessionEventsFromRaw : IFromRawJson<BetaManagedAgentsSendSessionEvents>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSendSessionEvents FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSendSessionEvents.FromRawUnchecked(rawData);
}

/// <summary>
/// Union type for events that can be sent to a session.
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
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

    public string ID
    {
        get
        {
            return Match(
                betaManagedAgentsUserMessageEvent: (x) => x.ID,
                betaManagedAgentsUserInterruptEvent: (x) => x.ID,
                betaManagedAgentsUserToolConfirmationEvent: (x) => x.ID,
                betaManagedAgentsUserCustomToolResultEvent: (x) => x.ID
            );
        }
    }

    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                betaManagedAgentsUserMessageEvent: (x) => x.ProcessedAt,
                betaManagedAgentsUserInterruptEvent: (x) => x.ProcessedAt,
                betaManagedAgentsUserToolConfirmationEvent: (x) => x.ProcessedAt,
                betaManagedAgentsUserCustomToolResultEvent: (x) => x.ProcessedAt
            );
        }
    }

    public Data(BetaManagedAgentsUserMessageEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(BetaManagedAgentsUserInterruptEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(BetaManagedAgentsUserToolConfirmationEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(BetaManagedAgentsUserCustomToolResultEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserMessageEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUserMessageEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserMessageEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUserMessageEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserMessageEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserMessageEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserInterruptEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUserInterruptEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserInterruptEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUserInterruptEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserInterruptEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserInterruptEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserToolConfirmationEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUserToolConfirmationEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserToolConfirmationEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUserToolConfirmationEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserToolConfirmationEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserToolConfirmationEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserCustomToolResultEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUserCustomToolResultEvent(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserCustomToolResultEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUserCustomToolResultEvent(
        [NotNullWhen(true)] out BetaManagedAgentsUserCustomToolResultEvent? value
    )
    {
        value = this.Value as BetaManagedAgentsUserCustomToolResultEvent;
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
    ///     (BetaManagedAgentsUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUserMessageEvent> betaManagedAgentsUserMessageEvent,
        System::Action<BetaManagedAgentsUserInterruptEvent> betaManagedAgentsUserInterruptEvent,
        System::Action<BetaManagedAgentsUserToolConfirmationEvent> betaManagedAgentsUserToolConfirmationEvent,
        System::Action<BetaManagedAgentsUserCustomToolResultEvent> betaManagedAgentsUserCustomToolResultEvent
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUserMessageEvent value:
                betaManagedAgentsUserMessageEvent(value);
                break;
            case BetaManagedAgentsUserInterruptEvent value:
                betaManagedAgentsUserInterruptEvent(value);
                break;
            case BetaManagedAgentsUserToolConfirmationEvent value:
                betaManagedAgentsUserToolConfirmationEvent(value);
                break;
            case BetaManagedAgentsUserCustomToolResultEvent value:
                betaManagedAgentsUserCustomToolResultEvent(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Data");
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
    ///     (BetaManagedAgentsUserMessageEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserInterruptEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserToolConfirmationEvent value) =&gt; {...},
    ///     (BetaManagedAgentsUserCustomToolResultEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUserMessageEvent, T> betaManagedAgentsUserMessageEvent,
        System::Func<BetaManagedAgentsUserInterruptEvent, T> betaManagedAgentsUserInterruptEvent,
        System::Func<
            BetaManagedAgentsUserToolConfirmationEvent,
            T
        > betaManagedAgentsUserToolConfirmationEvent,
        System::Func<
            BetaManagedAgentsUserCustomToolResultEvent,
            T
        > betaManagedAgentsUserCustomToolResultEvent
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUserMessageEvent value => betaManagedAgentsUserMessageEvent(value),
            BetaManagedAgentsUserInterruptEvent value => betaManagedAgentsUserInterruptEvent(value),
            BetaManagedAgentsUserToolConfirmationEvent value =>
                betaManagedAgentsUserToolConfirmationEvent(value),
            BetaManagedAgentsUserCustomToolResultEvent value =>
                betaManagedAgentsUserCustomToolResultEvent(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Data"),
        };
    }

    public static implicit operator Data(BetaManagedAgentsUserMessageEvent value) => new(value);

    public static implicit operator Data(BetaManagedAgentsUserInterruptEvent value) => new(value);

    public static implicit operator Data(BetaManagedAgentsUserToolConfirmationEvent value) =>
        new(value);

    public static implicit operator Data(BetaManagedAgentsUserCustomToolResultEvent value) =>
        new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch(
            (betaManagedAgentsUserMessageEvent) => betaManagedAgentsUserMessageEvent.Validate(),
            (betaManagedAgentsUserInterruptEvent) => betaManagedAgentsUserInterruptEvent.Validate(),
            (betaManagedAgentsUserToolConfirmationEvent) =>
                betaManagedAgentsUserToolConfirmationEvent.Validate(),
            (betaManagedAgentsUserCustomToolResultEvent) =>
                betaManagedAgentsUserCustomToolResultEvent.Validate()
        );
    }

    public virtual bool Equals(Data? other) =>
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
            BetaManagedAgentsUserMessageEvent _ => 0,
            BetaManagedAgentsUserInterruptEvent _ => 1,
            BetaManagedAgentsUserToolConfirmationEvent _ => 2,
            BetaManagedAgentsUserCustomToolResultEvent _ => 3,
            _ => -1,
        };
    }
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
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
            case "user.message":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEvent>(
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
            case "user.interrupt":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserInterruptEvent>(
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
            case "user.tool_confirmation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEvent>(
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
            case "user.custom_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEvent>(
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
                return new Data(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
