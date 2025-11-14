using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(ContentBlockParamConverter))]
public record class ContentBlockParam
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                image: (x) => x.Type,
                document: (x) => x.Type,
                searchResult: (x) => x.Type,
                thinking: (x) => x.Type,
                redactedThinking: (x) => x.Type,
                toolUse: (x) => x.Type,
                toolResult: (x) => x.Type,
                serverToolUse: (x) => x.Type,
                webSearchToolResult: (x) => x.Type
            );
        }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                text: (x) => x.CacheControl,
                image: (x) => x.CacheControl,
                document: (x) => x.CacheControl,
                searchResult: (x) => x.CacheControl,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.CacheControl,
                toolResult: (x) => x.CacheControl,
                serverToolUse: (x) => x.CacheControl,
                webSearchToolResult: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                document: (x) => x.Title,
                searchResult: (x) => x.Title,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                toolResult: (_) => null,
                serverToolUse: (_) => null,
                webSearchToolResult: (_) => null
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                document: (_) => null,
                searchResult: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.ID,
                toolResult: (_) => null,
                serverToolUse: (x) => x.ID,
                webSearchToolResult: (_) => null
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                document: (_) => null,
                searchResult: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                toolResult: (x) => x.ToolUseID,
                serverToolUse: (_) => null,
                webSearchToolResult: (x) => x.ToolUseID
            );
        }
    }

    public ContentBlockParam(TextBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(ImageBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(DocumentBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(SearchResultBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(ThinkingBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(RedactedThinkingBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(ToolUseBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(ToolResultBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(ServerToolUseBlockParam value)
    {
        Value = value;
    }

    public ContentBlockParam(WebSearchToolResultBlockParam value)
    {
        Value = value;
    }

    ContentBlockParam(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentBlockParam CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickText([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = this.Value as TextBlockParam;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = this.Value as ImageBlockParam;
        return value != null;
    }

    public bool TryPickDocument([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = this.Value as DocumentBlockParam;
        return value != null;
    }

    public bool TryPickSearchResult([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = this.Value as SearchResultBlockParam;
        return value != null;
    }

    public bool TryPickThinking([NotNullWhen(true)] out ThinkingBlockParam? value)
    {
        value = this.Value as ThinkingBlockParam;
        return value != null;
    }

    public bool TryPickRedactedThinking([NotNullWhen(true)] out RedactedThinkingBlockParam? value)
    {
        value = this.Value as RedactedThinkingBlockParam;
        return value != null;
    }

    public bool TryPickToolUse([NotNullWhen(true)] out ToolUseBlockParam? value)
    {
        value = this.Value as ToolUseBlockParam;
        return value != null;
    }

    public bool TryPickToolResult([NotNullWhen(true)] out ToolResultBlockParam? value)
    {
        value = this.Value as ToolResultBlockParam;
        return value != null;
    }

    public bool TryPickServerToolUse([NotNullWhen(true)] out ServerToolUseBlockParam? value)
    {
        value = this.Value as ServerToolUseBlockParam;
        return value != null;
    }

    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out WebSearchToolResultBlockParam? value
    )
    {
        value = this.Value as WebSearchToolResultBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<TextBlockParam> text,
        System::Action<ImageBlockParam> image,
        System::Action<DocumentBlockParam> document,
        System::Action<SearchResultBlockParam> searchResult,
        System::Action<ThinkingBlockParam> thinking,
        System::Action<RedactedThinkingBlockParam> redactedThinking,
        System::Action<ToolUseBlockParam> toolUse,
        System::Action<ToolResultBlockParam> toolResult,
        System::Action<ServerToolUseBlockParam> serverToolUse,
        System::Action<WebSearchToolResultBlockParam> webSearchToolResult
    )
    {
        switch (this.Value)
        {
            case TextBlockParam value:
                text(value);
                break;
            case ImageBlockParam value:
                image(value);
                break;
            case DocumentBlockParam value:
                document(value);
                break;
            case SearchResultBlockParam value:
                searchResult(value);
                break;
            case ThinkingBlockParam value:
                thinking(value);
                break;
            case RedactedThinkingBlockParam value:
                redactedThinking(value);
                break;
            case ToolUseBlockParam value:
                toolUse(value);
                break;
            case ToolResultBlockParam value:
                toolResult(value);
                break;
            case ServerToolUseBlockParam value:
                serverToolUse(value);
                break;
            case WebSearchToolResultBlockParam value:
                webSearchToolResult(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlockParam"
                );
        }
    }

    public T Match<T>(
        System::Func<TextBlockParam, T> text,
        System::Func<ImageBlockParam, T> image,
        System::Func<DocumentBlockParam, T> document,
        System::Func<SearchResultBlockParam, T> searchResult,
        System::Func<ThinkingBlockParam, T> thinking,
        System::Func<RedactedThinkingBlockParam, T> redactedThinking,
        System::Func<ToolUseBlockParam, T> toolUse,
        System::Func<ToolResultBlockParam, T> toolResult,
        System::Func<ServerToolUseBlockParam, T> serverToolUse,
        System::Func<WebSearchToolResultBlockParam, T> webSearchToolResult
    )
    {
        return this.Value switch
        {
            TextBlockParam value => text(value),
            ImageBlockParam value => image(value),
            DocumentBlockParam value => document(value),
            SearchResultBlockParam value => searchResult(value),
            ThinkingBlockParam value => thinking(value),
            RedactedThinkingBlockParam value => redactedThinking(value),
            ToolUseBlockParam value => toolUse(value),
            ToolResultBlockParam value => toolResult(value),
            ServerToolUseBlockParam value => serverToolUse(value),
            WebSearchToolResultBlockParam value => webSearchToolResult(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockParam"
            ),
        };
    }

    public static implicit operator ContentBlockParam(TextBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(ImageBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(DocumentBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(SearchResultBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(ThinkingBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(RedactedThinkingBlockParam value) =>
        new(value);

    public static implicit operator ContentBlockParam(ToolUseBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(ToolResultBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(ServerToolUseBlockParam value) => new(value);

    public static implicit operator ContentBlockParam(WebSearchToolResultBlockParam value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlockParam"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentBlockParamConverter : JsonConverter<ContentBlockParam>
{
    public override ContentBlockParam? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'TextBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ImageBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'DocumentBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'SearchResultBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ThinkingBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'RedactedThinkingBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolUseBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolResultBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ServerToolUseBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        deserialized.Validate();
                        return new ContentBlockParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'WebSearchToolResultBlockParam'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
