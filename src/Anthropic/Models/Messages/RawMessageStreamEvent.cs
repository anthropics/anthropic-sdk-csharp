using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawMessageStreamEventConverter))]
public abstract record class RawMessageStreamEvent
{
    internal RawMessageStreamEvent() { }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) =>
        new RawMessageStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) =>
        new RawMessageDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) =>
        new RawMessageStopEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new RawContentBlockStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new RawContentBlockDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
        new RawContentBlockStopEventVariant(value);

    public bool TryPickRawMessageStartEventVariant(
        [NotNullWhen(true)] out RawMessageStartEvent? value
    )
    {
        value = (this as RawMessageStartEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickRawMessageDeltaEventVariant(
        [NotNullWhen(true)] out RawMessageDeltaEvent? value
    )
    {
        value = (this as RawMessageDeltaEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickRawMessageStopEventVariant(
        [NotNullWhen(true)] out RawMessageStopEvent? value
    )
    {
        value = (this as RawMessageStopEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickRawContentBlockStartEventVariant(
        [NotNullWhen(true)] out RawContentBlockStartEvent? value
    )
    {
        value = (this as RawContentBlockStartEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickRawContentBlockDeltaEventVariant(
        [NotNullWhen(true)] out RawContentBlockDeltaEvent? value
    )
    {
        value = (this as RawContentBlockDeltaEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickRawContentBlockStopEventVariant(
        [NotNullWhen(true)] out RawContentBlockStopEvent? value
    )
    {
        value = (this as RawContentBlockStopEventVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RawMessageStartEventVariant> rawMessageStartEvent,
        Action<RawMessageDeltaEventVariant> rawMessageDeltaEvent,
        Action<RawMessageStopEventVariant> rawMessageStopEvent,
        Action<RawContentBlockStartEventVariant> rawContentBlockStartEvent,
        Action<RawContentBlockDeltaEventVariant> rawContentBlockDeltaEvent,
        Action<RawContentBlockStopEventVariant> rawContentBlockStopEvent
    )
    {
        switch (this)
        {
            case RawMessageStartEventVariant inner:
                rawMessageStartEvent(inner);
                break;
            case RawMessageDeltaEventVariant inner:
                rawMessageDeltaEvent(inner);
                break;
            case RawMessageStopEventVariant inner:
                rawMessageStopEvent(inner);
                break;
            case RawContentBlockStartEventVariant inner:
                rawContentBlockStartEvent(inner);
                break;
            case RawContentBlockDeltaEventVariant inner:
                rawContentBlockDeltaEvent(inner);
                break;
            case RawContentBlockStopEventVariant inner:
                rawContentBlockStopEvent(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<RawMessageStartEventVariant, T> rawMessageStartEvent,
        Func<RawMessageDeltaEventVariant, T> rawMessageDeltaEvent,
        Func<RawMessageStopEventVariant, T> rawMessageStopEvent,
        Func<RawContentBlockStartEventVariant, T> rawContentBlockStartEvent,
        Func<RawContentBlockDeltaEventVariant, T> rawContentBlockDeltaEvent,
        Func<RawContentBlockStopEventVariant, T> rawContentBlockStopEvent
    )
    {
        return this switch
        {
            RawMessageStartEventVariant inner => rawMessageStartEvent(inner),
            RawMessageDeltaEventVariant inner => rawMessageDeltaEvent(inner),
            RawMessageStopEventVariant inner => rawMessageStopEvent(inner),
            RawContentBlockStartEventVariant inner => rawContentBlockStartEvent(inner),
            RawContentBlockDeltaEventVariant inner => rawContentBlockDeltaEvent(inner),
            RawContentBlockStopEventVariant inner => rawContentBlockStopEvent(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RawMessageStreamEventConverter : JsonConverter<RawMessageStreamEvent>
{
    public override RawMessageStreamEvent? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new RawMessageStartEventVariant(deserialized);
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
                        return new RawMessageDeltaEventVariant(deserialized);
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
                        return new RawMessageStopEventVariant(deserialized);
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
                        return new RawContentBlockStartEventVariant(deserialized);
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
                        return new RawContentBlockDeltaEventVariant(deserialized);
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
                        return new RawContentBlockStopEventVariant(deserialized);
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
            RawMessageStartEventVariant(var rawMessageStartEvent) => rawMessageStartEvent,
            RawMessageDeltaEventVariant(var rawMessageDeltaEvent) => rawMessageDeltaEvent,
            RawMessageStopEventVariant(var rawMessageStopEvent) => rawMessageStopEvent,
            RawContentBlockStartEventVariant(var rawContentBlockStartEvent) =>
                rawContentBlockStartEvent,
            RawContentBlockDeltaEventVariant(var rawContentBlockDeltaEvent) =>
                rawContentBlockDeltaEvent,
            RawContentBlockStopEventVariant(var rawContentBlockStopEvent) =>
                rawContentBlockStopEvent,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
