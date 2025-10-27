using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public record class BetaRawContentBlockDelta
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

    public BetaRawContentBlockDelta(BetaTextDelta value)
    {
        Value = value;
    }

    public BetaRawContentBlockDelta(BetaInputJSONDelta value)
    {
        Value = value;
    }

    public BetaRawContentBlockDelta(BetaCitationsDelta value)
    {
        Value = value;
    }

    public BetaRawContentBlockDelta(BetaThinkingDelta value)
    {
        Value = value;
    }

    public BetaRawContentBlockDelta(BetaSignatureDelta value)
    {
        Value = value;
    }

    BetaRawContentBlockDelta(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaRawContentBlockDelta CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        Action<BetaTextDelta> text,
        Action<BetaInputJSONDelta> inputJSON,
        Action<BetaCitationsDelta> citations,
        Action<BetaThinkingDelta> thinking,
        Action<BetaSignatureDelta> signature
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
        Func<BetaTextDelta, T> text,
        Func<BetaInputJSONDelta, T> inputJSON,
        Func<BetaCitationsDelta, T> citations,
        Func<BetaThinkingDelta, T> thinking,
        Func<BetaSignatureDelta, T> signature
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawContentBlockDelta"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class BetaRawContentBlockDeltaConverter : JsonConverter<BetaRawContentBlockDelta>
{
    public override BetaRawContentBlockDelta? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextDelta'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaInputJSONDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaInputJSONDelta'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationsDelta'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaThinkingDelta'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaRawContentBlockDelta(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaSignatureDelta'",
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
        BetaRawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
