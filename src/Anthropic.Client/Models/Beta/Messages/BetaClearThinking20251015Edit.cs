using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaClearThinking20251015Edit>))]
public sealed record class BetaClearThinking20251015Edit
    : ModelBase,
        IFromRaw<BetaClearThinking20251015Edit>
{
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of most recent assistant turns to keep thinking blocks for. Older
    /// turns will have their thinking blocks removed.
    /// </summary>
    public Keep? Keep
    {
        get
        {
            if (!this._properties.TryGetValue("keep", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Keep?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["keep"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Keep?.Validate();
    }

    public BetaClearThinking20251015Edit()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

    public BetaClearThinking20251015Edit(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearThinking20251015Edit(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaClearThinking20251015Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

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
        System::Action<BetaThinkingTurns> betaThinkingTurns,
        System::Action<BetaAllThinkingTurns> betaAllThinkingTurns,
        System::Action<UnionMember2> all
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
        System::Func<BetaThinkingTurns, T> betaThinkingTurns,
        System::Func<BetaAllThinkingTurns, T> betaAllThinkingTurns,
        System::Func<UnionMember2, T> all
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

    public static implicit operator Keep(BetaThinkingTurns value) => new(value);

    public static implicit operator Keep(BetaAllThinkingTurns value) => new(value);

    public static implicit operator Keep(UnionMember2 value) => new(value);

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
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaAllThinkingTurns'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Keep value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(Converter))]
public class UnionMember2
{
    public JsonElement Json { get; private init; }

    public UnionMember2()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"all\"");
    }

    UnionMember2(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new UnionMember2().Json))
        {
            throw new AnthropicInvalidDataException("Invalid value given for 'UnionMember2'");
        }
    }

    class Converter : JsonConverter<UnionMember2>
    {
        public override UnionMember2? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnionMember2 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
