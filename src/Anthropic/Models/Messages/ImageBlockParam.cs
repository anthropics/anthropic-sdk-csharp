using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ImageBlockParam, ImageBlockParamFromRaw>))]
public sealed record class ImageBlockParam : ModelBase
{
    public required ImageBlockParamSource Source
    {
        get { return ModelBase.GetNotNullClass<ImageBlockParamSource>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
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

    public ImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

    public ImageBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageBlockParamFromRaw.FromRawUnchecked"/>
    public static ImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageBlockParam(ImageBlockParamSource source)
        : this()
    {
        this.Source = source;
    }
}

class ImageBlockParamFromRaw : IFromRaw<ImageBlockParam>
{
    /// <inheritdoc/>
    public ImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ImageBlockParamSourceConverter))]
public record class ImageBlockParamSource
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(base64Image: (x) => x.Type, urlImage: (x) => x.Type); }
    }

    public ImageBlockParamSource(Base64ImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ImageBlockParamSource(URLImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ImageBlockParamSource(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Base64ImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBase64Image(out var value)) {
    ///     // `value` is of type `Base64ImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBase64Image([NotNullWhen(true)] out Base64ImageSource? value)
    {
        value = this.Value as Base64ImageSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="URLImageSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickURLImage(out var value)) {
    ///     // `value` is of type `URLImageSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickURLImage([NotNullWhen(true)] out URLImageSource? value)
    {
        value = this.Value as URLImageSource;
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
    ///     (Base64ImageSource value) => {...},
    ///     (URLImageSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Base64ImageSource> base64Image,
        System::Action<URLImageSource> urlImage
    )
    {
        switch (this.Value)
        {
            case Base64ImageSource value:
                base64Image(value);
                break;
            case URLImageSource value:
                urlImage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ImageBlockParamSource"
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
    ///     (Base64ImageSource value) => {...},
    ///     (URLImageSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Base64ImageSource, T> base64Image,
        System::Func<URLImageSource, T> urlImage
    )
    {
        return this.Value switch
        {
            Base64ImageSource value => base64Image(value),
            URLImageSource value => urlImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ImageBlockParamSource"
            ),
        };
    }

    public static implicit operator ImageBlockParamSource(Base64ImageSource value) => new(value);

    public static implicit operator ImageBlockParamSource(URLImageSource value) => new(value);

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
                "Data did not match any variant of ImageBlockParamSource"
            );
        }
    }

    public virtual bool Equals(ImageBlockParamSource? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ImageBlockParamSourceConverter : JsonConverter<ImageBlockParamSource>
{
    public override ImageBlockParamSource? Read(
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
            case "base64":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json, options);
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
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLImageSource>(json, options);
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
                return new ImageBlockParamSource(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageBlockParamSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
