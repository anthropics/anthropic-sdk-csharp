using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockProperties.ContentVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockProperties;

[JsonConverter(typeof(ContentConverter))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(BetaWebFetchToolResultErrorBlock value) =>
        new ContentVariants::BetaWebFetchToolResultErrorBlock(value);

    public static implicit operator Content(BetaWebFetchBlock value) =>
        new ContentVariants::BetaWebFetchBlock(value);

    public bool TryPickBetaWebFetchToolResultErrorBlock(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlock? value
    )
    {
        value = (this as ContentVariants::BetaWebFetchToolResultErrorBlock)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlock([NotNullWhen(true)] out BetaWebFetchBlock? value)
    {
        value = (this as ContentVariants::BetaWebFetchBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ContentVariants::BetaWebFetchToolResultErrorBlock> betaWebFetchToolResultErrorBlock,
        Action<ContentVariants::BetaWebFetchBlock> betaWebFetchBlock
    )
    {
        switch (this)
        {
            case ContentVariants::BetaWebFetchToolResultErrorBlock inner:
                betaWebFetchToolResultErrorBlock(inner);
                break;
            case ContentVariants::BetaWebFetchBlock inner:
                betaWebFetchBlock(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ContentVariants::BetaWebFetchToolResultErrorBlock, T> betaWebFetchToolResultErrorBlock,
        Func<ContentVariants::BetaWebFetchBlock, T> betaWebFetchBlock
    )
    {
        return this switch
        {
            ContentVariants::BetaWebFetchToolResultErrorBlock inner =>
                betaWebFetchToolResultErrorBlock(inner),
            ContentVariants::BetaWebFetchBlock inner => betaWebFetchBlock(inner),
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
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentVariants::BetaWebFetchToolResultErrorBlock(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentVariants::BetaWebFetchBlock(deserialized);
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
            ContentVariants::BetaWebFetchToolResultErrorBlock(
                var betaWebFetchToolResultErrorBlock
            ) => betaWebFetchToolResultErrorBlock,
            ContentVariants::BetaWebFetchBlock(var betaWebFetchBlock) => betaWebFetchBlock,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
