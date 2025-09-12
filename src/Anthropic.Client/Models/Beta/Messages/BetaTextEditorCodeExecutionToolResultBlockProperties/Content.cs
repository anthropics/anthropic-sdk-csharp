using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(BetaTextEditorCodeExecutionToolResultError value) =>
        new ContentVariants::BetaTextEditorCodeExecutionToolResultError(value);

    public static implicit operator Content(BetaTextEditorCodeExecutionViewResultBlock value) =>
        new ContentVariants::BetaTextEditorCodeExecutionViewResultBlock(value);

    public static implicit operator Content(BetaTextEditorCodeExecutionCreateResultBlock value) =>
        new ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock(value);

    public static implicit operator Content(
        BetaTextEditorCodeExecutionStrReplaceResultBlock value
    ) => new ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock(value);

    public bool TryPickBetaTextEditorCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultError? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionToolResultError)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlock? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionViewResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlock? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlock? value
    )
    {
        value = (this as ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaTextEditorCodeExecutionToolResultError> betaTextEditorCodeExecutionToolResultError,
        Action<ContentVariants::BetaTextEditorCodeExecutionViewResultBlock> betaTextEditorCodeExecutionViewResultBlock,
        Action<ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock> betaTextEditorCodeExecutionCreateResultBlock,
        Action<ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock> betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        switch (this)
        {
            case ContentVariants::BetaTextEditorCodeExecutionToolResultError inner:
                betaTextEditorCodeExecutionToolResultError(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionViewResultBlock inner:
                betaTextEditorCodeExecutionViewResultBlock(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock inner:
                betaTextEditorCodeExecutionCreateResultBlock(inner);
                break;
            case ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock inner:
                betaTextEditorCodeExecutionStrReplaceResultBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            ContentVariants::BetaTextEditorCodeExecutionToolResultError,
            T
        > betaTextEditorCodeExecutionToolResultError,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlock,
            T
        > betaTextEditorCodeExecutionViewResultBlock,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock,
            T
        > betaTextEditorCodeExecutionCreateResultBlock,
        Func<
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        return this switch
        {
            ContentVariants::BetaTextEditorCodeExecutionToolResultError inner =>
                betaTextEditorCodeExecutionToolResultError(inner),
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlock inner =>
                betaTextEditorCodeExecutionViewResultBlock(inner),
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock inner =>
                betaTextEditorCodeExecutionCreateResultBlock(inner),
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock inner =>
                betaTextEditorCodeExecutionStrReplaceResultBlock(inner),
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionToolResultError(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionViewResultBlock(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock(
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

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ContentVariants::BetaTextEditorCodeExecutionToolResultError(
                var betaTextEditorCodeExecutionToolResultError
            ) => betaTextEditorCodeExecutionToolResultError,
            ContentVariants::BetaTextEditorCodeExecutionViewResultBlock(
                var betaTextEditorCodeExecutionViewResultBlock
            ) => betaTextEditorCodeExecutionViewResultBlock,
            ContentVariants::BetaTextEditorCodeExecutionCreateResultBlock(
                var betaTextEditorCodeExecutionCreateResultBlock
            ) => betaTextEditorCodeExecutionCreateResultBlock,
            ContentVariants::BetaTextEditorCodeExecutionStrReplaceResultBlock(
                var betaTextEditorCodeExecutionStrReplaceResultBlock
            ) => betaTextEditorCodeExecutionStrReplaceResultBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
