using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64ImageSource value) =>
        new BetaBase64ImageSourceVariant(value);

    public static implicit operator Source(BetaURLImageSource value) =>
        new BetaURLImageSourceVariant(value);

    public static implicit operator Source(BetaFileImageSource value) =>
        new BetaFileImageSourceVariant(value);

    public bool TryPickBetaBase64ImageSourceVariant(
        [NotNullWhen(true)] out BetaBase64ImageSource? value
    )
    {
        value = (this as BetaBase64ImageSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaURLImageSourceVariant([NotNullWhen(true)] out BetaURLImageSource? value)
    {
        value = (this as BetaURLImageSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaFileImageSourceVariant(
        [NotNullWhen(true)] out BetaFileImageSource? value
    )
    {
        value = (this as BetaFileImageSourceVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaBase64ImageSourceVariant> betaBase64ImageSource,
        Action<BetaURLImageSourceVariant> betaURLImageSource,
        Action<BetaFileImageSourceVariant> betaFileImageSource
    )
    {
        switch (this)
        {
            case BetaBase64ImageSourceVariant inner:
                betaBase64ImageSource(inner);
                break;
            case BetaURLImageSourceVariant inner:
                betaURLImageSource(inner);
                break;
            case BetaFileImageSourceVariant inner:
                betaFileImageSource(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaBase64ImageSourceVariant, T> betaBase64ImageSource,
        Func<BetaURLImageSourceVariant, T> betaURLImageSource,
        Func<BetaFileImageSourceVariant, T> betaFileImageSource
    )
    {
        return this switch
        {
            BetaBase64ImageSourceVariant inner => betaBase64ImageSource(inner),
            BetaURLImageSourceVariant inner => betaURLImageSource(inner),
            BetaFileImageSourceVariant inner => betaFileImageSource(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new BetaBase64ImageSourceVariant(deserialized);
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
                        return new BetaURLImageSourceVariant(deserialized);
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
                        return new BetaFileImageSourceVariant(deserialized);
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
            BetaBase64ImageSourceVariant(var betaBase64ImageSource) => betaBase64ImageSource,
            BetaURLImageSourceVariant(var betaURLImageSource) => betaURLImageSource,
            BetaFileImageSourceVariant(var betaFileImageSource) => betaFileImageSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
