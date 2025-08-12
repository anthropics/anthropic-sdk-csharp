using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockSourceContentVariants = Anthropic.Models.Messages.ContentBlockSourceContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ContentBlockSourceContentConverter))]
public abstract record class ContentBlockSourceContent
{
    internal ContentBlockSourceContent() { }

    public static implicit operator ContentBlockSourceContent(TextBlockParam value) =>
        new ContentBlockSourceContentVariants::TextBlockParamVariant(value);

    public static implicit operator ContentBlockSourceContent(ImageBlockParam value) =>
        new ContentBlockSourceContentVariants::ImageBlockParamVariant(value);

    public abstract void Validate();
}

sealed class ContentBlockSourceContentConverter : JsonConverter<ContentBlockSourceContent>
{
    public override ContentBlockSourceContent? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<TextBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockSourceContentVariants::TextBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockSourceContentVariants::ImageBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockSourceContentVariants::TextBlockParamVariant(var textBlockParam) =>
                textBlockParam,
            ContentBlockSourceContentVariants::ImageBlockParamVariant(var imageBlockParam) =>
                imageBlockParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
