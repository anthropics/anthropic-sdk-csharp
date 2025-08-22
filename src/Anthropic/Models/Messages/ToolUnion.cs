using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolUnionVariants = Anthropic.Models.Messages.ToolUnionVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ToolUnionConverter))]
public abstract record class ToolUnion
{
    internal ToolUnion() { }

    public static implicit operator ToolUnion(Tool value) => new ToolUnionVariants::Tool(value);

    public static implicit operator ToolUnion(ToolBash20250124 value) =>
        new ToolUnionVariants::ToolBash20250124(value);

    public static implicit operator ToolUnion(ToolTextEditor20250124 value) =>
        new ToolUnionVariants::ToolTextEditor20250124(value);

    public static implicit operator ToolUnion(ToolTextEditor20250429 value) =>
        new ToolUnionVariants::ToolTextEditor20250429(value);

    public static implicit operator ToolUnion(ToolTextEditor20250728 value) =>
        new ToolUnionVariants::ToolTextEditor20250728(value);

    public static implicit operator ToolUnion(WebSearchTool20250305 value) =>
        new ToolUnionVariants::WebSearchTool20250305(value);

    public bool TryPickTool([NotNullWhen(true)] out Tool? value)
    {
        value = (this as ToolUnionVariants::Tool)?.Value;
        return value != null;
    }

    public bool TryPickBash20250124([NotNullWhen(true)] out ToolBash20250124? value)
    {
        value = (this as ToolUnionVariants::ToolBash20250124)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250124([NotNullWhen(true)] out ToolTextEditor20250124? value)
    {
        value = (this as ToolUnionVariants::ToolTextEditor20250124)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250429([NotNullWhen(true)] out ToolTextEditor20250429? value)
    {
        value = (this as ToolUnionVariants::ToolTextEditor20250429)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250728([NotNullWhen(true)] out ToolTextEditor20250728? value)
    {
        value = (this as ToolUnionVariants::ToolTextEditor20250728)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305([NotNullWhen(true)] out WebSearchTool20250305? value)
    {
        value = (this as ToolUnionVariants::WebSearchTool20250305)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToolUnionVariants::Tool> tool,
        Action<ToolUnionVariants::ToolBash20250124> bash20250124,
        Action<ToolUnionVariants::ToolTextEditor20250124> textEditor20250124,
        Action<ToolUnionVariants::ToolTextEditor20250429> textEditor20250429,
        Action<ToolUnionVariants::ToolTextEditor20250728> textEditor20250728,
        Action<ToolUnionVariants::WebSearchTool20250305> webSearchTool20250305
    )
    {
        switch (this)
        {
            case ToolUnionVariants::Tool inner:
                tool(inner);
                break;
            case ToolUnionVariants::ToolBash20250124 inner:
                bash20250124(inner);
                break;
            case ToolUnionVariants::ToolTextEditor20250124 inner:
                textEditor20250124(inner);
                break;
            case ToolUnionVariants::ToolTextEditor20250429 inner:
                textEditor20250429(inner);
                break;
            case ToolUnionVariants::ToolTextEditor20250728 inner:
                textEditor20250728(inner);
                break;
            case ToolUnionVariants::WebSearchTool20250305 inner:
                webSearchTool20250305(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ToolUnionVariants::Tool, T> tool,
        Func<ToolUnionVariants::ToolBash20250124, T> bash20250124,
        Func<ToolUnionVariants::ToolTextEditor20250124, T> textEditor20250124,
        Func<ToolUnionVariants::ToolTextEditor20250429, T> textEditor20250429,
        Func<ToolUnionVariants::ToolTextEditor20250728, T> textEditor20250728,
        Func<ToolUnionVariants::WebSearchTool20250305, T> webSearchTool20250305
    )
    {
        return this switch
        {
            ToolUnionVariants::Tool inner => tool(inner),
            ToolUnionVariants::ToolBash20250124 inner => bash20250124(inner),
            ToolUnionVariants::ToolTextEditor20250124 inner => textEditor20250124(inner),
            ToolUnionVariants::ToolTextEditor20250429 inner => textEditor20250429(inner),
            ToolUnionVariants::ToolTextEditor20250728 inner => textEditor20250728(inner),
            ToolUnionVariants::WebSearchTool20250305 inner => webSearchTool20250305(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ToolUnionConverter : JsonConverter<ToolUnion>
{
    public override ToolUnion? Read(
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
                return new ToolUnionVariants::Tool(deserialized);
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
                return new ToolUnionVariants::ToolBash20250124(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250124(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250429(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250728(deserialized);
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
                return new ToolUnionVariants::WebSearchTool20250305(deserialized);
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
        ToolUnion value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ToolUnionVariants::Tool(var tool) => tool,
            ToolUnionVariants::ToolBash20250124(var bash20250124) => bash20250124,
            ToolUnionVariants::ToolTextEditor20250124(var textEditor20250124) => textEditor20250124,
            ToolUnionVariants::ToolTextEditor20250429(var textEditor20250429) => textEditor20250429,
            ToolUnionVariants::ToolTextEditor20250728(var textEditor20250728) => textEditor20250728,
            ToolUnionVariants::WebSearchTool20250305(var webSearchTool20250305) =>
                webSearchTool20250305,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
