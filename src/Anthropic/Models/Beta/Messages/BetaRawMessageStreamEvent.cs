using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public abstract record class BetaRawMessageStreamEvent
{
    internal BetaRawMessageStreamEvent() { }

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStartEvent value) =>
        new BetaRawMessageStartEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value) =>
        new BetaRawMessageDeltaEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStopEvent value) =>
        new BetaRawMessageStopEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value
    ) => new BetaRawContentBlockStartEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value
    ) => new BetaRawContentBlockDeltaEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value) =>
        new BetaRawContentBlockStopEventVariant(value);

    public bool TryPickBetaRawMessageStartEventVariant(
        [NotNullWhen(true)] out BetaRawMessageStartEvent? value
    )
    {
        value = (this as BetaRawMessageStartEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRawMessageDeltaEventVariant(
        [NotNullWhen(true)] out BetaRawMessageDeltaEvent? value
    )
    {
        value = (this as BetaRawMessageDeltaEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRawMessageStopEventVariant(
        [NotNullWhen(true)] out BetaRawMessageStopEvent? value
    )
    {
        value = (this as BetaRawMessageStopEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRawContentBlockStartEventVariant(
        [NotNullWhen(true)] out BetaRawContentBlockStartEvent? value
    )
    {
        value = (this as BetaRawContentBlockStartEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRawContentBlockDeltaEventVariant(
        [NotNullWhen(true)] out BetaRawContentBlockDeltaEvent? value
    )
    {
        value = (this as BetaRawContentBlockDeltaEventVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRawContentBlockStopEventVariant(
        [NotNullWhen(true)] out BetaRawContentBlockStopEvent? value
    )
    {
        value = (this as BetaRawContentBlockStopEventVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaRawMessageStartEventVariant> betaRawMessageStartEvent,
        Action<BetaRawMessageDeltaEventVariant> betaRawMessageDeltaEvent,
        Action<BetaRawMessageStopEventVariant> betaRawMessageStopEvent,
        Action<BetaRawContentBlockStartEventVariant> betaRawContentBlockStartEvent,
        Action<BetaRawContentBlockDeltaEventVariant> betaRawContentBlockDeltaEvent,
        Action<BetaRawContentBlockStopEventVariant> betaRawContentBlockStopEvent
    )
    {
        switch (this)
        {
            case BetaRawMessageStartEventVariant inner:
                betaRawMessageStartEvent(inner);
                break;
            case BetaRawMessageDeltaEventVariant inner:
                betaRawMessageDeltaEvent(inner);
                break;
            case BetaRawMessageStopEventVariant inner:
                betaRawMessageStopEvent(inner);
                break;
            case BetaRawContentBlockStartEventVariant inner:
                betaRawContentBlockStartEvent(inner);
                break;
            case BetaRawContentBlockDeltaEventVariant inner:
                betaRawContentBlockDeltaEvent(inner);
                break;
            case BetaRawContentBlockStopEventVariant inner:
                betaRawContentBlockStopEvent(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaRawMessageStartEventVariant, T> betaRawMessageStartEvent,
        Func<BetaRawMessageDeltaEventVariant, T> betaRawMessageDeltaEvent,
        Func<BetaRawMessageStopEventVariant, T> betaRawMessageStopEvent,
        Func<BetaRawContentBlockStartEventVariant, T> betaRawContentBlockStartEvent,
        Func<BetaRawContentBlockDeltaEventVariant, T> betaRawContentBlockDeltaEvent,
        Func<BetaRawContentBlockStopEventVariant, T> betaRawContentBlockStopEvent
    )
    {
        return this switch
        {
            BetaRawMessageStartEventVariant inner => betaRawMessageStartEvent(inner),
            BetaRawMessageDeltaEventVariant inner => betaRawMessageDeltaEvent(inner),
            BetaRawMessageStopEventVariant inner => betaRawMessageStopEvent(inner),
            BetaRawContentBlockStartEventVariant inner => betaRawContentBlockStartEvent(inner),
            BetaRawContentBlockDeltaEventVariant inner => betaRawContentBlockDeltaEvent(inner),
            BetaRawContentBlockStopEventVariant inner => betaRawContentBlockStopEvent(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaRawMessageStreamEventConverter : JsonConverter<BetaRawMessageStreamEvent>
{
    public override BetaRawMessageStreamEvent? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawMessageStartEventVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawMessageDeltaEventVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawMessageStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawMessageStopEventVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockStartEventVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDeltaEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaEventVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStopEvent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockStopEventVariant(deserialized);
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
        BetaRawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaRawMessageStartEventVariant(var betaRawMessageStartEvent) =>
                betaRawMessageStartEvent,
            BetaRawMessageDeltaEventVariant(var betaRawMessageDeltaEvent) =>
                betaRawMessageDeltaEvent,
            BetaRawMessageStopEventVariant(var betaRawMessageStopEvent) => betaRawMessageStopEvent,
            BetaRawContentBlockStartEventVariant(var betaRawContentBlockStartEvent) =>
                betaRawContentBlockStartEvent,
            BetaRawContentBlockDeltaEventVariant(var betaRawContentBlockDeltaEvent) =>
                betaRawContentBlockDeltaEvent,
            BetaRawContentBlockStopEventVariant(var betaRawContentBlockStopEvent) =>
                betaRawContentBlockStopEvent,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
