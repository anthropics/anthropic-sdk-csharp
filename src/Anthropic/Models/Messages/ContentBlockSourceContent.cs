using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ContentBlockSourceContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ContentBlockSourceContentConverter))]
public abstract record class ContentBlockSourceContent
{
    internal ContentBlockSourceContent() { }

    public static implicit operator ContentBlockSourceContent(TextBlockParam value) =>
        new TextBlockParamVariant(value);

    public static implicit operator ContentBlockSourceContent(ImageBlockParam value) =>
        new ImageBlockParamVariant(value);

    public bool TryPickTextBlockParamVariant([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = (this as TextBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickImageBlockParamVariant([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = (this as ImageBlockParamVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextBlockParamVariant> textBlockParam,
        Action<ImageBlockParamVariant> imageBlockParam
    )
    {
        switch (this)
        {
            case TextBlockParamVariant inner:
                textBlockParam(inner);
                break;
            case ImageBlockParamVariant inner:
                imageBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextBlockParamVariant, T> textBlockParam,
        Func<ImageBlockParamVariant, T> imageBlockParam
    )
    {
        return this switch
        {
            TextBlockParamVariant inner => textBlockParam(inner),
            ImageBlockParamVariant inner => imageBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockSourceContentConverter : JsonConverter<ContentBlockSourceContent>
{
    public override ContentBlockSourceContent? Read(
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
            case "text":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new TextBlockParamVariant(deserialized);
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
                        return new ImageBlockParamVariant(deserialized);
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
            TextBlockParamVariant(var textBlockParam) => textBlockParam,
            ImageBlockParamVariant(var imageBlockParam) => imageBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
