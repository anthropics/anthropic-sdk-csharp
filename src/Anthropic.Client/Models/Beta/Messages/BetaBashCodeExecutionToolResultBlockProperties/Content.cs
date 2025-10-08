using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaBashCodeExecutionToolResultError: (x) => x.Type,
                betaBashCodeExecutionResultBlock: (x) => x.Type
            );
        }
    }

    public Content(BetaBashCodeExecutionToolResultError value)
    {
        Value = value;
    }

    public Content(BetaBashCodeExecutionResultBlock value)
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

    public bool TryPickBetaBashCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultError? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultError;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionResultBlock(
        [NotNullWhen(true)] out BetaBashCodeExecutionResultBlock? value
    )
    {
        value = this.Value as BetaBashCodeExecutionResultBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaBashCodeExecutionToolResultError> betaBashCodeExecutionToolResultError,
        Action<BetaBashCodeExecutionResultBlock> betaBashCodeExecutionResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaBashCodeExecutionToolResultError value:
                betaBashCodeExecutionToolResultError(value);
                break;
            case BetaBashCodeExecutionResultBlock value:
                betaBashCodeExecutionResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<BetaBashCodeExecutionToolResultError, T> betaBashCodeExecutionToolResultError,
        Func<BetaBashCodeExecutionResultBlock, T> betaBashCodeExecutionResultBlock
    )
    {
        return this.Value switch
        {
            BetaBashCodeExecutionToolResultError value => betaBashCodeExecutionToolResultError(
                value
            ),
            BetaBashCodeExecutionResultBlock value => betaBashCodeExecutionResultBlock(value),
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
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultError>(
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
                    "Data does not match union variant 'BetaBashCodeExecutionToolResultError'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionResultBlock>(
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
                    "Data does not match union variant 'BetaBashCodeExecutionResultBlock'",
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
