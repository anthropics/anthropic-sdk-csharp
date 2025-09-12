using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(BetaBashCodeExecutionToolResultError value) =>
        new ContentVariants::BetaBashCodeExecutionToolResultError(value);

    public static implicit operator Content(BetaBashCodeExecutionResultBlock value) =>
        new ContentVariants::BetaBashCodeExecutionResultBlock(value);

    public bool TryPickBetaBashCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultError? value
    )
    {
        value = (this as ContentVariants::BetaBashCodeExecutionToolResultError)?.Value;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionResultBlock(
        [NotNullWhen(true)] out BetaBashCodeExecutionResultBlock? value
    )
    {
        value = (this as ContentVariants::BetaBashCodeExecutionResultBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaBashCodeExecutionToolResultError> betaBashCodeExecutionToolResultError,
        Action<ContentVariants::BetaBashCodeExecutionResultBlock> betaBashCodeExecutionResultBlock
    )
    {
        switch (this)
        {
            case ContentVariants::BetaBashCodeExecutionToolResultError inner:
                betaBashCodeExecutionToolResultError(inner);
                break;
            case ContentVariants::BetaBashCodeExecutionResultBlock inner:
                betaBashCodeExecutionResultBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            ContentVariants::BetaBashCodeExecutionToolResultError,
            T
        > betaBashCodeExecutionToolResultError,
        Func<ContentVariants::BetaBashCodeExecutionResultBlock, T> betaBashCodeExecutionResultBlock
    )
    {
        return this switch
        {
            ContentVariants::BetaBashCodeExecutionToolResultError inner =>
                betaBashCodeExecutionToolResultError(inner),
            ContentVariants::BetaBashCodeExecutionResultBlock inner =>
                betaBashCodeExecutionResultBlock(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::BetaBashCodeExecutionToolResultError(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionResultBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::BetaBashCodeExecutionResultBlock(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::BetaBashCodeExecutionToolResultError(
                var betaBashCodeExecutionToolResultError
            ) => betaBashCodeExecutionToolResultError,
            ContentVariants::BetaBashCodeExecutionResultBlock(
                var betaBashCodeExecutionResultBlock
            ) => betaBashCodeExecutionResultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
