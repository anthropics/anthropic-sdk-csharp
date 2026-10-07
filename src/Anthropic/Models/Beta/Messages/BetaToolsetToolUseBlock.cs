using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaToolsetToolUseBlockConverter))]
public record class BetaToolsetToolUseBlock : ModelBase
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

    public BetaToolsetToolUseBlock(BetaBrowserToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolsetToolUseBlock(BetaComputerToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolsetToolUseBlock(BetaToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolsetToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBrowser(out var value)) {
    ///     // `value` is of type `BetaBrowserToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBrowser([NotNullWhen(true)] out BetaBrowserToolUseBlock? value)
    {
        value = this.Value as BetaBrowserToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputer(out var value)) {
    ///     // `value` is of type `BetaComputerToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputer([NotNullWhen(true)] out BetaComputerToolUseBlock? value)
    {
        value = this.Value as BetaComputerToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolUseBlock(out var value)) {
    ///     // `value` is of type `BetaToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolUseBlock([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = this.Value as BetaToolUseBlock;
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
    ///     (BetaBrowserToolUseBlock value) =&gt; {...},
    ///     (BetaComputerToolUseBlock value) =&gt; {...},
    ///     (BetaToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBrowserToolUseBlock> browser,
        System::Action<BetaComputerToolUseBlock> computer,
        System::Action<BetaToolUseBlock> betaToolUseBlock
    )
    {
        switch (this.Value)
        {
            case BetaBrowserToolUseBlock value:
                browser(value);
                break;
            case BetaComputerToolUseBlock value:
                computer(value);
                break;
            case BetaToolUseBlock value:
                betaToolUseBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolsetToolUseBlock"
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
    ///     (BetaBrowserToolUseBlock value) =&gt; {...},
    ///     (BetaComputerToolUseBlock value) =&gt; {...},
    ///     (BetaToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBrowserToolUseBlock, T> browser,
        System::Func<BetaComputerToolUseBlock, T> computer,
        System::Func<BetaToolUseBlock, T> betaToolUseBlock
    )
    {
        return this.Value switch
        {
            BetaBrowserToolUseBlock value => browser(value),
            BetaComputerToolUseBlock value => computer(value),
            BetaToolUseBlock value => betaToolUseBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolsetToolUseBlock"
            ),
        };
    }

    public static implicit operator BetaToolsetToolUseBlock(BetaBrowserToolUseBlock value) =>
        new(value);

    public static implicit operator BetaToolsetToolUseBlock(BetaComputerToolUseBlock value) =>
        new(value);

    public static implicit operator BetaToolsetToolUseBlock(BetaToolUseBlock value) => new(value);

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
                "Data did not match any variant of BetaToolsetToolUseBlock"
            );
        }
        this.Switch(
            (browser) => browser.Validate(),
            (computer) => computer.Validate(),
            (betaToolUseBlock) => betaToolUseBlock.Validate()
        );
    }

    public virtual bool Equals(BetaToolsetToolUseBlock? other) =>
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
            BetaBrowserToolUseBlock _ => 0,
            BetaComputerToolUseBlock _ => 1,
            BetaToolUseBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaToolsetToolUseBlockConverter : JsonConverter<BetaToolsetToolUseBlock>
{
    public override BetaToolsetToolUseBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
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
            var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(element, options);
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
        BetaToolsetToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
