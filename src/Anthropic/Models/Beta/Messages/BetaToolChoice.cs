using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(BetaToolChoiceConverter))]
public record class BetaToolChoice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                auto: (x) => x.Type,
                any: (x) => x.Type,
                tool: (x) => x.Type,
                none: (x) => x.Type
            );
        }
    }

    public bool? DisableParallelToolUse
    {
        get
        {
            return Match<bool?>(
                auto: (x) => x.DisableParallelToolUse,
                any: (x) => x.DisableParallelToolUse,
                tool: (x) => x.DisableParallelToolUse,
                none: (_) => null
            );
        }
    }

    public BetaToolChoice(BetaToolChoiceAuto value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceAny value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceTool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceNone value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChoiceAuto"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuto(out var value)) {
    ///     // `value` is of type `BetaToolChoiceAuto`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuto([NotNullWhen(true)] out BetaToolChoiceAuto? value)
    {
        value = this.Value as BetaToolChoiceAuto;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChoiceAny"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAny(out var value)) {
    ///     // `value` is of type `BetaToolChoiceAny`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAny([NotNullWhen(true)] out BetaToolChoiceAny? value)
    {
        value = this.Value as BetaToolChoiceAny;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChoiceTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool(out var value)) {
    ///     // `value` is of type `BetaToolChoiceTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool([NotNullWhen(true)] out BetaToolChoiceTool? value)
    {
        value = this.Value as BetaToolChoiceTool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChoiceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `BetaToolChoiceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out BetaToolChoiceNone? value)
    {
        value = this.Value as BetaToolChoiceNone;
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
    ///     (BetaToolChoiceAuto value) => {...},
    ///     (BetaToolChoiceAny value) => {...},
    ///     (BetaToolChoiceTool value) => {...},
    ///     (BetaToolChoiceNone value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaToolChoiceAuto> auto,
        System::Action<BetaToolChoiceAny> any,
        System::Action<BetaToolChoiceTool> tool,
        System::Action<BetaToolChoiceNone> none
    )
    {
        switch (this.Value)
        {
            case BetaToolChoiceAuto value:
                auto(value);
                break;
            case BetaToolChoiceAny value:
                any(value);
                break;
            case BetaToolChoiceTool value:
                tool(value);
                break;
            case BetaToolChoiceNone value:
                none(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolChoice"
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
    ///     (BetaToolChoiceAuto value) => {...},
    ///     (BetaToolChoiceAny value) => {...},
    ///     (BetaToolChoiceTool value) => {...},
    ///     (BetaToolChoiceNone value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaToolChoiceAuto, T> auto,
        System::Func<BetaToolChoiceAny, T> any,
        System::Func<BetaToolChoiceTool, T> tool,
        System::Func<BetaToolChoiceNone, T> none
    )
    {
        return this.Value switch
        {
            BetaToolChoiceAuto value => auto(value),
            BetaToolChoiceAny value => any(value),
            BetaToolChoiceTool value => tool(value),
            BetaToolChoiceNone value => none(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            ),
        };
    }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            );
        }
    }

    public virtual bool Equals(BetaToolChoice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaToolChoiceConverter : JsonConverter<BetaToolChoice>
{
    public override BetaToolChoice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "auto":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAuto>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "any":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tool":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceTool>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceNone>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new BetaToolChoice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolChoice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
