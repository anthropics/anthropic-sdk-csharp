using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaThinkingConfigParamVariants;

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
        new BetaThinkingConfigEnabledVariant(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
        new BetaThinkingConfigDisabledVariant(value);

    public bool TryPickBetaThinkingConfigEnabledVariant(
        [NotNullWhen(true)] out BetaThinkingConfigEnabled? value
    )
    {
        value = (this as BetaThinkingConfigEnabledVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaThinkingConfigDisabledVariant(
        [NotNullWhen(true)] out BetaThinkingConfigDisabled? value
    )
    {
        value = (this as BetaThinkingConfigDisabledVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaThinkingConfigEnabledVariant> betaThinkingConfigEnabled,
        Action<BetaThinkingConfigDisabledVariant> betaThinkingConfigDisabled
    )
    {
        switch (this)
        {
            case BetaThinkingConfigEnabledVariant inner:
                betaThinkingConfigEnabled(inner);
                break;
            case BetaThinkingConfigDisabledVariant inner:
                betaThinkingConfigDisabled(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaThinkingConfigEnabledVariant, T> betaThinkingConfigEnabled,
        Func<BetaThinkingConfigDisabledVariant, T> betaThinkingConfigDisabled
    )
    {
        return this switch
        {
            BetaThinkingConfigEnabledVariant inner => betaThinkingConfigEnabled(inner),
            BetaThinkingConfigDisabledVariant inner => betaThinkingConfigDisabled(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaThinkingConfigParamConverter : JsonConverter<BetaThinkingConfigParam>
{
    public override BetaThinkingConfigParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaThinkingConfigEnabledVariant(deserialized);
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
                        return new BetaThinkingConfigDisabledVariant(deserialized);
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
            BetaThinkingConfigEnabledVariant(var betaThinkingConfigEnabled) =>
                betaThinkingConfigEnabled,
            BetaThinkingConfigDisabledVariant(var betaThinkingConfigDisabled) =>
                betaThinkingConfigDisabled,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
