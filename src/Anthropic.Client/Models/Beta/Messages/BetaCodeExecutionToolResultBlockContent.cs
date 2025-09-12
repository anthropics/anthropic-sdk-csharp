using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaCodeExecutionToolResultBlockContentVariants = Anthropic.Client.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public abstract record class BetaCodeExecutionToolResultBlockContent
{
    internal BetaCodeExecutionToolResultBlockContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) => new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock(value);

    public bool TryPickError([NotNullWhen(true)] out BetaCodeExecutionToolResultError? value)
    {
        value = (
            this
            as BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError
        )?.Value;
        return value != null;
    }

    public bool TryPickResultBlock([NotNullWhen(true)] out BetaCodeExecutionResultBlock? value)
    {
        value = (
            this as BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError> error,
        Action<BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock> resultBlock
    )
    {
        switch (this)
        {
            case BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError inner:
                error(inner);
                break;
            case BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock inner:
                resultBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError,
            T
        > error,
        Func<
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock,
            T
        > resultBlock
    )
    {
        return this switch
        {
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError inner =>
                error(inner),
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock inner =>
                resultBlock(inner),
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
        Type typeToConvert,
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
                return new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock(
                    deserialized
                );
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
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError(
                var error
            ) => error,
            BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock(
                var resultBlock
            ) => resultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
