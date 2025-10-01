using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.ToolResultBlockParamProperties.ContentProperties;
using ContentVariants = Anthropic.Client.Models.Messages.ToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Client.Models.Messages.ToolResultBlockParamProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<Block> value) =>
        new ContentVariants::Blocks(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ContentVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickBlocks([NotNullWhen(true)] out List<Block>? value)
    {
        value = (this as ContentVariants::Blocks)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::String> @string,
        Action<ContentVariants::Blocks> blocks
    )
    {
        switch (this)
        {
            case ContentVariants::String inner:
                @string(inner);
                break;
            case ContentVariants::Blocks inner:
                blocks(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<ContentVariants::String, T> @string,
        Func<ContentVariants::Blocks, T> blocks
    )
    {
        return this switch
        {
            ContentVariants::String inner => @string(inner),
            ContentVariants::Blocks inner => blocks(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
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
        List<AnthropicInvalidDataException> exceptions = [];

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
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::String",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Block>>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::Blocks(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ContentVariants::Blocks",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::String(var @string) => @string,
            ContentVariants::Blocks(var blocks) => blocks,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
