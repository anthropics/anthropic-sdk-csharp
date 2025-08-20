using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ContentBlockParamVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(ContentBlockParamConverter))]
public abstract record class ContentBlockParam
{
    internal ContentBlockParam() { }

    public static implicit operator ContentBlockParam(TextBlockParam value) =>
        new TextBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ImageBlockParam value) =>
        new ImageBlockParamVariant(value);

    public static implicit operator ContentBlockParam(DocumentBlockParam value) =>
        new DocumentBlockParamVariant(value);

    public static implicit operator ContentBlockParam(SearchResultBlockParam value) =>
        new SearchResultBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ThinkingBlockParam value) =>
        new ThinkingBlockParamVariant(value);

    public static implicit operator ContentBlockParam(RedactedThinkingBlockParam value) =>
        new RedactedThinkingBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ToolUseBlockParam value) =>
        new ToolUseBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ToolResultBlockParam value) =>
        new ToolResultBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ServerToolUseBlockParam value) =>
        new ServerToolUseBlockParamVariant(value);

    public static implicit operator ContentBlockParam(WebSearchToolResultBlockParam value) =>
        new WebSearchToolResultBlockParamVariant(value);

    public bool TryPickTextBlockParamVariant([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = (this as TextBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickImageBlockParamVariant([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = (this as ImageBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickDocumentBlockParamVariant([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = (this as DocumentBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickSearchResultBlockParamVariant(
        [NotNullWhen(true)] out SearchResultBlockParam? value
    )
    {
        value = (this as SearchResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickThinkingBlockParamVariant([NotNullWhen(true)] out ThinkingBlockParam? value)
    {
        value = (this as ThinkingBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickRedactedThinkingBlockParamVariant(
        [NotNullWhen(true)] out RedactedThinkingBlockParam? value
    )
    {
        value = (this as RedactedThinkingBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolUseBlockParamVariant([NotNullWhen(true)] out ToolUseBlockParam? value)
    {
        value = (this as ToolUseBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolResultBlockParamVariant(
        [NotNullWhen(true)] out ToolResultBlockParam? value
    )
    {
        value = (this as ToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickServerToolUseBlockParamVariant(
        [NotNullWhen(true)] out ServerToolUseBlockParam? value
    )
    {
        value = (this as ServerToolUseBlockParamVariant)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolResultBlockParamVariant(
        [NotNullWhen(true)] out WebSearchToolResultBlockParam? value
    )
    {
        value = (this as WebSearchToolResultBlockParamVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextBlockParamVariant> textBlockParam,
        Action<ImageBlockParamVariant> imageBlockParam,
        Action<DocumentBlockParamVariant> documentBlockParam,
        Action<SearchResultBlockParamVariant> searchResultBlockParam,
        Action<ThinkingBlockParamVariant> thinkingBlockParam,
        Action<RedactedThinkingBlockParamVariant> redactedThinkingBlockParam,
        Action<ToolUseBlockParamVariant> toolUseBlockParam,
        Action<ToolResultBlockParamVariant> toolResultBlockParam,
        Action<ServerToolUseBlockParamVariant> serverToolUseBlockParam,
        Action<WebSearchToolResultBlockParamVariant> webSearchToolResultBlockParam
    )
    {
        switch (this)
        {
            case TextBlockParamVariant inner:
                textBlockParam(inner);
                break;
            case ImageBlockParamVariant inner:
                imageBlockParam(inner);
                break;
            case DocumentBlockParamVariant inner:
                documentBlockParam(inner);
                break;
            case SearchResultBlockParamVariant inner:
                searchResultBlockParam(inner);
                break;
            case ThinkingBlockParamVariant inner:
                thinkingBlockParam(inner);
                break;
            case RedactedThinkingBlockParamVariant inner:
                redactedThinkingBlockParam(inner);
                break;
            case ToolUseBlockParamVariant inner:
                toolUseBlockParam(inner);
                break;
            case ToolResultBlockParamVariant inner:
                toolResultBlockParam(inner);
                break;
            case ServerToolUseBlockParamVariant inner:
                serverToolUseBlockParam(inner);
                break;
            case WebSearchToolResultBlockParamVariant inner:
                webSearchToolResultBlockParam(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextBlockParamVariant, T> textBlockParam,
        Func<ImageBlockParamVariant, T> imageBlockParam,
        Func<DocumentBlockParamVariant, T> documentBlockParam,
        Func<SearchResultBlockParamVariant, T> searchResultBlockParam,
        Func<ThinkingBlockParamVariant, T> thinkingBlockParam,
        Func<RedactedThinkingBlockParamVariant, T> redactedThinkingBlockParam,
        Func<ToolUseBlockParamVariant, T> toolUseBlockParam,
        Func<ToolResultBlockParamVariant, T> toolResultBlockParam,
        Func<ServerToolUseBlockParamVariant, T> serverToolUseBlockParam,
        Func<WebSearchToolResultBlockParamVariant, T> webSearchToolResultBlockParam
    )
    {
        return this switch
        {
            TextBlockParamVariant inner => textBlockParam(inner),
            ImageBlockParamVariant inner => imageBlockParam(inner),
            DocumentBlockParamVariant inner => documentBlockParam(inner),
            SearchResultBlockParamVariant inner => searchResultBlockParam(inner),
            ThinkingBlockParamVariant inner => thinkingBlockParam(inner),
            RedactedThinkingBlockParamVariant inner => redactedThinkingBlockParam(inner),
            ToolUseBlockParamVariant inner => toolUseBlockParam(inner),
            ToolResultBlockParamVariant inner => toolResultBlockParam(inner),
            ServerToolUseBlockParamVariant inner => serverToolUseBlockParam(inner),
            WebSearchToolResultBlockParamVariant inner => webSearchToolResultBlockParam(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentBlockParamConverter : JsonConverter<ContentBlockParam>
{
    public override ContentBlockParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new TextBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ImageBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "document":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DocumentBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "search_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SearchResultBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ThinkingBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new RedactedThinkingBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolUseBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tool_result":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ToolResultBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ServerToolUseBlockParamVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new WebSearchToolResultBlockParamVariant(deserialized);
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
        ContentBlockParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TextBlockParamVariant(var textBlockParam) => textBlockParam,
            ImageBlockParamVariant(var imageBlockParam) => imageBlockParam,
            DocumentBlockParamVariant(var documentBlockParam) => documentBlockParam,
            SearchResultBlockParamVariant(var searchResultBlockParam) => searchResultBlockParam,
            ThinkingBlockParamVariant(var thinkingBlockParam) => thinkingBlockParam,
            RedactedThinkingBlockParamVariant(var redactedThinkingBlockParam) =>
                redactedThinkingBlockParam,
            ToolUseBlockParamVariant(var toolUseBlockParam) => toolUseBlockParam,
            ToolResultBlockParamVariant(var toolResultBlockParam) => toolResultBlockParam,
            ServerToolUseBlockParamVariant(var serverToolUseBlockParam) => serverToolUseBlockParam,
            WebSearchToolResultBlockParamVariant(var webSearchToolResultBlockParam) =>
                webSearchToolResultBlockParam,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
