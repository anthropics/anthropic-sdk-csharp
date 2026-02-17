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

[JsonConverter(typeof(JsonModelConverter<ContentBlockSource, ContentBlockSourceFromRaw>))]
public sealed record class ContentBlockSource : JsonModel
{
    public required ContentBlockSourceContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContentBlockSourceContent>("content");
        }
        init { this._rawData.Set("content", value); }
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("content")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ContentBlockSource()
    {
        this.Type = JsonSerializer.SerializeToElement("content");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContentBlockSource(ContentBlockSource contentBlockSource)
        : base(contentBlockSource) { }
#pragma warning restore CS8618

    public ContentBlockSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentBlockSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentBlockSourceFromRaw.FromRawUnchecked"/>
    public static ContentBlockSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContentBlockSource(ContentBlockSourceContent content)
        : this()
    {
        this.Content = content;
    }
}

class ContentBlockSourceFromRaw : IFromRawJson<ContentBlockSource>
{
    /// <inheritdoc/>
    public ContentBlockSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContentBlockSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ContentBlockSourceContentConverter))]
public record class ContentBlockSourceContent : ModelBase
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

    public ContentBlockSourceContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlockSourceContent(
        IReadOnlyList<MessageContentBlockSourceContent> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ContentBlockSourceContent(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="IReadOnlyList<MessageContentBlockSourceContent>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBlockSource(out var value)) {
    ///     // `value` is of type `IReadOnlyList<MessageContentBlockSourceContent>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBlockSource(
        [NotNullWhen(true)] out IReadOnlyList<MessageContentBlockSourceContent>? value
    )
    {
        value = this.Value as IReadOnlyList<MessageContentBlockSourceContent>;
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
    ///     (IReadOnlyList<MessageContentBlockSourceContent> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<MessageContentBlockSourceContent>> contentBlockSourceContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<MessageContentBlockSourceContent> value:
                contentBlockSourceContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlockSourceContent"
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
    ///     (IReadOnlyList<MessageContentBlockSourceContent> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<MessageContentBlockSourceContent>, T> contentBlockSourceContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<MessageContentBlockSourceContent> value => contentBlockSourceContent(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockSourceContent"
            ),
        };
    }

    public static implicit operator ContentBlockSourceContent(string value) => new(value);

    public static implicit operator ContentBlockSourceContent(
        List<MessageContentBlockSourceContent> value
    ) => new((IReadOnlyList<MessageContentBlockSourceContent>)value);

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
                "Data did not match any variant of ContentBlockSourceContent"
            );
        }
    }

    public virtual bool Equals(ContentBlockSourceContent? other) =>
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
            string _ => 0,
            IReadOnlyList<MessageContentBlockSourceContent> _ => 1,
            _ => -1,
        };
    }
}

sealed class ContentBlockSourceContentConverter : JsonConverter<ContentBlockSourceContent>
{
    public override ContentBlockSourceContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<MessageContentBlockSourceContent>>(
                element,
                options
            );
            if (deserialized != null)
            {
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
        ContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
