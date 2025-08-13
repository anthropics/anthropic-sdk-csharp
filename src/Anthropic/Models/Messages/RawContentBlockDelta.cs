using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using RawContentBlockDeltaVariants = Anthropic.Models.Messages.RawContentBlockDeltaVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public abstract record class RawContentBlockDelta
{
    internal RawContentBlockDelta() { }

    public static implicit operator RawContentBlockDelta(TextDelta value) =>
        new RawContentBlockDeltaVariants::TextDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) =>
        new RawContentBlockDeltaVariants::InputJSONDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) =>
        new RawContentBlockDeltaVariants::CitationsDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) =>
        new RawContentBlockDeltaVariants::ThinkingDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) =>
        new RawContentBlockDeltaVariants::SignatureDeltaVariant(value);

    public abstract void Validate();
}

sealed class RawContentBlockDeltaConverter : JsonConverter<RawContentBlockDelta>
{
    public override RawContentBlockDelta? Read(
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
            case "text_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::TextDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "input_json_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::InputJSONDeltaVariant(
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
            case "citations_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::CitationsDeltaVariant(
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
            case "thinking_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::ThinkingDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "signature_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SignatureDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::SignatureDeltaVariant(
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
        RawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            RawContentBlockDeltaVariants::TextDeltaVariant(var textDelta) => textDelta,
            RawContentBlockDeltaVariants::InputJSONDeltaVariant(var inputJSONDelta) =>
                inputJSONDelta,
            RawContentBlockDeltaVariants::CitationsDeltaVariant(var citationsDelta) =>
                citationsDelta,
            RawContentBlockDeltaVariants::ThinkingDeltaVariant(var thinkingDelta) => thinkingDelta,
            RawContentBlockDeltaVariants::SignatureDeltaVariant(var signatureDelta) =>
                signatureDelta,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
