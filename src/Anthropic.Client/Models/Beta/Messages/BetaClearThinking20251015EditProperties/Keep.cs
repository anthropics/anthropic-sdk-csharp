using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Beta.Messages.BetaClearThinking20251015EditProperties.KeepProperties;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearThinking20251015EditProperties;

/// <summary>
/// Number of most recent assistant turns to keep thinking blocks for. Older turns
/// will have their thinking blocks removed.
/// </summary>
[JsonConverter(typeof(KeepConverter))]
public record class Keep
{
    public object Value { get; private init; }

    public JsonElement? Type
    {
        get
        {
            return Match<JsonElement?>(
                betaThinkingTurns: (x) => x.Type,
                betaAllThinkingTurns: (x) => x.Type,
                all: (_) => null
            );
        }
    }

    public Keep(BetaThinkingTurns value)
    {
        Value = value;
    }

    public Keep(BetaAllThinkingTurns value)
    {
        Value = value;
    }

    public Keep(UnionMember2 value)
    {
        Value = value;
    }

    Keep(UnknownVariant value)
    {
        Value = value;
    }

    public static Keep CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaThinkingTurns([NotNullWhen(true)] out BetaThinkingTurns? value)
    {
        value = this.Value as BetaThinkingTurns;
        return value != null;
    }

    public bool TryPickBetaAllThinkingTurns([NotNullWhen(true)] out BetaAllThinkingTurns? value)
    {
        value = this.Value as BetaAllThinkingTurns;
        return value != null;
    }

    public bool TryPickAll([NotNullWhen(true)] out UnionMember2? value)
    {
        value = this.Value as UnionMember2;
        return value != null;
    }

    public void Switch(
        Action<BetaThinkingTurns> betaThinkingTurns,
        Action<BetaAllThinkingTurns> betaAllThinkingTurns,
        Action<UnionMember2> all
    )
    {
        switch (this.Value)
        {
            case BetaThinkingTurns value:
                betaThinkingTurns(value);
                break;
            case BetaAllThinkingTurns value:
                betaAllThinkingTurns(value);
                break;
            case UnionMember2 value:
                all(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Keep");
        }
    }

    public T Match<T>(
        Func<BetaThinkingTurns, T> betaThinkingTurns,
        Func<BetaAllThinkingTurns, T> betaAllThinkingTurns,
        Func<UnionMember2, T> all
    )
    {
        return this.Value switch
        {
            BetaThinkingTurns value => betaThinkingTurns(value),
            BetaAllThinkingTurns value => betaAllThinkingTurns(value),
            UnionMember2 value => all(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Keep"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Keep");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class KeepConverter : JsonConverter<Keep>
{
    public override Keep? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Keep(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'UnionMember2'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaThinkingTurns>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Keep(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaThinkingTurns'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaAllThinkingTurns>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Keep(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaAllThinkingTurns'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Keep value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
