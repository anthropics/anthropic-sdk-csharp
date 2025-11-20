using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public record class BetaRawContentBlockDelta
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

    public BetaRawContentBlockDelta(BetaTextDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawContentBlockDelta(BetaInputJSONDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawContentBlockDelta(BetaCitationsDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawContentBlockDelta(BetaThinkingDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawContentBlockDelta(BetaSignatureDelta value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRawContentBlockDelta(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickText([NotNullWhen(true)] out BetaTextDelta? value)
    {
        value = this.Value as BetaTextDelta;
        return value != null;
    }

    public bool TryPickInputJSON([NotNullWhen(true)] out BetaInputJSONDelta? value)
    {
        value = this.Value as BetaInputJSONDelta;
        return value != null;
    }

    public bool TryPickCitations([NotNullWhen(true)] out BetaCitationsDelta? value)
    {
        value = this.Value as BetaCitationsDelta;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingDelta? value)
    {
        value = this.Value as BetaThinkingDelta;
        return value != null;
    }

    public bool TryPickSignature([NotNullWhen(true)] out BetaSignatureDelta? value)
    {
        value = this.Value as BetaSignatureDelta;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextDelta> text,
        System::Action<BetaInputJSONDelta> inputJSON,
        System::Action<BetaCitationsDelta> citations,
        System::Action<BetaThinkingDelta> thinking,
        System::Action<BetaSignatureDelta> signature
    )
    {
        switch (this.Value)
        {
            case BetaTextDelta value:
                text(value);
                break;
            case BetaInputJSONDelta value:
                inputJSON(value);
                break;
            case BetaCitationsDelta value:
                citations(value);
                break;
            case BetaThinkingDelta value:
                thinking(value);
                break;
            case BetaSignatureDelta value:
                signature(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRawContentBlockDelta"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaTextDelta, T> text,
        System::Func<BetaInputJSONDelta, T> inputJSON,
        System::Func<BetaCitationsDelta, T> citations,
        System::Func<BetaThinkingDelta, T> thinking,
        System::Func<BetaSignatureDelta, T> signature
    )
    {
        return this.Value switch
        {
            BetaTextDelta value => text(value),
            BetaInputJSONDelta value => inputJSON(value),
            BetaCitationsDelta value => citations(value),
            BetaThinkingDelta value => thinking(value),
            BetaSignatureDelta value => signature(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawContentBlockDelta"
            ),
        };
    }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) => new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJSONDelta value) =>
        new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) => new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawContentBlockDelta"
            );
        }
    }
}

sealed class BetaRawContentBlockDeltaConverter : JsonConverter<BetaRawContentBlockDelta>
{
    public override BetaRawContentBlockDelta? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaInputJSONDelta>(
                        json,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
                        json,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingDelta>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
                        json,
                        options
                    );
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
                return new BetaRawContentBlockDelta(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
