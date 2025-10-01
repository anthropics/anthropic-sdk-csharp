using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BetaRawMessageStreamEventVariants = Anthropic.Client.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public abstract record class BetaRawMessageStreamEvent
{
    internal BetaRawMessageStreamEvent() { }

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStartEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent(value);

    public bool TryPickStart([NotNullWhen(true)] out BetaRawMessageStartEvent? value)
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent)?.Value;
        return value != null;
    }

    public bool TryPickDelta([NotNullWhen(true)] out BetaRawMessageDeltaEvent? value)
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent)?.Value;
        return value != null;
    }

    public bool TryPickStop([NotNullWhen(true)] out BetaRawMessageStopEvent? value)
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockStart(
        [NotNullWhen(true)] out BetaRawContentBlockStartEvent? value
    )
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockDelta(
        [NotNullWhen(true)] out BetaRawContentBlockDeltaEvent? value
    )
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockStop([NotNullWhen(true)] out BetaRawContentBlockStopEvent? value)
    {
        value = (this as BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent> start,
        Action<BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent> delta,
        Action<BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent> stop,
        Action<BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent> contentBlockStart,
        Action<BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent> contentBlockDelta,
        Action<BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent> contentBlockStop
    )
    {
        switch (this)
        {
            case BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent inner:
                start(inner);
                break;
            case BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent inner:
                delta(inner);
                break;
            case BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent inner:
                stop(inner);
                break;
            case BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent inner:
                contentBlockStart(inner);
                break;
            case BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent inner:
                contentBlockDelta(inner);
                break;
            case BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent inner:
                contentBlockStop(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRawMessageStreamEvent"
                );
        }
    }

    public T Match<T>(
        Func<BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent, T> start,
        Func<BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent, T> delta,
        Func<BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent, T> stop,
        Func<BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent, T> contentBlockStart,
        Func<BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent, T> contentBlockDelta,
        Func<BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent, T> contentBlockStop
    )
    {
        return this switch
        {
            BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent inner => start(inner),
            BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent inner => delta(inner),
            BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent inner => stop(inner),
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent inner =>
                contentBlockStart(inner),
            BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent inner =>
                contentBlockDelta(inner),
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent inner =>
                contentBlockStop(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            ),
        };
    }

    public abstract void Validate();
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
                        return new BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent",
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
                        return new BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent",
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
                        return new BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent",
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
                        return new BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent",
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
                        return new BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent",
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
                        return new BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent",
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
        object variant = value switch
        {
            BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent(var start) => start,
            BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent(var delta) => delta,
            BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent(var stop) => stop,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent(
                var contentBlockStart
            ) => contentBlockStart,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent(
                var contentBlockDelta
            ) => contentBlockDelta,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent(var contentBlockStop) =>
                contentBlockStop,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawMessageStreamEvent"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
