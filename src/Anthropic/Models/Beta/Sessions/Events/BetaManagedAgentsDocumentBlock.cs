using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Document content, either specified directly as base64 data, as text, or as a reference
/// via a URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDocumentBlock,
        BetaManagedAgentsDocumentBlockFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDocumentBlock : JsonModel
{
    /// <summary>
    /// Union type for document source variants.
    /// </summary>
    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsDocumentBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDocumentBlockType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Additional context about the document for the model.
    /// </summary>
    public string? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    /// <summary>
    /// The title of the document.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Source.Validate();
        this.Type.Validate();
        _ = this.Context;
        _ = this.Title;
    }

    public BetaManagedAgentsDocumentBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDocumentBlock(
        BetaManagedAgentsDocumentBlock betaManagedAgentsDocumentBlock
    )
        : base(betaManagedAgentsDocumentBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDocumentBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDocumentBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDocumentBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDocumentBlockFromRaw : IFromRawJson<BetaManagedAgentsDocumentBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDocumentBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// Union type for document source variants.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public record class Source : ModelBase
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

    public string? Data
    {
        get
        {
            return Match<string?>(
                betaManagedAgentsBase64Document: (x) => x.Data,
                betaManagedAgentsPlainTextDocument: (x) => x.Data,
                betaManagedAgentsUrlDocument: (_) => null,
                betaManagedAgentsFileDocument: (_) => null
            );
        }
    }

    public Source(BetaManagedAgentsBase64DocumentSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaManagedAgentsPlainTextDocumentSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaManagedAgentsUrlDocumentSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaManagedAgentsFileDocumentSource value, JsonElement? element = null)
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
    /// type <see cref="BetaManagedAgentsBase64DocumentSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsBase64Document(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBase64DocumentSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsBase64Document(
        [NotNullWhen(true)] out BetaManagedAgentsBase64DocumentSource? value
    )
    {
        value = this.Value as BetaManagedAgentsBase64DocumentSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsPlainTextDocumentSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsPlainTextDocument(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsPlainTextDocumentSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsPlainTextDocument(
        [NotNullWhen(true)] out BetaManagedAgentsPlainTextDocumentSource? value
    )
    {
        value = this.Value as BetaManagedAgentsPlainTextDocumentSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUrlDocumentSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUrlDocument(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUrlDocumentSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUrlDocument(
        [NotNullWhen(true)] out BetaManagedAgentsUrlDocumentSource? value
    )
    {
        value = this.Value as BetaManagedAgentsUrlDocumentSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileDocumentSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileDocument(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileDocumentSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileDocument(
        [NotNullWhen(true)] out BetaManagedAgentsFileDocumentSource? value
    )
    {
        value = this.Value as BetaManagedAgentsFileDocumentSource;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BetaManagedAgentsBase64DocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsPlainTextDocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsUrlDocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsFileDocumentSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsBase64DocumentSource> betaManagedAgentsBase64Document,
        System::Action<BetaManagedAgentsPlainTextDocumentSource> betaManagedAgentsPlainTextDocument,
        System::Action<BetaManagedAgentsUrlDocumentSource> betaManagedAgentsUrlDocument,
        System::Action<BetaManagedAgentsFileDocumentSource> betaManagedAgentsFileDocument
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsBase64DocumentSource value:
                betaManagedAgentsBase64Document(value);
                break;
            case BetaManagedAgentsPlainTextDocumentSource value:
                betaManagedAgentsPlainTextDocument(value);
                break;
            case BetaManagedAgentsUrlDocumentSource value:
                betaManagedAgentsUrlDocument(value);
                break;
            case BetaManagedAgentsFileDocumentSource value:
                betaManagedAgentsFileDocument(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BetaManagedAgentsBase64DocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsPlainTextDocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsUrlDocumentSource value) =&gt; {...},
    ///     (BetaManagedAgentsFileDocumentSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsBase64DocumentSource, T> betaManagedAgentsBase64Document,
        System::Func<
            BetaManagedAgentsPlainTextDocumentSource,
            T
        > betaManagedAgentsPlainTextDocument,
        System::Func<BetaManagedAgentsUrlDocumentSource, T> betaManagedAgentsUrlDocument,
        System::Func<BetaManagedAgentsFileDocumentSource, T> betaManagedAgentsFileDocument
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsBase64DocumentSource value => betaManagedAgentsBase64Document(value),
            BetaManagedAgentsPlainTextDocumentSource value => betaManagedAgentsPlainTextDocument(
                value
            ),
            BetaManagedAgentsUrlDocumentSource value => betaManagedAgentsUrlDocument(value),
            BetaManagedAgentsFileDocumentSource value => betaManagedAgentsFileDocument(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(BetaManagedAgentsBase64DocumentSource value) =>
        new(value);

    public static implicit operator Source(BetaManagedAgentsPlainTextDocumentSource value) =>
        new(value);

    public static implicit operator Source(BetaManagedAgentsUrlDocumentSource value) => new(value);

    public static implicit operator Source(BetaManagedAgentsFileDocumentSource value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
        this.Switch(
            (betaManagedAgentsBase64Document) => betaManagedAgentsBase64Document.Validate(),
            (betaManagedAgentsPlainTextDocument) => betaManagedAgentsPlainTextDocument.Validate(),
            (betaManagedAgentsUrlDocument) => betaManagedAgentsUrlDocument.Validate(),
            (betaManagedAgentsFileDocument) => betaManagedAgentsFileDocument.Validate()
        );
    }

    public virtual bool Equals(Source? other) =>
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
            BetaManagedAgentsBase64DocumentSource _ => 0,
            BetaManagedAgentsPlainTextDocumentSource _ => 1,
            BetaManagedAgentsUrlDocumentSource _ => 2,
            BetaManagedAgentsFileDocumentSource _ => 3,
            _ => -1,
        };
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsBase64DocumentSource>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsPlainTextDocumentSource>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "url":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUrlDocumentSource>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "file":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsFileDocumentSource>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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

[JsonConverter(typeof(BetaManagedAgentsDocumentBlockTypeConverter))]
public enum BetaManagedAgentsDocumentBlockType
{
    Document,
}

sealed class BetaManagedAgentsDocumentBlockTypeConverter
    : JsonConverter<BetaManagedAgentsDocumentBlockType>
{
    public override BetaManagedAgentsDocumentBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "document" => BetaManagedAgentsDocumentBlockType.Document,
            _ => (BetaManagedAgentsDocumentBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDocumentBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDocumentBlockType.Document => "document",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
