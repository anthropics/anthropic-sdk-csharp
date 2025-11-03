using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.MessageCreateParamsProperties;

/// <summary>
/// Container identifier for reuse across requests.
/// </summary>
[JsonConverter(typeof(ContainerConverter))]
public record class Container
{
    public object Value { get; private init; }

    public Container(BetaContainerParams value)
    {
        Value = value;
    }

    public Container(string value)
    {
        Value = value;
    }

    Container(UnknownVariant value)
    {
        Value = value;
    }

    public static Container CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaContainerParams([NotNullWhen(true)] out BetaContainerParams? value)
    {
        value = this.Value as BetaContainerParams;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public void Switch(Action<BetaContainerParams> betaContainerParams, Action<string> @string)
    {
        switch (this.Value)
        {
            case BetaContainerParams value:
                betaContainerParams(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Container"
                );
        }
    }

    public T Match<T>(Func<BetaContainerParams, T> betaContainerParams, Func<string, T> @string)
    {
        return this.Value switch
        {
            BetaContainerParams value => betaContainerParams(value),
            string value => @string(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Container"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Container");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContainerConverter : JsonConverter<Container?>
{
    public override Container? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaContainerParams>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Container(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaContainerParams'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Container(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Container? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
