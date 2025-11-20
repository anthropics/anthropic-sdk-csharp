using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public record class BetaRawMessageStreamEvent
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

    public BetaRawMessageStreamEvent(BetaRawMessageStartEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageStopEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockStartEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockDeltaEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawMessageStreamEvent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickStart([NotNullWhen(true)] out BetaRawMessageStartEvent? value)
    {
        value = this.Value as BetaRawMessageStartEvent;
        return value != null;
    }

    public bool TryPickDelta([NotNullWhen(true)] out BetaRawMessageDeltaEvent? value)
    {
        value = this.Value as BetaRawMessageDeltaEvent;
        return value != null;
    }

    public bool TryPickStop([NotNullWhen(true)] out BetaRawMessageStopEvent? value)
    {
        value = this.Value as BetaRawMessageStopEvent;
        return value != null;
    }

    public bool TryPickContentBlockStart(
        [NotNullWhen(true)] out BetaRawContentBlockStartEvent? value
    )
    {
        value = this.Value as BetaRawContentBlockStartEvent;
        return value != null;
    }

    public bool TryPickContentBlockDelta(
        [NotNullWhen(true)] out BetaRawContentBlockDeltaEvent? value
    )
    {
        value = this.Value as BetaRawContentBlockDeltaEvent;
        return value != null;
    }

    public bool TryPickContentBlockStop([NotNullWhen(true)] out BetaRawContentBlockStopEvent? value)
    {
        value = this.Value as BetaRawContentBlockStopEvent;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            );
        }
    }
}

sealed class BetaRawMessageStreamEventConverter : JsonConverter<BetaRawMessageStreamEvent>
{
    public override BetaRawMessageStreamEvent? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStartEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageDeltaEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStopEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDeltaEvent>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStopEvent>(
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
                return new BetaRawMessageStreamEvent(json);
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
