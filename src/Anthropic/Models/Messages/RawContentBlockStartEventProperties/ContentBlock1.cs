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
                    var deserialized = JsonSerializer.Deserialize<Messages::TextBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::TextBlockVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::ThinkingBlock>(
                        json,
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

                throw new AggregateException(exceptions);
            }
            case "redacted_thinking":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::RedactedThinkingBlock>(
                        json,
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

                throw new AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::ToolUseBlock>(
                        json,
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

                throw new AggregateException(exceptions);
            }
            case "server_tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Messages::ServerToolUseBlock>(
                        json,
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

                throw new AggregateException(exceptions);
            }
            case "web_search_tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::WebSearchToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::WebSearchToolResultBlockVariant(
                            deserialized
                        );
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
