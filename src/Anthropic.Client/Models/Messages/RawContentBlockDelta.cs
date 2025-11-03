using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public record class RawContentBlockDelta
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                inputJSON: (x) => x.Type,
                citations: (x) => x.Type,
                thinking: (x) => x.Type,
                signature: (x) => x.Type
            );
        }
    }

    public RawContentBlockDelta(TextDelta value)
    {
        Value = value;
    }

    public RawContentBlockDelta(InputJSONDelta value)
    {
        Value = value;
    }

    public RawContentBlockDelta(CitationsDelta value)
    {
        Value = value;
    }

    public RawContentBlockDelta(ThinkingDelta value)
    {
        Value = value;
    }

    public RawContentBlockDelta(SignatureDelta value)
    {
        Value = value;
    }

    RawContentBlockDelta(UnknownVariant value)
    {
        Value = value;
    }

    public static RawContentBlockDelta CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickText([NotNullWhen(true)] out TextDelta? value)
    {
        value = this.Value as TextDelta;
        return value != null;
    }

    public bool TryPickInputJSON([NotNullWhen(true)] out InputJSONDelta? value)
    {
        value = this.Value as InputJSONDelta;
        return value != null;
    }

    public bool TryPickCitations([NotNullWhen(true)] out CitationsDelta? value)
    {
        value = this.Value as CitationsDelta;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingDelta? value)
    {
        value = this.Value as ThinkingDelta;
        return value != null;
    }

    public bool TryPickSignature([NotNullWhen(true)] out SignatureDelta? value)
    {
        value = this.Value as SignatureDelta;
        return value != null;
    }

    public void Switch(
        Action<TextDelta> text,
        Action<InputJSONDelta> inputJSON,
        Action<CitationsDelta> citations,
        Action<ThinkingDelta> thinking,
        Action<SignatureDelta> signature
    )
    {
        switch (this.Value)
        {
            case TextDelta value:
                text(value);
                break;
            case InputJSONDelta value:
                inputJSON(value);
                break;
            case CitationsDelta value:
                citations(value);
                break;
            case ThinkingDelta value:
                thinking(value);
                break;
            case SignatureDelta value:
                signature(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of RawContentBlockDelta"
                );
        }
    }

    public T Match<T>(
        Func<TextDelta, T> text,
        Func<InputJSONDelta, T> inputJSON,
        Func<CitationsDelta, T> citations,
        Func<ThinkingDelta, T> thinking,
        Func<SignatureDelta, T> signature
    )
    {
        return this.Value switch
        {
            TextDelta value => text(value),
            InputJSONDelta value => inputJSON(value),
            CitationsDelta value => citations(value),
            ThinkingDelta value => thinking(value),
            SignatureDelta value => signature(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockDelta"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockDelta"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new RawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'TextDelta'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "input_json_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new RawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'InputJSONDelta'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "citations_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new RawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationsDelta'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "thinking_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new RawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ThinkingDelta'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "signature_delta":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SignatureDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new RawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'SignatureDelta'",
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
        RawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
