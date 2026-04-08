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
/// Image content specified directly as base64 data or as a reference via a URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsImageBlock, BetaManagedAgentsImageBlockFromRaw>)
)]
public sealed record class BetaManagedAgentsImageBlock : JsonModel
{
    /// <summary>
    /// Union type for image source variants.
    /// </summary>
    public required BetaManagedAgentsImageBlockSource Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsImageBlockSource>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsImageBlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsImageBlockType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Source.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsImageBlock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsImageBlock(BetaManagedAgentsImageBlock betaManagedAgentsImageBlock)
        : base(betaManagedAgentsImageBlock) { }
#pragma warning restore CS8618

    public BetaManagedAgentsImageBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsImageBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsImageBlockFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsImageBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsImageBlockFromRaw : IFromRawJson<BetaManagedAgentsImageBlock>
{
    /// <inheritdoc/>
    public BetaManagedAgentsImageBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsImageBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// Union type for image source variants.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsImageBlockSourceConverter))]
public record class BetaManagedAgentsImageBlockSource : ModelBase
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

    public BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsBase64ImageSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsUrlImageSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsFileImageSource value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsImageBlockSource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsBase64ImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsBase64Image(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBase64ImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsBase64Image(
        [NotNullWhen(true)] out BetaManagedAgentsBase64ImageSource? value
    )
    {
        value = this.Value as BetaManagedAgentsBase64ImageSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUrlImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUrlImage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUrlImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUrlImage(
        [NotNullWhen(true)] out BetaManagedAgentsUrlImageSource? value
    )
    {
        value = this.Value as BetaManagedAgentsUrlImageSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsFileImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsFileImage(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsFileImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsFileImage(
        [NotNullWhen(true)] out BetaManagedAgentsFileImageSource? value
    )
    {
        value = this.Value as BetaManagedAgentsFileImageSource;
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
    ///     (BetaManagedAgentsBase64ImageSource value) =&gt; {...},
    ///     (BetaManagedAgentsUrlImageSource value) =&gt; {...},
    ///     (BetaManagedAgentsFileImageSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsBase64ImageSource> betaManagedAgentsBase64Image,
        System::Action<BetaManagedAgentsUrlImageSource> betaManagedAgentsUrlImage,
        System::Action<BetaManagedAgentsFileImageSource> betaManagedAgentsFileImage
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsBase64ImageSource value:
                betaManagedAgentsBase64Image(value);
                break;
            case BetaManagedAgentsUrlImageSource value:
                betaManagedAgentsUrlImage(value);
                break;
            case BetaManagedAgentsFileImageSource value:
                betaManagedAgentsFileImage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsImageBlockSource"
                );
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
    ///     (BetaManagedAgentsBase64ImageSource value) =&gt; {...},
    ///     (BetaManagedAgentsUrlImageSource value) =&gt; {...},
    ///     (BetaManagedAgentsFileImageSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsBase64ImageSource, T> betaManagedAgentsBase64Image,
        System::Func<BetaManagedAgentsUrlImageSource, T> betaManagedAgentsUrlImage,
        System::Func<BetaManagedAgentsFileImageSource, T> betaManagedAgentsFileImage
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsBase64ImageSource value => betaManagedAgentsBase64Image(value),
            BetaManagedAgentsUrlImageSource value => betaManagedAgentsUrlImage(value),
            BetaManagedAgentsFileImageSource value => betaManagedAgentsFileImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsImageBlockSource"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsBase64ImageSource value
    ) => new(value);

    public static implicit operator BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsUrlImageSource value
    ) => new(value);

    public static implicit operator BetaManagedAgentsImageBlockSource(
        BetaManagedAgentsFileImageSource value
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
                "Data did not match any variant of BetaManagedAgentsImageBlockSource"
            );
        }
        this.Switch(
            (betaManagedAgentsBase64Image) => betaManagedAgentsBase64Image.Validate(),
            (betaManagedAgentsUrlImage) => betaManagedAgentsUrlImage.Validate(),
            (betaManagedAgentsFileImage) => betaManagedAgentsFileImage.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsImageBlockSource? other) =>
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
            BetaManagedAgentsBase64ImageSource _ => 0,
            BetaManagedAgentsUrlImageSource _ => 1,
            BetaManagedAgentsFileImageSource _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsImageBlockSourceConverter
    : JsonConverter<BetaManagedAgentsImageBlockSource>
{
    public override BetaManagedAgentsImageBlockSource? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsBase64ImageSource>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUrlImageSource>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileImageSource>(
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
                return new BetaManagedAgentsImageBlockSource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsImageBlockSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsImageBlockTypeConverter))]
public enum BetaManagedAgentsImageBlockType
{
    Image,
}

sealed class BetaManagedAgentsImageBlockTypeConverter
    : JsonConverter<BetaManagedAgentsImageBlockType>
{
    public override BetaManagedAgentsImageBlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image" => BetaManagedAgentsImageBlockType.Image,
            _ => (BetaManagedAgentsImageBlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsImageBlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsImageBlockType.Image => "image",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
