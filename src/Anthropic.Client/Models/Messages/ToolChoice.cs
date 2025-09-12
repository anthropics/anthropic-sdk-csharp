using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolChoiceVariants = Anthropic.Client.Models.Messages.ToolChoiceVariants;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public abstract record class ToolChoice
{
    internal ToolChoice() { }

    public static implicit operator ToolChoice(ToolChoiceAuto value) =>
        new ToolChoiceVariants::ToolChoiceAuto(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) =>
        new ToolChoiceVariants::ToolChoiceAny(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) =>
        new ToolChoiceVariants::ToolChoiceTool(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) =>
        new ToolChoiceVariants::ToolChoiceNone(value);

    public bool TryPickAuto([NotNullWhen(true)] out ToolChoiceAuto? value)
    {
        value = (this as ToolChoiceVariants::ToolChoiceAuto)?.Value;
        return value != null;
    }

    public bool TryPickAny([NotNullWhen(true)] out ToolChoiceAny? value)
    {
        value = (this as ToolChoiceVariants::ToolChoiceAny)?.Value;
        return value != null;
    }

    public bool TryPickTool([NotNullWhen(true)] out ToolChoiceTool? value)
    {
        value = (this as ToolChoiceVariants::ToolChoiceTool)?.Value;
        return value != null;
    }

    public bool TryPickNone([NotNullWhen(true)] out ToolChoiceNone? value)
    {
        value = (this as ToolChoiceVariants::ToolChoiceNone)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToolChoiceVariants::ToolChoiceAuto> auto,
        Action<ToolChoiceVariants::ToolChoiceAny> any,
        Action<ToolChoiceVariants::ToolChoiceTool> tool,
        Action<ToolChoiceVariants::ToolChoiceNone> none
    )
    {
        switch (this)
        {
            case ToolChoiceVariants::ToolChoiceAuto inner:
                auto(inner);
                break;
            case ToolChoiceVariants::ToolChoiceAny inner:
                any(inner);
                break;
            case ToolChoiceVariants::ToolChoiceTool inner:
                tool(inner);
                break;
            case ToolChoiceVariants::ToolChoiceNone inner:
                none(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ToolChoiceVariants::ToolChoiceAuto, T> auto,
        Func<ToolChoiceVariants::ToolChoiceAny, T> any,
        Func<ToolChoiceVariants::ToolChoiceTool, T> tool,
        Func<ToolChoiceVariants::ToolChoiceNone, T> none
    )
    {
        return this switch
        {
            ToolChoiceVariants::ToolChoiceAuto inner => auto(inner),
            ToolChoiceVariants::ToolChoiceAny inner => any(inner),
            ToolChoiceVariants::ToolChoiceTool inner => tool(inner),
            ToolChoiceVariants::ToolChoiceNone inner => none(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                        return new ToolChoiceVariants::ToolChoiceAuto(deserialized);
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
                        return new ToolChoiceVariants::ToolChoiceAny(deserialized);
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
                        return new ToolChoiceVariants::ToolChoiceTool(deserialized);
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
                        return new ToolChoiceVariants::ToolChoiceNone(deserialized);
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
            ToolChoiceVariants::ToolChoiceAuto(var auto) => auto,
            ToolChoiceVariants::ToolChoiceAny(var any) => any,
            ToolChoiceVariants::ToolChoiceTool(var tool) => tool,
            ToolChoiceVariants::ToolChoiceNone(var none) => none,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
