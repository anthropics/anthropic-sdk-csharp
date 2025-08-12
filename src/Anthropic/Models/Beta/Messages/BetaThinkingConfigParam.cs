using System.Collections.Generic;
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
        new BetaThinkingConfigParamVariants::BetaThinkingConfigEnabledVariant(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
        new BetaThinkingConfigParamVariants::BetaThinkingConfigDisabledVariant(value);

    public abstract void Validate();
}

sealed class BetaThinkingConfigParamConverter : JsonConverter<BetaThinkingConfigParam>
{
    public override BetaThinkingConfigParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaThinkingConfigParamVariants::BetaThinkingConfigEnabledVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaThinkingConfigParamVariants::BetaThinkingConfigDisabledVariant(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaThinkingConfigParamVariants::BetaThinkingConfigEnabledVariant(
                var betaThinkingConfigEnabled
            ) => betaThinkingConfigEnabled,
            BetaThinkingConfigParamVariants::BetaThinkingConfigDisabledVariant(
                var betaThinkingConfigDisabled
            ) => betaThinkingConfigDisabled,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
