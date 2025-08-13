using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ThinkingConfigParamVariants = Anthropic.Models.Messages.ThinkingConfigParamVariants;

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
        new ThinkingConfigParamVariants::ThinkingConfigEnabledVariant(value);

    public static implicit operator ThinkingConfigParam(ThinkingConfigDisabled value) =>
        new ThinkingConfigParamVariants::ThinkingConfigDisabledVariant(value);

    public abstract void Validate();
}

sealed class ThinkingConfigParamConverter : JsonConverter<ThinkingConfigParam>
{
    public override ThinkingConfigParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new ThinkingConfigParamVariants::ThinkingConfigEnabledVariant(
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
                        return new ThinkingConfigParamVariants::ThinkingConfigDisabledVariant(
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
            default:
            {
                throw new global::System.Exception();
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
            ThinkingConfigParamVariants::ThinkingConfigEnabledVariant(var thinkingConfigEnabled) =>
                thinkingConfigEnabled,
            ThinkingConfigParamVariants::ThinkingConfigDisabledVariant(
                var thinkingConfigDisabled
            ) => thinkingConfigDisabled,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
