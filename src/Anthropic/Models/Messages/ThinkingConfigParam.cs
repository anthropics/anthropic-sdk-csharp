using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Configuration for enabling Claude's extended thinking.
///
/// <para>When enabled, responses include `thinking` content blocks showing Claude's
/// thinking process before the final answer. Requires a minimum budget of 1,024 tokens
/// and counts towards your `max_tokens` limit.</para>
///
/// <para>See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
/// for details.</para>
/// </summary>
[JsonConverter(typeof(ThinkingConfigParamConverter))]
public record class ThinkingConfigParam
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(enabled: (x) => x.Type, disabled: (x) => x.Type); }
    }

    public ThinkingConfigParam(ThinkingConfigEnabled value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ThinkingConfigParam(ThinkingConfigDisabled value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ThinkingConfigParam(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickEnabled([NotNullWhen(true)] out ThinkingConfigEnabled? value)
    {
        value = this.Value as ThinkingConfigEnabled;
        return value != null;
    }

    public bool TryPickDisabled([NotNullWhen(true)] out ThinkingConfigDisabled? value)
    {
        value = this.Value as ThinkingConfigDisabled;
        return value != null;
    }

    public void Switch(
        System::Action<ThinkingConfigEnabled> enabled,
        System::Action<ThinkingConfigDisabled> disabled
    )
    {
        switch (this.Value)
        {
            case ThinkingConfigEnabled value:
                enabled(value);
                break;
            case ThinkingConfigDisabled value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ThinkingConfigParam"
                );
        }
    }

    public T Match<T>(
        System::Func<ThinkingConfigEnabled, T> enabled,
        System::Func<ThinkingConfigDisabled, T> disabled
    )
    {
        return this.Value switch
        {
            ThinkingConfigEnabled value => enabled(value),
            ThinkingConfigDisabled value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ThinkingConfigParam"
            ),
        };
    }

    public static implicit operator ThinkingConfigParam(ThinkingConfigEnabled value) => new(value);

    public static implicit operator ThinkingConfigParam(ThinkingConfigDisabled value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ThinkingConfigParam"
            );
        }
    }
}

sealed class ThinkingConfigParamConverter : JsonConverter<ThinkingConfigParam>
{
    public override ThinkingConfigParam? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
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
                return new ThinkingConfigParam(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
