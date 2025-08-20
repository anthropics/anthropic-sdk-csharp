using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public abstract record class BetaCodeExecutionToolResultBlockContent
{
    internal BetaCodeExecutionToolResultBlockContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) => new BetaCodeExecutionToolResultErrorVariant(value);

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) => new BetaCodeExecutionResultBlockVariant(value);

    public bool TryPickBetaCodeExecutionToolResultErrorVariant(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultError? value
    )
    {
        value = (this as BetaCodeExecutionToolResultErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionResultBlockVariant(
        [NotNullWhen(true)] out BetaCodeExecutionResultBlock? value
    )
    {
        value = (this as BetaCodeExecutionResultBlockVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaCodeExecutionToolResultErrorVariant> betaCodeExecutionToolResultError,
        Action<BetaCodeExecutionResultBlockVariant> betaCodeExecutionResultBlock
    )
    {
        switch (this)
        {
            case BetaCodeExecutionToolResultErrorVariant inner:
                betaCodeExecutionToolResultError(inner);
                break;
            case BetaCodeExecutionResultBlockVariant inner:
                betaCodeExecutionResultBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaCodeExecutionToolResultErrorVariant, T> betaCodeExecutionToolResultError,
        Func<BetaCodeExecutionResultBlockVariant, T> betaCodeExecutionResultBlock
    )
    {
        return this switch
        {
            BetaCodeExecutionToolResultErrorVariant inner => betaCodeExecutionToolResultError(
                inner
            ),
            BetaCodeExecutionResultBlockVariant inner => betaCodeExecutionResultBlock(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockContent>
{
    public override BetaCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionResultBlockVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaCodeExecutionToolResultErrorVariant(var betaCodeExecutionToolResultError) =>
                betaCodeExecutionToolResultError,
            BetaCodeExecutionResultBlockVariant(var betaCodeExecutionResultBlock) =>
                betaCodeExecutionResultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
