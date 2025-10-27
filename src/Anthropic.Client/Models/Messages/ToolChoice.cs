using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                auto: (x) => x.Type,
                any: (x) => x.Type,
                tool: (x) => x.Type,
                none: (x) => x.Type
            );
        }
    }

    public bool? DisableParallelToolUse
    {
        get
        {
            return Match<bool?>(
                auto: (x) => x.DisableParallelToolUse,
                any: (x) => x.DisableParallelToolUse,
                tool: (x) => x.DisableParallelToolUse,
                none: (_) => null
            );
        }
    }

    public ToolChoice(ToolChoiceAuto value)
    {
        Value = value;
    }

    public ToolChoice(ToolChoiceAny value)
    {
        Value = value;
    }

    public ToolChoice(ToolChoiceTool value)
    {
        Value = value;
    }

    public ToolChoice(ToolChoiceNone value)
    {
        Value = value;
    }

    ToolChoice(UnknownVariant value)
    {
        Value = value;
    }

    public static ToolChoice CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickAuto([NotNullWhen(true)] out ToolChoiceAuto? value)
    {
        value = this.Value as ToolChoiceAuto;
        return value != null;
    }

    public bool TryPickAny([NotNullWhen(true)] out ToolChoiceAny? value)
    {
        value = this.Value as ToolChoiceAny;
        return value != null;
    }

    public bool TryPickTool([NotNullWhen(true)] out ToolChoiceTool? value)
    {
        value = this.Value as ToolChoiceTool;
        return value != null;
    }

    public bool TryPickNone([NotNullWhen(true)] out ToolChoiceNone? value)
    {
        value = this.Value as ToolChoiceNone;
        return value != null;
    }

    public void Switch(
        Action<ToolChoiceAuto> auto,
        Action<ToolChoiceAny> any,
        Action<ToolChoiceTool> tool,
        Action<ToolChoiceNone> none
    )
    {
        switch (this.Value)
        {
            case ToolChoiceAuto value:
                auto(value);
                break;
            case ToolChoiceAny value:
                any(value);
                break;
            case ToolChoiceTool value:
                tool(value);
                break;
            case ToolChoiceNone value:
                none(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolChoice"
                );
        }
    }

    public T Match<T>(
        Func<ToolChoiceAuto, T> auto,
        Func<ToolChoiceAny, T> any,
        Func<ToolChoiceTool, T> tool,
        Func<ToolChoiceNone, T> none
    )
    {
        return this.Value switch
        {
            ToolChoiceAuto value => auto(value),
            ToolChoiceAny value => any(value),
            ToolChoiceTool value => tool(value),
            ToolChoiceNone value => none(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolChoice"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolChoice");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ToolChoice(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolChoiceAuto'",
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
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ToolChoice(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolChoiceAny'",
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
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ToolChoice(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolChoiceTool'",
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
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ToolChoice(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ToolChoiceNone'",
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
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
