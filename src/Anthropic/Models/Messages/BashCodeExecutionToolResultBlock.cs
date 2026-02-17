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
        BashCodeExecutionToolResultBlock,
        BashCodeExecutionToolResultBlockFromRaw
    >)
)]
public sealed record class BashCodeExecutionToolResultBlock : JsonModel
{
    public required Content Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>("content");
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
                JsonSerializer.SerializeToElement("bash_code_execution_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BashCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BashCodeExecutionToolResultBlock(
        BashCodeExecutionToolResultBlock bashCodeExecutionToolResultBlock
    )
        : base(bashCodeExecutionToolResultBlock) { }
#pragma warning restore CS8618

    public BashCodeExecutionToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BashCodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BashCodeExecutionToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BashCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BashCodeExecutionToolResultBlockFromRaw : IFromRawJson<BashCodeExecutionToolResultBlock>
{
    /// <inheritdoc/>
    public BashCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BashCodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
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
                bashCodeExecutionToolResultError: (x) => x.Type,
                bashCodeExecutionResultBlock: (x) => x.Type
            );
        }
    }

    public Content(BashCodeExecutionToolResultError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(BashCodeExecutionResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BashCodeExecutionToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionToolResultError(out var value)) {
    ///     // `value` is of type `BashCodeExecutionToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionToolResultError(
        [NotNullWhen(true)] out BashCodeExecutionToolResultError? value
    )
    {
        value = this.Value as BashCodeExecutionToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BashCodeExecutionResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionResultBlock(out var value)) {
    ///     // `value` is of type `BashCodeExecutionResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionResultBlock(
        [NotNullWhen(true)] out BashCodeExecutionResultBlock? value
    )
    {
        value = this.Value as BashCodeExecutionResultBlock;
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
    ///     (BashCodeExecutionToolResultError value) => {...},
    ///     (BashCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BashCodeExecutionToolResultError> bashCodeExecutionToolResultError,
        System::Action<BashCodeExecutionResultBlock> bashCodeExecutionResultBlock
    )
    {
        switch (this.Value)
        {
            case BashCodeExecutionToolResultError value:
                bashCodeExecutionToolResultError(value);
                break;
            case BashCodeExecutionResultBlock value:
                bashCodeExecutionResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
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
    ///     (BashCodeExecutionToolResultError value) => {...},
    ///     (BashCodeExecutionResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BashCodeExecutionToolResultError, T> bashCodeExecutionToolResultError,
        System::Func<BashCodeExecutionResultBlock, T> bashCodeExecutionResultBlock
    )
    {
        return this.Value switch
        {
            BashCodeExecutionToolResultError value => bashCodeExecutionToolResultError(value),
            BashCodeExecutionResultBlock value => bashCodeExecutionResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public static implicit operator Content(BashCodeExecutionToolResultError value) => new(value);

    public static implicit operator Content(BashCodeExecutionResultBlock value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch(
            (bashCodeExecutionToolResultError) => bashCodeExecutionToolResultError.Validate(),
            (bashCodeExecutionResultBlock) => bashCodeExecutionResultBlock.Validate()
        );
    }

    public virtual bool Equals(Content? other) =>
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
            BashCodeExecutionToolResultError _ => 0,
            BashCodeExecutionResultBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<BashCodeExecutionResultBlock>(
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

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
