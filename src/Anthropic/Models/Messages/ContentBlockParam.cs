using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockParamVariants = Anthropic.Models.Messages.ContentBlockParamVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// Regular text content.
/// </summary>
[JsonConverter(typeof(ContentBlockParamConverter))]
public abstract record class ContentBlockParam
{
    internal ContentBlockParam() { }

    public static implicit operator ContentBlockParam(TextBlockParam value) =>
        new ContentBlockParamVariants::TextBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ImageBlockParam value) =>
        new ContentBlockParamVariants::ImageBlockParamVariant(value);

    public static implicit operator ContentBlockParam(DocumentBlockParam value) =>
        new ContentBlockParamVariants::DocumentBlockParamVariant(value);

    public static implicit operator ContentBlockParam(SearchResultBlockParam value) =>
        new ContentBlockParamVariants::SearchResultBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ThinkingBlockParam value) =>
        new ContentBlockParamVariants::ThinkingBlockParamVariant(value);

    public static implicit operator ContentBlockParam(RedactedThinkingBlockParam value) =>
        new ContentBlockParamVariants::RedactedThinkingBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ToolUseBlockParam value) =>
        new ContentBlockParamVariants::ToolUseBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ToolResultBlockParam value) =>
        new ContentBlockParamVariants::ToolResultBlockParamVariant(value);

    public static implicit operator ContentBlockParam(ServerToolUseBlockParam value) =>
        new ContentBlockParamVariants::ServerToolUseBlockParamVariant(value);

    public static implicit operator ContentBlockParam(WebSearchToolResultBlockParam value) =>
        new ContentBlockParamVariants::WebSearchToolResultBlockParamVariant(value);

    public abstract void Validate();
}

sealed class ContentBlockParamConverter : JsonConverter<ContentBlockParam>
{
    public override ContentBlockParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new ContentBlockParamVariants::TextBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ImageBlockParamVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::DocumentBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::SearchResultBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::ThinkingBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::RedactedThinkingBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockParamVariants::ToolUseBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::ToolResultBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::ServerToolUseBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockParamVariants::WebSearchToolResultBlockParamVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            ContentBlockParamVariants::TextBlockParamVariant(var textBlockParam) => textBlockParam,
            ContentBlockParamVariants::ImageBlockParamVariant(var imageBlockParam) =>
                imageBlockParam,
            ContentBlockParamVariants::DocumentBlockParamVariant(var documentBlockParam) =>
                documentBlockParam,
            ContentBlockParamVariants::SearchResultBlockParamVariant(var searchResultBlockParam) =>
                searchResultBlockParam,
            ContentBlockParamVariants::ThinkingBlockParamVariant(var thinkingBlockParam) =>
                thinkingBlockParam,
            ContentBlockParamVariants::RedactedThinkingBlockParamVariant(
                var redactedThinkingBlockParam
            ) => redactedThinkingBlockParam,
            ContentBlockParamVariants::ToolUseBlockParamVariant(var toolUseBlockParam) =>
                toolUseBlockParam,
            ContentBlockParamVariants::ToolResultBlockParamVariant(var toolResultBlockParam) =>
                toolResultBlockParam,
            ContentBlockParamVariants::ServerToolUseBlockParamVariant(
                var serverToolUseBlockParam
            ) => serverToolUseBlockParam,
            ContentBlockParamVariants::WebSearchToolResultBlockParamVariant(
                var webSearchToolResultBlockParam
            ) => webSearchToolResultBlockParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
