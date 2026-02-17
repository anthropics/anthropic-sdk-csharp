using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Code execution result with encrypted stdout for PFC + web_search results.
/// </summary>
[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public record class BetaCodeExecutionToolResultBlockContent : ModelBase
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

    public BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCodeExecutionToolResultBlockContent(
        BetaEncryptedCodeExecutionResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCodeExecutionToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out BetaCodeExecutionToolResultError? value)
    {
        value = this.Value as BetaCodeExecutionToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResultBlock(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResultBlock([NotNullWhen(true)] out BetaCodeExecutionResultBlock? value)
    {
        value = this.Value as BetaCodeExecutionResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaEncryptedCodeExecutionResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEncryptedCodeExecutionResultBlock(out var value)) {
    ///     // `value` is of type `BetaEncryptedCodeExecutionResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEncryptedCodeExecutionResultBlock(
        [NotNullWhen(true)] out BetaEncryptedCodeExecutionResultBlock? value
    )
    {
        value = this.Value as BetaEncryptedCodeExecutionResultBlock;
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
    ///     (BetaCodeExecutionToolResultError value) => {...},
    ///     (BetaCodeExecutionResultBlock value) => {...},
    ///     (BetaEncryptedCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCodeExecutionToolResultError> error,
        System::Action<BetaCodeExecutionResultBlock> resultBlock,
        System::Action<BetaEncryptedCodeExecutionResultBlock> encryptedCodeExecutionResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaCodeExecutionToolResultError value:
                error(value);
                break;
            case BetaCodeExecutionResultBlock value:
                resultBlock(value);
                break;
            case BetaEncryptedCodeExecutionResultBlock value:
                encryptedCodeExecutionResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
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
    ///     (BetaCodeExecutionToolResultError value) => {...},
    ///     (BetaCodeExecutionResultBlock value) => {...},
    ///     (BetaEncryptedCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCodeExecutionToolResultError, T> error,
        System::Func<BetaCodeExecutionResultBlock, T> resultBlock,
        System::Func<BetaEncryptedCodeExecutionResultBlock, T> encryptedCodeExecutionResultBlock
    )
    {
        return this.Value switch
        {
            BetaCodeExecutionToolResultError value => error(value),
            BetaCodeExecutionResultBlock value => resultBlock(value),
            BetaEncryptedCodeExecutionResultBlock value => encryptedCodeExecutionResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) => new(value);

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaEncryptedCodeExecutionResultBlock value
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
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            );
        }
        this.Switch(
            (error) => error.Validate(),
            (resultBlock) => resultBlock.Validate(),
            (encryptedCodeExecutionResultBlock) => encryptedCodeExecutionResultBlock.Validate()
        );
    }

    public virtual bool Equals(BetaCodeExecutionToolResultBlockContent? other) =>
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
            BetaCodeExecutionToolResultError _ => 0,
            BetaCodeExecutionResultBlock _ => 1,
            BetaEncryptedCodeExecutionResultBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockContent>
{
    public override BetaCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
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
            var deserialized = JsonSerializer.Deserialize<BetaEncryptedCodeExecutionResultBlock>(
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
        BetaCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
