using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public record class BetaCodeExecutionToolResultBlockContent
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(error: (x) => x.Type, resultBlock: (x) => x.Type); }
    }

    public BetaCodeExecutionToolResultBlockContent(BetaCodeExecutionToolResultError value)
    {
        Value = value;
    }

    public BetaCodeExecutionToolResultBlockContent(BetaCodeExecutionResultBlock value)
    {
        Value = value;
    }

    BetaCodeExecutionToolResultBlockContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaCodeExecutionToolResultBlockContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickError([NotNullWhen(true)] out BetaCodeExecutionToolResultError? value)
    {
        value = this.Value as BetaCodeExecutionToolResultError;
        return value != null;
    }

    public bool TryPickResultBlock([NotNullWhen(true)] out BetaCodeExecutionResultBlock? value)
    {
        value = this.Value as BetaCodeExecutionResultBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaCodeExecutionToolResultError> error,
        Action<BetaCodeExecutionResultBlock> resultBlock
    )
    {
        switch (this.Value)
        {
            case BetaCodeExecutionToolResultError value:
                error(value);
                break;
            case BetaCodeExecutionResultBlock value:
                resultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        Func<BetaCodeExecutionToolResultError, T> error,
        Func<BetaCodeExecutionResultBlock, T> resultBlock
    )
    {
        return this.Value switch
        {
            BetaCodeExecutionToolResultError value => error(value),
            BetaCodeExecutionResultBlock value => resultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaCodeExecutionToolResultBlockContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionToolResultError'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaCodeExecutionToolResultBlockContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionResultBlock'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
