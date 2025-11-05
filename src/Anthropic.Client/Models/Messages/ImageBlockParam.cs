using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ImageBlockParam>))]
public sealed record class ImageBlockParam : ModelBase, IFromRaw<ImageBlockParam>
{
    public required SourceModel Source
    {
        get
        {
            if (!this._properties.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<SourceModel>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentNullException("source")
                );
        }
        init
        {
            this._properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Source.Validate();
        _ = this.Type;
        this.CacheControl?.Validate();
    }

    public ImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

    public ImageBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ImageBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ImageBlockParam(SourceModel source)
        : this()
    {
        this.Source = source;
    }
}

[JsonConverter(typeof(SourceModelConverter))]
public record class SourceModel
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(base64Image: (x) => x.Type, urlImage: (x) => x.Type); }
    }

    public SourceModel(Base64ImageSource value)
    {
        Value = value;
    }

    public SourceModel(URLImageSource value)
    {
        Value = value;
    }

    SourceModel(UnknownVariant value)
    {
        Value = value;
    }

    public static SourceModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBase64Image([NotNullWhen(true)] out Base64ImageSource? value)
    {
        value = this.Value as Base64ImageSource;
        return value != null;
    }

    public bool TryPickURLImage([NotNullWhen(true)] out URLImageSource? value)
    {
        value = this.Value as URLImageSource;
        return value != null;
    }

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
                    "Data did not match any variant of SourceModel"
                );
        }
    }

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
                "Data did not match any variant of SourceModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of SourceModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class SourceModelConverter : JsonConverter<SourceModel>
{
    public override SourceModel? Read(
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SourceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'Base64ImageSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "url":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SourceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'URLImageSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
