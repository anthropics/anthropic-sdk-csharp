using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Beta.Client.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64ImageSource value) =>
        new SourceVariants::BetaBase64ImageSource(value);

    public static implicit operator Source(BetaURLImageSource value) =>
        new SourceVariants::BetaURLImageSource(value);

    public static implicit operator Source(BetaFileImageSource value) =>
        new SourceVariants::BetaFileImageSource(value);

    public bool TryPickBetaBase64Image([NotNullWhen(true)] out BetaBase64ImageSource? value)
    {
        value = (this as SourceVariants::BetaBase64ImageSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaURLImage([NotNullWhen(true)] out BetaURLImageSource? value)
    {
        value = (this as SourceVariants::BetaURLImageSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaFileImage([NotNullWhen(true)] out BetaFileImageSource? value)
    {
        value = (this as SourceVariants::BetaFileImageSource)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SourceVariants::BetaBase64ImageSource> betaBase64Image,
        Action<SourceVariants::BetaURLImageSource> betaURLImage,
        Action<SourceVariants::BetaFileImageSource> betaFileImage
    )
    {
        switch (this)
        {
            case SourceVariants::BetaBase64ImageSource inner:
                betaBase64Image(inner);
                break;
            case SourceVariants::BetaURLImageSource inner:
                betaURLImage(inner);
                break;
            case SourceVariants::BetaFileImageSource inner:
                betaFileImage(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SourceVariants::BetaBase64ImageSource, T> betaBase64Image,
        Func<SourceVariants::BetaURLImageSource, T> betaURLImage,
        Func<SourceVariants::BetaFileImageSource, T> betaFileImage
    )
    {
        return this switch
        {
            SourceVariants::BetaBase64ImageSource inner => betaBase64Image(inner),
            SourceVariants::BetaURLImageSource inner => betaURLImage(inner),
            SourceVariants::BetaFileImageSource inner => betaFileImage(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBase64ImageSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaBase64ImageSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "url":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaURLImageSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaURLImageSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "file":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileImageSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaFileImageSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SourceVariants::BetaBase64ImageSource(var betaBase64Image) => betaBase64Image,
            SourceVariants::BetaURLImageSource(var betaURLImage) => betaURLImage,
            SourceVariants::BetaFileImageSource(var betaFileImage) => betaFileImage,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
