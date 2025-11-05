using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ContentBlockSourceContentConverter))]
public record class ContentBlockSourceContent
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(textBlockParam: (x) => x.Type, imageBlockParam: (x) => x.Type); }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                textBlockParam: (x) => x.CacheControl,
                imageBlockParam: (x) => x.CacheControl
            );
        }
    }

    public ContentBlockSourceContent(TextBlockParam value)
    {
        Value = value;
    }

    public ContentBlockSourceContent(ImageBlockParam value)
    {
        Value = value;
    }

    ContentBlockSourceContent(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentBlockSourceContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = this.Value as TextBlockParam;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = this.Value as ImageBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<TextBlockParam> textBlockParam,
        System::Action<ImageBlockParam> imageBlockParam
    )
    {
        switch (this.Value)
        {
            case TextBlockParam value:
                textBlockParam(value);
                break;
            case ImageBlockParam value:
                imageBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlockSourceContent"
                );
        }
    }

    public T Match<T>(
        System::Func<TextBlockParam, T> textBlockParam,
        System::Func<ImageBlockParam, T> imageBlockParam
    )
    {
        return this.Value switch
        {
            TextBlockParam value => textBlockParam(value),
            ImageBlockParam value => imageBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockSourceContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockSourceContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentBlockSourceContentConverter : JsonConverter<ContentBlockSourceContent>
{
    public override ContentBlockSourceContent? Read(
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
            case "text":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlockSourceContent(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'TextBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlockSourceContent(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ImageBlockParam'",
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
        ContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
