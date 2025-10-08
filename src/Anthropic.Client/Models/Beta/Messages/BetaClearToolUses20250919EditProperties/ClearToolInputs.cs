using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties;

/// <summary>
/// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
/// </summary>
[JsonConverter(typeof(ClearToolInputsConverter))]
public record class ClearToolInputs
{
    public object Value { get; private init; }

    public ClearToolInputs(bool value)
    {
        Value = value;
    }

    public ClearToolInputs(List<string> value)
    {
        Value = value;
    }

    ClearToolInputs(UnknownVariant value)
    {
        Value = value;
    }

    public static ClearToolInputs CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public bool TryPickStrings([NotNullWhen(true)] out List<string>? value)
    {
        value = this.Value as List<string>;
        return value != null;
    }

    public void Switch(Action<bool> @bool, Action<List<string>> strings)
    {
        switch (this.Value)
        {
            case bool value:
                @bool(value);
                break;
            case List<string> value:
                strings(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ClearToolInputs"
                );
        }
    }

    public T Match<T>(Func<bool, T> @bool, Func<List<string>, T> strings)
    {
        return this.Value switch
        {
            bool value => @bool(value),
            List<string> value => strings(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ClearToolInputs"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new ClearToolInputs(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            if (deserialized != null)
            {
                return new ClearToolInputs(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<string>'",
                    e
                )
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
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
