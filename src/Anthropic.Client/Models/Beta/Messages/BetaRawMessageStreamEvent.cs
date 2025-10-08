using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public record class BetaRawMessageStreamEvent
{
    public object Value { get; private init; }

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

    public BetaRawMessageStreamEvent(BetaRawMessageStartEvent value)
    {
        Value = value;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value)
    {
        Value = value;
    }

    public BetaRawMessageStreamEvent(BetaRawMessageStopEvent value)
    {
        Value = value;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockStartEvent value)
    {
        Value = value;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockDeltaEvent value)
    {
        Value = value;
    }

    public BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value)
    {
        Value = value;
    }

    BetaRawMessageStreamEvent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaRawMessageStreamEvent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        Action<BetaRawMessageStartEvent> start,
        Action<BetaRawMessageDeltaEvent> delta,
        Action<BetaRawMessageStopEvent> stop,
        Action<BetaRawContentBlockStartEvent> contentBlockStart,
        Action<BetaRawContentBlockDeltaEvent> contentBlockDelta,
        Action<BetaRawContentBlockStopEvent> contentBlockStop
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
        Func<BetaRawMessageStartEvent, T> start,
        Func<BetaRawMessageDeltaEvent, T> delta,
        Func<BetaRawMessageStopEvent, T> stop,
        Func<BetaRawContentBlockStartEvent, T> contentBlockStart,
        Func<BetaRawContentBlockDeltaEvent, T> contentBlockDelta,
        Func<BetaRawContentBlockStopEvent, T> contentBlockStop
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

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class BetaRawMessageStreamEventConverter : JsonConverter<BetaRawMessageStreamEvent>
{
    public override BetaRawMessageStreamEvent? Read(
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawMessageStartEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "message_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawMessageDeltaEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "message_stop":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawMessageStopEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_start":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawContentBlockStartEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawContentBlockDeltaEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_stop":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawMessageStreamEvent(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRawContentBlockStopEvent'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
