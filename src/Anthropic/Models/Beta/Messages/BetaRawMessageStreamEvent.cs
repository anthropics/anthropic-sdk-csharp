using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public record class BetaRawMessageStreamEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                start: (x) => x.Type,
                delta: (x) => x.Type,
                stop: (x) => x.Type,
                contentBlockStart: (x) => x.Type,
                contentBlockDelta: (x) => x.Type,
                contentBlockStop: (x) => x.Type
            );
        }
    }

    public long? Index
    {
        get
        {
            return Match<long?>(
                start: (_) => null,
                delta: (_) => null,
                stop: (_) => null,
                contentBlockStart: (x) => x.Index,
                contentBlockDelta: (x) => x.Index,
                contentBlockStop: (x) => x.Index
            );
        }
    }

    public BetaRawMessageStreamEvent(BetaRawMessageStartEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageStopEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(
        BetaRawContentBlockStopEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawMessageStreamEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawMessageStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStart(out var value)) {
    ///     // `value` is of type `BetaRawMessageStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStart([NotNullWhen(true)] out BetaRawMessageStartEvent? value)
    {
        value = this.Value as BetaRawMessageStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawMessageDeltaEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDelta(out var value)) {
    ///     // `value` is of type `BetaRawMessageDeltaEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDelta([NotNullWhen(true)] out BetaRawMessageDeltaEvent? value)
    {
        value = this.Value as BetaRawMessageDeltaEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawMessageStopEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStop(out var value)) {
    ///     // `value` is of type `BetaRawMessageStopEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStop([NotNullWhen(true)] out BetaRawMessageStopEvent? value)
    {
        value = this.Value as BetaRawMessageStopEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawContentBlockStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockStart(out var value)) {
    ///     // `value` is of type `BetaRawContentBlockStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockStart(
        [NotNullWhen(true)] out BetaRawContentBlockStartEvent? value
    )
    {
        value = this.Value as BetaRawContentBlockStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawContentBlockDeltaEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockDelta(out var value)) {
    ///     // `value` is of type `BetaRawContentBlockDeltaEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockDelta(
        [NotNullWhen(true)] out BetaRawContentBlockDeltaEvent? value
    )
    {
        value = this.Value as BetaRawContentBlockDeltaEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRawContentBlockStopEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockStop(out var value)) {
    ///     // `value` is of type `BetaRawContentBlockStopEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockStop([NotNullWhen(true)] out BetaRawContentBlockStopEvent? value)
    {
        value = this.Value as BetaRawContentBlockStopEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (BetaRawMessageStartEvent value) => {...},
    ///     (BetaRawMessageDeltaEvent value) => {...},
    ///     (BetaRawMessageStopEvent value) => {...},
    ///     (BetaRawContentBlockStartEvent value) => {...},
    ///     (BetaRawContentBlockDeltaEvent value) => {...},
    ///     (BetaRawContentBlockStopEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaRawMessageStartEvent> start,
        System::Action<BetaRawMessageDeltaEvent> delta,
        System::Action<BetaRawMessageStopEvent> stop,
        System::Action<BetaRawContentBlockStartEvent> contentBlockStart,
        System::Action<BetaRawContentBlockDeltaEvent> contentBlockDelta,
        System::Action<BetaRawContentBlockStopEvent> contentBlockStop
    )
    {
        switch (this.Value)
        {
            case BetaRawMessageStartEvent value:
                start(value);
                break;
            case BetaRawMessageDeltaEvent value:
                delta(value);
                break;
            case BetaRawMessageStopEvent value:
                stop(value);
                break;
            case BetaRawContentBlockStartEvent value:
                contentBlockStart(value);
                break;
            case BetaRawContentBlockDeltaEvent value:
                contentBlockDelta(value);
                break;
            case BetaRawContentBlockStopEvent value:
                contentBlockStop(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRawMessageStreamEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (BetaRawMessageStartEvent value) => {...},
    ///     (BetaRawMessageDeltaEvent value) => {...},
    ///     (BetaRawMessageStopEvent value) => {...},
    ///     (BetaRawContentBlockStartEvent value) => {...},
    ///     (BetaRawContentBlockDeltaEvent value) => {...},
    ///     (BetaRawContentBlockStopEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaRawMessageStartEvent, T> start,
        System::Func<BetaRawMessageDeltaEvent, T> delta,
        System::Func<BetaRawMessageStopEvent, T> stop,
        System::Func<BetaRawContentBlockStartEvent, T> contentBlockStart,
        System::Func<BetaRawContentBlockDeltaEvent, T> contentBlockDelta,
        System::Func<BetaRawContentBlockStopEvent, T> contentBlockStop
    )
    {
        return this.Value switch
        {
            BetaRawMessageStartEvent value => start(value),
            BetaRawMessageDeltaEvent value => delta(value),
            BetaRawMessageStopEvent value => stop(value),
            BetaRawContentBlockStartEvent value => contentBlockStart(value),
            BetaRawContentBlockDeltaEvent value => contentBlockDelta(value),
            BetaRawContentBlockStopEvent value => contentBlockStop(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            ),
        };
    }

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStartEvent value) =>
        new(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value) =>
        new(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStopEvent value) =>
        new(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value
    ) => new(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value
    ) => new(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value) =>
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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            );
        }
        this.Switch(
            (start) => start.Validate(),
            (delta) => delta.Validate(),
            (stop) => stop.Validate(),
            (contentBlockStart) => contentBlockStart.Validate(),
            (contentBlockDelta) => contentBlockDelta.Validate(),
            (contentBlockStop) => contentBlockStop.Validate()
        );
    }

    public virtual bool Equals(BetaRawMessageStreamEvent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class BetaRawMessageStreamEventConverter : JsonConverter<BetaRawMessageStreamEvent>
{
    public override BetaRawMessageStreamEvent? Read(
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
            case "message_start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStartEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "message_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageDeltaEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "message_stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStopEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "content_block_start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "content_block_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDeltaEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "content_block_stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStopEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaRawMessageStreamEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
