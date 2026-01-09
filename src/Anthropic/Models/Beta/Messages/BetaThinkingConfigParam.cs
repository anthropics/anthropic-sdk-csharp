using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Configuration for enabling Claude's extended thinking.
///
/// <para>When enabled, responses include `thinking` content blocks showing Claude's
/// thinking process before the final answer. Requires a minimum budget of 1,024 tokens
/// and counts towards your `max_tokens` limit.</para>
///
/// <para>See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
/// for details.</para>
/// </summary>
[JsonConverter(typeof(BetaThinkingConfigParamConverter))]
public record class BetaThinkingConfigParam : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(enabled: (x) => x.Type, disabled: (x) => x.Type); }
    }

    public BetaThinkingConfigParam(BetaThinkingConfigEnabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaThinkingConfigParam(BetaThinkingConfigDisabled value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaThinkingConfigParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingConfigEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaThinkingConfigEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaThinkingConfigEnabled? value)
    {
        value = this.Value as BetaThinkingConfigEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingConfigDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaThinkingConfigDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out BetaThinkingConfigDisabled? value)
    {
        value = this.Value as BetaThinkingConfigDisabled;
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
    ///     (BetaThinkingConfigEnabled value) => {...},
    ///     (BetaThinkingConfigDisabled value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaThinkingConfigEnabled> enabled,
        System::Action<BetaThinkingConfigDisabled> disabled
    )
    {
        switch (this.Value)
        {
            case BetaThinkingConfigEnabled value:
                enabled(value);
                break;
            case BetaThinkingConfigDisabled value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaThinkingConfigParam"
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
    ///     (BetaThinkingConfigEnabled value) => {...},
    ///     (BetaThinkingConfigDisabled value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaThinkingConfigEnabled, T> enabled,
        System::Func<BetaThinkingConfigDisabled, T> disabled
    )
    {
        return this.Value switch
        {
            BetaThinkingConfigEnabled value => enabled(value),
            BetaThinkingConfigDisabled value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaThinkingConfigParam"
            ),
        };
    }

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigEnabled value) =>
        new(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
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
                "Data did not match any variant of BetaThinkingConfigParam"
            );
        }
        this.Switch((enabled) => enabled.Validate(), (disabled) => disabled.Validate());
    }

    public virtual bool Equals(BetaThinkingConfigParam? other)
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

sealed class BetaThinkingConfigParamConverter : JsonConverter<BetaThinkingConfigParam>
{
    public override BetaThinkingConfigParam? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
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
                return new BetaThinkingConfigParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
