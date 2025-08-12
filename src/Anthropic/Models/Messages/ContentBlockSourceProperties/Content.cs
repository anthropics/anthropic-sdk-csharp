using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;
using Messages = Anthropic.Models.Messages;
using System = System;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<Messages::ContentBlockSourceContent> value) =>
        new ContentVariants::ContentBlockSourceContentVariant(value);

    public abstract void Validate();
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<Messages::ContentBlockSourceContent>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::ContentBlockSourceContentVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::String(var string1) => string1,
            ContentVariants::ContentBlockSourceContentVariant(var contentBlockSourceContent) =>
                contentBlockSourceContent,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
