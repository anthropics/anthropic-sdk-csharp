using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaTextEditorCodeExecutionToolResultBlock,
        BetaTextEditorCodeExecutionToolResultBlockFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultBlock : ModelBase
{
    public required BetaTextEditorCodeExecutionToolResultBlockContent Content
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaTextEditorCodeExecutionToolResultBlockContent>(
                this.RawData,
                "content"
            );
        }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required string ToolUseID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_use_id"); }
        init { ModelBase.Set(this._rawData, "tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_tool_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionToolResultBlockFromRaw
    : IFromRaw<BetaTextEditorCodeExecutionToolResultBlock>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionToolResultBlockContentConverter))]
public record class BetaTextEditorCodeExecutionToolResultBlockContent
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
                betaTextEditorCodeExecutionToolResultError: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlock: (x) => x.Type
            );
        }
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionViewResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionCreateResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionToolResultError(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultError? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionViewResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionViewResultBlock(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionViewResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionViewResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionCreateResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionCreateResultBlock(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionCreateResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionStrReplaceResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionStrReplaceResultBlock(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionStrReplaceResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlock;
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
    ///     (BetaTextEditorCodeExecutionToolResultError value) => {...},
    ///     (BetaTextEditorCodeExecutionViewResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionCreateResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionStrReplaceResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextEditorCodeExecutionToolResultError> betaTextEditorCodeExecutionToolResultError,
        System::Action<BetaTextEditorCodeExecutionViewResultBlock> betaTextEditorCodeExecutionViewResultBlock,
        System::Action<BetaTextEditorCodeExecutionCreateResultBlock> betaTextEditorCodeExecutionCreateResultBlock,
        System::Action<BetaTextEditorCodeExecutionStrReplaceResultBlock> betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultError value:
                betaTextEditorCodeExecutionToolResultError(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlock value:
                betaTextEditorCodeExecutionViewResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlock value:
                betaTextEditorCodeExecutionCreateResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlock value:
                betaTextEditorCodeExecutionStrReplaceResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
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
    ///     (BetaTextEditorCodeExecutionToolResultError value) => {...},
    ///     (BetaTextEditorCodeExecutionViewResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionCreateResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionStrReplaceResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaTextEditorCodeExecutionToolResultError,
            T
        > betaTextEditorCodeExecutionToolResultError,
        System::Func<
            BetaTextEditorCodeExecutionViewResultBlock,
            T
        > betaTextEditorCodeExecutionViewResultBlock,
        System::Func<
            BetaTextEditorCodeExecutionCreateResultBlock,
            T
        > betaTextEditorCodeExecutionCreateResultBlock,
        System::Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlock,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultError value =>
                betaTextEditorCodeExecutionToolResultError(value),
            BetaTextEditorCodeExecutionViewResultBlock value =>
                betaTextEditorCodeExecutionViewResultBlock(value),
            BetaTextEditorCodeExecutionCreateResultBlock value =>
                betaTextEditorCodeExecutionCreateResultBlock(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlock value =>
                betaTextEditorCodeExecutionStrReplaceResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionViewResultBlock value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionCreateResultBlock value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlock value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaTextEditorCodeExecutionToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaTextEditorCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaTextEditorCodeExecutionToolResultBlockContent>
{
    public override BetaTextEditorCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
                    json,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
                    json,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
                    json,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlock>(
                    json,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextEditorCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
