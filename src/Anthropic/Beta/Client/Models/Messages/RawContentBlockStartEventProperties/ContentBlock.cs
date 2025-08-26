using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Beta.Client.Models.Messages.RawContentBlockStartEventProperties.ContentBlockVariants;
using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.RawContentBlockStartEventProperties;

[JsonConverter(typeof(ContentBlockConverter))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(Messages::TextBlock value) =>
        new ContentBlockVariants::TextBlock(value);

    public static implicit operator ContentBlock(Messages::ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlock(value);

    public static implicit operator ContentBlock(Messages::ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlock(value);

    public static implicit operator ContentBlock(Messages::WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlock(value);

    public bool TryPickText([NotNullWhen(true)] out Messages::TextBlock? value)
    {
        value = (this as ContentBlockVariants::TextBlock)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out Messages::ThinkingBlock? value)
    {
        value = (this as ContentBlockVariants::ThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinking(
        [NotNullWhen(true)] out Messages::RedactedThinkingBlock? value
    )
    {
        value = (this as ContentBlockVariants::RedactedThinkingBlock)?.Value;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out Messages::ToolUseBlock? value)
    {
        value = (this as ContentBlockVariants::ToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out Messages::ServerToolUseBlock? value)
    {
        value = (this as ContentBlockVariants::ServerToolUseBlock)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out Messages::WebSearchToolResultBlock? value
    )
    {
        value = (this as ContentBlockVariants::WebSearchToolResultBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentBlockVariants::TextBlock> text,
        Action<ContentBlockVariants::ThinkingBlock> thinking,
        Action<ContentBlockVariants::RedactedThinkingBlock> redactedThinking,
        Action<ContentBlockVariants::ToolUseBlock> toolUse,
        Action<ContentBlockVariants::ServerToolUseBlock> serverToolUse,
        Action<ContentBlockVariants::WebSearchToolResultBlock> webSearchToolResult
    )
    {
        switch (this)
        {
            case ContentBlockVariants::TextBlock inner:
                text(inner);
                break;
            case ContentBlockVariants::ThinkingBlock inner:
                thinking(inner);
                break;
            case ContentBlockVariants::RedactedThinkingBlock inner:
                redactedThinking(inner);
                break;
            case ContentBlockVariants::ToolUseBlock inner:
                toolUse(inner);
                break;
            case ContentBlockVariants::ServerToolUseBlock inner:
                serverToolUse(inner);
                break;
            case ContentBlockVariants::WebSearchToolResultBlock inner:
                webSearchToolResult(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentBlockVariants::TextBlock, T> text,
        Func<ContentBlockVariants::ThinkingBlock, T> thinking,
        Func<ContentBlockVariants::RedactedThinkingBlock, T> redactedThinking,
        Func<ContentBlockVariants::ToolUseBlock, T> toolUse,
        Func<ContentBlockVariants::ServerToolUseBlock, T> serverToolUse,
        Func<ContentBlockVariants::WebSearchToolResultBlock, T> webSearchToolResult
    )
    {
        return this switch
        {
            ContentBlockVariants::TextBlock inner => text(inner),
            ContentBlockVariants::ThinkingBlock inner => thinking(inner),
            ContentBlockVariants::RedactedThinkingBlock inner => redactedThinking(inner),
            ContentBlockVariants::ToolUseBlock inner => toolUse(inner),
            ContentBlockVariants::ServerToolUseBlock inner => serverToolUse(inner),
            ContentBlockVariants::WebSearchToolResultBlock inner => webSearchToolResult(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Messages::TextBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::TextBlock(deserialized);
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
                        return new ContentBlockVariants::ThinkingBlock(deserialized);
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
                        return new ContentBlockVariants::RedactedThinkingBlock(deserialized);
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
                        return new ContentBlockVariants::ToolUseBlock(deserialized);
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
                        return new ContentBlockVariants::ServerToolUseBlock(deserialized);
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
                        return new ContentBlockVariants::WebSearchToolResultBlock(deserialized);
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
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockVariants::TextBlock(var text) => text,
            ContentBlockVariants::ThinkingBlock(var thinking) => thinking,
            ContentBlockVariants::RedactedThinkingBlock(var redactedThinking) => redactedThinking,
            ContentBlockVariants::ToolUseBlock(var toolUse) => toolUse,
            ContentBlockVariants::ServerToolUseBlock(var serverToolUse) => serverToolUse,
            ContentBlockVariants::WebSearchToolResultBlock(var webSearchToolResult) =>
                webSearchToolResult,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
