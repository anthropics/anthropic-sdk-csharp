using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.RawContentBlockDeltaVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public abstract record class RawContentBlockDelta
{
    internal RawContentBlockDelta() { }

    public static implicit operator RawContentBlockDelta(TextDelta value) =>
        new TextDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) =>
        new InputJSONDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) =>
        new CitationsDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) =>
        new ThinkingDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) =>
        new SignatureDeltaVariant(value);

    public bool TryPickTextDeltaVariant([NotNullWhen(true)] out TextDelta? value)
    {
        value = (this as TextDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickInputJSONDeltaVariant([NotNullWhen(true)] out InputJSONDelta? value)
    {
        value = (this as InputJSONDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickCitationsDeltaVariant([NotNullWhen(true)] out CitationsDelta? value)
    {
        value = (this as CitationsDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickThinkingDeltaVariant([NotNullWhen(true)] out ThinkingDelta? value)
    {
        value = (this as ThinkingDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickSignatureDeltaVariant([NotNullWhen(true)] out SignatureDelta? value)
    {
        value = (this as SignatureDeltaVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextDeltaVariant> textDelta,
        Action<InputJSONDeltaVariant> inputJSONDelta,
        Action<CitationsDeltaVariant> citationsDelta,
        Action<ThinkingDeltaVariant> thinkingDelta,
        Action<SignatureDeltaVariant> signatureDelta
    )
    {
        switch (this)
        {
            case TextDeltaVariant inner:
                textDelta(inner);
                break;
            case InputJSONDeltaVariant inner:
                inputJSONDelta(inner);
                break;
            case CitationsDeltaVariant inner:
                citationsDelta(inner);
                break;
            case ThinkingDeltaVariant inner:
                thinkingDelta(inner);
                break;
            case SignatureDeltaVariant inner:
                signatureDelta(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextDeltaVariant, T> textDelta,
        Func<InputJSONDeltaVariant, T> inputJSONDelta,
        Func<CitationsDeltaVariant, T> citationsDelta,
        Func<ThinkingDeltaVariant, T> thinkingDelta,
        Func<SignatureDeltaVariant, T> signatureDelta
    )
    {
        return this switch
        {
            TextDeltaVariant inner => textDelta(inner),
            InputJSONDeltaVariant inner => inputJSONDelta(inner),
            CitationsDeltaVariant inner => citationsDelta(inner),
            ThinkingDeltaVariant inner => thinkingDelta(inner),
            SignatureDeltaVariant inner => signatureDelta(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RawContentBlockDeltaConverter : JsonConverter<RawContentBlockDelta>
{
    public override RawContentBlockDelta? Read(
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
            case "text_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new TextDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "input_json_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new InputJSONDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "citations_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new CitationsDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "thinking_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new ThinkingDeltaVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "signature_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SignatureDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new SignatureDeltaVariant(deserialized);
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
        RawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TextDeltaVariant(var textDelta) => textDelta,
            InputJSONDeltaVariant(var inputJSONDelta) => inputJSONDelta,
            CitationsDeltaVariant(var citationsDelta) => citationsDelta,
            ThinkingDeltaVariant(var thinkingDelta) => thinkingDelta,
            SignatureDeltaVariant(var signatureDelta) => signatureDelta,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
