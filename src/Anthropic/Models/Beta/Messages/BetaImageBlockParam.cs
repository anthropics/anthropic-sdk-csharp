using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaImageBlockParam, BetaImageBlockParamFromRaw>))]
public sealed record class BetaImageBlockParam : ModelBase
{
    public required BetaImageBlockParamSource Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaImageBlockParamSource>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentNullException("source")
                );
        }
        init
        {
            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

class BetaImageBlockParamFromRaw : IFromRaw<BetaImageBlockParam>
{
    public BetaImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaImageBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaImageBlockParamSourceConverter))]
public record class BetaImageBlockParamSource
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
                betaBase64Image: (x) => x.Type,
                betaURLImage: (x) => x.Type,
                betaFileImage: (x) => x.Type
            );
        }
    }

    public BetaImageBlockParamSource(BetaBase64ImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaImageBlockParamSource(BetaURLImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaImageBlockParamSource(BetaFileImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaImageBlockParamSource(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaBase64Image([NotNullWhen(true)] out BetaBase64ImageSource? value)
    {
        value = this.Value as BetaBase64ImageSource;
        return value != null;
    }

    public bool TryPickBetaURLImage([NotNullWhen(true)] out BetaURLImageSource? value)
    {
        value = this.Value as BetaURLImageSource;
        return value != null;
    }

    public bool TryPickBetaFileImage([NotNullWhen(true)] out BetaFileImageSource? value)
    {
        value = this.Value as BetaFileImageSource;
        return value != null;
    }

    public void Switch(
        System::Action<BetaBase64ImageSource> betaBase64Image,
        System::Action<BetaURLImageSource> betaURLImage,
        System::Action<BetaFileImageSource> betaFileImage
    )
    {
        switch (this.Value)
        {
            case BetaBase64ImageSource value:
                betaBase64Image(value);
                break;
            case BetaURLImageSource value:
                betaURLImage(value);
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

    public T Match<T>(
        System::Func<BetaBase64ImageSource, T> betaBase64Image,
        System::Func<BetaURLImageSource, T> betaURLImage,
        System::Func<BetaFileImageSource, T> betaFileImage
    )
    {
        return this.Value switch
        {
            BetaBase64ImageSource value => betaBase64Image(value),
            BetaURLImageSource value => betaURLImage(value),
            BetaFileImageSource value => betaFileImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaImageBlockParamSource"
            ),
        };
    }

    public static implicit operator BetaImageBlockParamSource(BetaBase64ImageSource value) =>
        new(value);

    public static implicit operator BetaImageBlockParamSource(BetaURLImageSource value) =>
        new(value);

    public static implicit operator BetaImageBlockParamSource(BetaFileImageSource value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaImageBlockParamSource"
            );
        }
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(
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
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaURLImageSource>(
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
            case "file":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(
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
                return new BetaImageBlockParamSource(json);
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
