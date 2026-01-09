using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public record class BetaRawContentBlockDelta : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public BetaRawContentBlockDelta(BetaTextDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawContentBlockDelta(BetaInputJsonDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawContentBlockDelta(BetaCitationsDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawContentBlockDelta(BetaThinkingDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawContentBlockDelta(BetaSignatureDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRawContentBlockDelta(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `BetaTextDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out BetaTextDelta? value)
    {
        value = this.Value as BetaTextDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaInputJsonDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInputJson(out var value)) {
    ///     // `value` is of type `BetaInputJsonDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInputJson([NotNullWhen(true)] out BetaInputJsonDelta? value)
    {
        value = this.Value as BetaInputJsonDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationsDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitations(out var value)) {
    ///     // `value` is of type `BetaCitationsDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitations([NotNullWhen(true)] out BetaCitationsDelta? value)
    {
        value = this.Value as BetaCitationsDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinking(out var value)) {
    ///     // `value` is of type `BetaThinkingDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingDelta? value)
    {
        value = this.Value as BetaThinkingDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSignatureDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSignature(out var value)) {
    ///     // `value` is of type `BetaSignatureDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSignature([NotNullWhen(true)] out BetaSignatureDelta? value)
    {
        value = this.Value as BetaSignatureDelta;
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
    ///     (BetaTextDelta value) => {...},
    ///     (BetaInputJsonDelta value) => {...},
    ///     (BetaCitationsDelta value) => {...},
    ///     (BetaThinkingDelta value) => {...},
    ///     (BetaSignatureDelta value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextDelta> text,
        System::Action<BetaInputJsonDelta> inputJson,
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
            case BetaInputJsonDelta value:
                inputJson(value);
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
    ///     (BetaTextDelta value) => {...},
    ///     (BetaInputJsonDelta value) => {...},
    ///     (BetaCitationsDelta value) => {...},
    ///     (BetaThinkingDelta value) => {...},
    ///     (BetaSignatureDelta value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTextDelta, T> text,
        System::Func<BetaInputJsonDelta, T> inputJson,
        System::Func<BetaCitationsDelta, T> citations,
        System::Func<BetaThinkingDelta, T> thinking,
        System::Func<BetaSignatureDelta, T> signature
    )
    {
        return this.Value switch
        {
            BetaTextDelta value => text(value),
            BetaInputJsonDelta value => inputJson(value),
            BetaCitationsDelta value => citations(value),
            BetaThinkingDelta value => thinking(value),
            BetaSignatureDelta value => signature(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRawContentBlockDelta"
            ),
        };
    }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) => new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJsonDelta value) =>
        new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) => new(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new(value);

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
                "Data did not match any variant of BetaRawContentBlockDelta"
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

    public virtual bool Equals(BetaRawContentBlockDelta? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class BetaRawContentBlockDeltaConverter : JsonConverter<BetaRawContentBlockDelta>
{
    public override BetaRawContentBlockDelta? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaInputJsonDelta>(
                        element,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(
                        element,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingDelta>(
                        element,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(
                        element,
                        options
                    );
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
                return new BetaRawContentBlockDelta(element);
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
