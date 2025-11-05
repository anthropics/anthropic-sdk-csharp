using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaImageBlockParam>))]
public sealed record class BetaImageBlockParam : ModelBase, IFromRaw<BetaImageBlockParam>
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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
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

    public BetaImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

    public BetaImageBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaImageBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaImageBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaImageBlockParam(SourceModel source)
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
        get
        {
            return Match(
                betaBase64Image: (x) => x.Type,
                betaURLImage: (x) => x.Type,
                betaFileImage: (x) => x.Type
            );
        }
    }

    public SourceModel(BetaBase64ImageSource value)
    {
        Value = value;
    }

    public SourceModel(BetaURLImageSource value)
    {
        Value = value;
    }

    public SourceModel(BetaFileImageSource value)
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
                    "Data did not match any variant of SourceModel"
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaBase64ImageSource'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaURLImageSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaURLImageSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "file":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaFileImageSource'",
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
