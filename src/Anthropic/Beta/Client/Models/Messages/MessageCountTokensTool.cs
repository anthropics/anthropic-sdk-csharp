using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessageCountTokensToolVariants = Anthropic.Beta.Client.Models.Messages.MessageCountTokensToolVariants;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(MessageCountTokensToolConverter))]
public abstract record class MessageCountTokensTool
{
    internal MessageCountTokensTool() { }

    public static implicit operator MessageCountTokensTool(Tool value) =>
        new MessageCountTokensToolVariants::Tool(value);

    public static implicit operator MessageCountTokensTool(ToolBash20250124 value) =>
        new MessageCountTokensToolVariants::ToolBash20250124(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250124 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250124(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250429 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250429(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250728 value) =>
        new MessageCountTokensToolVariants::ToolTextEditor20250728(value);

    public static implicit operator MessageCountTokensTool(WebSearchTool20250305 value) =>
        new MessageCountTokensToolVariants::WebSearchTool20250305(value);

    public bool TryPickTool([NotNullWhen(true)] out Tool? value)
    {
        value = (this as MessageCountTokensToolVariants::Tool)?.Value;
        return value != null;
    }

    public bool TryPickToolBash20250124([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = (this as MessageCountTokensToolVariants::ToolBash20250124)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250124([NotNullWhen(true)] out ToolTextEditor20250124? value)
    {
        value = (this as MessageCountTokensToolVariants::ToolTextEditor20250124)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250429([NotNullWhen(true)] out ToolTextEditor20250429? value)
    {
        value = (this as MessageCountTokensToolVariants::ToolTextEditor20250429)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250728([NotNullWhen(true)] out ToolTextEditor20250728? value)
    {
        value = (this as MessageCountTokensToolVariants::ToolTextEditor20250728)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305([NotNullWhen(true)] out WebSearchTool20250305? value)
    {
        value = (this as MessageCountTokensToolVariants::WebSearchTool20250305)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MessageCountTokensToolVariants::Tool> tool,
        Action<MessageCountTokensToolVariants::ToolBash20250124> toolBash20250124,
        Action<MessageCountTokensToolVariants::ToolTextEditor20250124> toolTextEditor20250124,
        Action<MessageCountTokensToolVariants::ToolTextEditor20250429> toolTextEditor20250429,
        Action<MessageCountTokensToolVariants::ToolTextEditor20250728> toolTextEditor20250728,
        Action<MessageCountTokensToolVariants::WebSearchTool20250305> webSearchTool20250305
    )
    {
        switch (this)
        {
            case MessageCountTokensToolVariants::Tool inner:
                tool(inner);
                break;
            case MessageCountTokensToolVariants::ToolBash20250124 inner:
                toolBash20250124(inner);
                break;
            case MessageCountTokensToolVariants::ToolTextEditor20250124 inner:
                toolTextEditor20250124(inner);
                break;
            case MessageCountTokensToolVariants::ToolTextEditor20250429 inner:
                toolTextEditor20250429(inner);
                break;
            case MessageCountTokensToolVariants::ToolTextEditor20250728 inner:
                toolTextEditor20250728(inner);
                break;
            case MessageCountTokensToolVariants::WebSearchTool20250305 inner:
                webSearchTool20250305(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MessageCountTokensToolVariants::Tool, T> tool,
        Func<MessageCountTokensToolVariants::ToolBash20250124, T> toolBash20250124,
        Func<MessageCountTokensToolVariants::ToolTextEditor20250124, T> toolTextEditor20250124,
        Func<MessageCountTokensToolVariants::ToolTextEditor20250429, T> toolTextEditor20250429,
        Func<MessageCountTokensToolVariants::ToolTextEditor20250728, T> toolTextEditor20250728,
        Func<MessageCountTokensToolVariants::WebSearchTool20250305, T> webSearchTool20250305
    )
    {
        return this switch
        {
            MessageCountTokensToolVariants::Tool inner => tool(inner),
            MessageCountTokensToolVariants::ToolBash20250124 inner => toolBash20250124(inner),
            MessageCountTokensToolVariants::ToolTextEditor20250124 inner => toolTextEditor20250124(
                inner
            ),
            MessageCountTokensToolVariants::ToolTextEditor20250429 inner => toolTextEditor20250429(
                inner
            ),
            MessageCountTokensToolVariants::ToolTextEditor20250728 inner => toolTextEditor20250728(
                inner
            ),
            MessageCountTokensToolVariants::WebSearchTool20250305 inner => webSearchTool20250305(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MessageCountTokensToolConverter : JsonConverter<MessageCountTokensTool>
{
    public override MessageCountTokensTool? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Tool>(ref reader, options);
            if (deserialized != null)
            {
                return new MessageCountTokensToolVariants::Tool(deserialized);
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
                return new MessageCountTokensToolVariants::ToolBash20250124(deserialized);
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
                return new MessageCountTokensToolVariants::ToolTextEditor20250124(deserialized);
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
                return new MessageCountTokensToolVariants::ToolTextEditor20250429(deserialized);
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
                return new MessageCountTokensToolVariants::ToolTextEditor20250728(deserialized);
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
                return new MessageCountTokensToolVariants::WebSearchTool20250305(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCountTokensTool value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            MessageCountTokensToolVariants::Tool(var tool) => tool,
            MessageCountTokensToolVariants::ToolBash20250124(var toolBash20250124) =>
                toolBash20250124,
            MessageCountTokensToolVariants::ToolTextEditor20250124(var toolTextEditor20250124) =>
                toolTextEditor20250124,
            MessageCountTokensToolVariants::ToolTextEditor20250429(var toolTextEditor20250429) =>
                toolTextEditor20250429,
            MessageCountTokensToolVariants::ToolTextEditor20250728(var toolTextEditor20250728) =>
                toolTextEditor20250728,
            MessageCountTokensToolVariants::WebSearchTool20250305(var webSearchTool20250305) =>
                webSearchTool20250305,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
