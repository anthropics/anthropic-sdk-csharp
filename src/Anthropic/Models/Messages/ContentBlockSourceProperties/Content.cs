using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<ContentBlockSourceContent> value) =>
        new ContentVariants::ContentBlockSourceContent(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ContentVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickBlockSource([NotNullWhen(true)] out List<ContentBlockSourceContent>? value)
    {
        value = (this as ContentVariants::ContentBlockSourceContent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::String> @string,
        Action<ContentVariants::ContentBlockSourceContent> contentBlockSourceContent
    )
    {
        switch (this)
        {
            case ContentVariants::String inner:
                @string(inner);
                break;
            case ContentVariants::ContentBlockSourceContent inner:
                contentBlockSourceContent(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentVariants::String, T> @string,
        Func<ContentVariants::ContentBlockSourceContent, T> contentBlockSourceContent
    )
    {
        return this switch
        {
            ContentVariants::String inner => @string(inner),
            ContentVariants::ContentBlockSourceContent inner => contentBlockSourceContent(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            var deserialized = JsonSerializer.Deserialize<List<ContentBlockSourceContent>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::ContentBlockSourceContent(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::String(var @string) => @string,
            ContentVariants::ContentBlockSourceContent(var contentBlockSourceContent) =>
                contentBlockSourceContent,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
