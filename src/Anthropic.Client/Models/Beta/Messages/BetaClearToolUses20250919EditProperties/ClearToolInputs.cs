using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties.ClearToolInputsVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties;

/// <summary>
/// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
/// </summary>
[JsonConverter(typeof(ClearToolInputsConverter))]
public abstract record class ClearToolInputs
{
    internal ClearToolInputs() { }

    public static implicit operator ClearToolInputs(bool value) => new Bool(value);

    public static implicit operator ClearToolInputs(List<string> value) => new Strings(value);

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as Bool)?.Value;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out List<string>? value)
    {
        value = (this as Strings)?.Value;
        return value != null;
    }

    public void Switch(Action<Bool> @bool, Action<Strings> strings)
    {
        switch (this)
        {
            case Bool inner:
                @bool(inner);
                break;
            case Strings inner:
                strings(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ClearToolInputs"
                );
        }
    }

    public T Match<T>(Func<Bool, T> @bool, Func<Strings, T> strings)
    {
        return this switch
        {
            Bool inner => @bool(inner),
            Strings inner => strings(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ClearToolInputsConverter : JsonConverter<ClearToolInputs?>
{
    public override ClearToolInputs? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            return new Bool(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant Bool", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new Strings(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant Strings", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClearToolInputs? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            Bool(var @bool) => @bool,
            Strings(var strings) => strings,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
