using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BetaWebSearchToolResultBlockContentVariants = Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockContentConverter))]
public abstract record class BetaWebSearchToolResultBlockContent
{
    internal BetaWebSearchToolResultBlockContent() { }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) => new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(value);

    public bool TryPickError([NotNullWhen(true)] out BetaWebSearchToolResultError? value)
    {
        value = (
            this as BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError
        )?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchResultBlocks(
        [NotNullWhen(true)] out List<BetaWebSearchResultBlock>? value
    )
    {
        value = (
            this as BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError> error,
        Action<BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks> betaWebSearchResultBlocks
    )
    {
        switch (this)
        {
            case BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError inner:
                error(inner);
                break;
            case BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks inner:
                betaWebSearchResultBlocks(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        Func<BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError, T> error,
        Func<
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks,
            T
        > betaWebSearchResultBlocks
    )
    {
        return this switch
        {
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError inner =>
                error(inner),
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks inner =>
                betaWebSearchResultBlocks(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            ),
        };
    }

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockContent>
{
    public override BetaWebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError(var error) =>
                error,
            BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(
                var betaWebSearchResultBlocks
            ) => betaWebSearchResultBlocks,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
