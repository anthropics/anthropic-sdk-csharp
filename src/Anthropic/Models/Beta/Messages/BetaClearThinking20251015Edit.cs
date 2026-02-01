using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaClearThinking20251015Edit, BetaClearThinking20251015EditFromRaw>)
)]
public sealed record class BetaClearThinking20251015Edit : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Number of most recent assistant turns to keep thinking blocks for. Older
    /// turns will have their thinking blocks removed.
    /// </summary>
    public Keep? Keep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Keep>("keep");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("keep", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("clear_thinking_20251015")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Keep?.Validate();
    }

    public BetaClearThinking20251015Edit()
    {
        this.Type = JsonSerializer.SerializeToElement("clear_thinking_20251015");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClearThinking20251015Edit(
        BetaClearThinking20251015Edit betaClearThinking20251015Edit
    )
        : base(betaClearThinking20251015Edit) { }
#pragma warning restore CS8618

    public BetaClearThinking20251015Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("clear_thinking_20251015");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearThinking20251015Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClearThinking20251015EditFromRaw.FromRawUnchecked"/>
    public static BetaClearThinking20251015Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClearThinking20251015EditFromRaw : IFromRawJson<BetaClearThinking20251015Edit>
{
    /// <inheritdoc/>
    public BetaClearThinking20251015Edit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClearThinking20251015Edit.FromRawUnchecked(rawData);
}

/// <summary>
/// Number of most recent assistant turns to keep thinking blocks for. Older turns
/// will have their thinking blocks removed.
/// </summary>
[JsonConverter(typeof(KeepConverter))]
public record class Keep : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public Keep(BetaThinkingTurns value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Keep(BetaAllThinkingTurns value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Keep(UnionMember2 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Keep(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingTurns"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaThinkingTurns(out var value)) {
    ///     // `value` is of type `BetaThinkingTurns`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaThinkingTurns([NotNullWhen(true)] out BetaThinkingTurns? value)
    {
        value = this.Value as BetaThinkingTurns;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAllThinkingTurns"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAllThinkingTurns(out var value)) {
    ///     // `value` is of type `BetaAllThinkingTurns`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAllThinkingTurns([NotNullWhen(true)] out BetaAllThinkingTurns? value)
    {
        value = this.Value as BetaAllThinkingTurns;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember2"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `UnionMember2`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll([NotNullWhen(true)] out UnionMember2? value)
    {
        value = this.Value as UnionMember2;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaThinkingTurns value) => {...},
    ///     (BetaAllThinkingTurns value) => {...},
    ///     (UnionMember2 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaThinkingTurns value) => {...},
    ///     (BetaAllThinkingTurns value) => {...},
    ///     (UnionMember2 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Keep");
        }
        this.Switch(
            (betaThinkingTurns) => betaThinkingTurns.Validate(),
            (betaAllThinkingTurns) => betaAllThinkingTurns.Validate(),
            (all) => all.Validate()
        );
    }

    public virtual bool Equals(Keep? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaThinkingTurns _ => 0,
            BetaAllThinkingTurns _ => 1,
            UnionMember2 _ => 2,
            _ => -1,
        };
    }
}

sealed class KeepConverter : JsonConverter<Keep>
{
    public override Keep? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaThinkingTurns>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaAllThinkingTurns>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Keep value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnionMember2Converter))]
public record class UnionMember2
{
    public JsonElement Element { get; private init; }

    public UnionMember2()
    {
        Element = JsonSerializer.SerializeToElement("all");
    }

    internal UnionMember2(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UnionMember2())
        {
            throw new AnthropicInvalidDataException("Invalid value given for 'UnionMember2'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UnionMember2? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UnionMember2Converter : JsonConverter<UnionMember2>
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
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}
