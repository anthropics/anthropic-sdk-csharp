using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        TextEditorCodeExecutionToolResultBlock,
        TextEditorCodeExecutionToolResultBlockFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionToolResultBlock : JsonModel
{
    public required TextEditorCodeExecutionToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TextEditorCodeExecutionToolResultBlockContent>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextEditorCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionToolResultBlock(
        TextEditorCodeExecutionToolResultBlock textEditorCodeExecutionToolResultBlock
    )
        : base(textEditorCodeExecutionToolResultBlock) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionToolResultBlockFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionToolResultBlockFromRaw
    : IFromRawJson<TextEditorCodeExecutionToolResultBlock>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TextEditorCodeExecutionToolResultBlockContentConverter))]
public record class TextEditorCodeExecutionToolResultBlockContent : ModelBase
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
                textEditorCodeExecutionToolResultError: (x) => x.Type,
                textEditorCodeExecutionViewResultBlock: (x) => x.Type,
                textEditorCodeExecutionCreateResultBlock: (x) => x.Type,
                textEditorCodeExecutionStrReplaceResultBlock: (x) => x.Type
            );
        }
    }

    public TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionToolResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionViewResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionCreateResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionStrReplaceResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionToolResultError(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionToolResultError(
        [NotNullWhen(true)] out TextEditorCodeExecutionToolResultError? value
    )
    {
        value = this.Value as TextEditorCodeExecutionToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionViewResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionViewResultBlock(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionViewResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionViewResultBlock(
        [NotNullWhen(true)] out TextEditorCodeExecutionViewResultBlock? value
    )
    {
        value = this.Value as TextEditorCodeExecutionViewResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionCreateResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionCreateResultBlock(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionCreateResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionCreateResultBlock(
        [NotNullWhen(true)] out TextEditorCodeExecutionCreateResultBlock? value
    )
    {
        value = this.Value as TextEditorCodeExecutionCreateResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionStrReplaceResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionStrReplaceResultBlock(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionStrReplaceResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionStrReplaceResultBlock(
        [NotNullWhen(true)] out TextEditorCodeExecutionStrReplaceResultBlock? value
    )
    {
        value = this.Value as TextEditorCodeExecutionStrReplaceResultBlock;
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
    ///     (TextEditorCodeExecutionToolResultError value) => {...},
    ///     (TextEditorCodeExecutionViewResultBlock value) => {...},
    ///     (TextEditorCodeExecutionCreateResultBlock value) => {...},
    ///     (TextEditorCodeExecutionStrReplaceResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextEditorCodeExecutionToolResultError> textEditorCodeExecutionToolResultError,
        System::Action<TextEditorCodeExecutionViewResultBlock> textEditorCodeExecutionViewResultBlock,
        System::Action<TextEditorCodeExecutionCreateResultBlock> textEditorCodeExecutionCreateResultBlock,
        System::Action<TextEditorCodeExecutionStrReplaceResultBlock> textEditorCodeExecutionStrReplaceResultBlock
    )
    {
        switch (this.Value)
        {
            case TextEditorCodeExecutionToolResultError value:
                textEditorCodeExecutionToolResultError(value);
                break;
            case TextEditorCodeExecutionViewResultBlock value:
                textEditorCodeExecutionViewResultBlock(value);
                break;
            case TextEditorCodeExecutionCreateResultBlock value:
                textEditorCodeExecutionCreateResultBlock(value);
                break;
            case TextEditorCodeExecutionStrReplaceResultBlock value:
                textEditorCodeExecutionStrReplaceResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TextEditorCodeExecutionToolResultBlockContent"
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
    ///     (TextEditorCodeExecutionToolResultError value) => {...},
    ///     (TextEditorCodeExecutionViewResultBlock value) => {...},
    ///     (TextEditorCodeExecutionCreateResultBlock value) => {...},
    ///     (TextEditorCodeExecutionStrReplaceResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            TextEditorCodeExecutionToolResultError,
            T
        > textEditorCodeExecutionToolResultError,
        System::Func<
            TextEditorCodeExecutionViewResultBlock,
            T
        > textEditorCodeExecutionViewResultBlock,
        System::Func<
            TextEditorCodeExecutionCreateResultBlock,
            T
        > textEditorCodeExecutionCreateResultBlock,
        System::Func<
            TextEditorCodeExecutionStrReplaceResultBlock,
            T
        > textEditorCodeExecutionStrReplaceResultBlock
    )
    {
        return this.Value switch
        {
            TextEditorCodeExecutionToolResultError value => textEditorCodeExecutionToolResultError(
                value
            ),
            TextEditorCodeExecutionViewResultBlock value => textEditorCodeExecutionViewResultBlock(
                value
            ),
            TextEditorCodeExecutionCreateResultBlock value =>
                textEditorCodeExecutionCreateResultBlock(value),
            TextEditorCodeExecutionStrReplaceResultBlock value =>
                textEditorCodeExecutionStrReplaceResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextEditorCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionViewResultBlock value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionCreateResultBlock value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockContent(
        TextEditorCodeExecutionStrReplaceResultBlock value
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
                "Data did not match any variant of TextEditorCodeExecutionToolResultBlockContent"
            );
        }
        this.Switch(
            (textEditorCodeExecutionToolResultError) =>
                textEditorCodeExecutionToolResultError.Validate(),
            (textEditorCodeExecutionViewResultBlock) =>
                textEditorCodeExecutionViewResultBlock.Validate(),
            (textEditorCodeExecutionCreateResultBlock) =>
                textEditorCodeExecutionCreateResultBlock.Validate(),
            (textEditorCodeExecutionStrReplaceResultBlock) =>
                textEditorCodeExecutionStrReplaceResultBlock.Validate()
        );
    }

    public virtual bool Equals(TextEditorCodeExecutionToolResultBlockContent? other) =>
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
            TextEditorCodeExecutionToolResultError _ => 0,
            TextEditorCodeExecutionViewResultBlock _ => 1,
            TextEditorCodeExecutionCreateResultBlock _ => 2,
            TextEditorCodeExecutionStrReplaceResultBlock _ => 3,
            _ => -1,
        };
    }
}

sealed class TextEditorCodeExecutionToolResultBlockContentConverter
    : JsonConverter<TextEditorCodeExecutionToolResultBlockContent>
{
    public override TextEditorCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionViewResultBlock>(
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
            var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionCreateResultBlock>(
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
            var deserialized =
                JsonSerializer.Deserialize<TextEditorCodeExecutionStrReplaceResultBlock>(
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
        TextEditorCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
