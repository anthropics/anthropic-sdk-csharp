using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public record class RawContentBlockDelta
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public RawContentBlockDelta(TextDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockDelta(InputJSONDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockDelta(CitationsDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockDelta(ThinkingDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockDelta(SignatureDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public RawContentBlockDelta(JsonElement json)
    {
        this._json = json;
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
        System::Action<TextDelta> text,
        System::Action<InputJSONDelta> inputJSON,
        System::Action<CitationsDelta> citations,
        System::Action<ThinkingDelta> thinking,
        System::Action<SignatureDelta> signature
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
        System::Func<TextDelta, T> text,
        System::Func<InputJSONDelta, T> inputJSON,
        System::Func<CitationsDelta, T> citations,
        System::Func<ThinkingDelta, T> thinking,
        System::Func<SignatureDelta, T> signature
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

    public static implicit operator RawContentBlockDelta(TextDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockDelta"
            );
        }
    }
}

sealed class RawContentBlockDeltaConverter : JsonConverter<RawContentBlockDelta>
{
    public override RawContentBlockDelta? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "input_json_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "citations_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "thinking_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "signature_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SignatureDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new RawContentBlockDelta(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        RawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
