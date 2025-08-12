using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolUnionVariants = Anthropic.Models.Messages.ToolUnionVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ToolUnionConverter))]
public abstract record class ToolUnion
{
    internal ToolUnion() { }

    public static implicit operator ToolUnion(Tool value) =>
        new ToolUnionVariants::ToolVariant(value);

    public static implicit operator ToolUnion(ToolBash20250124 value) =>
        new ToolUnionVariants::ToolBash20250124Variant(value);

    public static implicit operator ToolUnion(ToolTextEditor20250124 value) =>
        new ToolUnionVariants::ToolTextEditor20250124Variant(value);

    public static implicit operator ToolUnion(ToolTextEditor20250429 value) =>
        new ToolUnionVariants::ToolTextEditor20250429Variant(value);

    public static implicit operator ToolUnion(ToolTextEditor20250728 value) =>
        new ToolUnionVariants::ToolTextEditor20250728Variant(value);

    public static implicit operator ToolUnion(WebSearchTool20250305 value) =>
        new ToolUnionVariants::WebSearchTool20250305Variant(value);

    public abstract void Validate();
}

sealed class ToolUnionConverter : JsonConverter<ToolUnion>
{
    public override ToolUnion? Read(
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
                return new ToolUnionVariants::ToolVariant(deserialized);
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
                return new ToolUnionVariants::ToolBash20250124Variant(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250124Variant(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250429Variant(deserialized);
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
                return new ToolUnionVariants::ToolTextEditor20250728Variant(deserialized);
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
                return new ToolUnionVariants::WebSearchTool20250305Variant(deserialized);
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
        ToolUnion value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ToolUnionVariants::ToolVariant(var tool) => tool,
            ToolUnionVariants::ToolBash20250124Variant(var toolBash20250124) => toolBash20250124,
            ToolUnionVariants::ToolTextEditor20250124Variant(var toolTextEditor20250124) =>
                toolTextEditor20250124,
            ToolUnionVariants::ToolTextEditor20250429Variant(var toolTextEditor20250429) =>
                toolTextEditor20250429,
            ToolUnionVariants::ToolTextEditor20250728Variant(var toolTextEditor20250728) =>
                toolTextEditor20250728,
            ToolUnionVariants::WebSearchTool20250305Variant(var webSearchTool20250305) =>
                webSearchTool20250305,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
