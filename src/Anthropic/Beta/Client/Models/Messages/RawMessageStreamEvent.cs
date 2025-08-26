using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using RawMessageStreamEventVariants = Anthropic.Beta.Client.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(RawMessageStreamEventConverter))]
public abstract record class RawMessageStreamEvent
{
    internal RawMessageStreamEvent() { }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStartEvent(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawMessageDeltaEvent(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStopEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStartEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockDeltaEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStopEvent(value);

    public bool TryPickStart([NotNullWhen(true)] out RawMessageStartEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawMessageStartEvent)?.Value;
        return value != null;
    }

    public bool TryPickDelta([NotNullWhen(true)] out RawMessageDeltaEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawMessageDeltaEvent)?.Value;
        return value != null;
    }

    public bool TryPickStop([NotNullWhen(true)] out RawMessageStopEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawMessageStopEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockStart([NotNullWhen(true)] out RawContentBlockStartEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawContentBlockStartEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockDelta([NotNullWhen(true)] out RawContentBlockDeltaEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawContentBlockDeltaEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockStop([NotNullWhen(true)] out RawContentBlockStopEvent? value)
    {
        value = (this as RawMessageStreamEventVariants::RawContentBlockStopEvent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RawMessageStreamEventVariants::RawMessageStartEvent> start,
        Action<RawMessageStreamEventVariants::RawMessageDeltaEvent> delta,
        Action<RawMessageStreamEventVariants::RawMessageStopEvent> stop,
        Action<RawMessageStreamEventVariants::RawContentBlockStartEvent> contentBlockStart,
        Action<RawMessageStreamEventVariants::RawContentBlockDeltaEvent> contentBlockDelta,
        Action<RawMessageStreamEventVariants::RawContentBlockStopEvent> contentBlockStop
    )
    {
        switch (this)
        {
            case RawMessageStreamEventVariants::RawMessageStartEvent inner:
                start(inner);
                break;
            case RawMessageStreamEventVariants::RawMessageDeltaEvent inner:
                delta(inner);
                break;
            case RawMessageStreamEventVariants::RawMessageStopEvent inner:
                stop(inner);
                break;
            case RawMessageStreamEventVariants::RawContentBlockStartEvent inner:
                contentBlockStart(inner);
                break;
            case RawMessageStreamEventVariants::RawContentBlockDeltaEvent inner:
                contentBlockDelta(inner);
                break;
            case RawMessageStreamEventVariants::RawContentBlockStopEvent inner:
                contentBlockStop(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<RawMessageStreamEventVariants::RawMessageStartEvent, T> start,
        Func<RawMessageStreamEventVariants::RawMessageDeltaEvent, T> delta,
        Func<RawMessageStreamEventVariants::RawMessageStopEvent, T> stop,
        Func<RawMessageStreamEventVariants::RawContentBlockStartEvent, T> contentBlockStart,
        Func<RawMessageStreamEventVariants::RawContentBlockDeltaEvent, T> contentBlockDelta,
        Func<RawMessageStreamEventVariants::RawContentBlockStopEvent, T> contentBlockStop
    )
    {
        return this switch
        {
            RawMessageStreamEventVariants::RawMessageStartEvent inner => start(inner),
            RawMessageStreamEventVariants::RawMessageDeltaEvent inner => delta(inner),
            RawMessageStreamEventVariants::RawMessageStopEvent inner => stop(inner),
            RawMessageStreamEventVariants::RawContentBlockStartEvent inner => contentBlockStart(
                inner
            ),
            RawMessageStreamEventVariants::RawContentBlockDeltaEvent inner => contentBlockDelta(
                inner
            ),
            RawMessageStreamEventVariants::RawContentBlockStopEvent inner => contentBlockStop(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RawMessageStreamEventConverter : JsonConverter<RawMessageStreamEvent>
{
    public override RawMessageStreamEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawMessageStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawMessageStartEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "message_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawMessageDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawMessageDeltaEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "message_stop":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawMessageStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawMessageStopEvent(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_start":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawContentBlockStartEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawContentBlockDeltaEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_stop":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RawContentBlockStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RawMessageStreamEventVariants::RawContentBlockStopEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        RawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            RawMessageStreamEventVariants::RawMessageStartEvent(var start) => start,
            RawMessageStreamEventVariants::RawMessageDeltaEvent(var delta) => delta,
            RawMessageStreamEventVariants::RawMessageStopEvent(var stop) => stop,
            RawMessageStreamEventVariants::RawContentBlockStartEvent(var contentBlockStart) =>
                contentBlockStart,
            RawMessageStreamEventVariants::RawContentBlockDeltaEvent(var contentBlockDelta) =>
                contentBlockDelta,
            RawMessageStreamEventVariants::RawContentBlockStopEvent(var contentBlockStop) =>
                contentBlockStop,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
