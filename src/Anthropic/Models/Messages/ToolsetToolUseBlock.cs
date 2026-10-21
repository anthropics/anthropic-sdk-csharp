using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ToolsetToolUseBlockConverter))]
public record class ToolsetToolUseBlock : ModelBase
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

    public ToolsetToolUseBlock(BrowserToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolsetToolUseBlock(ComputerToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolsetToolUseBlock(ToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolsetToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBrowser(out var value)) {
    ///     // `value` is of type `BrowserToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBrowser([NotNullWhen(true)] out BrowserToolUseBlock? value)
    {
        value = this.Value as BrowserToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputer(out var value)) {
    ///     // `value` is of type `ComputerToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputer([NotNullWhen(true)] out ComputerToolUseBlock? value)
    {
        value = this.Value as ComputerToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolUseBlock(out var value)) {
    ///     // `value` is of type `ToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolUseBlock([NotNullWhen(true)] out ToolUseBlock? value)
    {
        value = this.Value as ToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BrowserToolUseBlock value) =&gt; {...},
    ///     (ComputerToolUseBlock value) =&gt; {...},
    ///     (ToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BrowserToolUseBlock> browser,
        System::Action<ComputerToolUseBlock> computer,
        System::Action<ToolUseBlock> toolUseBlock
    )
    {
        switch (this.Value)
        {
            case BrowserToolUseBlock value:
                browser(value);
                break;
            case ComputerToolUseBlock value:
                computer(value);
                break;
            case ToolUseBlock value:
                toolUseBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolsetToolUseBlock"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BrowserToolUseBlock value) =&gt; {...},
    ///     (ComputerToolUseBlock value) =&gt; {...},
    ///     (ToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BrowserToolUseBlock, T> browser,
        System::Func<ComputerToolUseBlock, T> computer,
        System::Func<ToolUseBlock, T> toolUseBlock
    )
    {
        return this.Value switch
        {
            BrowserToolUseBlock value => browser(value),
            ComputerToolUseBlock value => computer(value),
            ToolUseBlock value => toolUseBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolsetToolUseBlock"
            ),
        };
    }

    public static implicit operator ToolsetToolUseBlock(BrowserToolUseBlock value) => new(value);

    public static implicit operator ToolsetToolUseBlock(ComputerToolUseBlock value) => new(value);

    public static implicit operator ToolsetToolUseBlock(ToolUseBlock value) => new(value);

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
                "Data did not match any variant of ToolsetToolUseBlock"
            );
        }
        this.Switch(
            (browser) => browser.Validate(),
            (computer) => computer.Validate(),
            (toolUseBlock) => toolUseBlock.Validate()
        );
    }

    public virtual bool Equals(ToolsetToolUseBlock? other) =>
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
            BrowserToolUseBlock _ => 0,
            ComputerToolUseBlock _ => 1,
            ToolUseBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class ToolsetToolUseBlockConverter : JsonConverter<ToolsetToolUseBlock>
{
    public override ToolsetToolUseBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(element, options);
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
        ToolsetToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
