using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaWebFetchToolResultErrorBlock: (x) => x.Type,
                betaWebFetchBlock: (x) => x.Type
            );
        }
    }

    public Content(BetaWebFetchToolResultErrorBlock value)
    {
        Value = value;
    }

    public Content(BetaWebFetchBlock value)
    {
        Value = value;
    }

    Content(UnknownVariant value)
    {
        Value = value;
    }

    public static Content CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaWebFetchToolResultErrorBlock(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlock;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlock([NotNullWhen(true)] out BetaWebFetchBlock? value)
    {
        value = this.Value as BetaWebFetchBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaWebFetchToolResultErrorBlock> betaWebFetchToolResultErrorBlock,
        Action<BetaWebFetchBlock> betaWebFetchBlock
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchToolResultErrorBlock value:
                betaWebFetchToolResultErrorBlock(value);
                break;
            case BetaWebFetchBlock value:
                betaWebFetchBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<BetaWebFetchToolResultErrorBlock, T> betaWebFetchToolResultErrorBlock,
        Func<BetaWebFetchBlock, T> betaWebFetchBlock
    )
    {
        return this.Value switch
        {
            BetaWebFetchToolResultErrorBlock value => betaWebFetchToolResultErrorBlock(value),
            BetaWebFetchBlock value => betaWebFetchBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchToolResultErrorBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchBlock'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
