using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.RawContentBlockStartEventProperties;

[JsonConverter(typeof(ContentBlockConverter))]
public record class ContentBlock
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                thinking: (x) => x.Type,
                redactedThinking: (x) => x.Type,
                toolUse: (x) => x.Type,
                serverToolUse: (x) => x.Type,
                webSearchToolResult: (x) => x.Type
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.ID,
                serverToolUse: (x) => x.ID,
                webSearchToolResult: (_) => null
            );
        }
    }

    public JsonElement? Input
    {
        get
        {
            return Match<JsonElement?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.Input,
                serverToolUse: (x) => x.Input,
                webSearchToolResult: (_) => null
            );
        }
    }

    public ContentBlock(TextBlock value)
    {
        Value = value;
    }

    public ContentBlock(ThinkingBlock value)
    {
        Value = value;
    }

    public ContentBlock(RedactedThinkingBlock value)
    {
        Value = value;
    }

    public ContentBlock(ToolUseBlock value)
    {
        Value = value;
    }

    public ContentBlock(ServerToolUseBlock value)
    {
        Value = value;
    }

    public ContentBlock(WebSearchToolResultBlock value)
    {
        Value = value;
    }

    ContentBlock(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentBlock CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickText([NotNullWhen(true)] out TextBlock? value)
    {
        value = this.Value as TextBlock;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingBlock? value)
    {
        value = this.Value as ThinkingBlock;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out RedactedThinkingBlock? value)
    {
        value = this.Value as RedactedThinkingBlock;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out ToolUseBlock? value)
    {
        value = this.Value as ToolUseBlock;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out ServerToolUseBlock? value)
    {
        value = this.Value as ServerToolUseBlock;
        return value != null;
    }

    public bool TryPickWebSearchToolResult([NotNullWhen(true)] out WebSearchToolResultBlock? value)
    {
        value = this.Value as WebSearchToolResultBlock;
        return value != null;
    }

    public void Switch(
        Action<TextBlock> text,
        Action<ThinkingBlock> thinking,
        Action<RedactedThinkingBlock> redactedThinking,
        Action<ToolUseBlock> toolUse,
        Action<ServerToolUseBlock> serverToolUse,
        Action<WebSearchToolResultBlock> webSearchToolResult
    )
    {
        switch (this.Value)
        {
            case TextBlock value:
                text(value);
                break;
            case ThinkingBlock value:
                thinking(value);
                break;
            case RedactedThinkingBlock value:
                redactedThinking(value);
                break;
            case ToolUseBlock value:
                toolUse(value);
                break;
            case ServerToolUseBlock value:
                serverToolUse(value);
                break;
            case WebSearchToolResultBlock value:
                webSearchToolResult(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlock"
                );
        }
    }

    public T Match<T>(
        Func<TextBlock, T> text,
        Func<ThinkingBlock, T> thinking,
        Func<RedactedThinkingBlock, T> redactedThinking,
        Func<ToolUseBlock, T> toolUse,
        Func<ServerToolUseBlock, T> serverToolUse,
        Func<WebSearchToolResultBlock, T> webSearchToolResult
    )
    {
        return this.Value switch
        {
            TextBlock value => text(value),
            ThinkingBlock value => thinking(value),
            RedactedThinkingBlock value => redactedThinking(value),
            ToolUseBlock value => toolUse(value),
            ServerToolUseBlock value => serverToolUse(value),
            WebSearchToolResultBlock value => webSearchToolResult(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'TextBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "thinking":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ThinkingBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "redacted_thinking":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'RedactedThinkingBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolUseBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "server_tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ServerToolUseBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlock(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'WebSearchToolResultBlock'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
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
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
