using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockContentConverter))]
public record class BetaWebSearchToolResultBlockContent
{
    public object Value { get; private init; }

    public BetaWebSearchToolResultBlockContent(BetaWebSearchToolResultError value)
    {
        Value = value;
    }

    public BetaWebSearchToolResultBlockContent(IReadOnlyList<BetaWebSearchResultBlock> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    BetaWebSearchToolResultBlockContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaWebSearchToolResultBlockContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickError([NotNullWhen(true)] out BetaWebSearchToolResultError? value)
    {
        value = this.Value as BetaWebSearchToolResultError;
        return value != null;
    }

    public bool TryPickBetaWebSearchResultBlocks(
        [NotNullWhen(true)] out IReadOnlyList<BetaWebSearchResultBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaWebSearchResultBlock>;
        return value != null;
    }

    public void Switch(
        System::Action<BetaWebSearchToolResultError> error,
        System::Action<IReadOnlyList<BetaWebSearchResultBlock>> betaWebSearchResultBlocks
    )
    {
        switch (this.Value)
        {
            case BetaWebSearchToolResultError value:
                error(value);
                break;
            case List<BetaWebSearchResultBlock> value:
                betaWebSearchResultBlocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaWebSearchToolResultError, T> error,
        System::Func<IReadOnlyList<BetaWebSearchResultBlock>, T> betaWebSearchResultBlocks
    )
    {
        return this.Value switch
        {
            BetaWebSearchToolResultError value => error(value),
            IReadOnlyList<BetaWebSearchResultBlock> value => betaWebSearchResultBlocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) => new(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new((IReadOnlyList<BetaWebSearchResultBlock>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaWebSearchToolResultBlockContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockContent>
{
    public override BetaWebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                deserialized.Validate();
                return new BetaWebSearchToolResultBlockContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebSearchToolResultError'",
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
                return new BetaWebSearchToolResultBlockContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaWebSearchResultBlock>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
