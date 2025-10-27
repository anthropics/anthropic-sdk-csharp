using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties;

/// <summary>
/// Condition that triggers the context management strategy
/// </summary>
[JsonConverter(typeof(TriggerConverter))]
public record class Trigger
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(betaInputTokens: (x) => x.Type, betaToolUses: (x) => x.Type); }
    }

    public long Value1
    {
        get { return Match(betaInputTokens: (x) => x.Value, betaToolUses: (x) => x.Value); }
    }

    public Trigger(BetaInputTokensTrigger value)
    {
        Value = value;
    }

    public Trigger(BetaToolUsesTrigger value)
    {
        Value = value;
    }

    Trigger(UnknownVariant value)
    {
        Value = value;
    }

    public static Trigger CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaInputTokens([NotNullWhen(true)] out BetaInputTokensTrigger? value)
    {
        value = this.Value as BetaInputTokensTrigger;
        return value != null;
    }

    public bool TryPickBetaToolUses([NotNullWhen(true)] out BetaToolUsesTrigger? value)
    {
        value = this.Value as BetaToolUsesTrigger;
        return value != null;
    }

    public void Switch(
        Action<BetaInputTokensTrigger> betaInputTokens,
        Action<BetaToolUsesTrigger> betaToolUses
    )
    {
        switch (this.Value)
        {
            case BetaInputTokensTrigger value:
                betaInputTokens(value);
                break;
            case BetaToolUsesTrigger value:
                betaToolUses(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Trigger"
                );
        }
    }

    public T Match<T>(
        Func<BetaInputTokensTrigger, T> betaInputTokens,
        Func<BetaToolUsesTrigger, T> betaToolUses
    )
    {
        return this.Value switch
        {
            BetaInputTokensTrigger value => betaInputTokens(value),
            BetaToolUsesTrigger value => betaToolUses(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Trigger"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Trigger");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class TriggerConverter : JsonConverter<Trigger>
{
    public override Trigger? Read(
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
            case "input_tokens":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Trigger(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaInputTokensTrigger'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tool_uses":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUsesTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Trigger(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaToolUsesTrigger'",
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

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
