using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextEditorCodeExecutionToolResultError: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlock: (x) => x.Type
            );
        }
    }

    public Content(BetaTextEditorCodeExecutionToolResultError value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionViewResultBlock value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionCreateResultBlock value)
    {
        Value = value;
    }

    public Content(BetaTextEditorCodeExecutionStrReplaceResultBlock value)
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

    public bool TryPickBetaTextEditorCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultError? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultError;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlock;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlock;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaTextEditorCodeExecutionToolResultError> betaTextEditorCodeExecutionToolResultError,
        Action<BetaTextEditorCodeExecutionViewResultBlock> betaTextEditorCodeExecutionViewResultBlock,
        Action<BetaTextEditorCodeExecutionCreateResultBlock> betaTextEditorCodeExecutionCreateResultBlock,
        Action<BetaTextEditorCodeExecutionStrReplaceResultBlock> betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultError value:
                betaTextEditorCodeExecutionToolResultError(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlock value:
                betaTextEditorCodeExecutionViewResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlock value:
                betaTextEditorCodeExecutionCreateResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlock value:
                betaTextEditorCodeExecutionStrReplaceResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content"
                );
        }
    }

    public T Match<T>(
        Func<
            BetaTextEditorCodeExecutionToolResultError,
            T
        > betaTextEditorCodeExecutionToolResultError,
        Func<
            BetaTextEditorCodeExecutionViewResultBlock,
            T
        > betaTextEditorCodeExecutionViewResultBlock,
        Func<
            BetaTextEditorCodeExecutionCreateResultBlock,
            T
        > betaTextEditorCodeExecutionCreateResultBlock,
        Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlock,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultError value =>
                betaTextEditorCodeExecutionToolResultError(value),
            BetaTextEditorCodeExecutionViewResultBlock value =>
                betaTextEditorCodeExecutionViewResultBlock(value),
            BetaTextEditorCodeExecutionCreateResultBlock value =>
                betaTextEditorCodeExecutionCreateResultBlock(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlock value =>
                betaTextEditorCodeExecutionStrReplaceResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultError'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionViewResultBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionCreateResultBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlock>(
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
                    "Data does not match union variant 'BetaTextEditorCodeExecutionStrReplaceResultBlock'",
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
