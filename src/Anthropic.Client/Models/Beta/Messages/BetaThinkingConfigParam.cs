using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

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
[JsonConverter(typeof(BetaThinkingConfigParamConverter))]
public record class BetaThinkingConfigParam
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(enabled: (x) => x.Type, disabled: (x) => x.Type); }
    }

    public BetaThinkingConfigParam(BetaThinkingConfigEnabled value)
    {
        Value = value;
    }

    public BetaThinkingConfigParam(BetaThinkingConfigDisabled value)
    {
        Value = value;
    }

    BetaThinkingConfigParam(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaThinkingConfigParam CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickEnabled([NotNullWhen(true)] out BetaThinkingConfigEnabled? value)
    {
        value = this.Value as BetaThinkingConfigEnabled;
        return value != null;
    }

    public bool TryPickDisabled([NotNullWhen(true)] out BetaThinkingConfigDisabled? value)
    {
        value = this.Value as BetaThinkingConfigDisabled;
        return value != null;
    }

    public void Switch(
        Action<BetaThinkingConfigEnabled> enabled,
        Action<BetaThinkingConfigDisabled> disabled
    )
    {
        switch (this.Value)
        {
            case BetaThinkingConfigEnabled value:
                enabled(value);
                break;
            case BetaThinkingConfigDisabled value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaThinkingConfigParam"
                );
        }
    }

    public T Match<T>(
        Func<BetaThinkingConfigEnabled, T> enabled,
        Func<BetaThinkingConfigDisabled, T> disabled
    )
    {
        return this.Value switch
        {
            BetaThinkingConfigEnabled value => enabled(value),
            BetaThinkingConfigDisabled value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaThinkingConfigParam"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaThinkingConfigParam"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaThinkingConfigParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaThinkingConfigEnabled'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "disabled":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaThinkingConfigParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaThinkingConfigDisabled'",
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
        BetaThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
