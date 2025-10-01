using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BetaToolChoiceVariants = Anthropic.Client.Models.Beta.Messages.BetaToolChoiceVariants;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(BetaToolChoiceConverter))]
public abstract record class BetaToolChoice
{
    internal BetaToolChoice() { }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAuto(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAny(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) =>
        new BetaToolChoiceVariants::BetaToolChoiceTool(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) =>
        new BetaToolChoiceVariants::BetaToolChoiceNone(value);

    public bool TryPickAuto([NotNullWhen(true)] out BetaToolChoiceAuto? value)
    {
        value = (this as BetaToolChoiceVariants::BetaToolChoiceAuto)?.Value;
        return value != null;
    }

    public bool TryPickAny([NotNullWhen(true)] out BetaToolChoiceAny? value)
    {
        value = (this as BetaToolChoiceVariants::BetaToolChoiceAny)?.Value;
        return value != null;
    }

    public bool TryPickTool([NotNullWhen(true)] out BetaToolChoiceTool? value)
    {
        value = (this as BetaToolChoiceVariants::BetaToolChoiceTool)?.Value;
        return value != null;
    }

    public bool TryPickNone([NotNullWhen(true)] out BetaToolChoiceNone? value)
    {
        value = (this as BetaToolChoiceVariants::BetaToolChoiceNone)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaToolChoiceVariants::BetaToolChoiceAuto> auto,
        Action<BetaToolChoiceVariants::BetaToolChoiceAny> any,
        Action<BetaToolChoiceVariants::BetaToolChoiceTool> tool,
        Action<BetaToolChoiceVariants::BetaToolChoiceNone> none
    )
    {
        switch (this)
        {
            case BetaToolChoiceVariants::BetaToolChoiceAuto inner:
                auto(inner);
                break;
            case BetaToolChoiceVariants::BetaToolChoiceAny inner:
                any(inner);
                break;
            case BetaToolChoiceVariants::BetaToolChoiceTool inner:
                tool(inner);
                break;
            case BetaToolChoiceVariants::BetaToolChoiceNone inner:
                none(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolChoice"
                );
        }
    }

    public T Match<T>(
        Func<BetaToolChoiceVariants::BetaToolChoiceAuto, T> auto,
        Func<BetaToolChoiceVariants::BetaToolChoiceAny, T> any,
        Func<BetaToolChoiceVariants::BetaToolChoiceTool, T> tool,
        Func<BetaToolChoiceVariants::BetaToolChoiceNone, T> none
    )
    {
        return this switch
        {
            BetaToolChoiceVariants::BetaToolChoiceAuto inner => auto(inner),
            BetaToolChoiceVariants::BetaToolChoiceAny inner => any(inner),
            BetaToolChoiceVariants::BetaToolChoiceTool inner => tool(inner),
            BetaToolChoiceVariants::BetaToolChoiceNone inner => none(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            ),
        };
    }

    public abstract void Validate();
}

sealed class BetaToolChoiceConverter : JsonConverter<BetaToolChoice>
{
    public override BetaToolChoice? Read(
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAuto>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceAuto(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaToolChoiceVariants::BetaToolChoiceAuto",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "any":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceAny(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaToolChoiceVariants::BetaToolChoiceAny",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tool":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceTool>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceTool(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaToolChoiceVariants::BetaToolChoiceTool",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "none":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceNone>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceNone(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BetaToolChoiceVariants::BetaToolChoiceNone",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolChoice value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaToolChoiceVariants::BetaToolChoiceAuto(var auto) => auto,
            BetaToolChoiceVariants::BetaToolChoiceAny(var any) => any,
            BetaToolChoiceVariants::BetaToolChoiceTool(var tool) => tool,
            BetaToolChoiceVariants::BetaToolChoiceNone(var none) => none,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
