using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.MessageCountTokensToolVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(MessageCountTokensToolConverter))]
public abstract record class MessageCountTokensTool
{
    internal MessageCountTokensTool() { }

    public static implicit operator MessageCountTokensTool(Tool value) => new ToolVariant(value);

    public static implicit operator MessageCountTokensTool(ToolBash20250124 value) =>
        new ToolBash20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250124 value) =>
        new ToolTextEditor20250124Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250429 value) =>
        new ToolTextEditor20250429Variant(value);

    public static implicit operator MessageCountTokensTool(ToolTextEditor20250728 value) =>
        new ToolTextEditor20250728Variant(value);

    public static implicit operator MessageCountTokensTool(WebSearchTool20250305 value) =>
        new WebSearchTool20250305Variant(value);

    public bool TryPickToolVariant([NotNullWhen(true)] out Tool? value)
    {
        value = (this as ToolVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolBash20250124Variant([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = (this as ToolBash20250124Variant)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250124Variant(
        [NotNullWhen(true)] out ToolTextEditor20250124? value
    )
    {
        value = (this as ToolTextEditor20250124Variant)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250429Variant(
        [NotNullWhen(true)] out ToolTextEditor20250429? value
    )
    {
        value = (this as ToolTextEditor20250429Variant)?.Value;
        return value != null;
    }

    public bool TryPickToolTextEditor20250728Variant(
        [NotNullWhen(true)] out ToolTextEditor20250728? value
    )
    {
        value = (this as ToolTextEditor20250728Variant)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305Variant(
        [NotNullWhen(true)] out WebSearchTool20250305? value
    )
    {
        value = (this as WebSearchTool20250305Variant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToolVariant> tool,
        Action<ToolBash20250124Variant> toolBash20250124,
        Action<ToolTextEditor20250124Variant> toolTextEditor20250124,
        Action<ToolTextEditor20250429Variant> toolTextEditor20250429,
        Action<ToolTextEditor20250728Variant> toolTextEditor20250728,
        Action<WebSearchTool20250305Variant> webSearchTool20250305
    )
    {
        switch (this)
        {
            case ToolVariant inner:
                tool(inner);
                break;
            case ToolBash20250124Variant inner:
                toolBash20250124(inner);
                break;
            case ToolTextEditor20250124Variant inner:
                toolTextEditor20250124(inner);
                break;
            case ToolTextEditor20250429Variant inner:
                toolTextEditor20250429(inner);
                break;
            case ToolTextEditor20250728Variant inner:
                toolTextEditor20250728(inner);
                break;
            case WebSearchTool20250305Variant inner:
                webSearchTool20250305(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ToolVariant, T> tool,
        Func<ToolBash20250124Variant, T> toolBash20250124,
        Func<ToolTextEditor20250124Variant, T> toolTextEditor20250124,
        Func<ToolTextEditor20250429Variant, T> toolTextEditor20250429,
        Func<ToolTextEditor20250728Variant, T> toolTextEditor20250728,
        Func<WebSearchTool20250305Variant, T> webSearchTool20250305
    )
    {
        return this switch
        {
            ToolVariant inner => tool(inner),
            ToolBash20250124Variant inner => toolBash20250124(inner),
            ToolTextEditor20250124Variant inner => toolTextEditor20250124(inner),
            ToolTextEditor20250429Variant inner => toolTextEditor20250429(inner),
            ToolTextEditor20250728Variant inner => toolTextEditor20250728(inner),
            WebSearchTool20250305Variant inner => webSearchTool20250305(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MessageCountTokensToolConverter : JsonConverter<MessageCountTokensTool>
{
    public override MessageCountTokensTool? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Tool>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolVariant(deserialized);
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
                return new ToolBash20250124Variant(deserialized);
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
                return new ToolTextEditor20250124Variant(deserialized);
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
                return new ToolTextEditor20250429Variant(deserialized);
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
                return new ToolTextEditor20250728Variant(deserialized);
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
                return new WebSearchTool20250305Variant(deserialized);
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
            ToolVariant(var tool) => tool,
            ToolBash20250124Variant(var toolBash20250124) => toolBash20250124,
            ToolTextEditor20250124Variant(var toolTextEditor20250124) => toolTextEditor20250124,
            ToolTextEditor20250429Variant(var toolTextEditor20250429) => toolTextEditor20250429,
            ToolTextEditor20250728Variant(var toolTextEditor20250728) => toolTextEditor20250728,
            WebSearchTool20250305Variant(var webSearchTool20250305) => webSearchTool20250305,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
