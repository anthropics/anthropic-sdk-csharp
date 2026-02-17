using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Code execution result with encrypted stdout for PFC + web_search results.
/// </summary>
[JsonConverter(typeof(CodeExecutionToolResultBlockContentConverter))]
public record class CodeExecutionToolResultBlockContent : ModelBase
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
                error: (x) => x.Type,
                resultBlock: (x) => x.Type,
                encryptedCodeExecutionResultBlock: (x) => x.Type
            );
        }
    }

    public long? ReturnCode
    {
        get
        {
            return Match<long?>(
                error: (_) => null,
                resultBlock: (x) => x.ReturnCode,
                encryptedCodeExecutionResultBlock: (x) => x.ReturnCode
            );
        }
    }

    public string? Stderr
    {
        get
        {
            return Match<string?>(
                error: (_) => null,
                resultBlock: (x) => x.Stderr,
                encryptedCodeExecutionResultBlock: (x) => x.Stderr
            );
        }
    }

    public CodeExecutionToolResultBlockContent(
        CodeExecutionToolResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockContent(
        CodeExecutionResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockContent(
        EncryptedCodeExecutionResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `CodeExecutionToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out CodeExecutionToolResultError? value)
    {
        value = this.Value as CodeExecutionToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResultBlock(out var value)) {
    ///     // `value` is of type `CodeExecutionResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResultBlock([NotNullWhen(true)] out CodeExecutionResultBlock? value)
    {
        value = this.Value as CodeExecutionResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EncryptedCodeExecutionResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEncryptedCodeExecutionResultBlock(out var value)) {
    ///     // `value` is of type `EncryptedCodeExecutionResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEncryptedCodeExecutionResultBlock(
        [NotNullWhen(true)] out EncryptedCodeExecutionResultBlock? value
    )
    {
        value = this.Value as EncryptedCodeExecutionResultBlock;
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
    ///     (CodeExecutionToolResultError value) => {...},
    ///     (CodeExecutionResultBlock value) => {...},
    ///     (EncryptedCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CodeExecutionToolResultError> error,
        System::Action<CodeExecutionResultBlock> resultBlock,
        System::Action<EncryptedCodeExecutionResultBlock> encryptedCodeExecutionResultBlock
    )
    {
        switch (this.Value)
        {
            case CodeExecutionToolResultError value:
                error(value);
                break;
            case CodeExecutionResultBlock value:
                resultBlock(value);
                break;
            case EncryptedCodeExecutionResultBlock value:
                encryptedCodeExecutionResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CodeExecutionToolResultBlockContent"
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
    ///     (CodeExecutionToolResultError value) => {...},
    ///     (CodeExecutionResultBlock value) => {...},
    ///     (EncryptedCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CodeExecutionToolResultError, T> error,
        System::Func<CodeExecutionResultBlock, T> resultBlock,
        System::Func<EncryptedCodeExecutionResultBlock, T> encryptedCodeExecutionResultBlock
    )
    {
        return this.Value switch
        {
            CodeExecutionToolResultError value => error(value),
            CodeExecutionResultBlock value => resultBlock(value),
            EncryptedCodeExecutionResultBlock value => encryptedCodeExecutionResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator CodeExecutionToolResultBlockContent(
        CodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator CodeExecutionToolResultBlockContent(
        CodeExecutionResultBlock value
    ) => new(value);

    public static implicit operator CodeExecutionToolResultBlockContent(
        EncryptedCodeExecutionResultBlock value
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
                "Data did not match any variant of CodeExecutionToolResultBlockContent"
            );
        }
        this.Switch(
            (error) => error.Validate(),
            (resultBlock) => resultBlock.Validate(),
            (encryptedCodeExecutionResultBlock) => encryptedCodeExecutionResultBlock.Validate()
        );
    }

    public virtual bool Equals(CodeExecutionToolResultBlockContent? other) =>
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
            CodeExecutionToolResultError _ => 0,
            CodeExecutionResultBlock _ => 1,
            EncryptedCodeExecutionResultBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class CodeExecutionToolResultBlockContentConverter
    : JsonConverter<CodeExecutionToolResultBlockContent>
{
    public override CodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<CodeExecutionResultBlock>(
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
            var deserialized = JsonSerializer.Deserialize<EncryptedCodeExecutionResultBlock>(
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
        CodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
