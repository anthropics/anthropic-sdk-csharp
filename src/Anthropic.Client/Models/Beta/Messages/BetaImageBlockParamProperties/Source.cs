using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public record class Source
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

    public Source(BetaBase64ImageSource value)
    {
        Value = value;
    }

    public Source(BetaURLImageSource value)
    {
        Value = value;
    }

    public Source(BetaFileImageSource value)
    {
        Value = value;
    }

    Source(UnknownVariant value)
    {
        Value = value;
    }

    public static Source CreateUnknownVariant(JsonElement value)
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
        Action<BetaBase64ImageSource> betaBase64Image,
        Action<BetaURLImageSource> betaURLImage,
        Action<BetaFileImageSource> betaFileImage
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
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        Func<BetaBase64ImageSource, T> betaBase64Image,
        Func<BetaURLImageSource, T> betaURLImage,
        Func<BetaFileImageSource, T> betaFileImage
    )
    {
        return this.Value switch
        {
            BetaBase64ImageSource value => betaBase64Image(value),
            BetaURLImageSource value => betaURLImage(value),
            BetaFileImageSource value => betaFileImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                        return new Source(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaBase64ImageSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new Source(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaURLImageSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
                        return new Source(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaFileImageSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
