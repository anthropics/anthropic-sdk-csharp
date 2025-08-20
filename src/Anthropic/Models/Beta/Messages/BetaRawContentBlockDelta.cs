using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public abstract record class BetaRawContentBlockDelta
{
    internal BetaRawContentBlockDelta() { }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) =>
        new BetaTextDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJSONDelta value) =>
        new BetaInputJSONDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new BetaCitationsDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) =>
        new BetaThinkingDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new BetaSignatureDeltaVariant(value);

    public bool TryPickBetaTextDeltaVariant([NotNullWhen(true)] out BetaTextDelta? value)
    {
        value = (this as BetaTextDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaInputJSONDeltaVariant([NotNullWhen(true)] out BetaInputJSONDelta? value)
    {
        value = (this as BetaInputJSONDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCitationsDeltaVariant([NotNullWhen(true)] out BetaCitationsDelta? value)
    {
        value = (this as BetaCitationsDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaThinkingDeltaVariant([NotNullWhen(true)] out BetaThinkingDelta? value)
    {
        value = (this as BetaThinkingDeltaVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaSignatureDeltaVariant([NotNullWhen(true)] out BetaSignatureDelta? value)
    {
        value = (this as BetaSignatureDeltaVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaTextDeltaVariant> betaTextDelta,
        Action<BetaInputJSONDeltaVariant> betaInputJSONDelta,
        Action<BetaCitationsDeltaVariant> betaCitationsDelta,
        Action<BetaThinkingDeltaVariant> betaThinkingDelta,
        Action<BetaSignatureDeltaVariant> betaSignatureDelta
    )
    {
        switch (this)
        {
            case BetaTextDeltaVariant inner:
                betaTextDelta(inner);
                break;
            case BetaInputJSONDeltaVariant inner:
                betaInputJSONDelta(inner);
                break;
            case BetaCitationsDeltaVariant inner:
                betaCitationsDelta(inner);
                break;
            case BetaThinkingDeltaVariant inner:
                betaThinkingDelta(inner);
                break;
            case BetaSignatureDeltaVariant inner:
                betaSignatureDelta(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaTextDeltaVariant, T> betaTextDelta,
        Func<BetaInputJSONDeltaVariant, T> betaInputJSONDelta,
        Func<BetaCitationsDeltaVariant, T> betaCitationsDelta,
        Func<BetaThinkingDeltaVariant, T> betaThinkingDelta,
        Func<BetaSignatureDeltaVariant, T> betaSignatureDelta
    )
    {
        return this switch
        {
            BetaTextDeltaVariant inner => betaTextDelta(inner),
            BetaInputJSONDeltaVariant inner => betaInputJSONDelta(inner),
            BetaCitationsDeltaVariant inner => betaCitationsDelta(inner),
            BetaThinkingDeltaVariant inner => betaThinkingDelta(inner),
            BetaSignatureDeltaVariant inner => betaSignatureDelta(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaRawContentBlockDeltaConverter : JsonConverter<BetaRawContentBlockDelta>
{
    public override BetaRawContentBlockDelta? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaTextDeltaVariant(deserialized);
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
                        return new BetaInputJSONDeltaVariant(deserialized);
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
                        return new BetaCitationsDeltaVariant(deserialized);
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
                        return new BetaThinkingDeltaVariant(deserialized);
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
                        return new BetaSignatureDeltaVariant(deserialized);
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
            BetaTextDeltaVariant(var betaTextDelta) => betaTextDelta,
            BetaInputJSONDeltaVariant(var betaInputJSONDelta) => betaInputJSONDelta,
            BetaCitationsDeltaVariant(var betaCitationsDelta) => betaCitationsDelta,
            BetaThinkingDeltaVariant(var betaThinkingDelta) => betaThinkingDelta,
            BetaSignatureDeltaVariant(var betaSignatureDelta) => betaSignatureDelta,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
