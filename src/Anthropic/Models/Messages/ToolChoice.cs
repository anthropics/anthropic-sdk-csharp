using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public ToolChoice(ToolChoiceAuto value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolChoice(ToolChoiceAny value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolChoice(ToolChoiceTool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolChoice(ToolChoiceNone value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ToolChoice(JsonElement json)
    {
        this._json = json;
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
        System::Action<ToolChoiceAuto> auto,
        System::Action<ToolChoiceAny> any,
        System::Action<ToolChoiceTool> tool,
        System::Action<ToolChoiceNone> none
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
        System::Func<ToolChoiceAuto, T> auto,
        System::Func<ToolChoiceAny, T> any,
        System::Func<ToolChoiceTool, T> tool,
        System::Func<ToolChoiceNone, T> none
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

    public static implicit operator ToolChoice(ToolChoiceAuto value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolChoice");
        }
    }
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "any":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tool":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "none":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolChoiceNone>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ToolChoice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
