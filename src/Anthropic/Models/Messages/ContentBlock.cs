using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentBlockVariants = Anthropic.Models.Messages.ContentBlockVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ContentBlockConverter))]
public abstract record class ContentBlock
{
    internal ContentBlock() { }

    public static implicit operator ContentBlock(TextBlock value) =>
        new ContentBlockVariants::TextBlockVariant(value);

    public static implicit operator ContentBlock(ThinkingBlock value) =>
        new ContentBlockVariants::ThinkingBlockVariant(value);

    public static implicit operator ContentBlock(RedactedThinkingBlock value) =>
        new ContentBlockVariants::RedactedThinkingBlockVariant(value);

    public static implicit operator ContentBlock(ToolUseBlock value) =>
        new ContentBlockVariants::ToolUseBlockVariant(value);

    public static implicit operator ContentBlock(ServerToolUseBlock value) =>
        new ContentBlockVariants::ServerToolUseBlockVariant(value);

    public static implicit operator ContentBlock(WebSearchToolResultBlock value) =>
        new ContentBlockVariants::WebSearchToolResultBlockVariant(value);

    public abstract void Validate();
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<TextBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::TextBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::ThinkingBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlock>(
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

                throw new global::System.AggregateException(exceptions);
            }
            case "tool_use":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        return new ContentBlockVariants::ToolUseBlockVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlock>(
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

                throw new global::System.AggregateException(exceptions);
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
                        return new ContentBlockVariants::WebSearchToolResultBlockVariant(
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
        ContentBlock value,
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
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
