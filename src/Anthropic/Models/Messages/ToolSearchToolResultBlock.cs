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
    typeof(JsonModelConverter<ToolSearchToolResultBlock, ToolSearchToolResultBlockFromRaw>)
)]
public sealed record class ToolSearchToolResultBlock : JsonModel
{
    public required ToolSearchToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToolSearchToolResultBlockContent>("content");
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
                JsonSerializer.SerializeToElement("tool_search_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolSearchToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolResultBlock(ToolSearchToolResultBlock toolSearchToolResultBlock)
        : base(toolSearchToolResultBlock) { }
#pragma warning restore CS8618

    public ToolSearchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolResultBlockFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolSearchToolResultBlockFromRaw : IFromRawJson<ToolSearchToolResultBlock>
{
    /// <inheritdoc/>
    public ToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolSearchToolResultBlockContentConverter))]
public record class ToolSearchToolResultBlockContent : ModelBase
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
                toolSearchToolResultError: (x) => x.Type,
                toolSearchToolSearchResultBlock: (x) => x.Type
            );
        }
    }

    public ToolSearchToolResultBlockContent(
        ToolSearchToolResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ToolSearchToolResultBlockContent(
        ToolSearchToolSearchResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ToolSearchToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolResultError(out var value)) {
    ///     // `value` is of type `ToolSearchToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolResultError(
        [NotNullWhen(true)] out ToolSearchToolResultError? value
    )
    {
        value = this.Value as ToolSearchToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolSearchResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolSearchResultBlock(out var value)) {
    ///     // `value` is of type `ToolSearchToolSearchResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolSearchResultBlock(
        [NotNullWhen(true)] out ToolSearchToolSearchResultBlock? value
    )
    {
        value = this.Value as ToolSearchToolSearchResultBlock;
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
    ///     (ToolSearchToolResultError value) => {...},
    ///     (ToolSearchToolSearchResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ToolSearchToolResultError> toolSearchToolResultError,
        System::Action<ToolSearchToolSearchResultBlock> toolSearchToolSearchResultBlock
    )
    {
        switch (this.Value)
        {
            case ToolSearchToolResultError value:
                toolSearchToolResultError(value);
                break;
            case ToolSearchToolSearchResultBlock value:
                toolSearchToolSearchResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolSearchToolResultBlockContent"
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
    ///     (ToolSearchToolResultError value) => {...},
    ///     (ToolSearchToolSearchResultBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ToolSearchToolResultError, T> toolSearchToolResultError,
        System::Func<ToolSearchToolSearchResultBlock, T> toolSearchToolSearchResultBlock
    )
    {
        return this.Value switch
        {
            ToolSearchToolResultError value => toolSearchToolResultError(value),
            ToolSearchToolSearchResultBlock value => toolSearchToolSearchResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator ToolSearchToolResultBlockContent(
        ToolSearchToolResultError value
    ) => new(value);

    public static implicit operator ToolSearchToolResultBlockContent(
        ToolSearchToolSearchResultBlock value
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
                "Data did not match any variant of ToolSearchToolResultBlockContent"
            );
        }
        this.Switch(
            (toolSearchToolResultError) => toolSearchToolResultError.Validate(),
            (toolSearchToolSearchResultBlock) => toolSearchToolSearchResultBlock.Validate()
        );
    }

    public virtual bool Equals(ToolSearchToolResultBlockContent? other) =>
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
            ToolSearchToolResultError _ => 0,
            ToolSearchToolSearchResultBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class ToolSearchToolResultBlockContentConverter
    : JsonConverter<ToolSearchToolResultBlockContent>
{
    public override ToolSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolSearchResultBlock>(
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
        ToolSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
