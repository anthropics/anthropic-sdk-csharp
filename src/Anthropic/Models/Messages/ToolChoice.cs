using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice
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

    public ToolChoice(ToolChoiceAuto value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceAny value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceNone value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceAuto"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuto(out var value)) {
    ///     // `value` is of type `ToolChoiceAuto`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuto([NotNullWhen(true)] out ToolChoiceAuto? value)
    {
        value = this.Value as ToolChoiceAuto;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceAny"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAny(out var value)) {
    ///     // `value` is of type `ToolChoiceAny`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAny([NotNullWhen(true)] out ToolChoiceAny? value)
    {
        value = this.Value as ToolChoiceAny;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceTool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTool(out var value)) {
    ///     // `value` is of type `ToolChoiceTool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTool([NotNullWhen(true)] out ToolChoiceTool? value)
    {
        value = this.Value as ToolChoiceTool;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceNone"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `ToolChoiceNone`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out ToolChoiceNone? value)
    {
        value = this.Value as ToolChoiceNone;
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
    ///     (ToolChoiceAuto value) => {...},
    ///     (ToolChoiceAny value) => {...},
    ///     (ToolChoiceTool value) => {...},
    ///     (ToolChoiceNone value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ToolChoiceAuto> auto,
        System::Action<ToolChoiceAny> any,
        System::Action<ToolChoiceTool> tool,
        System::Action<ToolChoiceNone> none
    )
    {
        switch (this.Value)
        {
            case ToolChoiceAuto value:
                auto(value);
                break;
            case ToolChoiceAny value:
                any(value);
                break;
            case ToolChoiceTool value:
                tool(value);
                break;
            case ToolChoiceNone value:
                none(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolChoice"
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
    ///     (ToolChoiceAuto value) => {...},
    ///     (ToolChoiceAny value) => {...},
    ///     (ToolChoiceTool value) => {...},
    ///     (ToolChoiceNone value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ToolChoiceAuto, T> auto,
        System::Func<ToolChoiceAny, T> any,
        System::Func<ToolChoiceTool, T> tool,
        System::Func<ToolChoiceNone, T> none
    )
    {
        return this.Value switch
        {
            ToolChoiceAuto value => auto(value),
            ToolChoiceAny value => any(value),
            ToolChoiceTool value => tool(value),
            ToolChoiceNone value => none(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolChoice"
            ),
        };
    }

    public static implicit operator ToolChoice(ToolChoiceAuto value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolChoice");
        }
        this.Switch(
            (auto) => auto.Validate(),
            (any) => any.Validate(),
            (tool) => tool.Validate(),
            (none) => none.Validate()
        );
    }

    public virtual bool Equals(ToolChoice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
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
            case "auto":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(element, options);
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
            case "any":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(element, options);
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
            case "tool":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(element, options);
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
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(element, options);
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
                return new ToolChoice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
