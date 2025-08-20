using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockContentConverter))]
public abstract record class BetaWebSearchToolResultBlockContent
{
    internal BetaWebSearchToolResultBlockContent() { }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) => new BetaWebSearchToolResultErrorVariant(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new BetaWebSearchResultBlocks(value);

    public bool TryPickBetaWebSearchToolResultErrorVariant(
        [NotNullWhen(true)] out BetaWebSearchToolResultError? value
    )
    {
        value = (this as BetaWebSearchToolResultErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchResultBlocks(
        [NotNullWhen(true)] out List<BetaWebSearchResultBlock>? value
    )
    {
        value = (this as BetaWebSearchResultBlocks)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaWebSearchToolResultErrorVariant> betaWebSearchToolResultError,
        Action<BetaWebSearchResultBlocks> betaWebSearchResultBlocks
    )
    {
        switch (this)
        {
            case BetaWebSearchToolResultErrorVariant inner:
                betaWebSearchToolResultError(inner);
                break;
            case BetaWebSearchResultBlocks inner:
                betaWebSearchResultBlocks(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaWebSearchToolResultErrorVariant, T> betaWebSearchToolResultError,
        Func<BetaWebSearchResultBlocks, T> betaWebSearchResultBlocks
    )
    {
        return this switch
        {
            BetaWebSearchToolResultErrorVariant inner => betaWebSearchToolResultError(inner),
            BetaWebSearchResultBlocks inner => betaWebSearchResultBlocks(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaWebSearchToolResultBlockContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockContent>
{
    public override BetaWebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchResultBlocks(deserialized);
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
        BetaWebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaWebSearchToolResultErrorVariant(var betaWebSearchToolResultError) =>
                betaWebSearchToolResultError,
            BetaWebSearchResultBlocks(var betaWebSearchResultBlocks) => betaWebSearchResultBlocks,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
