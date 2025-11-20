using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

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
[JsonConverter(typeof(BetaThinkingConfigParamConverter))]
public record class BetaThinkingConfigParam
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

    public BetaThinkingConfigParam(BetaThinkingConfigEnabled value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaThinkingConfigParam(BetaThinkingConfigDisabled value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaThinkingConfigParam(JsonElement json)
    {
        this._json = json;
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
        System::Action<BetaThinkingConfigEnabled> enabled,
        System::Action<BetaThinkingConfigDisabled> disabled
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
        System::Func<BetaThinkingConfigEnabled, T> enabled,
        System::Func<BetaThinkingConfigDisabled, T> disabled
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

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigEnabled value) =>
        new(value);

    public static implicit operator BetaThinkingConfigParam(BetaThinkingConfigDisabled value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaThinkingConfigParam"
            );
        }
    }
}

sealed class BetaThinkingConfigParamConverter : JsonConverter<BetaThinkingConfigParam>
{
    public override BetaThinkingConfigParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigDisabled>(
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
                return new BetaThinkingConfigParam(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingConfigParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
