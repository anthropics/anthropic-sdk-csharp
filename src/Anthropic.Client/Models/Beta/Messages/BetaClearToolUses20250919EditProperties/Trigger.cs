using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TriggerVariants = Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties.TriggerVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties;

/// <summary>
/// Condition that triggers the context management strategy
/// </summary>
[JsonConverter(typeof(TriggerConverter))]
public abstract record class Trigger
{
    internal Trigger() { }

    public static implicit operator Trigger(BetaInputTokensTrigger value) =>
        new TriggerVariants::BetaInputTokensTrigger(value);

    public static implicit operator Trigger(BetaToolUsesTrigger value) =>
        new TriggerVariants::BetaToolUsesTrigger(value);

    public bool TryPickBetaInputTokens([NotNullWhen(true)] out BetaInputTokensTrigger? value)
    {
        value = (this as TriggerVariants::BetaInputTokensTrigger)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolUses([NotNullWhen(true)] out BetaToolUsesTrigger? value)
    {
        value = (this as TriggerVariants::BetaToolUsesTrigger)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TriggerVariants::BetaInputTokensTrigger> betaInputTokens,
        Action<TriggerVariants::BetaToolUsesTrigger> betaToolUses
    )
    {
        switch (this)
        {
            case TriggerVariants::BetaInputTokensTrigger inner:
                betaInputTokens(inner);
                break;
            case TriggerVariants::BetaToolUsesTrigger inner:
                betaToolUses(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TriggerVariants::BetaInputTokensTrigger, T> betaInputTokens,
        Func<TriggerVariants::BetaToolUsesTrigger, T> betaToolUses
    )
    {
        return this switch
        {
            TriggerVariants::BetaInputTokensTrigger inner => betaInputTokens(inner),
            TriggerVariants::BetaToolUsesTrigger inner => betaToolUses(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInputTokensTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TriggerVariants::BetaInputTokensTrigger(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tool_uses":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUsesTrigger>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TriggerVariants::BetaToolUsesTrigger(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Trigger value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            TriggerVariants::BetaInputTokensTrigger(var betaInputTokens) => betaInputTokens,
            TriggerVariants::BetaToolUsesTrigger(var betaToolUses) => betaToolUses,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
