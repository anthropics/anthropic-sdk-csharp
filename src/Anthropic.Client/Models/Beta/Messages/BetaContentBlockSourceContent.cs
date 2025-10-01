using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BetaContentBlockSourceContentVariants = Anthropic.Client.Models.Beta.Messages.BetaContentBlockSourceContentVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaContentBlockSourceContentConverter))]
public abstract record class BetaContentBlockSourceContent
{
    internal BetaContentBlockSourceContent() { }

    public static implicit operator BetaContentBlockSourceContent(BetaTextBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaTextBlockParam(value);

    public static implicit operator BetaContentBlockSourceContent(BetaImageBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaImageBlockParam(value);

    public bool TryPickTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = (this as BetaContentBlockSourceContentVariants::BetaTextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = (this as BetaContentBlockSourceContentVariants::BetaImageBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaContentBlockSourceContentVariants::BetaTextBlockParam> textBlockParam,
        Action<BetaContentBlockSourceContentVariants::BetaImageBlockParam> imageBlockParam
    )
    {
        switch (this)
        {
            case BetaContentBlockSourceContentVariants::BetaTextBlockParam inner:
                textBlockParam(inner);
                break;
            case BetaContentBlockSourceContentVariants::BetaImageBlockParam inner:
                imageBlockParam(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlockSourceContent"
                );
        }
    }

    public T Match<T>(
        Func<BetaContentBlockSourceContentVariants::BetaTextBlockParam, T> textBlockParam,
        Func<BetaContentBlockSourceContentVariants::BetaImageBlockParam, T> imageBlockParam
    )
    {
        return this switch
        {
            BetaContentBlockSourceContentVariants::BetaTextBlockParam inner => textBlockParam(
                inner
            ),
            BetaContentBlockSourceContentVariants::BetaImageBlockParam inner => imageBlockParam(
                inner
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            ),
        };
    }

    public abstract void Validate();
}

sealed class BetaContentBlockSourceContentConverter : JsonConverter<BetaContentBlockSourceContent>
{
    public override BetaContentBlockSourceContent? Read(
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
            case "text":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockSourceContentVariants::BetaTextBlockParam(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaContentBlockSourceContentVariants::BetaTextBlockParam",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaContentBlockSourceContentVariants::BetaImageBlockParam(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaContentBlockSourceContentVariants::BetaImageBlockParam",
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaContentBlockSourceContentVariants::BetaTextBlockParam(var textBlockParam) =>
                textBlockParam,
            BetaContentBlockSourceContentVariants::BetaImageBlockParam(var imageBlockParam) =>
                imageBlockParam,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
