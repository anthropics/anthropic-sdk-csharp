using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaRawContentBlockDeltaVariants = Anthropic.Beta.Client.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public abstract record class BetaRawContentBlockDelta
{
    internal BetaRawContentBlockDelta() { }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaTextDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJSONDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaInputJSONDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaCitationsDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaThinkingDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaSignatureDelta(value);

    public bool TryPickText([NotNullWhen(true)] out BetaTextDelta? value)
    {
        value = (this as BetaRawContentBlockDeltaVariants::BetaTextDelta)?.Value;
        return value != null;
    }

    public bool TryPickInputJSON([NotNullWhen(true)] out BetaInputJSONDelta? value)
    {
        value = (this as BetaRawContentBlockDeltaVariants::BetaInputJSONDelta)?.Value;
        return value != null;
    }

    public bool TryPickCitations([NotNullWhen(true)] out BetaCitationsDelta? value)
    {
        value = (this as BetaRawContentBlockDeltaVariants::BetaCitationsDelta)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingDelta? value)
    {
        value = (this as BetaRawContentBlockDeltaVariants::BetaThinkingDelta)?.Value;
        return value != null;
    }

    public bool TryPickSignature([NotNullWhen(true)] out BetaSignatureDelta? value)
    {
        value = (this as BetaRawContentBlockDeltaVariants::BetaSignatureDelta)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaRawContentBlockDeltaVariants::BetaTextDelta> text,
        Action<BetaRawContentBlockDeltaVariants::BetaInputJSONDelta> inputJSON,
        Action<BetaRawContentBlockDeltaVariants::BetaCitationsDelta> citations,
        Action<BetaRawContentBlockDeltaVariants::BetaThinkingDelta> thinking,
        Action<BetaRawContentBlockDeltaVariants::BetaSignatureDelta> signature
    )
    {
        switch (this)
        {
            case BetaRawContentBlockDeltaVariants::BetaTextDelta inner:
                text(inner);
                break;
            case BetaRawContentBlockDeltaVariants::BetaInputJSONDelta inner:
                inputJSON(inner);
                break;
            case BetaRawContentBlockDeltaVariants::BetaCitationsDelta inner:
                citations(inner);
                break;
            case BetaRawContentBlockDeltaVariants::BetaThinkingDelta inner:
                thinking(inner);
                break;
            case BetaRawContentBlockDeltaVariants::BetaSignatureDelta inner:
                signature(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaRawContentBlockDeltaVariants::BetaTextDelta, T> text,
        Func<BetaRawContentBlockDeltaVariants::BetaInputJSONDelta, T> inputJSON,
        Func<BetaRawContentBlockDeltaVariants::BetaCitationsDelta, T> citations,
        Func<BetaRawContentBlockDeltaVariants::BetaThinkingDelta, T> thinking,
        Func<BetaRawContentBlockDeltaVariants::BetaSignatureDelta, T> signature
    )
    {
        return this switch
        {
            BetaRawContentBlockDeltaVariants::BetaTextDelta inner => text(inner),
            BetaRawContentBlockDeltaVariants::BetaInputJSONDelta inner => inputJSON(inner),
            BetaRawContentBlockDeltaVariants::BetaCitationsDelta inner => citations(inner),
            BetaRawContentBlockDeltaVariants::BetaThinkingDelta inner => thinking(inner),
            BetaRawContentBlockDeltaVariants::BetaSignatureDelta inner => signature(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaVariants::BetaTextDelta(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaInputJSONDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaVariants::BetaInputJSONDelta(
                            deserialized
                        );
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaVariants::BetaCitationsDelta(
                            deserialized
                        );
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaVariants::BetaThinkingDelta(
                            deserialized
                        );
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
                    var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaRawContentBlockDeltaVariants::BetaSignatureDelta(
                            deserialized
                        );
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
        BetaRawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaRawContentBlockDeltaVariants::BetaTextDelta(var text) => text,
            BetaRawContentBlockDeltaVariants::BetaInputJSONDelta(var inputJSON) => inputJSON,
            BetaRawContentBlockDeltaVariants::BetaCitationsDelta(var citations) => citations,
            BetaRawContentBlockDeltaVariants::BetaThinkingDelta(var thinking) => thinking,
            BetaRawContentBlockDeltaVariants::BetaSignatureDelta(var signature) => signature,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
