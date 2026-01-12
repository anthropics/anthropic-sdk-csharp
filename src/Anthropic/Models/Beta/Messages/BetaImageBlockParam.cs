using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaImageBlockParam, BetaImageBlockParamFromRaw>))]
public sealed record class BetaImageBlockParam : JsonModel
{
    public required BetaImageBlockParamSource Source
    {
        get { return JsonModel.GetNotNullClass<BetaImageBlockParamSource>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return JsonModel.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { JsonModel.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Source.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"image\""))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

    public BetaImageBlockParam(BetaImageBlockParam betaImageBlockParam)
        : base(betaImageBlockParam) { }

    public BetaImageBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaImageBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaImageBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaImageBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaImageBlockParam(BetaImageBlockParamSource source)
        : this()
    {
        this.Source = source;
    }
}

class BetaImageBlockParamFromRaw : IFromRawJson<BetaImageBlockParam>
{
    /// <inheritdoc/>
    public BetaImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaImageBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaImageBlockParamSourceConverter))]
public record class BetaImageBlockParamSource
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaBase64Image: (x) => x.Type,
                betaUrlImage: (x) => x.Type,
                betaFileImage: (x) => x.Type
            );
        }
    }

    public BetaImageBlockParamSource(BetaBase64ImageSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaImageBlockParamSource(BetaUrlImageSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaImageBlockParamSource(BetaFileImageSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaImageBlockParamSource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBase64ImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaBase64Image(out var value)) {
    ///     // `value` is of type `BetaBase64ImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaBase64Image([NotNullWhen(true)] out BetaBase64ImageSource? value)
    {
        value = this.Value as BetaBase64ImageSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaUrlImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaUrlImage(out var value)) {
    ///     // `value` is of type `BetaUrlImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaUrlImage([NotNullWhen(true)] out BetaUrlImageSource? value)
    {
        value = this.Value as BetaUrlImageSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaFileImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFileImage(out var value)) {
    ///     // `value` is of type `BetaFileImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFileImage([NotNullWhen(true)] out BetaFileImageSource? value)
    {
        value = this.Value as BetaFileImageSource;
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
    ///     (BetaBase64ImageSource value) => {...},
    ///     (BetaUrlImageSource value) => {...},
    ///     (BetaFileImageSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBase64ImageSource> betaBase64Image,
        System::Action<BetaUrlImageSource> betaUrlImage,
        System::Action<BetaFileImageSource> betaFileImage
    )
    {
        switch (this.Value)
        {
            case BetaBase64ImageSource value:
                betaBase64Image(value);
                break;
            case BetaUrlImageSource value:
                betaUrlImage(value);
                break;
            case BetaFileImageSource value:
                betaFileImage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaImageBlockParamSource"
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
    ///     (BetaBase64ImageSource value) => {...},
    ///     (BetaUrlImageSource value) => {...},
    ///     (BetaFileImageSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBase64ImageSource, T> betaBase64Image,
        System::Func<BetaUrlImageSource, T> betaUrlImage,
        System::Func<BetaFileImageSource, T> betaFileImage
    )
    {
        return this.Value switch
        {
            BetaBase64ImageSource value => betaBase64Image(value),
            BetaUrlImageSource value => betaUrlImage(value),
            BetaFileImageSource value => betaFileImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaImageBlockParamSource"
            ),
        };
    }

    public static implicit operator BetaImageBlockParamSource(BetaBase64ImageSource value) =>
        new(value);

    public static implicit operator BetaImageBlockParamSource(BetaUrlImageSource value) =>
        new(value);

    public static implicit operator BetaImageBlockParamSource(BetaFileImageSource value) =>
        new(value);

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
                "Data did not match any variant of BetaImageBlockParamSource"
            );
        }
        this.Switch(
            (betaBase64Image) => betaBase64Image.Validate(),
            (betaUrlImage) => betaUrlImage.Validate(),
            (betaFileImage) => betaFileImage.Validate()
        );
    }

    public virtual bool Equals(BetaImageBlockParamSource? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaImageBlockParamSourceConverter : JsonConverter<BetaImageBlockParamSource>
{
    public override BetaImageBlockParamSource? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(
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
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaUrlImageSource>(
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
            case "file":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(
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
                return new BetaImageBlockParamSource(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaImageBlockParamSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
