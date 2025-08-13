using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using RawMessageStreamEventVariants = Anthropic.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawMessageStreamEventConverter))]
public abstract record class RawMessageStreamEvent
{
    internal RawMessageStreamEvent() { }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawMessageDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStopEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStopEventVariant(value);

    public abstract void Validate();
}

sealed class RawMessageStreamEventConverter : JsonConverter<RawMessageStreamEvent>
{
    public override RawMessageStreamEvent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new RawMessageStreamEventVariants::RawMessageStartEventVariant(
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
                        return new RawMessageStreamEventVariants::RawMessageDeltaEventVariant(
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
                        return new RawMessageStreamEventVariants::RawMessageStopEventVariant(
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
                        return new RawMessageStreamEventVariants::RawContentBlockStartEventVariant(
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
                        return new RawMessageStreamEventVariants::RawContentBlockDeltaEventVariant(
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
                        return new RawMessageStreamEventVariants::RawContentBlockStopEventVariant(
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
            default:
            {
                throw new global::System.Exception();
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
            RawMessageStreamEventVariants::RawMessageStartEventVariant(var rawMessageStartEvent) =>
                rawMessageStartEvent,
            RawMessageStreamEventVariants::RawMessageDeltaEventVariant(var rawMessageDeltaEvent) =>
                rawMessageDeltaEvent,
            RawMessageStreamEventVariants::RawMessageStopEventVariant(var rawMessageStopEvent) =>
                rawMessageStopEvent,
            RawMessageStreamEventVariants::RawContentBlockStartEventVariant(
                var rawContentBlockStartEvent
            ) => rawContentBlockStartEvent,
            RawMessageStreamEventVariants::RawContentBlockDeltaEventVariant(
                var rawContentBlockDeltaEvent
            ) => rawContentBlockDeltaEvent,
            RawMessageStreamEventVariants::RawContentBlockStopEventVariant(
                var rawContentBlockStopEvent
            ) => rawContentBlockStopEvent,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
