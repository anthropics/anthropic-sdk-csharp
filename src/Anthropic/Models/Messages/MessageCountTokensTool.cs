using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessageCountTokensToolVariants = Anthropic.Models.Messages.MessageCountTokensToolVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(MessageCountTokensToolConverter))]
public abstract record class MessageCountTokensTool
{
    internal MessageCountTokensTool() { }

    public static implicit operator MessageCountTokensTool(Tool value) =>
        new MessageCountTokensToolVariants::ToolVariant(value);

    public static implicit operator MessageCountTokensTool(ToolBash20250124 value) =>
        new MessageCountTokensToolVariants::ToolBash20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250124 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250429 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250429Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250728 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250728Variant(value);

    public static implicit operator MessageCountTokensTool(WebSearchTool20250305 value) =>
        new MessageCountTokensToolVariants::WebSearchTool20250305Variant(value);

    public abstract void Validate();
}

sealed class MessageCountTokensToolConverter : JsonConverter<MessageCountTokensTool>
{
    public override MessageCountTokensTool? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Tool>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::ToolVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolBash20250124>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::ToolBash20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::ToolTextEditor20250124Variant(
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
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250429>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::ToolTextEditor20250429Variant(
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
            var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::ToolTextEditor20250728Variant(
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
            var deserialized = JsonSerializer.Deserialize<WebSearchTool20250305>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::WebSearchTool20250305Variant(
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
        MessageCountTokensTool value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            MessageCountTokensToolVariants::ToolVariant(var tool) => tool,
            MessageCountTokensToolVariants::ToolBash20250124Variant(var toolBash20250124) =>
                toolBash20250124,
            MessageCountTokensToolVariants::ToolTextEditor20250124Variant(
                var toolTextEditor20250124
            ) => toolTextEditor20250124,
            MessageCountTokensToolVariants::ToolTextEditor20250429Variant(
                var toolTextEditor20250429
            ) => toolTextEditor20250429,
            MessageCountTokensToolVariants::ToolTextEditor20250728Variant(
                var toolTextEditor20250728
            ) => toolTextEditor20250728,
            MessageCountTokensToolVariants::WebSearchTool20250305Variant(
                var webSearchTool20250305
            ) => webSearchTool20250305,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
