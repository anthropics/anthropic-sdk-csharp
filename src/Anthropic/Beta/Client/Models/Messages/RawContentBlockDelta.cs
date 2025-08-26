using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using RawContentBlockDeltaVariants = Anthropic.Beta.Client.Models.Messages.RawContentBlockDeltaVariants;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public abstract record class RawContentBlockDelta
{
    internal RawContentBlockDelta() { }

    public static implicit operator RawContentBlockDelta(TextDelta value) =>
        new RawContentBlockDeltaVariants::TextDelta(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) =>
        new RawContentBlockDeltaVariants::InputJSONDelta(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) =>
        new RawContentBlockDeltaVariants::CitationsDelta(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) =>
        new RawContentBlockDeltaVariants::ThinkingDelta(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) =>
        new RawContentBlockDeltaVariants::SignatureDelta(value);

    public bool TryPickText([NotNullWhen(true)] out TextDelta? value)
    {
        value = (this as RawContentBlockDeltaVariants::TextDelta)?.Value;
        return value != null;
    }

    public bool TryPickInputJSON([NotNullWhen(true)] out InputJSONDelta? value)
    {
        value = (this as RawContentBlockDeltaVariants::InputJSONDelta)?.Value;
        return value != null;
    }

    public bool TryPickCitations([NotNullWhen(true)] out CitationsDelta? value)
    {
        value = (this as RawContentBlockDeltaVariants::CitationsDelta)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingDelta? value)
    {
        value = (this as RawContentBlockDeltaVariants::ThinkingDelta)?.Value;
        return value != null;
    }

    public bool TryPickSignature([NotNullWhen(true)] out SignatureDelta? value)
    {
        value = (this as RawContentBlockDeltaVariants::SignatureDelta)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RawContentBlockDeltaVariants::TextDelta> text,
        Action<RawContentBlockDeltaVariants::InputJSONDelta> inputJSON,
        Action<RawContentBlockDeltaVariants::CitationsDelta> citations,
        Action<RawContentBlockDeltaVariants::ThinkingDelta> thinking,
        Action<RawContentBlockDeltaVariants::SignatureDelta> signature
    )
    {
        switch (this)
        {
            case RawContentBlockDeltaVariants::TextDelta inner:
                text(inner);
                break;
            case RawContentBlockDeltaVariants::InputJSONDelta inner:
                inputJSON(inner);
                break;
            case RawContentBlockDeltaVariants::CitationsDelta inner:
                citations(inner);
                break;
            case RawContentBlockDeltaVariants::ThinkingDelta inner:
                thinking(inner);
                break;
            case RawContentBlockDeltaVariants::SignatureDelta inner:
                signature(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<RawContentBlockDeltaVariants::TextDelta, T> text,
        Func<RawContentBlockDeltaVariants::InputJSONDelta, T> inputJSON,
        Func<RawContentBlockDeltaVariants::CitationsDelta, T> citations,
        Func<RawContentBlockDeltaVariants::ThinkingDelta, T> thinking,
        Func<RawContentBlockDeltaVariants::SignatureDelta, T> signature
    )
    {
        return this switch
        {
            RawContentBlockDeltaVariants::TextDelta inner => text(inner),
            RawContentBlockDeltaVariants::InputJSONDelta inner => inputJSON(inner),
            RawContentBlockDeltaVariants::CitationsDelta inner => citations(inner),
            RawContentBlockDeltaVariants::ThinkingDelta inner => thinking(inner),
            RawContentBlockDeltaVariants::SignatureDelta inner => signature(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RawContentBlockDeltaConverter : JsonConverter<RawContentBlockDelta>
{
    public override RawContentBlockDelta? Read(
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
            case "text_delta":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new RawContentBlockDeltaVariants::TextDelta(deserialized);
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
                        return new RawContentBlockDeltaVariants::InputJSONDelta(deserialized);
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
                        return new RawContentBlockDeltaVariants::CitationsDelta(deserialized);
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
                        return new RawContentBlockDeltaVariants::ThinkingDelta(deserialized);
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
                        return new RawContentBlockDeltaVariants::SignatureDelta(deserialized);
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
            RawContentBlockDeltaVariants::TextDelta(var text) => text,
            RawContentBlockDeltaVariants::InputJSONDelta(var inputJSON) => inputJSON,
            RawContentBlockDeltaVariants::CitationsDelta(var citations) => citations,
            RawContentBlockDeltaVariants::ThinkingDelta(var thinking) => thinking,
            RawContentBlockDeltaVariants::SignatureDelta(var signature) => signature,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
