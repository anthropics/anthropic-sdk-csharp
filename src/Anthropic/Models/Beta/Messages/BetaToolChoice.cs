using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(BetaToolChoiceConverter))]
public record class BetaToolChoice
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

    public BetaToolChoice(BetaToolChoiceAuto value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceAny value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceTool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(BetaToolChoiceNone value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolChoice(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickAuto([NotNullWhen(true)] out BetaToolChoiceAuto? value)
    {
        value = this.Value as BetaToolChoiceAuto;
        return value != null;
    }

    public bool TryPickAny([NotNullWhen(true)] out BetaToolChoiceAny? value)
    {
        value = this.Value as BetaToolChoiceAny;
        return value != null;
    }

    public bool TryPickTool([NotNullWhen(true)] out BetaToolChoiceTool? value)
    {
        value = this.Value as BetaToolChoiceTool;
        return value != null;
    }

    public bool TryPickNone([NotNullWhen(true)] out BetaToolChoiceNone? value)
    {
        value = this.Value as BetaToolChoiceNone;
        return value != null;
    }

    public void Switch(
        System::Action<BetaToolChoiceAuto> auto,
        System::Action<BetaToolChoiceAny> any,
        System::Action<BetaToolChoiceTool> tool,
        System::Action<BetaToolChoiceNone> none
    )
    {
        switch (this.Value)
        {
            case BetaToolChoiceAuto value:
                auto(value);
                break;
            case BetaToolChoiceAny value:
                any(value);
                break;
            case BetaToolChoiceTool value:
                tool(value);
                break;
            case BetaToolChoiceNone value:
                none(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolChoice"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaToolChoiceAuto, T> auto,
        System::Func<BetaToolChoiceAny, T> any,
        System::Func<BetaToolChoiceTool, T> tool,
        System::Func<BetaToolChoiceNone, T> none
    )
    {
        return this.Value switch
        {
            BetaToolChoiceAuto value => auto(value),
            BetaToolChoiceAny value => any(value),
            BetaToolChoiceTool value => tool(value),
            BetaToolChoiceNone value => none(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            ),
        };
    }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) => new(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolChoice"
            );
        }
    }
}

sealed class BetaToolChoiceConverter : JsonConverter<BetaToolChoice>
{
    public override BetaToolChoice? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAuto>(
                        json,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAny>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceTool>(
                        json,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceNone>(
                        json,
                        options
                    );
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
                return new BetaToolChoice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolChoice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
