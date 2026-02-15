using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaContentBlockSource, BetaContentBlockSourceFromRaw>))]
public sealed record class BetaContentBlockSource : JsonModel
{
    public required BetaContentBlockSourceContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaContentBlockSourceContent>("content");
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

    public BetaContentBlockSource()
    {
        this.Type = JsonSerializer.SerializeToElement("content");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaContentBlockSource(BetaContentBlockSource betaContentBlockSource)
        : base(betaContentBlockSource) { }
#pragma warning restore CS8618

    public BetaContentBlockSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContentBlockSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContentBlockSourceFromRaw.FromRawUnchecked"/>
    public static BetaContentBlockSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaContentBlockSource(BetaContentBlockSourceContent content)
        : this()
    {
        this.Content = content;
    }
}

class BetaContentBlockSourceFromRaw : IFromRawJson<BetaContentBlockSource>
{
    /// <inheritdoc/>
    public BetaContentBlockSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContentBlockSource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaContentBlockSourceContentConverter))]
public record class BetaContentBlockSourceContent : ModelBase
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

    public BetaContentBlockSourceContent(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaContentBlockSourceContent(
        IReadOnlyList<MessageBetaContentBlockSourceContent> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public BetaContentBlockSourceContent(JsonElement element)
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
    /// type <see cref="IReadOnlyList<MessageBetaContentBlockSourceContent>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaContentBlockSource(out var value)) {
    ///     // `value` is of type `IReadOnlyList<MessageBetaContentBlockSourceContent>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaContentBlockSource(
        [NotNullWhen(true)] out IReadOnlyList<MessageBetaContentBlockSourceContent>? value
    )
    {
        value = this.Value as IReadOnlyList<MessageBetaContentBlockSourceContent>;
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
    ///     (IReadOnlyList<MessageBetaContentBlockSourceContent> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<
            IReadOnlyList<MessageBetaContentBlockSourceContent>
        > betaContentBlockSourceContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyList<MessageBetaContentBlockSourceContent> value:
                betaContentBlockSourceContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlockSourceContent"
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
    ///     (IReadOnlyList<MessageBetaContentBlockSourceContent> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<
            IReadOnlyList<MessageBetaContentBlockSourceContent>,
            T
        > betaContentBlockSourceContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<MessageBetaContentBlockSourceContent> value =>
                betaContentBlockSourceContent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            ),
        };
    }

    public static implicit operator BetaContentBlockSourceContent(string value) => new(value);

    public static implicit operator BetaContentBlockSourceContent(
        List<MessageBetaContentBlockSourceContent> value
    ) => new((IReadOnlyList<MessageBetaContentBlockSourceContent>)value);

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
                "Data did not match any variant of BetaContentBlockSourceContent"
            );
        }
    }

    public virtual bool Equals(BetaContentBlockSourceContent? other) =>
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
            IReadOnlyList<MessageBetaContentBlockSourceContent> _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaContentBlockSourceContentConverter : JsonConverter<BetaContentBlockSourceContent>
{
    public override BetaContentBlockSourceContent? Read(
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
            var deserialized = JsonSerializer.Deserialize<
                List<MessageBetaContentBlockSourceContent>
            >(element, options);
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
        BetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
