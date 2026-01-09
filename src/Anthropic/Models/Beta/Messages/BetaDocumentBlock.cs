using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaDocumentBlock, BetaDocumentBlockFromRaw>))]
public sealed record class BetaDocumentBlock : JsonModel
{
    /// <summary>
    /// Citation configuration for the document
    /// </summary>
    public required BetaCitationConfig? Citations
    {
        get { return JsonModel.GetNullableClass<BetaCitationConfig>(this.RawData, "citations"); }
        init { JsonModel.Set(this._rawData, "citations", value); }
    }

    public required Source Source
    {
        get { return JsonModel.GetNotNullClass<Source>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
    }

    /// <summary>
    /// The title of the document
    /// </summary>
    public required string? Title
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Citations?.Validate();
        this.Source.Validate();
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"document\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDocumentBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

    public BetaDocumentBlock(BetaDocumentBlock betaDocumentBlock)
        : base(betaDocumentBlock) { }

    public BetaDocumentBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDocumentBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDocumentBlockFromRaw.FromRawUnchecked"/>
    public static BetaDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDocumentBlockFromRaw : IFromRawJson<BetaDocumentBlock>
{
    /// <inheritdoc/>
    public BetaDocumentBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDocumentBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string Data
    {
        get { return Match(betaBase64PDF: (x) => x.Data, betaPlainText: (x) => x.Data); }
    }

    public JsonElement MediaType
    {
        get { return Match(betaBase64PDF: (x) => x.MediaType, betaPlainText: (x) => x.MediaType); }
    }

    public JsonElement Type
    {
        get { return Match(betaBase64PDF: (x) => x.Type, betaPlainText: (x) => x.Type); }
    }

    public Source(BetaBase64PDFSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaPlainTextSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBase64PDFSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaBase64PDF(out var value)) {
    ///     // `value` is of type `BetaBase64PDFSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaBase64PDF([NotNullWhen(true)] out BetaBase64PDFSource? value)
    {
        value = this.Value as BetaBase64PDFSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPlainTextSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPlainText(out var value)) {
    ///     // `value` is of type `BetaPlainTextSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPlainText([NotNullWhen(true)] out BetaPlainTextSource? value)
    {
        value = this.Value as BetaPlainTextSource;
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
    ///     (BetaBase64PDFSource value) => {...},
    ///     (BetaPlainTextSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBase64PDFSource> betaBase64PDF,
        System::Action<BetaPlainTextSource> betaPlainText
    )
    {
        switch (this.Value)
        {
            case BetaBase64PDFSource value:
                betaBase64PDF(value);
                break;
            case BetaPlainTextSource value:
                betaPlainText(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
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
    ///     (BetaBase64PDFSource value) => {...},
    ///     (BetaPlainTextSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBase64PDFSource, T> betaBase64PDF,
        System::Func<BetaPlainTextSource, T> betaPlainText
    )
    {
        return this.Value switch
        {
            BetaBase64PDFSource value => betaBase64PDF(value),
            BetaPlainTextSource value => betaPlainText(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(BetaBase64PDFSource value) => new(value);

    public static implicit operator Source(BetaPlainTextSource value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
        this.Switch(
            (betaBase64PDF) => betaBase64PDF.Validate(),
            (betaPlainText) => betaPlainText.Validate()
        );
    }

    public virtual bool Equals(Source? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "base64":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Source(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
