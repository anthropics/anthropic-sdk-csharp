using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolChoiceVariants = Anthropic.Models.Messages.ToolChoiceVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public abstract record class ToolChoice
{
    internal ToolChoice() { }

    public static implicit operator ToolChoice(ToolChoiceAuto value) =>
        new ToolChoiceVariants::ToolChoiceAutoVariant(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) =>
        new ToolChoiceVariants::ToolChoiceAnyVariant(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) =>
        new ToolChoiceVariants::ToolChoiceToolVariant(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) =>
        new ToolChoiceVariants::ToolChoiceNoneVariant(value);

    public abstract void Validate();
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolChoiceVariants::ToolChoiceAutoVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolChoiceVariants::ToolChoiceAnyVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolChoiceVariants::ToolChoiceToolVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolChoiceVariants::ToolChoiceNoneVariant(deserialized);
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
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ToolChoiceVariants::ToolChoiceAutoVariant(var toolChoiceAuto) => toolChoiceAuto,
            ToolChoiceVariants::ToolChoiceAnyVariant(var toolChoiceAny) => toolChoiceAny,
            ToolChoiceVariants::ToolChoiceToolVariant(var toolChoiceTool) => toolChoiceTool,
            ToolChoiceVariants::ToolChoiceNoneVariant(var toolChoiceNone) => toolChoiceNone,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
