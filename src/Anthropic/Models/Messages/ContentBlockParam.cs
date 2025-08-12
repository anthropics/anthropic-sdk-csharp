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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<TextBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::TextBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::ImageBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::DocumentBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::SearchResultBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ThinkingBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::ThinkingBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlockParam>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::ToolUseBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::ToolResultBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentBlockParamVariants::ServerToolUseBlockParamVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockParam>(
                ref reader,
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
