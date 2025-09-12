using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockSourceContentVariants = Anthropic.Client.Models.Messages.ContentBlockSourceContentVariants;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ContentBlockSourceContentConverter))]
public abstract record class ContentBlockSourceContent
{
    internal ContentBlockSourceContent() { }

    public static implicit operator ContentBlockSourceContent(TextBlockParam value) =>
        new ContentBlockSourceContentVariants::TextBlockParam(value);

    public static implicit operator ContentBlockSourceContent(ImageBlockParam value) =>
        new ContentBlockSourceContentVariants::ImageBlockParam(value);

    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = (this as ContentBlockSourceContentVariants::TextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = (this as ContentBlockSourceContentVariants::ImageBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentBlockSourceContentVariants::TextBlockParam> textBlockParam,
        Action<ContentBlockSourceContentVariants::ImageBlockParam> imageBlockParam
    )
    {
        switch (this)
        {
            case ContentBlockSourceContentVariants::TextBlockParam inner:
                textBlockParam(inner);
                break;
            case ContentBlockSourceContentVariants::ImageBlockParam inner:
                imageBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentBlockSourceContentVariants::TextBlockParam, T> textBlockParam,
        Func<ContentBlockSourceContentVariants::ImageBlockParam, T> imageBlockParam
    )
    {
        return this switch
        {
            ContentBlockSourceContentVariants::TextBlockParam inner => textBlockParam(inner),
            ContentBlockSourceContentVariants::ImageBlockParam inner => imageBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockSourceContentConverter : JsonConverter<ContentBlockSourceContent>
{
    public override ContentBlockSourceContent? Read(
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockSourceContentVariants::TextBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockSourceContentVariants::ImageBlockParam(deserialized);
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

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockSourceContentVariants::TextBlockParam(var textBlockParam) => textBlockParam,
            ContentBlockSourceContentVariants::ImageBlockParam(var imageBlockParam) =>
                imageBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
