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
        TextEditorCodeExecutionToolResultBlockParam,
        TextEditorCodeExecutionToolResultBlockParamFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionToolResultBlockParam : JsonModel
{
    public required TextEditorCodeExecutionToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TextEditorCodeExecutionToolResultBlockParamContent>(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
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
        this.CacheControl?.Validate();
    }

    public TextEditorCodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionToolResultBlockParam(
        TextEditorCodeExecutionToolResultBlockParam textEditorCodeExecutionToolResultBlockParam
    )
        : base(textEditorCodeExecutionToolResultBlockParam) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionToolResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionToolResultBlockParamFromRaw
    : IFromRawJson<TextEditorCodeExecutionToolResultBlockParam>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TextEditorCodeExecutionToolResultBlockParamContentConverter))]
public record class TextEditorCodeExecutionToolResultBlockParamContent : ModelBase
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
                textEditorCodeExecutionToolResultErrorParam: (x) => x.Type,
                textEditorCodeExecutionViewResultBlockParam: (x) => x.Type,
                textEditorCodeExecutionCreateResultBlockParam: (x) => x.Type,
                textEditorCodeExecutionStrReplaceResultBlockParam: (x) => x.Type
            );
        }
    }

    public TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionToolResultErrorParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionViewResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionCreateResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionStrReplaceResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextEditorCodeExecutionToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionToolResultErrorParam(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out TextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as TextEditorCodeExecutionToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionViewResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionViewResultBlockParam(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionViewResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out TextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = this.Value as TextEditorCodeExecutionViewResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionCreateResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionCreateResultBlockParam(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionCreateResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out TextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = this.Value as TextEditorCodeExecutionCreateResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionStrReplaceResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionStrReplaceResultBlockParam(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionStrReplaceResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out TextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = this.Value as TextEditorCodeExecutionStrReplaceResultBlockParam;
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
    ///     (TextEditorCodeExecutionToolResultErrorParam value) => {...},
    ///     (TextEditorCodeExecutionViewResultBlockParam value) => {...},
    ///     (TextEditorCodeExecutionCreateResultBlockParam value) => {...},
    ///     (TextEditorCodeExecutionStrReplaceResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextEditorCodeExecutionToolResultErrorParam> textEditorCodeExecutionToolResultErrorParam,
        System::Action<TextEditorCodeExecutionViewResultBlockParam> textEditorCodeExecutionViewResultBlockParam,
        System::Action<TextEditorCodeExecutionCreateResultBlockParam> textEditorCodeExecutionCreateResultBlockParam,
        System::Action<TextEditorCodeExecutionStrReplaceResultBlockParam> textEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        switch (this.Value)
        {
            case TextEditorCodeExecutionToolResultErrorParam value:
                textEditorCodeExecutionToolResultErrorParam(value);
                break;
            case TextEditorCodeExecutionViewResultBlockParam value:
                textEditorCodeExecutionViewResultBlockParam(value);
                break;
            case TextEditorCodeExecutionCreateResultBlockParam value:
                textEditorCodeExecutionCreateResultBlockParam(value);
                break;
            case TextEditorCodeExecutionStrReplaceResultBlockParam value:
                textEditorCodeExecutionStrReplaceResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TextEditorCodeExecutionToolResultBlockParamContent"
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
    ///     (TextEditorCodeExecutionToolResultErrorParam value) => {...},
    ///     (TextEditorCodeExecutionViewResultBlockParam value) => {...},
    ///     (TextEditorCodeExecutionCreateResultBlockParam value) => {...},
    ///     (TextEditorCodeExecutionStrReplaceResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            TextEditorCodeExecutionToolResultErrorParam,
            T
        > textEditorCodeExecutionToolResultErrorParam,
        System::Func<
            TextEditorCodeExecutionViewResultBlockParam,
            T
        > textEditorCodeExecutionViewResultBlockParam,
        System::Func<
            TextEditorCodeExecutionCreateResultBlockParam,
            T
        > textEditorCodeExecutionCreateResultBlockParam,
        System::Func<
            TextEditorCodeExecutionStrReplaceResultBlockParam,
            T
        > textEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        return this.Value switch
        {
            TextEditorCodeExecutionToolResultErrorParam value =>
                textEditorCodeExecutionToolResultErrorParam(value),
            TextEditorCodeExecutionViewResultBlockParam value =>
                textEditorCodeExecutionViewResultBlockParam(value),
            TextEditorCodeExecutionCreateResultBlockParam value =>
                textEditorCodeExecutionCreateResultBlockParam(value),
            TextEditorCodeExecutionStrReplaceResultBlockParam value =>
                textEditorCodeExecutionStrReplaceResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextEditorCodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionViewResultBlockParam value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionCreateResultBlockParam value
    ) => new(value);

    public static implicit operator TextEditorCodeExecutionToolResultBlockParamContent(
        TextEditorCodeExecutionStrReplaceResultBlockParam value
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
                "Data did not match any variant of TextEditorCodeExecutionToolResultBlockParamContent"
            );
        }
        this.Switch(
            (textEditorCodeExecutionToolResultErrorParam) =>
                textEditorCodeExecutionToolResultErrorParam.Validate(),
            (textEditorCodeExecutionViewResultBlockParam) =>
                textEditorCodeExecutionViewResultBlockParam.Validate(),
            (textEditorCodeExecutionCreateResultBlockParam) =>
                textEditorCodeExecutionCreateResultBlockParam.Validate(),
            (textEditorCodeExecutionStrReplaceResultBlockParam) =>
                textEditorCodeExecutionStrReplaceResultBlockParam.Validate()
        );
    }

    public virtual bool Equals(TextEditorCodeExecutionToolResultBlockParamContent? other) =>
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
            TextEditorCodeExecutionToolResultErrorParam _ => 0,
            TextEditorCodeExecutionViewResultBlockParam _ => 1,
            TextEditorCodeExecutionCreateResultBlockParam _ => 2,
            TextEditorCodeExecutionStrReplaceResultBlockParam _ => 3,
            _ => -1,
        };
    }
}

sealed class TextEditorCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<TextEditorCodeExecutionToolResultBlockParamContent>
{
    public override TextEditorCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultErrorParam>(
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
                JsonSerializer.Deserialize<TextEditorCodeExecutionViewResultBlockParam>(
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
                JsonSerializer.Deserialize<TextEditorCodeExecutionCreateResultBlockParam>(
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
                JsonSerializer.Deserialize<TextEditorCodeExecutionStrReplaceResultBlockParam>(
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
        TextEditorCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
