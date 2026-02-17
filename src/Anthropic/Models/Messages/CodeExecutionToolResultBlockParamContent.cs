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
[JsonConverter(typeof(CodeExecutionToolResultBlockParamContentConverter))]
public record class CodeExecutionToolResultBlockParamContent : ModelBase
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
                errorParam: (x) => x.Type,
                resultBlockParam: (x) => x.Type,
                encryptedCodeExecutionResultBlockParam: (x) => x.Type
            );
        }
    }

    public long? ReturnCode
    {
        get
        {
            return Match<long?>(
                errorParam: (_) => null,
                resultBlockParam: (x) => x.ReturnCode,
                encryptedCodeExecutionResultBlockParam: (x) => x.ReturnCode
            );
        }
    }

    public string? Stderr
    {
        get
        {
            return Match<string?>(
                errorParam: (_) => null,
                resultBlockParam: (x) => x.Stderr,
                encryptedCodeExecutionResultBlockParam: (x) => x.Stderr
            );
        }
    }

    public CodeExecutionToolResultBlockParamContent(
        CodeExecutionToolResultErrorParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockParamContent(
        CodeExecutionResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockParamContent(
        EncryptedCodeExecutionResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CodeExecutionToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickErrorParam(out var value)) {
    ///     // `value` is of type `CodeExecutionToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickErrorParam([NotNullWhen(true)] out CodeExecutionToolResultErrorParam? value)
    {
        value = this.Value as CodeExecutionToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResultBlockParam(out var value)) {
    ///     // `value` is of type `CodeExecutionResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResultBlockParam(
        [NotNullWhen(true)] out CodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as CodeExecutionResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EncryptedCodeExecutionResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEncryptedCodeExecutionResultBlockParam(out var value)) {
    ///     // `value` is of type `EncryptedCodeExecutionResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEncryptedCodeExecutionResultBlockParam(
        [NotNullWhen(true)] out EncryptedCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as EncryptedCodeExecutionResultBlockParam;
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
    ///     (CodeExecutionToolResultErrorParam value) => {...},
    ///     (CodeExecutionResultBlockParam value) => {...},
    ///     (EncryptedCodeExecutionResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CodeExecutionToolResultErrorParam> errorParam,
        System::Action<CodeExecutionResultBlockParam> resultBlockParam,
        System::Action<EncryptedCodeExecutionResultBlockParam> encryptedCodeExecutionResultBlockParam
    )
    {
        switch (this.Value)
        {
            case CodeExecutionToolResultErrorParam value:
                errorParam(value);
                break;
            case CodeExecutionResultBlockParam value:
                resultBlockParam(value);
                break;
            case EncryptedCodeExecutionResultBlockParam value:
                encryptedCodeExecutionResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CodeExecutionToolResultBlockParamContent"
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
    ///     (CodeExecutionToolResultErrorParam value) => {...},
    ///     (CodeExecutionResultBlockParam value) => {...},
    ///     (EncryptedCodeExecutionResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CodeExecutionToolResultErrorParam, T> errorParam,
        System::Func<CodeExecutionResultBlockParam, T> resultBlockParam,
        System::Func<
            EncryptedCodeExecutionResultBlockParam,
            T
        > encryptedCodeExecutionResultBlockParam
    )
    {
        return this.Value switch
        {
            CodeExecutionToolResultErrorParam value => errorParam(value),
            CodeExecutionResultBlockParam value => resultBlockParam(value),
            EncryptedCodeExecutionResultBlockParam value => encryptedCodeExecutionResultBlockParam(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator CodeExecutionToolResultBlockParamContent(
        CodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator CodeExecutionToolResultBlockParamContent(
        CodeExecutionResultBlockParam value
    ) => new(value);

    public static implicit operator CodeExecutionToolResultBlockParamContent(
        EncryptedCodeExecutionResultBlockParam value
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
                "Data did not match any variant of CodeExecutionToolResultBlockParamContent"
            );
        }
        this.Switch(
            (errorParam) => errorParam.Validate(),
            (resultBlockParam) => resultBlockParam.Validate(),
            (encryptedCodeExecutionResultBlockParam) =>
                encryptedCodeExecutionResultBlockParam.Validate()
        );
    }

    public virtual bool Equals(CodeExecutionToolResultBlockParamContent? other) =>
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
            CodeExecutionToolResultErrorParam _ => 0,
            CodeExecutionResultBlockParam _ => 1,
            EncryptedCodeExecutionResultBlockParam _ => 2,
            _ => -1,
        };
    }
}

sealed class CodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<CodeExecutionToolResultBlockParamContent>
{
    public override CodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultErrorParam>(
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
            var deserialized = JsonSerializer.Deserialize<CodeExecutionResultBlockParam>(
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
            var deserialized = JsonSerializer.Deserialize<EncryptedCodeExecutionResultBlockParam>(
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
        CodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
