using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(RawContentBlockDeltaConverter))]
public record class RawContentBlockDelta : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                inputJson: (x) => x.Type,
                citations: (x) => x.Type,
                thinking: (x) => x.Type,
                signature: (x) => x.Type
            );
        }
    }

    public RawContentBlockDelta(TextDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RawContentBlockDelta(InputJsonDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RawContentBlockDelta(CitationsDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RawContentBlockDelta(ThinkingDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RawContentBlockDelta(SignatureDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RawContentBlockDelta(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextDelta? value)
    {
        value = this.Value as TextDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InputJsonDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInputJson(out var value)) {
    ///     // `value` is of type `InputJsonDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInputJson([NotNullWhen(true)] out InputJsonDelta? value)
    {
        value = this.Value as InputJsonDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationsDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitations(out var value)) {
    ///     // `value` is of type `CitationsDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitations([NotNullWhen(true)] out CitationsDelta? value)
    {
        value = this.Value as CitationsDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThinkingDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinking(out var value)) {
    ///     // `value` is of type `ThinkingDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinking([NotNullWhen(true)] out ThinkingDelta? value)
    {
        value = this.Value as ThinkingDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SignatureDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSignature(out var value)) {
    ///     // `value` is of type `SignatureDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSignature([NotNullWhen(true)] out SignatureDelta? value)
    {
        value = this.Value as SignatureDelta;
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
    ///     (TextDelta value) => {...},
    ///     (InputJsonDelta value) => {...},
    ///     (CitationsDelta value) => {...},
    ///     (ThinkingDelta value) => {...},
    ///     (SignatureDelta value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextDelta> text,
        System::Action<InputJsonDelta> inputJson,
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
            case InputJsonDelta value:
                inputJson(value);
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
    ///     (TextDelta value) => {...},
    ///     (InputJsonDelta value) => {...},
    ///     (CitationsDelta value) => {...},
    ///     (ThinkingDelta value) => {...},
    ///     (SignatureDelta value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TextDelta, T> text,
        System::Func<InputJsonDelta, T> inputJson,
        System::Func<CitationsDelta, T> citations,
        System::Func<ThinkingDelta, T> thinking,
        System::Func<SignatureDelta, T> signature
    )
    {
        return this.Value switch
        {
            TextDelta value => text(value),
            InputJsonDelta value => inputJson(value),
            CitationsDelta value => citations(value),
            ThinkingDelta value => thinking(value),
            SignatureDelta value => signature(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of RawContentBlockDelta"
            ),
        };
    }

    public static implicit operator RawContentBlockDelta(TextDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(InputJsonDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) => new(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) => new(value);

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
                "Data did not match any variant of RawContentBlockDelta"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (inputJson) => inputJson.Validate(),
            (citations) => citations.Validate(),
            (thinking) => thinking.Validate(),
            (signature) => signature.Validate()
        );
    }

    public virtual bool Equals(RawContentBlockDelta? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            TextDelta _ => 0,
            InputJsonDelta _ => 1,
            CitationsDelta _ => 2,
            ThinkingDelta _ => 3,
            SignatureDelta _ => 4,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "input_json_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InputJsonDelta>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "citations_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsDelta>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thinking_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "signature_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SignatureDelta>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new RawContentBlockDelta(element);
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
