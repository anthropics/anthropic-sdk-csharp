using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawMessageStreamEventConverter))]
public record class RawMessageStreamEvent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public RawMessageStreamEvent(RawMessageStartEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(RawMessageDeltaEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(RawMessageStopEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(RawContentBlockStartEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(RawContentBlockDeltaEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(RawContentBlockStopEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawMessageStreamEvent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawMessageStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStart(out var value)) {
    ///     // `value` is of type `RawMessageStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStart([NotNullWhen(true)] out RawMessageStartEvent? value)
    {
        value = this.Value as RawMessageStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawMessageDeltaEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDelta(out var value)) {
    ///     // `value` is of type `RawMessageDeltaEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDelta([NotNullWhen(true)] out RawMessageDeltaEvent? value)
    {
        value = this.Value as RawMessageDeltaEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawMessageStopEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStop(out var value)) {
    ///     // `value` is of type `RawMessageStopEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStop([NotNullWhen(true)] out RawMessageStopEvent? value)
    {
        value = this.Value as RawMessageStopEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawContentBlockStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockStart(out var value)) {
    ///     // `value` is of type `RawContentBlockStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockStart([NotNullWhen(true)] out RawContentBlockStartEvent? value)
    {
        value = this.Value as RawContentBlockStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawContentBlockDeltaEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockDelta(out var value)) {
    ///     // `value` is of type `RawContentBlockDeltaEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockDelta([NotNullWhen(true)] out RawContentBlockDeltaEvent? value)
    {
        value = this.Value as RawContentBlockDeltaEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RawContentBlockStopEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlockStop(out var value)) {
    ///     // `value` is of type `RawContentBlockStopEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockStop([NotNullWhen(true)] out RawContentBlockStopEvent? value)
    {
        value = this.Value as RawContentBlockStopEvent;
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
    ///     (RawMessageStartEvent value) => {...},
    ///     (RawMessageDeltaEvent value) => {...},
    ///     (RawMessageStopEvent value) => {...},
    ///     (RawContentBlockStartEvent value) => {...},
    ///     (RawContentBlockDeltaEvent value) => {...},
    ///     (RawContentBlockStopEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<RawMessageStartEvent> start,
        System::Action<RawMessageDeltaEvent> delta,
        System::Action<RawMessageStopEvent> stop,
        System::Action<RawContentBlockStartEvent> contentBlockStart,
        System::Action<RawContentBlockDeltaEvent> contentBlockDelta,
        System::Action<RawContentBlockStopEvent> contentBlockStop
    )
    {
        switch (this.Value)
        {
            case RawMessageStartEvent value:
                start(value);
                break;
            case RawMessageDeltaEvent value:
                delta(value);
                break;
            case RawMessageStopEvent value:
                stop(value);
                break;
            case RawContentBlockStartEvent value:
                contentBlockStart(value);
                break;
            case RawContentBlockDeltaEvent value:
                contentBlockDelta(value);
                break;
            case RawContentBlockStopEvent value:
                contentBlockStop(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of RawMessageStreamEvent"
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
    ///     (RawMessageStartEvent value) => {...},
    ///     (RawMessageDeltaEvent value) => {...},
    ///     (RawMessageStopEvent value) => {...},
    ///     (RawContentBlockStartEvent value) => {...},
    ///     (RawContentBlockDeltaEvent value) => {...},
    ///     (RawContentBlockStopEvent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<RawMessageStartEvent, T> start,
        System::Func<RawMessageDeltaEvent, T> delta,
        System::Func<RawMessageStopEvent, T> stop,
        System::Func<RawContentBlockStartEvent, T> contentBlockStart,
        System::Func<RawContentBlockDeltaEvent, T> contentBlockDelta,
        System::Func<RawContentBlockStopEvent, T> contentBlockStop
    )
    {
        return this.Value switch
        {
            RawMessageStartEvent value => start(value),
            RawMessageDeltaEvent value => delta(value),
            RawMessageStopEvent value => stop(value),
            RawContentBlockStartEvent value => contentBlockStart(value),
            RawContentBlockDeltaEvent value => contentBlockDelta(value),
            RawContentBlockStopEvent value => contentBlockStop(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawMessageStreamEvent"
            ),
        };
    }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) => new(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) => new(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) => new(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawMessageStreamEvent"
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

    public virtual bool Equals(RawMessageStreamEvent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class RawMessageStreamEventConverter : JsonConverter<RawMessageStreamEvent>
{
    public override RawMessageStreamEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<RawMessageStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "message_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawMessageDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "message_stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawMessageStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "content_block_start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "content_block_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "content_block_stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new RawMessageStreamEvent(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        RawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
