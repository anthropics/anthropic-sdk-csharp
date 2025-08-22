using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaThinkingConfigParamVariants = Anthropic.Models.Beta.Messages.BetaThinkingConfigParamVariants;

namespace Anthropic.Models.Beta.Messages;

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
[JsonConverter(typeof(BetaThinkingConfigParamConverter))]
public abstract record class BetaThinkingConfigParam
{
    internal BetaThinkingConfigParam() { }

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigEnabled value) =>
        new BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
        new BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled(value);

    public bool TryPickEnabled([NotNullWhen(true)] out BetaThinkingConfigEnabled? value)
    {
        value = (this as BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled)?.Value;
        return value != null;
    }

    public bool TryPickDisabled([NotNullWhen(true)] out BetaThinkingConfigDisabled? value)
    {
        value = (this as BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled> enabled,
        Action<BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled> disabled
    )
    {
        switch (this)
        {
            case BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled inner:
                enabled(inner);
                break;
            case BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled inner:
                disabled(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled, T> enabled,
        Func<BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled, T> disabled
    )
    {
        return this switch
        {
            BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled inner => enabled(inner),
            BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled inner => disabled(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaThinkingConfigParamConverter : JsonConverter<BetaThinkingConfigParam>
{
    public override BetaThinkingConfigParam? Read(
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
            case "enabled":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled(
                            deserialized
                        );
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled(
                            deserialized
                        );
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
        BetaThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaThinkingConfigParamVariants::BetaThinkingConfigEnabled(var enabled) => enabled,
            BetaThinkingConfigParamVariants::BetaThinkingConfigDisabled(var disabled) => disabled,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
