using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaRawMessageStreamEventVariants = Anthropic.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawMessageStreamEventConverter))]
public abstract record class BetaRawMessageStreamEvent
{
    internal BetaRawMessageStreamEvent() { }

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStartEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStartEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStopEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEventVariant(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEventVariant(value);

    public abstract void Validate();
}

sealed class BetaRawMessageStreamEventConverter : JsonConverter<BetaRawMessageStreamEvent>
{
    public override BetaRawMessageStreamEvent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawMessageStartEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawMessageStartEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawMessageDeltaEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawMessageStopEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawMessageStopEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStartEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockDeltaEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaRawContentBlockStopEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEventVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRawMessageStreamEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaRawMessageStreamEventVariants::BetaRawMessageStartEventVariant(
                var betaRawMessageStartEvent
            ) => betaRawMessageStartEvent,
            BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEventVariant(
                var betaRawMessageDeltaEvent
            ) => betaRawMessageDeltaEvent,
            BetaRawMessageStreamEventVariants::BetaRawMessageStopEventVariant(
                var betaRawMessageStopEvent
            ) => betaRawMessageStopEvent,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEventVariant(
                var betaRawContentBlockStartEvent
            ) => betaRawContentBlockStartEvent,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEventVariant(
                var betaRawContentBlockDeltaEvent
            ) => betaRawContentBlockDeltaEvent,
            BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEventVariant(
                var betaRawContentBlockStopEvent
            ) => betaRawContentBlockStopEvent,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
