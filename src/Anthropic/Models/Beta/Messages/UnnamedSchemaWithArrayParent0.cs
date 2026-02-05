using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Token usage for a sampling iteration.
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public record class UnnamedSchemaWithArrayParent0 : ModelBase
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

    public BetaCacheCreation? CacheCreation
    {
        get
        {
            return Match<BetaCacheCreation?>(
                betaMessageIterationUsage: (x) => x.CacheCreation,
                betaCompactionIterationUsage: (x) => x.CacheCreation
            );
        }
    }

    public long CacheCreationInputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.CacheCreationInputTokens,
                betaCompactionIterationUsage: (x) => x.CacheCreationInputTokens
            );
        }
    }

    public long CacheReadInputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.CacheReadInputTokens,
                betaCompactionIterationUsage: (x) => x.CacheReadInputTokens
            );
        }
    }

    public long InputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.InputTokens,
                betaCompactionIterationUsage: (x) => x.InputTokens
            );
        }
    }

    public long OutputTokens
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.OutputTokens,
                betaCompactionIterationUsage: (x) => x.OutputTokens
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaMessageIterationUsage: (x) => x.Type,
                betaCompactionIterationUsage: (x) => x.Type
            );
        }
    }

    public UnnamedSchemaWithArrayParent0(
        BetaMessageIterationUsage value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(
        BetaCompactionIterationUsage value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent0(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMessageIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMessageIterationUsage(out var value)) {
    ///     // `value` is of type `BetaMessageIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMessageIterationUsage(
        [NotNullWhen(true)] out BetaMessageIterationUsage? value
    )
    {
        value = this.Value as BetaMessageIterationUsage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCompactionIterationUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCompactionIterationUsage(out var value)) {
    ///     // `value` is of type `BetaCompactionIterationUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCompactionIterationUsage(
        [NotNullWhen(true)] out BetaCompactionIterationUsage? value
    )
    {
        value = this.Value as BetaCompactionIterationUsage;
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
    ///     (BetaMessageIterationUsage value) => {...},
    ///     (BetaCompactionIterationUsage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaMessageIterationUsage> betaMessageIterationUsage,
        System::Action<BetaCompactionIterationUsage> betaCompactionIterationUsage
    )
    {
        switch (this.Value)
        {
            case BetaMessageIterationUsage value:
                betaMessageIterationUsage(value);
                break;
            case BetaCompactionIterationUsage value:
                betaCompactionIterationUsage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0"
                );
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
    ///     (BetaMessageIterationUsage value) => {...},
    ///     (BetaCompactionIterationUsage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaMessageIterationUsage, T> betaMessageIterationUsage,
        System::Func<BetaCompactionIterationUsage, T> betaCompactionIterationUsage
    )
    {
        return this.Value switch
        {
            BetaMessageIterationUsage value => betaMessageIterationUsage(value),
            BetaCompactionIterationUsage value => betaCompactionIterationUsage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            ),
        };
    }

    public static implicit operator UnnamedSchemaWithArrayParent0(
        BetaMessageIterationUsage value
    ) => new(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(
        BetaCompactionIterationUsage value
    ) => new(value);

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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            );
        }
        this.Switch(
            (betaMessageIterationUsage) => betaMessageIterationUsage.Validate(),
            (betaCompactionIterationUsage) => betaCompactionIterationUsage.Validate()
        );
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent0? other) =>
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
            BetaMessageIterationUsage _ => 0,
            BetaCompactionIterationUsage _ => 1,
            _ => -1,
        };
    }
}

sealed class UnnamedSchemaWithArrayParent0Converter : JsonConverter<UnnamedSchemaWithArrayParent0>
{
    public override UnnamedSchemaWithArrayParent0? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMessageIterationUsage>(
                element,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<BetaCompactionIterationUsage>(
                element,
                options
            );
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

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
