using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.RawContentBlockStartEventProperties;

[JsonConverter(typeof(ContentBlock1Converter))]
public abstract record class ContentBlock1
{
    internal ContentBlock1() { }

    public static implicit operator ContentBlock1(Messages::TextBlock value) =>
        new ContentBlockVariants::TextBlockVariant(value);

    public static implicit operator ContentBlock1(Messages::ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlockVariant(value);

    public static implicit operator ContentBlock1(Messages::RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock1(Messages::ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlockVariant(value);

    public static implicit operator ContentBlock1(Messages::ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock1(Messages::WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlockVariant(value);

    public abstract void Validate();
}

sealed class ContentBlock1Converter : JsonConverter<ContentBlock1>
{
    public override ContentBlock1? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::TextBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockVariants::TextBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::ThinkingBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockVariants::ThinkingBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::RedactedThinkingBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockVariants::RedactedThinkingBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::ToolUseBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockVariants::ToolUseBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::ServerToolUseBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockVariants::ServerToolUseBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::WebSearchToolResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockVariants::WebSearchToolResultBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlock1 value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockVariants::TextBlockVariant(var textBlock) => textBlock,
            ContentBlockVariants::ThinkingBlockVariant(var thinkingBlock) => thinkingBlock,
            ContentBlockVariants::RedactedThinkingBlockVariant(var redactedThinkingBlock) =>
                redactedThinkingBlock,
            ContentBlockVariants::ToolUseBlockVariant(var toolUseBlock) => toolUseBlock,
            ContentBlockVariants::ServerToolUseBlockVariant(var serverToolUseBlock) =>
                serverToolUseBlock,
            ContentBlockVariants::WebSearchToolResultBlockVariant(var webSearchToolResultBlock) =>
                webSearchToolResultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
