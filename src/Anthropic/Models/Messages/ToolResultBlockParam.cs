using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ToolResultBlockParam, ToolResultBlockParamFromRaw>))]
public sealed record class ToolResultBlockParam : ModelBase
{
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    public ToolResultBlockParamContent? Content
    {
        get
        {
            return ModelBase.GetNullableClass<ToolResultBlockParamContent>(this.RawData, "content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "content", value);
        }
    }

    public bool? IsError
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "is_error"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "is_error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Content?.Validate();
        _ = this.IsError;
    }

    public ToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

    public ToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static ToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}

class ToolResultBlockParamFromRaw : IFromRaw<ToolResultBlockParam>
{
    /// <inheritdoc/>
    public ToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolResultBlockParamContentConverter))]
public record class ToolResultBlockParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ToolResultBlockParamContent(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolResultBlockParamContent(IReadOnlyList<Block> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public ToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<Block>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBlocks(out var value)) {
    ///     // `value` is of type `IReadOnlyList<Block>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBlocks([NotNullWhen(true)] out IReadOnlyList<Block>? value)
    {
        value = this.Value as IReadOnlyList<Block>;
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
    ///     (string value) => {...},
    ///     (IReadOnlyList<Block> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<IReadOnlyList<Block>> blocks)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<Block> value:
                blocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolResultBlockParamContent"
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
    ///     (string value) => {...},
    ///     (IReadOnlyList<Block> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<IReadOnlyList<Block>, T> blocks)
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<Block> value => blocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator ToolResultBlockParamContent(string value) => new(value);

    public static implicit operator ToolResultBlockParamContent(List<Block> value) =>
        new((IReadOnlyList<Block>)value);

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
                "Data did not match any variant of ToolResultBlockParamContent"
            );
        }
    }

    public virtual bool Equals(ToolResultBlockParamContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ToolResultBlockParamContentConverter : JsonConverter<ToolResultBlockParamContent>
{
    public override ToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Block>>(json, options);
            if (deserialized != null)
            {
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
        ToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BlockConverter))]
public record class Block
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
                textBlockParam: (x) => x.Type,
                imageBlockParam: (x) => x.Type,
                searchResultBlockParam: (x) => x.Type,
                documentBlockParam: (x) => x.Type
            );
        }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                textBlockParam: (x) => x.CacheControl,
                imageBlockParam: (x) => x.CacheControl,
                searchResultBlockParam: (x) => x.CacheControl,
                documentBlockParam: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                textBlockParam: (_) => null,
                imageBlockParam: (_) => null,
                searchResultBlockParam: (x) => x.Title,
                documentBlockParam: (x) => x.Title
            );
        }
    }

    public Block(TextBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(ImageBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(SearchResultBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(DocumentBlockParam value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Block(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextBlockParam(out var value)) {
    ///     // `value` is of type `TextBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = this.Value as TextBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImageBlockParam(out var value)) {
    ///     // `value` is of type `ImageBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = this.Value as ImageBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SearchResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSearchResultBlockParam(out var value)) {
    ///     // `value` is of type `SearchResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSearchResultBlockParam([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = this.Value as SearchResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DocumentBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDocumentBlockParam(out var value)) {
    ///     // `value` is of type `DocumentBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDocumentBlockParam([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = this.Value as DocumentBlockParam;
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
    ///     (TextBlockParam value) => {...},
    ///     (ImageBlockParam value) => {...},
    ///     (SearchResultBlockParam value) => {...},
    ///     (DocumentBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextBlockParam> textBlockParam,
        System::Action<ImageBlockParam> imageBlockParam,
        System::Action<SearchResultBlockParam> searchResultBlockParam,
        System::Action<DocumentBlockParam> documentBlockParam
    )
    {
        switch (this.Value)
        {
            case TextBlockParam value:
                textBlockParam(value);
                break;
            case ImageBlockParam value:
                imageBlockParam(value);
                break;
            case SearchResultBlockParam value:
                searchResultBlockParam(value);
                break;
            case DocumentBlockParam value:
                documentBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
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
    ///     (TextBlockParam value) => {...},
    ///     (ImageBlockParam value) => {...},
    ///     (SearchResultBlockParam value) => {...},
    ///     (DocumentBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TextBlockParam, T> textBlockParam,
        System::Func<ImageBlockParam, T> imageBlockParam,
        System::Func<SearchResultBlockParam, T> searchResultBlockParam,
        System::Func<DocumentBlockParam, T> documentBlockParam
    )
    {
        return this.Value switch
        {
            TextBlockParam value => textBlockParam(value),
            ImageBlockParam value => imageBlockParam(value),
            SearchResultBlockParam value => searchResultBlockParam(value),
            DocumentBlockParam value => documentBlockParam(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public static implicit operator Block(TextBlockParam value) => new(value);

    public static implicit operator Block(ImageBlockParam value) => new(value);

    public static implicit operator Block(SearchResultBlockParam value) => new(value);

    public static implicit operator Block(DocumentBlockParam value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public virtual bool Equals(Block? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BlockConverter : JsonConverter<Block>
{
    public override Block? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "search_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "document":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new Block(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
