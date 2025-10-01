using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using ContentBlockParamVariants = Anthropic.Client.Models.Messages.ContentBlockParamVariants;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(ContentBlockParamConverter))]
public abstract record class ContentBlockParam
{
    internal ContentBlockParam() { }

    public static implicit operator ContentBlockParam(TextBlockParam value) =>
        new ContentBlockParamVariants::TextBlockParam(value);

    public static implicit operator ContentBlockParam(ImageBlockParam value) =>
        new ContentBlockParamVariants::ImageBlockParam(value);

    public static implicit operator ContentBlockParam(DocumentBlockParam value) =>
        new ContentBlockParamVariants::DocumentBlockParam(value);

    public static implicit operator ContentBlockParam(SearchResultBlockParam value) =>
        new ContentBlockParamVariants::SearchResultBlockParam(value);

    public static implicit operator ContentBlockParam(ThinkingBlockParam value) =>
        new ContentBlockParamVariants::ThinkingBlockParam(value);

    public static implicit operator ContentBlockParam(RedactedThinkingBlockParam value) =>
        new ContentBlockParamVariants::RedactedThinkingBlockParam(value);

    public static implicit operator ContentBlockParam(ToolUseBlockParam value) =>
        new ContentBlockParamVariants::ToolUseBlockParam(value);

    public static implicit operator ContentBlockParam(ToolResultBlockParam value) =>
        new ContentBlockParamVariants::ToolResultBlockParam(value);

    public static implicit operator ContentBlockParam(ServerToolUseBlockParam value) =>
        new ContentBlockParamVariants::ServerToolUseBlockParam(value);

    public static implicit operator ContentBlockParam(WebSearchToolResultBlockParam value) =>
        new ContentBlockParamVariants::WebSearchToolResultBlockParam(value);

    public bool TryPickText([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::TextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::ImageBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickDocument([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::DocumentBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickSearchResult([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::SearchResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::ThinkingBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out RedactedThinkingBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::RedactedThinkingBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out ToolUseBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::ToolUseBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickToolResult([NotNullWhen(true)] out ToolResultBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::ToolResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out ServerToolUseBlockParam? value)
    {
        value = (this as ContentBlockParamVariants::ServerToolUseBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out WebSearchToolResultBlockParam? value
    )
    {
        value = (this as ContentBlockParamVariants::WebSearchToolResultBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentBlockParamVariants::TextBlockParam> text,
        Action<ContentBlockParamVariants::ImageBlockParam> image,
        Action<ContentBlockParamVariants::DocumentBlockParam> document,
        Action<ContentBlockParamVariants::SearchResultBlockParam> searchResult,
        Action<ContentBlockParamVariants::ThinkingBlockParam> thinking,
        Action<ContentBlockParamVariants::RedactedThinkingBlockParam> redactedThinking,
        Action<ContentBlockParamVariants::ToolUseBlockParam> toolUse,
        Action<ContentBlockParamVariants::ToolResultBlockParam> toolResult,
        Action<ContentBlockParamVariants::ServerToolUseBlockParam> serverToolUse,
        Action<ContentBlockParamVariants::WebSearchToolResultBlockParam> webSearchToolResult
    )
    {
        switch (this)
        {
            case ContentBlockParamVariants::TextBlockParam inner:
                text(inner);
                break;
            case ContentBlockParamVariants::ImageBlockParam inner:
                image(inner);
                break;
            case ContentBlockParamVariants::DocumentBlockParam inner:
                document(inner);
                break;
            case ContentBlockParamVariants::SearchResultBlockParam inner:
                searchResult(inner);
                break;
            case ContentBlockParamVariants::ThinkingBlockParam inner:
                thinking(inner);
                break;
            case ContentBlockParamVariants::RedactedThinkingBlockParam inner:
                redactedThinking(inner);
                break;
            case ContentBlockParamVariants::ToolUseBlockParam inner:
                toolUse(inner);
                break;
            case ContentBlockParamVariants::ToolResultBlockParam inner:
                toolResult(inner);
                break;
            case ContentBlockParamVariants::ServerToolUseBlockParam inner:
                serverToolUse(inner);
                break;
            case ContentBlockParamVariants::WebSearchToolResultBlockParam inner:
                webSearchToolResult(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlockParam"
                );
        }
    }

    public T Match<T>(
        Func<ContentBlockParamVariants::TextBlockParam, T> text,
        Func<ContentBlockParamVariants::ImageBlockParam, T> image,
        Func<ContentBlockParamVariants::DocumentBlockParam, T> document,
        Func<ContentBlockParamVariants::SearchResultBlockParam, T> searchResult,
        Func<ContentBlockParamVariants::ThinkingBlockParam, T> thinking,
        Func<ContentBlockParamVariants::RedactedThinkingBlockParam, T> redactedThinking,
        Func<ContentBlockParamVariants::ToolUseBlockParam, T> toolUse,
        Func<ContentBlockParamVariants::ToolResultBlockParam, T> toolResult,
        Func<ContentBlockParamVariants::ServerToolUseBlockParam, T> serverToolUse,
        Func<ContentBlockParamVariants::WebSearchToolResultBlockParam, T> webSearchToolResult
    )
    {
        return this switch
        {
            ContentBlockParamVariants::TextBlockParam inner => text(inner),
            ContentBlockParamVariants::ImageBlockParam inner => image(inner),
            ContentBlockParamVariants::DocumentBlockParam inner => document(inner),
            ContentBlockParamVariants::SearchResultBlockParam inner => searchResult(inner),
            ContentBlockParamVariants::ThinkingBlockParam inner => thinking(inner),
            ContentBlockParamVariants::RedactedThinkingBlockParam inner => redactedThinking(inner),
            ContentBlockParamVariants::ToolUseBlockParam inner => toolUse(inner),
            ContentBlockParamVariants::ToolResultBlockParam inner => toolResult(inner),
            ContentBlockParamVariants::ServerToolUseBlockParam inner => serverToolUse(inner),
            ContentBlockParamVariants::WebSearchToolResultBlockParam inner => webSearchToolResult(
                inner
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockParam"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockParamConverter : JsonConverter<ContentBlockParam>
{
    public override ContentBlockParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::TextBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::TextBlockParam",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ImageBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::ImageBlockParam",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "document":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::DocumentBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::DocumentBlockParam",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "search_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::SearchResultBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::SearchResultBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ThinkingBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::ThinkingBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::RedactedThinkingBlockParam(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::RedactedThinkingBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ToolUseBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::ToolUseBlockParam",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tool_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ToolResultBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::ToolResultBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ServerToolUseBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::ServerToolUseBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::WebSearchToolResultBlockParam(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ContentBlockParamVariants::WebSearchToolResultBlockParam",
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
        ContentBlockParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ContentBlockParamVariants::TextBlockParam(var text) => text,
            ContentBlockParamVariants::ImageBlockParam(var image) => image,
            ContentBlockParamVariants::DocumentBlockParam(var document) => document,
            ContentBlockParamVariants::SearchResultBlockParam(var searchResult) => searchResult,
            ContentBlockParamVariants::ThinkingBlockParam(var thinking) => thinking,
            ContentBlockParamVariants::RedactedThinkingBlockParam(var redactedThinking) =>
                redactedThinking,
            ContentBlockParamVariants::ToolUseBlockParam(var toolUse) => toolUse,
            ContentBlockParamVariants::ToolResultBlockParam(var toolResult) => toolResult,
            ContentBlockParamVariants::ServerToolUseBlockParam(var serverToolUse) => serverToolUse,
            ContentBlockParamVariants::WebSearchToolResultBlockParam(var webSearchToolResult) =>
                webSearchToolResult,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockParam"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
