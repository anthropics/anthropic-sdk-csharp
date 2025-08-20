using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ToolChoiceVariants;

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
        new ToolChoiceAutoVariant(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) =>
        new ToolChoiceAnyVariant(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) =>
        new ToolChoiceToolVariant(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) =>
        new ToolChoiceNoneVariant(value);

    public bool TryPickToolChoiceAutoVariant([NotNullWhen(true)] out ToolChoiceAuto? value)
    {
        value = (this as ToolChoiceAutoVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolChoiceAnyVariant([NotNullWhen(true)] out ToolChoiceAny? value)
    {
        value = (this as ToolChoiceAnyVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolChoiceToolVariant([NotNullWhen(true)] out ToolChoiceTool? value)
    {
        value = (this as ToolChoiceToolVariant)?.Value;
        return value != null;
    }

    public bool TryPickToolChoiceNoneVariant([NotNullWhen(true)] out ToolChoiceNone? value)
    {
        value = (this as ToolChoiceNoneVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToolChoiceAutoVariant> toolChoiceAuto,
        Action<ToolChoiceAnyVariant> toolChoiceAny,
        Action<ToolChoiceToolVariant> toolChoiceTool,
        Action<ToolChoiceNoneVariant> toolChoiceNone
    )
    {
        switch (this)
        {
            case ToolChoiceAutoVariant inner:
                toolChoiceAuto(inner);
                break;
            case ToolChoiceAnyVariant inner:
                toolChoiceAny(inner);
                break;
            case ToolChoiceToolVariant inner:
                toolChoiceTool(inner);
                break;
            case ToolChoiceNoneVariant inner:
                toolChoiceNone(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ToolChoiceAutoVariant, T> toolChoiceAuto,
        Func<ToolChoiceAnyVariant, T> toolChoiceAny,
        Func<ToolChoiceToolVariant, T> toolChoiceTool,
        Func<ToolChoiceNoneVariant, T> toolChoiceNone
    )
    {
        return this switch
        {
            ToolChoiceAutoVariant inner => toolChoiceAuto(inner),
            ToolChoiceAnyVariant inner => toolChoiceAny(inner),
            ToolChoiceToolVariant inner => toolChoiceTool(inner),
            ToolChoiceNoneVariant inner => toolChoiceNone(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
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
            case "auto":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolChoiceAutoVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "any":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolChoiceAnyVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tool":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolChoiceToolVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "none":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(json, options);
                    if (deserialized != null)
                    {
                        return new ToolChoiceNoneVariant(deserialized);
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
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ToolChoiceAutoVariant(var toolChoiceAuto) => toolChoiceAuto,
            ToolChoiceAnyVariant(var toolChoiceAny) => toolChoiceAny,
            ToolChoiceToolVariant(var toolChoiceTool) => toolChoiceTool,
            ToolChoiceNoneVariant(var toolChoiceNone) => toolChoiceNone,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
