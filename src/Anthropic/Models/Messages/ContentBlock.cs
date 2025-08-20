using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ContentBlockVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ContentBlockConverter))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(TextBlock value) => new TextBlockVariant(value);

    public static implicit operator ContentBlock(ThinkingBlock value) =>
        new ThinkingBlockVariant(value);

    public static implicit operator ContentBlock(RedactedThinkingBlock value) =>
        new RedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock(ToolUseBlock value) =>
        new ToolUseBlockVariant(value);

    public static implicit operator ContentBlock(ServerToolUseBlock value) =>
        new ServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock(WebSearchToolResultBlock value) =>
        new WebSearchToolResultBlockVariant(value);

    public bool TryPickTextBlockVariant([NotNullWhen(true)] out TextBlock? value)
    {
        value = (this as TextBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickThinkingBlockVariant([NotNullWhen(true)] out ThinkingBlock? value)
    {
        value = (this as ThinkingBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinkingBlockVariant(
        [NotNullWhen(true)] out RedactedThinkingBlock? value
    )
    {
        value = (this as RedactedThinkingBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolUseBlockVariant([NotNullWhen(true)] out ToolUseBlock? value)
    {
        value = (this as ToolUseBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUseBlockVariant([NotNullWhen(true)] out ServerToolUseBlock? value)
    {
        value = (this as ServerToolUseBlockVariant)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResultBlockVariant(
        [NotNullWhen(true)] out WebSearchToolResultBlock? value
    )
    {
        value = (this as WebSearchToolResultBlockVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextBlockVariant> textBlock,
        Action<ThinkingBlockVariant> thinkingBlock,
        Action<RedactedThinkingBlockVariant> redactedThinkingBlock,
        Action<ToolUseBlockVariant> toolUseBlock,
        Action<ServerToolUseBlockVariant> serverToolUseBlock,
        Action<WebSearchToolResultBlockVariant> webSearchToolResultBlock
    )
    {
        switch (this)
        {
            case TextBlockVariant inner:
                textBlock(inner);
                break;
            case ThinkingBlockVariant inner:
                thinkingBlock(inner);
                break;
            case RedactedThinkingBlockVariant inner:
                redactedThinkingBlock(inner);
                break;
            case ToolUseBlockVariant inner:
                toolUseBlock(inner);
                break;
            case ServerToolUseBlockVariant inner:
                serverToolUseBlock(inner);
                break;
            case WebSearchToolResultBlockVariant inner:
                webSearchToolResultBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextBlockVariant, T> textBlock,
        Func<ThinkingBlockVariant, T> thinkingBlock,
        Func<RedactedThinkingBlockVariant, T> redactedThinkingBlock,
        Func<ToolUseBlockVariant, T> toolUseBlock,
        Func<ServerToolUseBlockVariant, T> serverToolUseBlock,
        Func<WebSearchToolResultBlockVariant, T> webSearchToolResultBlock
    )
    {
        return this switch
        {
            TextBlockVariant inner => textBlock(inner),
            ThinkingBlockVariant inner => thinkingBlock(inner),
            RedactedThinkingBlockVariant inner => redactedThinkingBlock(inner),
            ToolUseBlockVariant inner => toolUseBlock(inner),
            ServerToolUseBlockVariant inner => serverToolUseBlock(inner),
            WebSearchToolResultBlockVariant inner => webSearchToolResultBlock(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<TextBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new TextBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ThinkingBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RedactedThinkingBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolUseBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ServerToolUseBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new WebSearchToolResultBlockVariant(deserialized);
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
            TextBlockVariant(var textBlock) => textBlock,
            ThinkingBlockVariant(var thinkingBlock) => thinkingBlock,
            RedactedThinkingBlockVariant(var redactedThinkingBlock) => redactedThinkingBlock,
            ToolUseBlockVariant(var toolUseBlock) => toolUseBlock,
            ServerToolUseBlockVariant(var serverToolUseBlock) => serverToolUseBlock,
            WebSearchToolResultBlockVariant(var webSearchToolResultBlock) =>
                webSearchToolResultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
