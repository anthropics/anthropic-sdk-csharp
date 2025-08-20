using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ThinkingConfigParamVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// Configuration for enabling Claude's extended thinking.
///
/// When enabled, responses include `thinking` content blocks showing Claude's thinking
/// process before the final answer. Requires a minimum budget of 1,024 tokens and
/// counts towards your `max_tokens` limit.
///
/// See [extended thinking](https://docs.anthropic.com/en/docs/build-with-claude/extended-thinking)
/// for details.
/// </summary>
[JsonConverter(typeof(ThinkingConfigParamConverter))]
public abstract record class ThinkingConfigParam
{
    internal ThinkingConfigParam() { }

    public static implicit operator ThinkingConfigParam(ThinkingConfigEnabled value) =>
        new ThinkingConfigEnabledVariant(value);

    public static implicit operator ThinkingConfigParam(ThinkingConfigDisabled value) =>
        new ThinkingConfigDisabledVariant(value);

    public bool TryPickThinkingConfigEnabledVariant(
        [NotNullWhen(true)] out ThinkingConfigEnabled? value
    )
    {
        value = (this as ThinkingConfigEnabledVariant)?.Value;
        return value != null;
    }

    public bool TryPickThinkingConfigDisabledVariant(
        [NotNullWhen(true)] out ThinkingConfigDisabled? value
    )
    {
        value = (this as ThinkingConfigDisabledVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ThinkingConfigEnabledVariant> thinkingConfigEnabled,
        Action<ThinkingConfigDisabledVariant> thinkingConfigDisabled
    )
    {
        switch (this)
        {
            case ThinkingConfigEnabledVariant inner:
                thinkingConfigEnabled(inner);
                break;
            case ThinkingConfigDisabledVariant inner:
                thinkingConfigDisabled(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ThinkingConfigEnabledVariant, T> thinkingConfigEnabled,
        Func<ThinkingConfigDisabledVariant, T> thinkingConfigDisabled
    )
    {
        return this switch
        {
            ThinkingConfigEnabledVariant inner => thinkingConfigEnabled(inner),
            ThinkingConfigDisabledVariant inner => thinkingConfigDisabled(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ThinkingConfigParamConverter : JsonConverter<ThinkingConfigParam>
{
    public override ThinkingConfigParam? Read(
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
            case "enabled":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigEnabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ThinkingConfigEnabledVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "disabled":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingConfigDisabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ThinkingConfigDisabledVariant(deserialized);
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
        ThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ThinkingConfigEnabledVariant(var thinkingConfigEnabled) => thinkingConfigEnabled,
            ThinkingConfigDisabledVariant(var thinkingConfigDisabled) => thinkingConfigDisabled,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
