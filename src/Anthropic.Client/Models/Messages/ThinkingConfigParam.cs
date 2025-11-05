using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// Configuration for enabling Claude's extended thinking.
///
/// When enabled, responses include `thinking` content blocks showing Claude's thinking
/// process before the final answer. Requires a minimum budget of 1,024 tokens and
/// counts towards your `max_tokens` limit.
///
/// See [extended thinking](https://docs.claude.com/en/docs/build-with-claude/extended-thinking)
/// for details.
/// </summary>
[JsonConverter(typeof(ThinkingConfigParamConverter))]
public record class ThinkingConfigParam
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(enabled: (x) => x.Type, disabled: (x) => x.Type); }
    }

    public ThinkingConfigParam(ThinkingConfigEnabled value)
    {
        Value = value;
    }

    public ThinkingConfigParam(ThinkingConfigDisabled value)
    {
        Value = value;
    }

    ThinkingConfigParam(UnknownVariant value)
    {
        Value = value;
    }

    public static ThinkingConfigParam CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ThinkingConfigParam"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ThinkingConfigParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ThinkingConfigEnabled'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "disabled":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new ThinkingConfigParam(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ThinkingConfigDisabled'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
        ThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
